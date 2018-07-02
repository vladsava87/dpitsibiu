namespace DatabaseLayer.Migrations
{
    using System;
    using DataModels;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseLayer.CatalogContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        int AddProfessor(String nume, String prenume, string telefon, string email, DatabaseLayer.CatalogContex context)
        {
            var newProfesor = new t_profesor();
            newProfesor.Nume = nume;
            newProfesor.Prenume = prenume;
            newProfesor.Telefon = telefon;
            newProfesor.Email = email;

            context.Profesorii.AddOrUpdate(newProfesor);
            context.SaveChanges();

            int profesorId = newProfesor.Id;
            return profesorId;
        }

        int AddMaterie(String nume, Boolean optional, DatabaseLayer.CatalogContex context)
        {
            var newMaterie = new t_materie();
            newMaterie.Nume = nume;
            newMaterie.Optional = optional;

            context.Materii.AddOrUpdate(newMaterie);
            context.SaveChanges();

            int materieId = newMaterie.Id;
            return materieId;
        }

       void AddRelationshipProfesorMaterie(int profesorId, int materieId, DatabaseLayer.CatalogContex context)
        {
            var newProfesor = context.Profesorii.Where(p => p.Id == profesorId).FirstOrDefault();
            var newMaterie = context.Materii.Where(m => m.Id == materieId).FirstOrDefault();

            // adaug legatura intre cele 2 tabele prin tabela de legatura
            var newProfesorMaterieRelationship = new t_profesor_materie();
            newProfesorMaterieRelationship.Profesor = newProfesor;
            newProfesorMaterieRelationship.Materie = newMaterie;
            context.ProfesoriMaterii.AddOrUpdate(newProfesorMaterieRelationship);
            context.SaveChanges();

            newProfesor.Materie.Add(newProfesorMaterieRelationship);
            context.SaveChanges();

            newMaterie.Profesori.Add(newProfesorMaterieRelationship);
            context.SaveChanges();
        }

        int AddProfil(string nume, DatabaseLayer.CatalogContex context)
        {
            var newProfil = new t_profil();
            newProfil.Nume = nume;

            context.Profiluri.AddOrUpdate(newProfil);
            context.SaveChanges();

            int ProfilId = newProfil.Id;
            return ProfilId;
        }
        
       void AddProfilClasa(int profil, int clasa, DatabaseLayer.CatalogContex context)
        {
            var newProfil = context.Profiluri.Where(p => p.Id == profil).FirstOrDefault();
            var newClasa = context.Clase.Where(c => c.Id == clasa).FirstOrDefault();

            newClasa.Profil = newProfil;
            //context.Clase.AddOrUpdate(newClasa);
            context.SaveChanges();
        }

        void AddDiriginteClasa(int profesor, int clasa, DatabaseLayer.CatalogContex context)
        {
            var newProfesor = context.Profesorii.Where(p => p.Id == profesor).FirstOrDefault();
            var newClasa = context.Clase.Where(c => c.Id == clasa).FirstOrDefault();

            newClasa.Diriginte= newProfesor;
            //context.Clase.AddOrUpdate(newClasa);
            context.SaveChanges();
        }

        int AddAbsenta(int Materie, Boolean Motivata, DateTime Data, sem Semestrul, int Profesor, DatabaseLayer.CatalogContex context)
        {
            var newAbsenta = new t_absenta();
            newAbsenta.MaterieID = Materie;

            var tempMaterie = context.Materii.Where(m => m.Id == Materie).FirstOrDefault();
            newAbsenta.Materie = tempMaterie;

            newAbsenta.Motivata = Motivata;
            newAbsenta.Data = Data;
            newAbsenta.Semestrul = Semestrul;
            newAbsenta.ProfesorID = Profesor;

            var tempProfesor = context.Profesorii.Where(p => p.Id == Profesor).FirstOrDefault();
            newAbsenta.Profesor = tempProfesor;

            context.Absente.AddOrUpdate(newAbsenta);
            context.SaveChanges();

            int AbesntaID = newAbsenta.Id;
            return AbesntaID;
            
        }

        void AddAbsentaElev(int elev, int absenta, DatabaseLayer.CatalogContex context)
        {
            var newElev = context.Elevi.Where(p => p.Id == elev).FirstOrDefault();
            var newAbsenta = context.Absente.Where(m => m.Id == absenta).FirstOrDefault();
            newElev.Absente.Add(newAbsenta);
            // context.Elevi.AddOrUpdate(newElev);
            context.SaveChanges();
        }

        int AddNota(int ElevId, int Materie, double Nota, Boolean Teza, sem Semestrul,DateTime Data, DatabaseLayer.CatalogContex context)
        {
            var newNota = new t_nota();
            newNota.MaterieID = Materie;

            var tempMaterie = context.Materii.Where(p => p.Id == Materie).FirstOrDefault();
            newNota.Materie = tempMaterie;


            newNota.Data = Data;
            newNota.Nota = Nota;
            newNota.Teza = Teza;
            newNota.Semestrul = Semestrul;

            //var tempElev = context.Elevi.Where(e => e.Id == ElevId).FirstOrDefault();
            //tempElev.Note = Nota;


            context.Note.AddOrUpdate(newNota);
            context.SaveChanges();

            int NotaID = newNota.Id;
            return NotaID;

        }


        int AddObservatie( DateTime Data, int Profesor, String Text, DatabaseLayer.CatalogContex context)
        {
            var newObservatie = new t_observatie();
            newObservatie.Data = Data;
            //newObservatie.ProfesorID = Profesor;

            var tempProfesor = context.Profesorii.Where(p => p.Id == Profesor).FirstOrDefault();
            newObservatie.Profesor = tempProfesor;

            newObservatie.Text = Text;

            context.Observatii.AddOrUpdate(newObservatie);
            context.SaveChanges();

            int ObservatieID = newObservatie.Id;
            return ObservatieID;

        }

        void AddObservatieElev(int elev, int observatie, DatabaseLayer.CatalogContex context)
        {
            var newElev = context.Elevi.Where(p => p.Id == elev).FirstOrDefault();
            var newObservatie = context.Observatii.Where(m => m.Id == observatie).FirstOrDefault();
            newElev.Observatii.Add(newObservatie);
            //context.Elevi.AddOrUpdate(newElev);

            context.SaveChanges();
        }

        int AddElev (string Nume, string Prenume, DateTime Data_Nasterii, string Telefon, string Email, int Numar_Matricol, int Clasa, DatabaseLayer.CatalogContex context)
        {
            var newElev = new t_elev();
            newElev.Nume = Nume;
            newElev.Prenume = Prenume;
            newElev.Date = Data_Nasterii;
            newElev.Telefon = Telefon;
            newElev.Email = Email;
            newElev.Numar_Matricol = Numar_Matricol;


            newElev.ClasaID = Clasa;
            var tempClasa = context.Clase.Where(c => c.Id == Clasa).FirstOrDefault();
            newElev.Clasa = tempClasa;


            //newElev.Note = Note;
            //newElev.Absente = Absente;
            //newElev.Observatii = Observatii;

            context.Elevi.AddOrUpdate(newElev);
            context.SaveChanges();

            int ElevId = newElev.Id;
            return ElevId;

        }

        void AddNotaElev(int elev, int nota, DatabaseLayer.CatalogContex context)
        {
            var newElev = context.Elevi.Where(p => p.Id == elev).FirstOrDefault();
            var newNota = context.Note.Where(m => m.Id == nota).FirstOrDefault();
            newElev.Note.Add(newNota);
            //context.Elevi.AddOrUpdate(newElev);

            context.SaveChanges();

        }


        int AddClasa(int Numar, string Serie, int An, int Profil, int Diriginte, DatabaseLayer.CatalogContex context)
        {
            var newClasa = new t_clasa();
            newClasa.Numar = Numar;
            newClasa.Serie = Serie;
            newClasa.An = An;
            newClasa.ProfilID = Profil;

            var tempProfil = context.Profiluri.Where(p => p.Id == Profil).FirstOrDefault();
            newClasa.Profil = tempProfil;

            newClasa.DiriginteID = Diriginte;
            var tempDiriginte = context.Profesorii.Where(p => p.Id == Diriginte).FirstOrDefault();
            newClasa.Diriginte = tempDiriginte;

           

            context.Clase.AddOrUpdate(newClasa);
            context.SaveChanges();

            int ClasaID = newClasa.Id;
            return ClasaID;


        }

        void AddElevClasa(int clasa, int elev, DatabaseLayer.CatalogContex context)
        {
            var newElev = context.Elevi.Where(e => e.Id == elev).FirstOrDefault();
            var newClasa = context.Clase.Where(c => c.Id == clasa).FirstOrDefault();

            newClasa.Elevi.Add(newElev);
           // context.Clase.AddOrUpdate(newClasa);

            context.SaveChanges();

        }


        //void RelationshipElevNota (int ElevId, int NotaId, DatabaseLayer.CatalogContex context)
        //{
        //    var tempElev = context.Elevi.Where(e => e.Id == ElevId).FirstOrDefault();
        //    var tempNota = context.Note.Where(n => n.Id == NotaId).FirstOrDefault();

        //    tempElev.Note = tempNota.Nota;


        //}

       
        protected override void Seed(DatabaseLayer.CatalogContex context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data

            // adaug profil nou
            //var newProfil = new t_profil();
            //newProfil.Nume = "Mate-Info";

            //context.Profiluri.AddOrUpdate(newProfil);
            //context.SaveChanges(); // salvez in baza de date

            //int profilId = newProfil.Id; // ID-ul din baza de date dupa ce a fost inserat

            ///////////////////////////////////////////////////////

            //// adaug profesor nou
            //var newProfesor = new t_profesor();
            //newProfesor.Nume = "Vasie";
            //newProfesor.Prenume = "Pop";
            //newProfesor.Telefon = "0746662435";
            //newProfesor.Email = "pop.vasile@scoala.ro";

            //context.Profesorii.AddOrUpdate(newProfesor);
            //context.SaveChanges();

            //int profesorId = newProfesor.Id; // ID-ul din baza de date dupa ce a fost inserat

            //// adaug materie noua nou
            //var newMaterie = new t_materie();
            //newMaterie.Nume = "Matematica";
            //newMaterie.Optional = false;

            //context.Materii.AddOrUpdate(newMaterie);
            //context.SaveChanges();

            //int materieId = newMaterie.Id; // ID-ul din baza de date dupa ce a fost inserat

            //// adaug legatura intre cele 2 tabele prin tabela de legatura
            //var newProfesorMaterieRelationship = new t_profesor_materie();
            //newProfesorMaterieRelationship.Profesor = newProfesor;
            //newProfesorMaterieRelationship.Materie = newMaterie;

            //context.ProfesoriMaterii.AddOrUpdate(newProfesorMaterieRelationship);
            //context.SaveChanges();

            //// Actualizaez lagaturile la dintre profesorul si materie pentru a creaa legatura many-to-many

            //var tempProfesor = context.Profesorii.Where(p => p.Id == profesorId).FirstOrDefault();
            //tempProfesor.Materie.Add(newProfesorMaterieRelationship);
            //context.SaveChanges();

            //var tempMaterie = context.Materii.Where(m => m.Id == materieId).FirstOrDefault();
            //tempMaterie.Profesori.Add(newProfesorMaterieRelationship);
            //context.SaveChanges();

            ////////////////////////////////////////
            sem Semestrul = new sem();


            int Mate_Info = AddProfil("Mate_Info", context);
            int Filo = AddProfil("Filo", context);
            int Stinte = AddProfil("Stinte", context);


            
            int d_Matematica = AddMaterie("Matematica", false, context);
            int d_Fizica = AddMaterie("Fizica", false, context);
            int d_MatematicaM3 = AddMaterie("Matematica M3", true, context);
            int d_Romana = AddMaterie("Romana", false, context);
            int d_Chimie = AddMaterie("Chimie", false, context);



            int p_VasilePop = AddProfessor("Vasie", "Pop", "0746662435", "pop.vasile@scoala.ro", context);
            AddRelationshipProfesorMaterie(p_VasilePop, d_Matematica, context);

            int p_IoanRoata = AddProfessor("Ioan", "Roata", "0746662435", "ioan.roata@scoala.ro", context);
            AddRelationshipProfesorMaterie(p_IoanRoata, d_Matematica, context);
            AddRelationshipProfesorMaterie(p_IoanRoata, d_Fizica, context);

            int p_MariaAdrian = AddProfessor("Maria", "Adrian", "0741000000", "Maria.Adrian@scoala.ro", context);
            AddRelationshipProfesorMaterie(p_MariaAdrian, d_Matematica, context);
            AddRelationshipProfesorMaterie(p_MariaAdrian, d_MatematicaM3, context);

            int p_RaduPopescu = AddProfessor("Radu", "Popescu", "0741234567", "Radu.popescu@scoala.ro", context);
            AddRelationshipProfesorMaterie(p_RaduPopescu, d_Matematica, context);
            AddRelationshipProfesorMaterie(p_RaduPopescu, d_Fizica, context);
            AddRelationshipProfesorMaterie(p_RaduPopescu, d_MatematicaM3, context);

            int p_GeorgeStan = AddProfessor("George", "Stan", "0745678901", "GeorgescuStan@scoala.ro", context);
            AddRelationshipProfesorMaterie(p_GeorgeStan, d_Chimie, context);



            int c_9A = AddClasa(9, "A", 2018, Mate_Info, p_RaduPopescu, context);
            int c_11B = AddClasa(11, "B", 2018, Stinte, p_GeorgeStan, context);
            int c_10D = AddClasa(10, "D", 2017, Filo, p_IoanRoata, context);

            //DateTime newData;
            
            int e_AlexandruAlexandrescu = AddElev("Alexandrescu","Alexandru", new DateTime(2002, 03, 24), "074555000444","AlexAlexandrescu@elev.ro", 7452, c_9A, context);

            
            int o_ObsAlexandrescu = AddObservatie(new DateTime(2018, 02, 02), p_IoanRoata, "Folosirea telefonului mobil in timpul orei", context);

         
            
            int a_Alexandrescu1 = AddAbsenta(d_Matematica, true, new DateTime(2018, 02, 02), Semestrul, p_IoanRoata, context);
            int a_Alexandrescu2 = AddAbsenta(d_Matematica, true, new DateTime(2018, 02, 02), Semestrul, p_IoanRoata, context);

            
            int a_Alexandrescu3 = AddAbsenta(d_MatematicaM3, false, new DateTime(2018, 02, 01), Semestrul, p_IoanRoata, context);

            int n_AlexandrescuChimie1 = AddNota(e_AlexandruAlexandrescu, d_Chimie, 7, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_AlexandrescuChimie2 = AddNota(e_AlexandruAlexandrescu, d_Chimie, 8, true, Semestrul, new DateTime(2018, 02, 01), context);
            int n_AlexandrescuFizica1 = AddNota(e_AlexandruAlexandrescu, d_Fizica, 5, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_AlexandrescuFizica2 = AddNota(e_AlexandruAlexandrescu, d_Fizica, 8, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_AlexandrescuMate1 = AddNota(e_AlexandruAlexandrescu, d_Matematica, 7, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_AlexandrescuMate2 = AddNota(e_AlexandruAlexandrescu, d_Matematica, 9, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_AlexandrescuMate3 = AddNota(e_AlexandruAlexandrescu, d_Matematica, 10, true, Semestrul, new DateTime(2018, 02, 01), context);
            int n_AlexandrescuMateM31 = AddNota(e_AlexandruAlexandrescu, d_MatematicaM3, 9, false, Semestrul, new DateTime(2018, 02, 01), context);

            AddObservatieElev(e_AlexandruAlexandrescu, o_ObsAlexandrescu, context);

            AddAbsentaElev(e_AlexandruAlexandrescu, a_Alexandrescu1, context);
            AddAbsentaElev(e_AlexandruAlexandrescu, a_Alexandrescu2, context);
            AddAbsentaElev(e_AlexandruAlexandrescu, a_Alexandrescu3, context);

            AddNotaElev(e_AlexandruAlexandrescu, n_AlexandrescuChimie1, context);
            AddNotaElev(e_AlexandruAlexandrescu, n_AlexandrescuChimie2, context);
            AddNotaElev(e_AlexandruAlexandrescu, n_AlexandrescuFizica1, context);
            AddNotaElev(e_AlexandruAlexandrescu, n_AlexandrescuFizica2, context);
            AddNotaElev(e_AlexandruAlexandrescu, n_AlexandrescuMate1, context);
            AddNotaElev(e_AlexandruAlexandrescu, n_AlexandrescuMate2, context);
            AddNotaElev(e_AlexandruAlexandrescu, n_AlexandrescuMate3, context);
            AddNotaElev(e_AlexandruAlexandrescu, n_AlexandrescuMateM31, context);

            AddElevClasa(c_9A, e_AlexandruAlexandrescu, context);

            ////////////////////////////////////


            

            int e_FlorinFlorescu = AddElev("Florescu", "Florin", new DateTime(2001, 04, 15), "074445556667", "FlorinFlorescu@elev.ro", 1234, c_11B, context);

          
            int o_ObsFlorescu = AddObservatie(new DateTime(2002, 02, 03), p_IoanRoata, "Folosirea telefonului mobil in timpul orei", context);

           
            int a_Florescu1 = AddAbsenta(d_MatematicaM3, false, new DateTime(01, 02, 2018), Semestrul, p_IoanRoata, context);
            int a_Florescu2 = AddAbsenta(d_Fizica, false, new DateTime(01, 02, 2018), Semestrul, p_RaduPopescu, context);

            int n_FlorescuChimie1 = AddNota(e_FlorinFlorescu, d_Chimie, 10, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_FlorescuFizica1 = AddNota(e_FlorinFlorescu, d_Fizica, 10, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_FlorescuFizica2 = AddNota(e_FlorinFlorescu, d_Chimie, 8, true, Semestrul, new DateTime(2018, 02, 01), context);
            int n_FlorescuMate1 = AddNota(e_FlorinFlorescu, d_Matematica, 6, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_FlorescuMate2 = AddNota(e_FlorinFlorescu, d_Matematica, 10, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_FlorescuRomana1 = AddNota(e_FlorinFlorescu, d_Romana, 7, true, Semestrul, new DateTime(2018, 02, 01), context);
            int n_FlorescuRomana2 = AddNota(e_FlorinFlorescu, d_Romana, 7, false, Semestrul, new DateTime(2018, 02, 01), context);

            AddObservatieElev(e_FlorinFlorescu, o_ObsFlorescu, context);

            AddAbsentaElev(e_FlorinFlorescu, a_Florescu1, context);
            AddAbsentaElev(e_FlorinFlorescu, a_Florescu2, context);

            AddNotaElev(e_FlorinFlorescu, n_FlorescuChimie1, context);
            AddNotaElev(e_FlorinFlorescu, n_FlorescuFizica1, context);
            AddNotaElev(e_FlorinFlorescu, n_FlorescuFizica2, context);
            AddNotaElev(e_FlorinFlorescu, n_FlorescuMate1, context);
            AddNotaElev(e_FlorinFlorescu, n_FlorescuMate2, context);
            AddNotaElev(e_FlorinFlorescu, n_FlorescuRomana1, context);
            AddNotaElev(e_FlorinFlorescu, n_FlorescuRomana2, context);


            AddElevClasa(c_11B, e_FlorinFlorescu, context);

            //////////////////////////////////////////////////////////////////////////////
           
            int e_GeorgeGeorgescu = AddElev("Georgescu", "George", new DateTime(2001, 03, 04), "074447756667", "GeorgeGeorgescu@elev.ro", 1834, c_11B, context);

            int n_GeorgescuChimie1 = AddNota(e_GeorgeGeorgescu, d_Chimie, 8, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_GeorgescuChimie2 = AddNota(e_GeorgeGeorgescu, d_Chimie, 8, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_GeorgescuRomana1 = AddNota(e_GeorgeGeorgescu, d_Romana, 9, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_GeorgescuRomana2 = AddNota(e_GeorgeGeorgescu, d_Romana, 9, true, Semestrul, new DateTime(2018, 02, 01), context);
            int n_GeorgescuMate1 = AddNota(e_GeorgeGeorgescu, d_Matematica, 10, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_GeorgescuMate2 = AddNota(e_GeorgeGeorgescu, d_Matematica, 9, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_GeorgescuMate3 = AddNota(e_GeorgeGeorgescu, d_Matematica, 10, true, Semestrul, new DateTime(2018, 02, 01), context);
            int n_GeorgescuFizica1 = AddNota(e_GeorgeGeorgescu, d_Fizica, 9, false, Semestrul, new DateTime(2018, 02, 01), context);

            AddNotaElev(e_GeorgeGeorgescu, n_GeorgescuChimie1, context);
            AddNotaElev(e_GeorgeGeorgescu, n_GeorgescuChimie2, context);
            AddNotaElev(e_GeorgeGeorgescu, n_GeorgescuRomana1, context);
            AddNotaElev(e_GeorgeGeorgescu, n_GeorgescuRomana2, context);
            AddNotaElev(e_GeorgeGeorgescu, n_GeorgescuMate1, context);
            AddNotaElev(e_GeorgeGeorgescu, n_GeorgescuMate2, context);
            AddNotaElev(e_GeorgeGeorgescu, n_GeorgescuMate3, context);
            AddNotaElev(e_GeorgeGeorgescu, n_GeorgescuFizica1, context);

            AddElevClasa(c_11B, e_GeorgeGeorgescu, context);

            //////////////////////////////////////////////////////////////////////////

             

            int e_IoanIonsescu = AddElev("Ionescu", "Ioan", new DateTime(2001, 07, 09), "074555990444", "IoanIonsescu@elev.ro", 5892, c_10D, context);


            int n_IonescuChimie1 = AddNota(e_IoanIonsescu, d_Chimie, 8, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_IonescuChimie2 = AddNota(e_IoanIonsescu, d_Chimie, 8, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_IonescuRomana1 = AddNota(e_IoanIonsescu, d_Romana, 9, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_IonescuRomana2 = AddNota(e_IoanIonsescu, d_Romana, 9, true, Semestrul, new DateTime(2018, 02, 01), context);
            int n_IonescuMate1 = AddNota(e_IoanIonsescu, d_Matematica, 10, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_IonescuMate2 = AddNota(e_IoanIonsescu, d_Matematica, 9, false, Semestrul, new DateTime(2018, 02, 01), context);
            int n_IonescuMate3 = AddNota(e_IoanIonsescu, d_Matematica, 10, true, Semestrul, new DateTime(2018, 02, 01), context);
            int n_IonescuFizica1 = AddNota(e_IoanIonsescu, d_Fizica, 9, false, Semestrul, new DateTime(2018, 02, 01), context);


            AddElevClasa(c_10D, e_IoanIonsescu, context);
           






            
            


            

           



            ////////////////////////////////////////////////////

            // incepo sa mai adug un prfesor nou si mia jos inca o materie.
            // profestul acesta va fi legat de materia noua si de cea deja existenta
            //    newProfesor = new t_profesor();
            //    newProfesor.Nume = "Maria";
            //    newProfesor.Prenume = "Adrian";
            //    newProfesor.Telefon = "0741000000";
            //    newProfesor.Email = "Maria.Adrian@scoala.ro";

            //    context.Profesorii.AddOrUpdate(newProfesor);
            //    context.SaveChanges();

            //    var secodprofesorId = newProfesor.Id; // ID-ul din baza de date dupa ce a fost inserat

            //    newProfesorMaterieRelationship = new t_profesor_materie();
            //    newProfesorMaterieRelationship.Profesor = newProfesor;
            //    newProfesorMaterieRelationship.Materie = newMaterie;

            //    context.ProfesoriMaterii.AddOrUpdate(newProfesorMaterieRelationship);
            //    context.SaveChanges();

            //    tempProfesor = context.Profesorii.Where(p => p.Id == secodprofesorId).FirstOrDefault();
            //    tempProfesor.Materie.Add(newProfesorMaterieRelationship);
            //    context.SaveChanges();

            //    tempMaterie = context.Materii.Where(m => m.Id == materieId).FirstOrDefault();
            //    tempMaterie.Profesori.Add(newProfesorMaterieRelationship);
            //    context.SaveChanges();


            //    newMaterie = new t_materie();
            //    newMaterie.Nume = "Matematica M3";
            //    newMaterie.Optional = true;

            //    context.Materii.AddOrUpdate(newMaterie);
            //    context.SaveChanges();

            //    materieId = newMaterie.Id; // ID-ul din baza de date dupa ce a fost inserat

            //    newProfesorMaterieRelationship = new t_profesor_materie();
            //    newProfesorMaterieRelationship.Profesor = newProfesor;
            //    newProfesorMaterieRelationship.Materie = newMaterie;

            //    context.ProfesoriMaterii.AddOrUpdate(newProfesorMaterieRelationship);
            //    context.SaveChanges();

            //    tempProfesor = context.Profesorii.Where(p => p.Id == secodprofesorId).FirstOrDefault();
            //    tempProfesor.Materie.Add(newProfesorMaterieRelationship);
            //    context.SaveChanges();

            //    tempMaterie = context.Materii.Where(m => m.Id == materieId).FirstOrDefault();
            //    tempMaterie.Profesori.Add(newProfesorMaterieRelationship);
            //    context.SaveChanges();
        }
    }
}

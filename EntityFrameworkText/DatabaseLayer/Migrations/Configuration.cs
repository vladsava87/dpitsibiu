namespace DatabaseLayer.Migrations
{
    using DataModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseLayer.CatalogContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatabaseLayer.CatalogContex context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data

            // adaug profil nou
            var newProfil = new t_profil();
            newProfil.Nume = "Mate-Info";

            context.Profiluri.AddOrUpdate(newProfil);
            context.SaveChanges(); // salvez in baza de date

            int profilId = newProfil.Id; // ID-ul din baza de date dupa ce a fost inserat

            // adaug profesor nou
            var newProfesor = new t_profesor();
            newProfesor.Nume = "Vasie";
            newProfesor.Prenume = "Pop";
            newProfesor.Telefon = 0746662435;
            newProfesor.Email = "pop.vasile@scoala.ro";

            context.Profesorii.AddOrUpdate(newProfesor);
            context.SaveChanges();

            int profesorId = newProfesor.Id; // ID-ul din baza de date dupa ce a fost inserat

            // adaug materie noua nou
            var newMaterie = new t_materie();
            newMaterie.Nume = "Matematica";
            newMaterie.Optional = false;

            context.Materii.AddOrUpdate(newMaterie);
            context.SaveChanges();
            
            int materieId = newMaterie.Id; // ID-ul din baza de date dupa ce a fost inserat

            // adaug legatura intre cele 2 tabele prin tabela de legatura
            var newProfesorMaterieRelationship = new t_profesor_materie();
            newProfesorMaterieRelationship.Profesor = newProfesor;
            newProfesorMaterieRelationship.IdProfesor = profesorId;
            newProfesorMaterieRelationship.IdMaterie = materieId;
            newProfesorMaterieRelationship.Materie = newMaterie;

            context.ProfesoriMaterii.AddOrUpdate(newProfesorMaterieRelationship);
            context.SaveChanges();

            // Actualizaez lagaturile la dintre profesorul si materie pentru a creaa legatura many-to-many

            var tempProfesor = context.Profesorii.Where(p => p.Id == profesorId).FirstOrDefault();
            tempProfesor.Materie.Add(newProfesorMaterieRelationship);
            context.SaveChanges();

            var tempMaterie = context.Materii.Where(m => m.Id == materieId).FirstOrDefault();
            tempMaterie.Profesori.Add(newProfesorMaterieRelationship);
            context.SaveChanges();


            // incepo sa mai adug un prfesor nou si mia jos inca o materie.
            // profestul acesta va fi legat de materia noua si de cea deja existenta
            newProfesor = new t_profesor();
            newProfesor.Nume = "Maria";
            newProfesor.Prenume = "Adrian";
            newProfesor.Telefon = 0741000000;
            newProfesor.Email = "Maria.Adrian@scoala.ro";

            context.Profesorii.AddOrUpdate(newProfesor);
            context.SaveChanges();

            var secodprofesorId = newProfesor.Id; // ID-ul din baza de date dupa ce a fost inserat

            newProfesorMaterieRelationship = new t_profesor_materie();
            newProfesorMaterieRelationship.Profesor = newProfesor;
            newProfesorMaterieRelationship.IdProfesor = secodprofesorId;
            newProfesorMaterieRelationship.IdMaterie = materieId;
            newProfesorMaterieRelationship.Materie = newMaterie;

            context.ProfesoriMaterii.AddOrUpdate(newProfesorMaterieRelationship);
            context.SaveChanges();

            tempProfesor = context.Profesorii.Where(p => p.Id == secodprofesorId).FirstOrDefault();
            tempProfesor.Materie.Add(newProfesorMaterieRelationship);
            context.SaveChanges();

            tempMaterie = context.Materii.Where(m => m.Id == materieId).FirstOrDefault();
            tempMaterie.Profesori.Add(newProfesorMaterieRelationship);
            context.SaveChanges();


            newMaterie = new t_materie();
            newMaterie.Nume = "Matematica M3";
            newMaterie.Optional = true;

            context.Materii.AddOrUpdate(newMaterie);
            context.SaveChanges();

            materieId = newMaterie.Id; // ID-ul din baza de date dupa ce a fost inserat

            newProfesorMaterieRelationship = new t_profesor_materie();
            newProfesorMaterieRelationship.Profesor = newProfesor;
            newProfesorMaterieRelationship.IdProfesor = secodprofesorId;
            newProfesorMaterieRelationship.IdMaterie = materieId;
            newProfesorMaterieRelationship.Materie = newMaterie;

            context.ProfesoriMaterii.AddOrUpdate(newProfesorMaterieRelationship);
            context.SaveChanges();

            tempProfesor = context.Profesorii.Where(p => p.Id == secodprofesorId).FirstOrDefault();
            tempProfesor.Materie.Add(newProfesorMaterieRelationship);
            context.SaveChanges();

            tempMaterie = context.Materii.Where(m => m.Id == materieId).FirstOrDefault();
            tempMaterie.Profesori.Add(newProfesorMaterieRelationship);
            context.SaveChanges();
        }
    }
}

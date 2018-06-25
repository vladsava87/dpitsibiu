﻿using DatabaseLayer.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace DatabaseLayer.DataModels
{
    public class t_materie
    {
        [Key]
        public int Id { get; set; }
        public int Nume { get; set; }
        public bool Optional { get; set; }

        public virtual List<t_absenta> Absente { get; set; }
        public virtual List<t_nota> Note { get; set; }
        public virtual ICollection<t_profesor_materie> Profesori { get; set; }
    }

    public class t_absenta
    {
        [Key]
        public int Id { get; set; }
        public bool Motivata{ get; set; }
        public DateTime Data { get; set; }
        public sem Semestrul { get; set; }

        public int IdMaterie { get; set; }
        public virtual t_materie Materie { get; set; }
        public int IdProfesor { get; set; }
        public virtual t_profesor Profesor { get; set; }

        public int IdElev { get; set; }
        public virtual t_elev Elev { get; set; }
    }

    public enum sem
    {
        sem1 = 1,
        sem2 = 2
    }

    public class t_observatie
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Text { get; set; }


        public int IdProfesor { get; set; }
        public virtual t_profesor Profesor { get; set; }
        public int IdElev { get; set; }
        public virtual t_elev Elev { get; set; }
    }

   public class t_profesor
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public int IdMaterii { get; set; }

        public virtual List<t_absenta> Absente { get; set; }
        public virtual ICollection<t_profesor_materie> Materie { get; set; }
        public virtual List<t_observatie> Observatii { get; set; }
    }

    public class t_elev
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
        public DateTime Date { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public int Numar_Matricol { get; set; }
        public int Clasa { get; set; }

        public virtual List<t_nota> Note { get; set; }
        public virtual List<t_absenta> Absente { get; set; }
        public virtual List<t_observatie> Observatii { get; set; }
    }

    public class t_nota
    {
        [Key]
        public int Id { get; set; }
        public double Nota { get; set; }
        public bool Teza { get; set; }
        public sem Semestrul { get; set; }

        public int IdElev { get; set; }
        public virtual t_elev Elev { get; set; }
        public int IdMaterie { get; set; }
        public virtual t_materie Materie { get; set; }
    }

    public class t_clasa
    {
        [Key]
        public int Id { get; set; }
        public int Numar { get; set; }
        public string Serie { get; set; }
        public int An { get; set; }

        public int IdProfil { get; set; }
        public virtual t_profil Profil { get; set; }
        public int IdProfesor { get; set; }
        public virtual t_profesor Diriginte { get; set; }
        public virtual List<t_elev> Elevi { get; set; }
    }

    public class t_profil
    {
        [Key]
        public int Id { get; set; }
        string Nume { get; set; } 
        
        public virtual List<t_clasa> Clase { get; set; }
    }

    public class t_profesor_materie
    {
        [Key, Column(Order = 0)]
        public int IdMaterie { get; set; }
        [Key, Column(Order = 1)]
        public int IdProfesor { get; set; }
        

        public virtual t_materie Materie { get; set; }
        public virtual t_profesor Profesor { get; set; }
    }
}

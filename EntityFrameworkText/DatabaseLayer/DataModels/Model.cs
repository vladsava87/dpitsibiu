using DatabaseLayer.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace DatabaseLayer.DataModels
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }
    }

    public class t_materie
    {
        [Key]
        public int Id { get; set; }
        public int Nume { get; set; }
        public bool Optional { get; set; }
       // public int IdProfesor { get; set; }


        public virtual List<t_absenta> Absente { get; set; }
        public virtual List<t_nota> Note { get; set; }
        public virtual List<t_profesor> Profesori { get; set; }
    }

    public class t_absenta
    {
        [Key]
        public int Id { get; set; }
        public int Materie { get; set; }
        public bool Motivatie { get; set; }
        public DateTime Data { get; set; }
        public sem Semestrul { get; set; }
        public int Profesor { get; set; }
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
        public int Profesor { get; set; }
        public string Text { get; set; }
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
    }

    public class t_profesor_materie
    {
        [Key, Column(Order = 0)]
        public int IdMaterie { get; set; }
        

        public virtual t_materie Materie { get; set; }
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
        public virtual List<t_elev> Absente { get; set; }
        public virtual List<t_observatii> Observatii { get; set; }
    }

    public class t_nota
    {
        [Key]
        public int Id { get; set; }
        public virtual List<t_materie> Materie { get; set; }
        public double Nota { get; set; }
        public bool Teza { get; set; }
        public Sem { get; set; }
        public t_elev Elev { get; set; }
    }

    public class t_clasa
    {
        [Key]
        public int Id { get; set; }
        public int Numar { get; set; }
        public string Serie { get; set; }
        public int An { get; set; }

        public virtual List<t_profil> Profil { get; set; }
        public virtual List<t_profesor> Diriginte { get; set; }
        public virtual List<t_elev> Elevi { get; set; }
    }

    public class t_profil
    {
        [Key]
        public int Id { get; set; }
        string Nume { get; set; }
        public virtual t_profil Profil { get; set; }
    }
}

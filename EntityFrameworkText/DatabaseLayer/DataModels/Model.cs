﻿using DatabaseLayer.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLayer.DataModels
{
    public class t_materie
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
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

        public int MaterieID { get; set; }
        public virtual t_materie Materie { get; set; }
        public int ProfesorID { get; set; }
        public virtual t_profesor Profesor { get; set; }

        public int ElevID { get; set; }
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


        public int ProfesorID { get; set; }
        public virtual t_profesor Profesor { get; set; }
        public int ElevID { get; set; }
        public virtual t_elev Elev { get; set; }
    }

   public class t_profesor : IDisposable
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }

        public virtual List<t_absenta> Absente { get; set; }
        public virtual ICollection<t_profesor_materie> Materie { get; set; }
        public virtual List<t_observatie> Observatii { get; set; }

        public virtual ICollection<t_profesor_clasa> Clase { get; set; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~t_profesor() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class t_elev : IDisposable
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime Data { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int Numar_Matricol { get; set; }
        public string Parola { get; set; }

        public int ClasaID { get; set; }
        public virtual t_clasa Clasa { get; set; }

        public virtual List<t_nota> Note { get; set; }
        public virtual List<t_absenta> Absente { get; set; }
        public virtual List<t_observatie> Observatii { get; set; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~t_elev() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class t_nota
    {
        [Key]
        public int Id { get; set; }
        public double Nota { get; set; }
        public bool Teza { get; set; }
        public sem Semestrul { get; set; }
        public DateTime Data { get; set; }

        public int ElevID { get; set; }
        public virtual t_elev Elev { get; set; }
        public int MaterieID { get; set; }
        public virtual t_materie Materie { get; set; }
    }

    public class t_clasa
    {
        [Key]
        public int Id { get; set; }
        public int Numar { get; set; }
        public string Serie { get; set; }
        public int An { get; set; }

        public int ProfilID { get; set; }
        public virtual t_profil Profil { get; set; }
        public int DiriginteID { get; set; }
        public virtual t_profesor Diriginte { get; set; }
        public virtual List<t_elev> Elevi { get; set; }

        public virtual ICollection<t_profesor_clasa> Profesori { get; set; }
    }

    public class t_profil
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; } 
        
        public virtual List<t_clasa> Clase { get; set; }
    }

    public class t_profesor_materie
    {
        [Key, Column(Order = 0)]
        public int MaterieID { get; set; }
        [Key, Column(Order = 1)]
        public int ProfesorID { get; set; }
        

        public virtual t_materie Materie { get; set; }
        public virtual t_profesor Profesor { get; set; }
    }

    public class t_profesor_clasa
    {
        [Key, Column(Order = 0)]
        public int ClasaID { get; set; }
        [Key, Column(Order = 1)]
        public int ProfesorID { get; set; }


        public virtual t_clasa Clasa { get; set; }
        public virtual t_profesor Profesor { get; set; }
    }
}
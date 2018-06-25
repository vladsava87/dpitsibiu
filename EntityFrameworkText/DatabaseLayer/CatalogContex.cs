using System.Data.Entity;
using DatabaseLayer.DataModels;

namespace DatabaseLayer
{
    public class CatalogContex : DbContext
    {
        public CatalogContex(string connectionName)
            : base(string.Format("name={0}", connectionName))
        {

        }

        public DbSet<t_materie> Materii { get; set; }
        public DbSet<t_absenta> Absente { get; set; }
        public DbSet<t_observatie> Observatii { get; set; }
        public DbSet<t_profesor> Profesorii { get; set; }
        public DbSet<t_elev> Elevi { get; set; }
        public DbSet<t_nota> Note { get; set; }
        public DbSet<t_clasa> Clase { get; set; }
        public DbSet<t_profil> Profiluri { get; set; }
    }
}

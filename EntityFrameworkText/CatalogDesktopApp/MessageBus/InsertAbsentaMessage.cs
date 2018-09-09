using System;

namespace CatalogDesktopApp
{
    public class InsertAbsentaMessage : IMessage
    {
        public int MaterieID { get; set; }

        public int ProfesorID { get; set; }

        public bool Motivata { get; set; }

        public DateTime Data { get; set; }

        public int Semestrul { get; set; }
    }
}

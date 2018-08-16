using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.DTO
{
    [DataContract]
    public class ElevDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nume { get; set; }
        [DataMember]
        public string Prenume { get; set; }
        [DataMember]
        public string Parola { get; set; }
        [DataMember]
        public string Telefon { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int Numar_Matricol { get; set; }
        [DataMember]
        public DateTime Data { get; set; }

        [DataMember]
        public int ClasaID { get; set; }

        // [DataMember]
        // public int NotaID { get; set; }
        [DataMember]
        public List<NotaDTO> Note { get; set; }
        // [DataMember]
        // public int AbsentaID { get; set; }
        [DataMember]
        public List<AbsentaDTO> Absente { get; set; }
        // [DataMember]
        // public int ObservatieID { get; set; }
        [DataMember]
        public List<ObservatieDTO> Observatii { get; set; }
    }
}

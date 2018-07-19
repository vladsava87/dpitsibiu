using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using DatabaseLayer.DataModels;

namespace DatabaseLayer.DTO
{
    [DataContract]
    public class NotaDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public double Nota { get; set; }
        [DataMember]
        public bool Teza { get; set; }
        [DataMember]
        public sem Semestrul { get; set; }
        [DataMember]
        public DateTime Data { get; set; }
        [DataMember]
        public int ElevID { get; set; }
        [DataMember]
        public ElevDTO Elev { get; set; }
        [DataMember]
        public int MaterieID { get; set; }
        [DataMember]
        public MaterieDTO Materie { get; set; }
    }
}

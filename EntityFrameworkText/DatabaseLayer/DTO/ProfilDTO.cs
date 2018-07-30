using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.DTO
{
    [DataContract]
    public class ProfilDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nume { get; set; }

        // [DataMember]
        // public int ClasaID { get; set; }
        [DataMember]
        public List<ClasaDTO> Clase { get; set; }
    }
}

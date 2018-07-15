using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.DTO
{
    [DataContract]
    public class ClasaDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Numar { get; set; }
        [DataMember]
        public string Serie { get; set; }
        [DataMember]
        public int An { get; set; }

        [DataMember]
        public int ProfilID { get; set; }
        [DataMember]
        public ProfilDTO Profil { get; set; }
        [DataMember]
        public int DiriginteID { get; set; }
        [DataMember]
        public ProfesorDTO Diriginte { get; set; }
        [DataMember]
        public int ElevID { get; set; }
        [DataMember]
        public List<ElevDTO> Elevi { get; set; }
    }
}

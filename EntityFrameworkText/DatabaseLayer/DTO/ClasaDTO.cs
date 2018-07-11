using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

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
        //public virtual t_profesor Diriginte { get; set; }
        //public virtual List<t_elev> Elevi { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DatabaseLayer.DTO
{
    [DataContract]
    public class MaterieDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nume { get; set; }
        [DataMember]
        public bool Optional { get; set; }

        // [DataMember]
        // public int AbsentaID { get; set; }
        [DataMember]
        public List<AbsentaDTO> Absente { get; set; }
        // [DataMember]
        // public int NotaID { get; set; }
        [DataMember]
        public List<NotaDTO> Note { get; set; }
        [DataMember]
        public int ProfesorID { get; set; }
        [DataMember]
        public ProfesorDTO Profesor { get; set; }


        //public virtual ICollection<t_profesor_materie> Profesori { get; set; }


    }
}

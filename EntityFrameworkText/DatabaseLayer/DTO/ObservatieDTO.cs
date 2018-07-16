using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.DTO
{
    [DataContract]
    public class ObservatieDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public int ProfesorID { get; set; }
        [DataMember]
        public ProfesorDTO Profesor { get; set; }
        [DataMember]
        public int ElevID { get; set; }
        [DataMember]
        public ElevDTO Elev { get; set; }
    }
}

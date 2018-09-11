using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewWebService.Util
{
    public class Utilizator
    {
        public int Id { get; set; }
        public ut Tip { get; set; }
    }

    public enum ut
    {
        elev = 1,
        profesor = 2
    }
}
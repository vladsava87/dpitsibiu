using DatabaseLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewWebService
{
    public class WebServiceSecurity
    {
        public static bool Login(string username, string password)
        {
            bool req = false;

            using (t_elev persoana = new t_elev())
            {
                if (persoana.Email.Equals(username, StringComparison.OrdinalIgnoreCase) && persoana.Parola == password)
                {
                    req = true;
                }
            }

            if (req == false)
            {
                using (t_profesor persoana = new t_profesor())
                {
                    if (persoana.Email.Equals(username, StringComparison.OrdinalIgnoreCase) && persoana.Parola == password)
                    {
                        req = true;
                    }
                }
            }

            return req;
        }
    }
}
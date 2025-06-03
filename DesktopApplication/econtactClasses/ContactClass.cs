using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication.econtactClasses
{
    public class ContactClass
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        //static string myconnectionstring = ConfigrationManager.ConnectionString["DefaultConnection"].ConnectionString;
        //string conn = _config.GetConnectionString("DefaultConnection");

    }
}

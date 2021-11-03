using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2009M1HelloUWP.Entitis
{
    public class Student
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Fullname { get; set; }
        public String Email { get; set; }

        public override string ToString()
        {
            return $"Username {Username}, Fullname {Fullname},Email {Email}";
        }

    }
}

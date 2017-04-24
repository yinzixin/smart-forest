using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Model
{
    public class User
    {
        public int ID { get; set; }

        public string DefaultArea { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Title { get; set; }

        public string RealName { get; set; }

        public string CompanyName { get; set; }

        public bool IsPause { get; set; }
    }
}

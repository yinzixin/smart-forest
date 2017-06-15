using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Model
{
    public class LoginLog
    {
        public int IDUser { get; set; }

        public DateTime CreateTime { get; set; }

        public string LoginName { get; set; }

        public string IP { get; set; }

        public bool IsPass { get; set; }
    }
}

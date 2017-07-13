using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Model
{
    public class User
    {
        public int ID { get; set; }
         [Required(ErrorMessage = "必填字段")]
        public string DefaultArea { get; set; }

         [Required(ErrorMessage = "必填字段")]
        public string UserName { get; set; }
          [Required(ErrorMessage = "必填字段")]
        public string Password { get; set; }
        [Required(ErrorMessage = "必填字段")]
        public string Title { get; set; }
          [Required(ErrorMessage = "必填字段")]
        public string RealName { get; set; }
          [Required(ErrorMessage = "必填字段")]
        public string CompanyName { get; set; }

        public int ParentUser { get; set; }

        public int Level { get; set; }

        public bool IsPause { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Web.Models
{
    public class TreeQueryModel
    {
        public TreeQueryModel()
        {
            Current = 1;
        }
        public int? Age_Start { get; set; }

        public int? Age_End { get; set; }

        public string Area { get; set; }

        public string IDName { get; set; }

        public decimal? Chest_Start { get; set; }

        public decimal? Chest_End { get; set; }

        public decimal? Root_Start { get; set; }

        public decimal? Root_End { get; set; }

        public int Current { get; set; }

        public int? Jump { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using DapperExtensions.Mapper;
 
namespace SF.Model
{
    public class Tree
    {
        public long ID { get; set; }

        [Required(ErrorMessage = "必填字段")]
        public string Number { get; set; }
        public long UserID { get; set; }

        [Required(ErrorMessage = "必填字段")]
        public string Name { get; set; }
        [Required(ErrorMessage = "必填字段")]
        public string NameLatin { get; set; }
        public string Photo { get; set; }
        public int YearOfBirth
        {
            get;
            set;
        }
        [Required(ErrorMessage = "必填字段")]
        public decimal Height { get; set; }
        public string Story { get; set; }
        public bool? IsFamous { get; set; }
        public bool? IsBooked { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Town { get; set; }
        public string AddressType { get; set; }
        public string CivilizedLevel { get; set; }
        public decimal Longtitude { get; set; }
        public decimal Latitude { get; set; }
        public string Dutier { get; set; }
        public string Health { get; set; }


        [Required(ErrorMessage = "必填字段")]
        public decimal ChestSize { get; set; }
         [Required(ErrorMessage = "必填字段")]
        public decimal RootSize { get; set; }
        public decimal? CrownNorthSouth { get; set; }
        public decimal? CrownEastWest { get; set; }
        public string CrownDeviated { get; set; }
        public string CrownStatus { get; set; }
        public string BodySkin { get; set; }
        public string BodyHole { get; set; }
        public string BodyDeadwood { get; set; }
        public string BodyBug { get; set; }
        public string BodyUsage { get; set; }
        public string OtherChanges { get; set; }
        public string Information { get; set; }
        public string OtherSoil { get; set; }
        public string OtherDrain { get; set; }
        public string OtherVegetation { get; set; }
        public string OtherSeeper { get; set; }
        public string OtherWater { get; set; }
        public string OtherIsGroup { get; set; }
        public string OtherProtectRadient { get; set; }
        public string OtherPavement { get; set; }
        public string OtherHeightMarker { get; set; }
        public string OtherThunder { get; set; }
        public string OtherBuilding { get; set; }
        public string OtherActivity { get; set; }
        public string OtherFenceRadient { get; set; }
        public string OtherSoilProtector { get; set; }
        public string OtherRoot { get; set; }
        public string OtherStrut { get; set; }
        public string OtherBulkhead { get; set; }
        public string OtherThunderProtector { get; set; }
        public string Inspector { get; set; }
        public DateTime? InspectTime { get; set; }
        public string Checker { get; set; }
        public DateTime? CheckTime { get; set; }
        public string Creator { get; set; }
        public DateTime? CreateTime { get; set; }


        public string LonText { get; set; }

        public string LatText { get; set; }

        [Required(ErrorMessage = "必填字段")]
        public int Age { get; set; }
    }


    public class TreeMapper : ClassMapper<Tree>
    {
        public TreeMapper()
        {
            Table("Tree");
            Map(m => m.Age).Ignore();
            Map(m => m.LatText).Ignore();
            Map(m => m.LonText).Ignore();
            AutoMap();
        }
    }
}
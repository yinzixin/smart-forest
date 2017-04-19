﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace SF.Model
{
    class Tree
    {
        public long ID { get; set; }
        public string Number { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string NameLatin { get; set; }
        public string Photo { get; set; }
        public int YearOfBirth { get; set; }
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
        public decimal ChestSize { get; set; }
        public decimal RootSize { get; set; }
        public decimal CrownNorthSouth { get; set; }
        public decimal CrownEastWest { get; set; }
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
        public bool? OtherThunder { get; set; }
        public string OtherBuilding { get; set; }
        public string OtherActivity { get; set; }
        public string OtherFenceRadient { get; set; }
        public string OtherSoilProtector { get; set; }
        public string OtherRoot { get; set; }
        public string OtherStrut { get; set; }
        public string OtherBulkhead { get; set; }
        public string OtherThunderProtector { get; set; }
        public string Inspector { get; set; }
        public string InspectTime { get; set; }
        public string Checker { get; set; }
        public string CheckTime { get; set; }
        public string Creator { get; set; }
        public string CreateTime { get; set; }

    }
}
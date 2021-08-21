using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class DlyGrpCatRegister
    {
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public string ICategory { get; set; }
        public int RegisterID { get; set; }
        public string Register { get; set; }
        public string AircraftType { get; set; }
        public int? TypeId { get; set; }
        public int Delay { get; set; }
        public int DelayUnder30 { get; set; }
        public int DelayOver30 { get; set; }
        public int Delay3060 { get; set; }
        public int Delay60120 { get; set; }
        public int Delay120180 { get; set; }
        public int DelayOver180 { get; set; }
        public int DelayOver240 { get; set; }
        public int DelayUnder30Time { get; set; }
        public int DelayOver30Time { get; set; }
        public int Delay3060Time { get; set; }
        public int Delay60120Time { get; set; }
        public int Delay120180Time { get; set; }
        public int DelayOver180Time { get; set; }
        public int DelayOver240Time { get; set; }
        public int Count { get; set; }
    }
}

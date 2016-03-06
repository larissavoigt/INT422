using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1.Controllers
{
    public class PhoneBase
    {
        public PhoneBase()
        {
            DateReleased = DateTime.Now;
            PhoneName = string.Empty;
            Manufacturer = string.Empty;
        }
        public int Id { get; set; }
        public string PhoneName { get; set; }
        public string Manufacturer { get; set; }
        public DateTime DateReleased { get; set; }
        public int MSRP { get; set; }
        public double ScreenSize { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public int? PickUpLOcationID { get; set; }
        public int? DropOffLocationID { get; set; }
        public int CarID { get; set; }
        public Car Car{ get; set; }

     //  public string PickUpLocationID { get; set; }

        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }

        public string Description { get; set; }
        public Location PickUpLOcation { get; set; }
        public Location DropOffLOcation { get; set; }

        public string Status { get; set; }

    }
}

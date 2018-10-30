using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Car
    {
        [Key]
        public string Grz { get; set; }
        public DateTime Year { get; set; }
        public int Power { get; set; }

        public string Driverlicense { get; set; }
        public string BrandName { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Car()
        {
            Orders = new List<Order>();
        }
    }
}

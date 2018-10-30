using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class OrderQualification
    {
        [Key]
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public OrderQualification()
        {
            Orders = new List<Order>();
        }
    }
}

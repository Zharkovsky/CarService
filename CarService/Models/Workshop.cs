using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Workshop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Mechanic> Mechanics { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Workshop()
        {
            Mechanics = new List<Mechanic>();
            Orders = new List<Order>();
        }
    }
}

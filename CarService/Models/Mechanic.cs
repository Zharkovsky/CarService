using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Mechanic
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string MechanicQualificationName { get; set; }
        public int WorkshopId { get; set; }

        public virtual MechanicQualification MechanicQualification { get; set; }
        public virtual Workshop Workshop { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Mechanic()
        {
            Orders = new List<Order>();
        }
    }
}

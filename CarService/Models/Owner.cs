using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Owner
    {
        [Key]
        public string Driverlicense { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public Owner()
        {
            Cars = new List<Car>();
        }
    }
}

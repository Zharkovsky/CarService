using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Brand
    {
        [Key]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public Brand()
        {
            Cars = new List<Car>();
        }
    }
}

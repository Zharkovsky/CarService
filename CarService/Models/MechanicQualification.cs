using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class MechanicQualification
    {
        [Key]
        public string Name { get; set; }

        public virtual ICollection<Mechanic> Mechanics { get; set; }

        public MechanicQualification()
        {
            Mechanics = new List<Mechanic>();
        }
    }
}

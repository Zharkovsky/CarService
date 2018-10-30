using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime? RealDate { get; set; }

        public string Grz { get; set; }
        public int MechanicId { get; set; }
        public int WorkshopId { get; set; }
        public string OrderQualificationName { get; set; }

        public virtual Car Car { get; set; }
        public virtual Mechanic Mechanic { get; set; }
        public virtual Workshop Workshop { get; set; }
        public virtual OrderQualification OrderQualification { get; set; }

        public Order() { }
    }
}

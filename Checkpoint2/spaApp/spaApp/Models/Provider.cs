using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace spaApp.Models
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public String Name { get; set; }

        [Required]
        [StringLength(20)]
        public String JobTitle { get; set; }

        public List<UsersAppointment> UsersAppointments { get; set; }

    }
}

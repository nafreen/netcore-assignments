using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace spaApp.Models
{
    public class UsersAppointment
    {
        [Key]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Create { get; set; }

        [UIHint ("Provider")]
        public Provider provider { get; set; }
        [UIHint("Customer")]
        public Customer customer { get; set; }
       
    }
}

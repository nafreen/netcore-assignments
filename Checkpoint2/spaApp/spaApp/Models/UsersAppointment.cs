using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace spaApp.Models
{
    public class UsersAppointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime? Create { get; set; }

        public int ProviderId { get; set; }
        public int CustomerId { get; set; }

        [UIHint ("Provider")]
        [Display(Name = "Provider Name")]
        public Provider Provider { get; set; }

        [UIHint("Customer")]
        [Display(Name = "Customer Name")]
        public Customer Customer { get; set; }
       
    }
}

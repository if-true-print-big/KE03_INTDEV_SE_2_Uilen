using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Naam")]
        public string Name { get; set; }


        //hoewel we in het klassendiagram adres als een losse klasse hebben, lukte het ons niet om die functionaliteit correct te implementeren
        //hiertoe blijven wij adres opslaan als string in de customer en gebruiken we deze waarde voor de code.
        [Required]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Status")]
        public bool Active { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();

        public ICollection<Review> Reviews { get; } = new List<Review>();
        
        //dit wordt  dus niet gebruikt
        public ICollection<Address> Addresses { get; } = new List<Address>();
        public ICollection<Complaint> Complaints { get; } = new List<Complaint>();
    }
}
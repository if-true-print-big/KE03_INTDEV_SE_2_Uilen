using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int CustomerId { get; set; }

        public enum ComplaintStatus
        {
            Open,
            Afgehandeld
        }

        public ComplaintStatus Status { get; set; }

        public Customer Customer { get; set; } = null!;
    }
}

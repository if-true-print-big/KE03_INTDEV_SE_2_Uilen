using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        private int _rating;
        public int Rating
        {
            get => _rating;
            set => _rating = Math.Clamp(value, 1, 5);
        }
    }
}

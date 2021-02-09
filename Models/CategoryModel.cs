using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Img { get; set; } // Bild på room som är direkt kopplat till den kategorin
        public int NumberOfBeds { get; set; }
        public int Price { get; set; } 

        [NotMapped]
        public Microsoft.AspNetCore.Http.IFormFile uploadedimg { get; set; } // För att lägga till bilder
    }
}

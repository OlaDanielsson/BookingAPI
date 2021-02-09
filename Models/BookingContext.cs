using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Models
{
    public class BookingContext : DbContext
    {
        public  DbSet<BookingModel> BookingModel { get; set;}

        public BookingContext(DbContextOptions options) : base (options)
        {

        }

        
    }
}

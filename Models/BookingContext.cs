using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingAPI.Models;

namespace BookingAPI.Models
{
    public class BookingContext : DbContext
    {
        public  DbSet<BookingModel> BookingModel { get; set;}

        public BookingContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<BookingAPI.Models.RoomModel> RoomModel { get; set; }

        public DbSet<BookingAPI.Models.CategoryModel> CategoryModel { get; set; }       
    }
}

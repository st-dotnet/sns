using Microsoft.EntityFrameworkCore;
using SNSEcom.Domain;
using SNSEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNSEcom.Data
{
    public class SNSContext:DbContext
    {
        public SNSContext(DbContextOptions<SNSContext> options) : base(options) { }
        public DbSet<Products> product { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
    }
}

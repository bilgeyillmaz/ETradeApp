using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ETradeContext: DbContext 
    {
        public DbSet<Product> Products { get; set; } //benim bir productım var onu entity seti olarak, yani tablo gibi products ismi ile kullanacağım. Tablolarda products arar.

    }
}

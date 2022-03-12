using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll() // çalıştırdığım zaman veri tabanındaki tüm ürünleri çekecek bir liste // list of product
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList(); //list of product
            }
        }
        public List<Product> GetByName(string key) 
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p=>p.Name.Contains(key)).ToList();
            }
        }
        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= price).ToList();
            }
        }
        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList();
            }
        }
        public Product GetById(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                // var result = context.Products.FirstOrDefault(p => p.Id == id); // bu id'ye uygun olan ilk kaydı getir, eğer o numarada bir kayıt yoksa null getir.
                var result = context.Products.SingleOrDefault(p => p.Id == id);// bu id ye uygun olan birden fazla sonuç olursa, hata fırlatır.
                return result;
            }
        }
        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //contextsteki products a ekle
                //context.Products.Add(product);  
                var entity = context.Entry(product);
                entity.State = EntityState.Added;
                context.SaveChanges();  // yaptığımız işlemleri veri tabanına yaz diyerek, commit ediyoruz.
            }
        }
        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);    //bu product için context üzerinden üye ol, gönderdiğimiz productı veri tabanındaki product ile eşitliyor. 
                //^^veri tabanındaki o ürünle ilişkilendiriyor. onun id si üzerinden eşitleme yapar, id primary key olduğu için.
                entity.State = EntityState.Modified; //durumunu da güncellediğimi söylüyorum.
                context.SaveChanges();  
            }
        }
        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);   
                entity.State = EntityState.Deleted; 
                context.SaveChanges();
            }
        }

    }
}

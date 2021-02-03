using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable Pattern implementation of C# kullanımı
            //bir class newlendiğinde o bellekte garbage collector onu atar using ile yapılır.
            //Context nesnesi pahalıdır. 
            //using ile NorthWindContext ile işi bittiğinde bellekten atılmasını söylüyoruz.
            //using kullanımı daha performanslı bir yapı kurgulamış oluyoruz.
            //bu using ile yukarıdaki using aynı değildir.

            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);    //veritabanındaki nesneye eşleş
                addedEntity.State = EntityState.Added;      //referansı yakala
                context.SaveChanges();                      //veriyi ekle
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);      //veritabanındaki nesneye eşleş
                deletedEntity.State = EntityState.Deleted;      //referansı yakala
                context.SaveChanges();                          //veriyi ekle
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList(); //producta yerleş ve oradaki tüm datayı listeye çevir. Teranity operatörü ile yazdık
            }           
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);      //veritabanındaki nesneye eşleş
                updatedEntity.State = EntityState.Modified;     //referansı yakala
                context.SaveChanges();                          //veriyi ekle
            }
        }
    }
}

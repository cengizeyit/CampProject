using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable Pattern implementation of C# kullanımı
            //bir class newlendiğinde o bellekte garbage collector onu atar using ile yapılır.
            //Context nesnesi pahalıdır. 
            //using ile NorthWindContext ile işi bittiğinde bellekten atılmasını söylüyoruz.
            //using kullanımı daha performanslı bir yapı kurgulamış oluyoruz.
            //bu using ile yukarıdaki using aynı değildir.

            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);    //veritabanındaki nesneye eşleş
                addedEntity.State = EntityState.Added;      //referansı yakala
                context.SaveChanges();                      //veriyi ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);      //veritabanındaki nesneye eşleş
                deletedEntity.State = EntityState.Deleted;      //referansı yakala
                context.SaveChanges();                          //veriyi ekle
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList(); //producta yerleş ve oradaki tüm datayı listeye çevir. Teranity operatörü ile yazdık
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);      //veritabanındaki nesneye eşleş
                updatedEntity.State = EntityState.Modified;     //referansı yakala
                context.SaveChanges();                          //veriyi ekle
            }
        }
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{

    //Generic constraint
    //Generik kısıtlama yaparak IEntityRepository Type olarak farklı database modellerinden harici gelmesini engelliyoruz.

    //class: demek referans tip olabilir demektir.
    //Referans tipi sadece class verilebilir.

    //IEntity : olabilir veya IEntity implemente eden bir nesne olabilir.
    //vertabanı classlarımızın ortak özelliği IEntity olması nedeniyle tanımlıyoruz. 
    //dolasyısıyla herhangi bir classın tanımlanmasının önüne geçmiş oluyoruz.

    //new : newlenebilir olmalı IEntity newlenemeyeceği için Type olarak IEntity almasını engellemiş olduk.
    public interface IEntityRepository<T> 
        where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

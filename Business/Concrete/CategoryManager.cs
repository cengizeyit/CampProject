using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //bu Business katmanı kime bağımlı veri erişime bağlı 
        //Veri Erişiminde EntityFramework olabilir, NHibernate olabilir, Dapper olabilir
        //biz bu noktada bağımlılığımızı minimize etmek için (ICategoryDal _categoryDal;) yapıyoruz. 
        //bağımlılığımız Constructor injection ile yapıyoruz.
        // _categoryDal seçerek sağ tuşla 

        ICategoryDal _categoryDal;

        // Bu şu demek ben CategoryManager olarak veri erişimi katmanına bağımlıyım
        // ama biraz zayıf bağımlılığım var çünkü ben interface üzerinden yani referans üzerinden bağımlıyım 
        // o yüzden sen data access katmanında istediğin gibi at koşturabilirsin. 
        // yeterki kurallarıma uy diyor
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //İş Kodları buraya yazılacak
            return _categoryDal.GetAll();
        }

        // Select * from Categories where categoryId=3 demek gibi bir anlama geliyor.
        // c = categori için kullandığımız bir kısaltma tanımlaması
        //
        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{

    // SOLID
    // O : Open Closed Principle
    // DTO : Data Transformation Object
    class Program
    {
        static void Main(string[] args)
        {
            //ProductGetAllTest();

            //ProductGetAllByCategoryTest();

            //ProductGetByUnitPriceTest();

            //CategroyGetAllTest();

            //CategoryGetByIdTest();

            ProductGetProductDetailsTest();

        }

        private static void ProductGetProductDetailsTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CategoryGetByIdTest()
        {
            //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            //foreach (var category in categoryManager.GetById(2))
            //{
            //    Console.WriteLine(category.CategoryName);
            //}
        }

        private static void CategroyGetAllTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }


        private static void ProductGetAllTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetAll();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
       }

        private static void ProductGetAllByCategoryTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetAllByCategory(2);

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ProductGetByUnitPriceTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetByUnitPrice(10, 20);

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " " + product.UnitPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}

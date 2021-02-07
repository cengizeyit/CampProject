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

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName + " / " + product.CategoryName);
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

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void ProductGetAllByCategoryTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAllByCategory(2))
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void ProductGetByUnitPriceTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetByUnitPrice(10, 20))
            {
                Console.WriteLine(product.ProductName + " " + product.UnitPrice);
            }
        }
    }
}

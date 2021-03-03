using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    //Extensions methodu yazabilmemiz için o classın statik olması gerekiyor.
    public static class ServiceCollectionExtensions
    {
        //bize bir IServiceCollection dönsün. bizim ASP.NET uygulamamızın kısacısı API mizin 
        //servis bağımlılıklarımızı eklediğimiz yada araya girmesini istediğimiz servisleri 
        //eklediğimiz kolleksiyonların kendisidir.
        //polimorfizm yaparak 
        //IServiceCollection'ı gibi neyi genişletmek istiyorsak bunu this ile veriyoruz. 
        //buradaki this parametre değildir.
        //Modullerdeki eklenen her bir modul için modulü yükle. 
        //birden fazla modulu buraya ekleyebileceğimi gösteriyor.
        //servisleri create ediyoruz. 
        //bu yaptığımız hareket bizim Core katmanı dahil olmak üzere ekleyeceğimiz injectionları yapıya dönüştü.

        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}

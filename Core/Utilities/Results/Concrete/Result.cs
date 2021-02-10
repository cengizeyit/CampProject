using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        //İşlem sonucunu döndürmek istiyoruz ve bir mesaj vermek isteiyorsak burası çalışır.
        //hata mesajlarını iki türlü vermeyi ayarlıyoruz.
        //iki parametreli ve tek parametreli

        //c# dilinde :this(success) demek classın  kendisi demektir yani Result demektir
        //this ile tek parametreli constructoruna success bilgisini yolluyoruz. 
        //Result (sonuç) bilgisini göstermek istediğimizde 
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }

        //İşlem sonucunu döndürmek istiyoruz ancak herhangi bir mesaj vermek istemiyorsak burası çalışır.
        //işlem başarılı ise success'i set etme işini burası yapacak 
        public Result(bool success)
        {
            Success = success;
        }


        public bool Success { get; }

        public string Message { get; }
    }
}

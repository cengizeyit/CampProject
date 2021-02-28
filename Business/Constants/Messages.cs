using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    //new lenmesin diye static veriyoruz
    public static class Messages
    {
        //publicler büyük harflerle yazılır. PascalCase
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün adı geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir Kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Bu isimde Ürün mevcut";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor.";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola Hatası";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Jeton oluşturuldu";
    }
}

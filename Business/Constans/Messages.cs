using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi gerçersiz";
        public static string MaintenanceTime= "Sistem bakımda";
        public static string ProductListed="Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoriden en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists="Bu isimde bir ürün zaten var";
        public static string CategoryLimitExceted= "Kategori limiti aşıldı";
    }
}

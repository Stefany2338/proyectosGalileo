using System;
namespace Test.Models
{
    public class ProductModel
    {
        //Atributos
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int existencia { get; set; }
        public int precio { get; set; }


        //Metodos
        public ProductModel()
        {
        }

    }
}


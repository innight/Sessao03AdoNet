using System;

namespace ClassLibrary1_Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Stock { get; set; }
        public DateTime DateRegist { get; set; }

        // Na nossa BD vão existir produtos,  como por exemplo: Cola-cola,Fanta,Agua etc...
        // vamos ter muitoas bebidas - existiar por cada produto
        // mas alguns produtos sao refrifgentes, outros aguas,oturos vinhos

        //PRODUTO       SUBCATEGORIA       CATEGORIA
        //Cola-Cola     REFRIGENTE          BEBIDA
        //Fanta         REFRIGENTE          BEBIDA       
        //Fanta         AGUA                BEBIDA    


        //[ForeignKey("IdSubcategory")]

        public SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }

    }
}

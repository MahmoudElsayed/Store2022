using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DTO.Guide
{
    public class ProductCategoryDTO
    {

        public int TotalCount { get; set; }
        public int Seq_Id { get; set; }

        public string Product_Category_Code { get; set; }
  
        public string Category_Name { get; set; }
    
        public string Category_Description { get; set; }
        public string Create_Date { get; set; } 
        public string Update_Date { get; set; }


    }
    public class ProductCategoryUpdateDTO
    {

        public int Seq_Id { get; set; }


        public string Category_Name { get; set; }

        public string Category_Description { get; set; }


    }
}

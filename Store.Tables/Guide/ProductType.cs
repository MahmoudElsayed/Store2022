using Store.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Tables
{
    [Table(nameof(ProductType) + "s", Schema = AppConstants.Areas.Guide)]

    public class ProductType:BaseEntity
    {

        [Column(Order = 1, TypeName = "varchar(250)")]
        [Required]
        public string Product_Type_Code { get; set; }
       



        [Column(Order = 3, TypeName = "varchar(250)")]
        [Required]
        [ForeignKey(nameof(ProductCategory))]

        public string Product_Category_Code { get; set; }

      

        [Column(Order = 4, TypeName = "varchar(250)")]
        [Required]
        public string Type_Name { get; set; }
        [Column(Order = 5, TypeName = "varchar(500)")]
        [Required]
        public string Type_Description { get; set; }


        #region Relations
        public virtual ProductCategory ProductCategory { get; set; }
        public ICollection<Product> Products { get; set; }

        #endregion

    }
}

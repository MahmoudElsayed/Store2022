using Store.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Tables
{

    [Table(nameof(Product) + "s", Schema = AppConstants.Areas.Guide)]

    public class Product : BaseEntity
    {


        [Column(Order = 1, TypeName = "varchar(250)")]
        [Required]
        [ForeignKey(nameof(ProductType))]
        public string Product_Type_Code { get; set; }


        [Column(Order = 3, TypeName = "varchar(250)")]
        [Required]
        public string Product_Code { get; set; }

        [Column(Order = 4, TypeName = "varchar(250)")]
        [Required]
        public string Product_Name { get; set; }

        [Column(Order = 5, TypeName = "varchar(500)")]
        [Required]
        public string Product_Description { get; set; }

        #region Relations
        public virtual ProductType ProductType { get; set; }

        #endregion

    }
}

using Store.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Tables
{

    [Table("ProductCategories", Schema = AppConstants.Areas.Guide)]

    public class ProductCategory : BaseEntity
    {
        [Column(Order = 1, TypeName = "varchar(250)")]
        [Required]

        public string Product_Category_Code { get; set; }
        [Column(Order = 3, TypeName = "varchar(250)")]
        [Required]
        public string Category_Name { get; set; }
        [Column(Order = 4, TypeName = "varchar(500)")]
        [Required]
        public string Category_Description { get; set; }

        #region Relations
        public ICollection<ProductType> ProductTypes { get; set; }

        #endregion

    }
}

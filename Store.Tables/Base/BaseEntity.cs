
using Store.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Tables
{
   
    public class BaseEntity
    {

        /// <summary>
        /// The Id Of Table 
        /// uniqueidentifier
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 2)]
        public int Seq_Id { get; set; }


        /// <summary>
        /// Status
        /// </summary>
        [Column(Order = 40, TypeName = "varchar(250)")]
        [Required]
        public string Status { get; set; } = "ACTIVE";


        /// <summary>
        /// Creation Date Of The Item
        /// </summary>
        [Column(Order = 50)]
        [Required]
        public DateTime Create_Date { get; set; } = AppDateTime.Now;



        /// <summary>
        /// Modified Date Of The Item
        /// </summary>
        [Column(Order = 60)]
        public DateTime? Update_Date { get; set; }
        /// <summary>
        /// The Date of Deleted This Item
        /// </summary>
        [Column(Order = 70)]
        public DateTime? Delete_Date { get; set; }
        
        /// <summary>
        /// Row is deleted or not
        /// </summary>
        [Column(Order = 80)]
        [Required]
        public bool IsDeleted { get; set; } = false;




 


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Models
{

    [Table("purchase")]
    public class Purchase
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Purchase Date")]
        [Required]
        public DateTime purchaseDate { get; set; }

        [Display(Name ="Quantity")]
        [Required]
        public int quantity { get; set; }

        [Display(Name = "Item")]
        [Required]
        public int itemId { get; set; }

        [ForeignKey("itemId")]
        public virtual Item item { get; set; }
    }
}
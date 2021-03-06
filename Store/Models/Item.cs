using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(225)]
        public string name { get; set; }

        public List<Purchase> purchases { get ; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? quantity 
        {
            get {
                    if (purchases != null){
                        return purchases.Sum(a => a.quantity);
                    }
                    else {
                        return 0;
                    }
                }
             set { } 
        }
    }
}
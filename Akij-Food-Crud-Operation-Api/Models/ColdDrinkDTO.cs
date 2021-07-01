using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Akij_Food_Crud_Operation_Api.Models
{
    public class CreateColdDrinkDTO
    {
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "Cold Drink Name Is Too Long")]
        public string ColdDrinksName { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
    }
    public class ColdDrinkDTO : CreateColdDrinkDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColdDrinksId { get; set; }
    }
}

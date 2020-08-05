using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoveragePlanApi.Models
{
    public class Contracts
    {
        [Key]
        public int customerId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string customerName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string customerAddress { get; set; }

        [Column(TypeName = "nvarchar(1)")]
        public string customerGender { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string customerCountry { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime customerDateofBirth { get; set; } 

        [Column(TypeName = "datetime")]
        public DateTime saleDate { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string coveragePlan { get; set; }
        [Column(TypeName = "float")]

        public float netPrice { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoveragePlanApi.Models
{
    public class RateChart
    {
        [Key]
        public int rateChartId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string coveragePlan { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string customerGender { get; set; }

        [Column(TypeName = "nvarchar(4)")]
        public string CustomerAge { get; set; }
        [Column(TypeName = "float")]

        public float netPrice { get; set; }
    }
}

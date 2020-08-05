using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoveragePlanApi.Models
{
    public class CoveragePlan
    {
        [Key]
        public int coveragePlanId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string coveragePlan { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EligibilityDateFrom { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EligibilityDateTo { get; set; }
        [Column(TypeName = "nvarchar(3)")]
        public string EligibilityCountry { get; set; }
    }
}

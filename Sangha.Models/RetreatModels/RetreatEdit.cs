using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.RetreatModels
{
    public class RetreatEdit
    {
        [DisplayName("ID")]
        public int RetreatId { get; set; }

        [DisplayName("Name")]
        public string RetreatName { get; set; }

        [DataType(DataType.Date, ErrorMessage = ("Please enter a valid date"))]
        [DisplayName("Date")]
        public DateTime RetreatDate { get; set; }

        [DisplayName("Retreat Length (days)")]
        public int RetreatLength { get; set; }
        public string Description { get; set; }
    }
}

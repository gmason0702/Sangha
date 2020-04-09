using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.RetreatModels
{
    public class RetreatCreate
    {
        [DisplayName("Retreat Name")]
        public string RetreatName { get; set; }

        [DisplayName("Retreat Date")]
        [DataType(DataType.Date, ErrorMessage = ("Please enter a valid date"))]
        public DateTime RetreatDate { get; set; }

        [DisplayName("Retreat Length")]
        public int RetreatLength { get; set; }
        public string Description { get; set; }

        public ICollection<Teacher> Teacher { get; set; }

        [DisplayName("ID")]
        public int CenterId { get; set; }

        [DisplayName("Name")]
        public string CenterName { get; set; }
        public Center Center { get; set; }
    }
}

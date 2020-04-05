using Sangha.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.RetreatModels
{
    public class RetreatCreate
    {
        public string RetreatName { get; set; }

        public DateTime RetreatDate { get; set; }
        public int RetreatLength { get; set; }
        public string Description { get; set; }

        public ICollection<Teacher> Teacher { get; set; }
        public int CenterId { get; set; }
        public string CenterName { get; set; }
        public Center Center { get; set; }
    }
}

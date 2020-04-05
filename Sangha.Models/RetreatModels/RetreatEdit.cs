using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.RetreatModels
{
    public class RetreatEdit
    {
        public int RetreatId { get; set; }
        public string RetreatName { get; set; }
        public DateTime RetreatDate { get; set; }
        public int RetreatLength { get; set; }
        public string Description { get; set; }

    }
}

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
        public DateTimeOffset RetreatDate { get; set; }
        public int RetreatLength { get; set; }
        public ICollection<Teacher> Teacher { get; set; }
        public Center Center { get; set; }
    }
}

using Sangha.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.TalkModels
{
    public class TalkListItem
    {
        public int TalkId { get; set; }
        public string Name { get; set; }
        public int? TeacherId { get; set; }
        public string Teacher { get; set; }
        public string Topic { get; set; }
        public TimeSpan TalkLength { get; set; }
        public int? RetreatId { get; set; }
    }
}

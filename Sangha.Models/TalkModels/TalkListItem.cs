using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.TalkModels
{
    public class TalkListItem
    {
        [DisplayName("ID")]
        public int TalkId { get; set; }
        public string Name { get; set; }
        public int? TeacherId { get; set; }
        public string Teacher { get; set; }
        public string Topic { get; set; }
        public TimeSpan TalkLength { get; set; }
        public int? RetreatId { get; set; }
        public bool IsGuided { get; set; }
    }
}

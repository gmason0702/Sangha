using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.TalkModels
{
    public class TalkCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Topic { get; set; }
        public int? TeacherId { get; set; }

        [DisplayName("Teacher")]
        public string TeacherName { get; set; }
        public TimeSpan TalkLength { get; set; }
        public DateTime TalkDate { get; set; }
        public bool IsGuided { get; set; }
        public int? RetreatId { get; set; }
        public int? CenterId { get; set; }
    }
}

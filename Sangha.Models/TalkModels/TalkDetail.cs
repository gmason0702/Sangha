using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.TalkModels
{
    public class TalkDetail
    {
        [DisplayName("Talk ID")]
        public int TalkId { get; set; }

        [DisplayName("Talk Name")]
        public string Name { get; set; }

        [DisplayName("Teacher ID")]
        public int? TeacherId { get; set; }

        [DisplayName("Teacher")]
        public string TeacherName { get; set; }

        [DisplayName("Retreat ID")]
        public int? RetreatId { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }

        [DisplayName("Talk Length")]
        public TimeSpan TalkLength { get; set; }

        [UIHint("ADateTime")]
        [DisplayName("Talk Date")]
        [DataType(DataType.Date)]
        public DateTime TalkDate { get; set; }

        [DisplayName("Guided?")]
        public bool IsGuided { get; set; }

        [DisplayName("Favorite?")]
        public bool IsStarred { get; set; }

        [DisplayName("Listen")]
        public string TalkLink { get; set; }
        

    }
}

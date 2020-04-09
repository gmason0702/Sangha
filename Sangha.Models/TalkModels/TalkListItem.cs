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
    public class TalkListItem
    {
        [DisplayName("ID")]
        public int TalkId { get; set; }

        [DisplayName("Talk Name")]
        public string Name { get; set; }
        public int? TeacherId { get; set; }

        [DisplayName("Teacher")]
        public string TeacherName { get; set; }
        public string Topic { get; set; }
        public TimeSpan TalkLength { get; set; }

        [DisplayName("Talk Date")]
        public DateTime TalkDate { get; set; }
        public int? RetreatId { get; set; }

        [UIHint("Guided")]
        public bool IsGuided { get; set; }
        
        [UIHint("Starred")]
        [DisplayName("Favorite")]
        public bool IsStarred { get; set; }

        [DisplayName("Listen")]
        public string TalkLink { get; set; }
        public int TeacherLinkId { get; set; }
        public int TalkLinkId { get; set; }
    }
}

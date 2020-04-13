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
    public class TalkCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Topic { get; set; }
        [DisplayName("Teacher ID")]
        public int? TeacherId { get; set; }

        [DisplayName("Teacher")]
        public string TeacherName { get; set; }

        [DisplayName("Talk Length")]
        public TimeSpan TalkLength { get; set; }

        [UIHint("ADateTime")]
        [DisplayName("Talk Date")]
        [DataType(DataType.Date, ErrorMessage = ("Please enter a valid date"))]
        public DateTime TalkDate { get; set; }

        [DisplayName("Guided?")]
        public bool IsGuided { get; set; }
        public string TalkLink { get; set; }

        [DisplayName("Dharmaseed Teacher ID")]
        public int TeacherLinkId { get; set; }

        [DisplayName("Dharmaseed Talk ID")]
        public int TalkLinkId { get; set; }

        [DisplayName("Retreat ID")]
        public int? RetreatId { get; set; }

        [DisplayName("Center ID")]
        public int? CenterId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.TalkModels
{
    public class TalkEdit
    {
        [DisplayName("ID")]
        public int TalkId { get; set; }
        public string Name { get; set; }

        [DisplayName("Teacher ID")]
        public int? TeacherId { get; set; }

        [DisplayName("Teacher")]
        public string TeacherName { get; set; }
        public string Topic { get; set; }

        [DisplayName("Talk Length")]
        public TimeSpan TalkLength { get; set; }

        [DisplayName("Talk Date")]
        [DataType(DataType.Date, ErrorMessage = ("Please enter a valid date"))]
        public DateTime TalkDate { get; set; }

        [DisplayName("Guided?")]
        public bool IsGuided { get; set; }

        [DisplayName("Favorite?")]
        public bool IsStarred { get; set; }
    }
}

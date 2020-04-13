using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Data
{
    public class Talk
    {
        [Key]
        public int TalkId { get; set; }
        //public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Topic { get; set; }
        public bool IsGuided { get; set; }
        public TimeSpan TalkLength { get; set; }

        [DataType(DataType.Date)]
        public DateTime TalkDate { get; set; }

        [DefaultValue(false)]
        [DisplayName("Favorite")]
        public bool IsStarred { get; set; }

        [DisplayName("Listen")]
        public string TalkLink { get; set; }
        public int TeacherLinkId { get; set; }
        public int TalkLinkId { get; set; }


        [ForeignKey(nameof(Teachers))]
        public int? TeacherId { get; set; }
        public virtual Teacher Teachers { get; set; }


        [ForeignKey(nameof(Retreats))]
        public int? RetreatId { get; set; }
        public virtual Retreat Retreats { get; set; }


        [ForeignKey(nameof(Centers))]
        public int? CenterId { get; set; }
        public virtual Center Centers { get; set; }
    }
}

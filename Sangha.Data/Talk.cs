﻿using System;
using System.Collections.Generic;
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
        public DateTime TalkDate { get; set; }


        [ForeignKey(nameof(Teacher))]
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [ForeignKey(nameof(Retreat))]
        public int? RetreatId { get; set; }
        public virtual Retreat Retreat { get; set; }

        // If Talk is at a Retreat, CenterId should be null; the CenterId will be provided via the CenterId property of the Retreat that the talk was given on. You could put a conditional in the setter for if RetreatID != null then CenterId = null.
        [ForeignKey(nameof(Center))]
        public int? CenterId { get; set; }
        public virtual Center Center { get; set; }
    }
}

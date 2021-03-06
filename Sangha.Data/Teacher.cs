﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Data
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [DisplayName("About")]
        [MaxLength(1000, ErrorMessage = "Please enter a shorter bio")]
        public string Bio { get; set; }

        //[ForeignKey(nameof(Talks))]
        //public int? TalkId { get; set; }
        public virtual ICollection<Talk> Talks { get; set; }

        //public virtual ICollection<Retreat> Retreats { get; set; } = new List<Retreat>();

        //[ForeignKey(nameof(Retreats))]
        //public int? RetreatId { get; set; }
      //  public virtual ICollection<Retreat> Retreats { get; set; }

        //[ForeignKey(nameof(Centers))]
        //public int? CenterId { get; set; }
       // public virtual ICollection<Center> Centers { get; set; }
    }
}

﻿using Sangha.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.TeacherModels
{
    public class TeacherListItem
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<Talk> Talks { get; set; }
        public ICollection<Retreat> Retreats { get; set; }
        public ICollection<Center> Centers { get; set; }
    }
}

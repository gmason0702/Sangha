using Sangha.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.TeacherModels
{
    public class TeacherListItem
    {
        [DisplayName("Teacher Id")]
        public int TeacherId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [DisplayName("About")]
        [MaxLength(1000, ErrorMessage = "Please enter a shorter bio")]
        public string Bio { get; set; }
        public ICollection<Talk> Talks { get; set; }
        public ICollection<Retreat> Retreats { get; set; }
        public ICollection<Center> Centers { get; set; }
    }
}

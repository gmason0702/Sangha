using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sangha.Models.TeacherModels
{
    public class TeacherEdit
    {
        [Display(Name = "ID")]
        public int TeacherId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [DisplayName("About")]
        [MaxLength(1000, ErrorMessage = "Please enter a shorter bio")]
        public string Bio { get; set; }
    }
}

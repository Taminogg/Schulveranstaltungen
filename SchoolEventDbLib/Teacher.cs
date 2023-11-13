using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEventDbLib
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required] public string Firstname { get; set; } = null!;
        [Required] public string Lastname { get; set; } = null!;
        [Required] public string Email { get; set; } = null!;
    }
}

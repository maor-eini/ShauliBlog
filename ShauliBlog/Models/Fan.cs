using System;
using System.ComponentModel.DataAnnotations;

namespace ShauliBlog.Models
{
    public class Fan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        [Required]
        [StringLength(256)]
        public string LastName { get; set; }
        [Required]
        [StringLength(1, MinimumLength = 1)]
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int SeniorityInYears { get; set; }
    }


}
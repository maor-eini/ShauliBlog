﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShauliBlog.ViewModels
{
    public class FanFormViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public int SeniorityInYears { get; set; }
        public IEnumerable<SelectListItem> GenderList { get; set; }

        public DateTime GetDateTimeOfBirth()
        {
            return DateTime.Parse(DateOfBirth);
        }

    }
}
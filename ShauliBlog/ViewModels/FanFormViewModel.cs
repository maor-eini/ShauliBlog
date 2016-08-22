using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShauliBlog.ViewModels
{
    public class FanFormViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public int SeniorityInYears { get; set; }
        public IEnumerable<SelectListItem> GenderList { get; set; }

        public DateTime DateTimeOfBirth
        {
            get
            {
                return DateTime.Parse(DateOfBirth);
            }
        }

    }
}
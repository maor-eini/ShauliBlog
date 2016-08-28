using ShauliBlog.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ShauliBlog.ViewModels
{
    public class FanFormViewModel
    {
        [Required]
        public int Id { get; set; }

        public string Heading { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Seniority in Years")]
        public int SeniorityInYears { get; set; }

        public IEnumerable<SelectListItem> GenderList { get; set; }

        public string Action {
            get
            {
                Expression<Func<FanClubController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<FanClubController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public DateTime GetDateTimeOfBirth()
        {
            return DateTime.ParseExact(DateOfBirth ,"dd/mm/yyyy" , new CultureInfo("it-IT"));
        }

    }
}
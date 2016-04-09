using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TPP_Project.Models.entities;

namespace TPP_Project.Models.ViewModels
{
    public class EditUserViewModel
    {

        [Required]
        public string FistName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Organization { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public string Id { get; set; }


        public EditUserViewModel() { }
        public EditUserViewModel(ApplicationUser user)
        {
            this.FistName = user.FistName;
            this.LastName = user.LastName;
            this.Organization = user.Organization;
            this.City = user.City;
            this.Country = user.Country;
            this.Role = user.RoleName;
            this.Id = user.Id;
        }
    }
}
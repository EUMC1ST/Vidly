using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name="Subscribed to Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        //This is s navigation property to use membershiptype object
        public MembershipType MembershipType { get; set; }

        //This is a foreignkey used when don´t need the entire membeship object
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [DataType(DataType.Date)]
        [Min18YearsIfAMember]
        public Nullable<DateTime> BirthDay { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Hosting.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        private string fullName;

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Full Name")]
        public string Fullname
        {
            get
            {
                if (this.fullName.IsNullEmptyOrWhiteSpace())
                {

                    if (this.FirstName.IsNullEmptyOrWhiteSpace()
                        && this.Surname.IsNullEmptyOrWhiteSpace())
                        this.fullName = this.UserName;
                    this.fullName = string.Format("{0}, {1}", this.Surname, this.FirstName);
                }
                return this.fullName;
            }
        }

        [Required]
        public string Email { get; set; }
    }
}

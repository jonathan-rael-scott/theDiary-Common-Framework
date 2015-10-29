using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETMS.Models
{
    public class CompanyNews
    {
        #region Constructors
        public CompanyNews()
        {
        }
        #endregion

        #region Public Properties
        [Key]
        public int NewsId { get; set; }

        [Display(Name = "Heading")]
        [Required]
        public string Heading { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd ddd}")]
        public DateTime Date { get; set; }

        [Required]
        public string Content { get; set; }
        #endregion
    }
}
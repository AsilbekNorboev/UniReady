using System;
using System.ComponentModel.DataAnnotations;

//TODO: Update this namespace to match your project name
namespace UniReady.Models
{
    public class Posting
    {
        //Scalar properties

        //This this the primary key
        //By naming this ClassNameID, EF automatically sets this
        //as the primary key
        public Int32 PostingID { get; set; }

        [Display(Name = "Unique Identifier")]
        public String UniqueIdentifier { get; set; }

        public String Title { get; set; }

        public String Author { get; set; }

        public Int32 Views { get; set; }

        [Display(Name = "Posted Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime PostedDate { get; set; }

        [StringLength(3000)]
        public String Summary { get; set; }

        public String Article { get; set; }


        [Display(Name = "Minimum Salary")]
        [DisplayFormat(DataFormatString = "{0:c0}")]
        public Decimal MinimumSalary { get; set; }


    }
}

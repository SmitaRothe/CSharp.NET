using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalQuizAddPersonData
{
    [Table("Passport")]
    public class Passport
    {
        //add the columns
        [Key]
        [ForeignKey("Person")]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public string PassportNo { get; set; }
        public byte[] Photo { get; set; }


        //Single Field- always eagerly loaded
        public virtual Person Person { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Name},{PassportNo},{Photo}";
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalQuizAddPersonData
{
    [Table("Person")]
    public class Person
    {
        //add the columns
        [Key]
        public int Id{ get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
        

        //Single Field- always eagerly loaded
        public virtual Passport Passport { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name},{Age}";
        }

    }
}

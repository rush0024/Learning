using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Models
{
    public class LearningPractise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Temperature { get; set; }
        public DateTime DateTime { get; set; }
    }
}

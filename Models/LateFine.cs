using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssignmentT1809ELateFine.Models
{
    public class LateFine
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Roll Number")]
        public string RollNumber { get; set; }
        [Display(Name = "Discipline Types")]
        public DisciplineTypes DisciplineType { get; set; }
        [Display(Name = "Discipline Amount")]
        public double DisciplineAmount { get; set; }
        [Display(Name = "Submit Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SubmitTime { get; set; }
    }

    public enum DisciplineTypes
    {
        PushUps, Fine
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.QuestionModels
{
    public enum Subject {
        Bangla,English,Math,Biology,Physics,
        SocialScience,Chemestry,PhysicalExercise,Ict
    }
    public class Question
    {
        [Key]
        public int Sl { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public Subject Subject { get; set; }

        [Required]
        public string Q { get; set; }
        [Required]
        public string A { get; set; }
        [Required]
        public string B { get; set; }
        [Required]
        public string C { get; set; }
        [Required]
        public string D { get; set; }
        [Required]
        public string Answer { get; set; }

    }
}

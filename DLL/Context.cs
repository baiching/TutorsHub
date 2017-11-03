﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Entity.QuestionModels;
using Entity.UserModels;

namespace DLL
{
    internal class Context:DbContext
    {
        public  Context():base("Name=ATP2")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Executive> Executives { get; set; }
        public DbSet<Question> QuestionPapers { get; set; }


    }
}

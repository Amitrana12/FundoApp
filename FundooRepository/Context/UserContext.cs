using FundooModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<RegisterModel> RegisterModels {   get;     set;     }

        public DbSet<NotesModel> Note_model { get; set; }

        public DbSet<CollaboratorModel> Collaborator { get; set; }
        
        /// <summary>
        /// Gets or sets the lable models.
        /// </summary>
        /// <value>
        /// The lable models.
        /// </value>
        public DbSet<LableModel> Lable_Models { get; set; }
    }
}

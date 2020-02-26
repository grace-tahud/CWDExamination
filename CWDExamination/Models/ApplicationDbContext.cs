using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWDExamination.Models
{
    public class ApplicationDbContext:DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = 1,
                Title= "POST",
                TextNote = "Create API Method"

            }, new Note
            {
                Id = 2,
                Title = "GET",
                TextNote= "Retrieve API Method",
            });

            modelBuilder.Entity<TodoItem>().HasData(new TodoItem
            {
                Id=1,
                Name="Crud Operation",
                IsComplete=false
            }, new TodoItem
            {
                Id=2,
                Name="Restful API",
                IsComplete= true
            }
                );
        }
    }
}

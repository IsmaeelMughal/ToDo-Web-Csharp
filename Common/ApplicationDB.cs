using Common.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Common
{
    public class ApplicationDB : DbContext
    {

        public ApplicationDB() : base("name=connectionString")
        {
            Database.SetInitializer<ApplicationDB>(
                new DropCreateDatabaseIfModelChanges<ApplicationDB>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoTasks> Tasks { get; set; }
    }
}

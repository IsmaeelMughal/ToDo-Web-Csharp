using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Common.Models;
using System.Data.Entity;

namespace DAL
{
    public class DBHelper
    {
        public bool AddUser(User user)
        {
            using (ApplicationDB db = new ApplicationDB())
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    return false;
                }
            }
        }

        public User GetUser(String email, String pass)
        {
            using (ApplicationDB db = new ApplicationDB())
            {
                try
                {
                    User usr = db.Users.FirstOrDefault(t => t.Email == email && t.Password == pass);
                    return usr;
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    return null;
                }
            }
        }

        public List<User> FetchAllUsers()
        {
            using (ApplicationDB db = new ApplicationDB())
            {
                try
                {
                    var usrs = db.Users.ToList();
                    return usrs;
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    return null;
                }
            }
        }

        public List<TodoTasks> FetchAllTodosOfUser(String v)
        {
            using (ApplicationDB db = new ApplicationDB())
            {
                try
                {
                    var usrs = db.Tasks.Where(t => t.UserEmail == v).ToList();
                    return usrs;
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    return null;
                }
            }
        }

        public List<TodoTasks> FetchAllTodos()
        {
            using (ApplicationDB db = new ApplicationDB())
            {
                try
                {
                    var usrs = db.Tasks.ToList();
                    return usrs;
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    return null;
                }
            }
        }

        public bool AddTaskForUser(TodoTasks task)
        {
            using (ApplicationDB db = new ApplicationDB())
            {
                try
                {
                    db.Tasks.Add(task);
                    db.SaveChanges();
                    return true;
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    return false;
                }
            }
        }

        public bool UpdateTaskForUser(TodoTasks task)
        {
            using (ApplicationDB db = new ApplicationDB())
            {
                try
                {
                    var ta = db.Tasks.First(t => t.Title == task.Title && t.UserEmail == task.UserEmail);
                    ta.Description = task.Description;
                    db.SaveChanges();
                    return true;
                }
                catch (System.InvalidOperationException)
                {
                    return false;
                }
            }
        }

        public bool DeleteTaskForUser(TodoTasks task)
        {
            using (ApplicationDB db = new ApplicationDB())
            {
                try
                {
                    var ta = db.Tasks.SingleOrDefault(t => t.Title == task.Title && t.UserEmail == task.UserEmail);
                    if (ta != null)
                    {
                        db.Tasks.Remove(ta);
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (System.InvalidOperationException)
                {
                    return false;
                }
            }
        }

    }
}

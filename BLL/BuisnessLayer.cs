using Common.Models;
using DAL;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BusinessLayer
    {
        public bool AddUser(String nickname, String email, String password)
        {
            User user = new User();
            user.Nickname = nickname;
            user.Email = email;
            user.Password = password;

            DBHelper dBHelper = new DBHelper();

            if (dBHelper.AddUser(user))
            {
                return true;
            }
            return false;
        }

        public User IsUserExist(String email, String password)
        {
            DBHelper dBHelper = new DBHelper();

            User u = dBHelper.GetUser(email, password);
            if (u == null)
            {
                return null;
            }
            return u;
        }

        public List<User> GetAllUsers()
        {
            DBHelper dBHelper = new DBHelper();

            var u = dBHelper.FetchAllUsers();
            if (u == null)
            {
                return null;
            }
            return u;
        }

        public List<TodoTasks> GetAlltodosOfUser(String v)
        {
            DBHelper dBHelper = new DBHelper();

            var u = dBHelper.FetchAllTodosOfUser(v);
            if (u == null)
            {
                return null;
            }
            return u;
        }

        public List<TodoTasks> GetAllTodos()
        {
            DBHelper dBHelper = new DBHelper();

            var u = dBHelper.FetchAllTodos();
            if (u == null)
            {
                return null;
            }
            return u;
        }

        public bool AddTaskForUser(String title, String description, String email)
        {
            TodoTasks task = new TodoTasks();
            task.Title = title;
            task.Description = description;
            task.UserEmail = email;

            DBHelper dBHelper = new DBHelper();

            if (dBHelper.AddTaskForUser(task))
            {
                return true;
            }
            return false;
        }

        public bool UpdateTaskForUser(String title, String description, String email)
        {
            TodoTasks task = new TodoTasks();
            task.Title = title;
            task.Description = description;
            task.UserEmail = email;

            DBHelper dBHelper = new DBHelper();

            if (dBHelper.UpdateTaskForUser(task))
            {
                return true;
            }
            return false;
        }

        public bool DeleteTaskForUser(String title, String description, String email)
        {
            TodoTasks task = new TodoTasks();
            task.Title = title;
            task.Description = description;
            task.UserEmail = email;

            DBHelper dBHelper = new DBHelper();

            if (dBHelper.DeleteTaskForUser(task))
            {
                return true;
            }
            return false;
        }
    }
}

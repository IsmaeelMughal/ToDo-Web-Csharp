using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }

        public List<TodoTasks> TodoTasks { get; set; }
    }
}

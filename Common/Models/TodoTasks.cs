using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class TodoTasks
    {
        [Key]   [Column(Order = 1)]
        public string Title { get; set; }

        public string Description { get; set; }


        [Key]   [Column(Order = 2)]     [ForeignKey("User")]
        public string UserEmail { get; set; }
        public User User { get; set; }

    }
}

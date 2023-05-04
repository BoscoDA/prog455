using Service.Decorators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class AuthModel
    {
        [StringSize(3)]
        [Required]
        public string Username { get; set; }

        [StringSize(9)]
        [Required]
        [Password]
        public string Password { get; set; }
    }
}

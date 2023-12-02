using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Domain.Entities
{
    /// <summary>
    /// class is use for member data manipulation
    /// </summary>
    public class MemberInfo
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterClone.DAL
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [StringLength(10)]
        [Required]
        public string UserId { get; set; }

        [StringLength(15)]
        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "Varchar")]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinedDate { get; set; }


        public Int16 Active { get; set; }

        public IEnumerable<Tweet> Tweets { get; set; }
    }
}

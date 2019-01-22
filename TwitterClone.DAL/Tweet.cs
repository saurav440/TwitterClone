using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterClone.DAL
{
    [Table("Tweet")]
    public class Tweet
    {
        [Key]
        public int TweetId { get; set; }

        [Required]
        [StringLength(140)]
        [Column(TypeName = "Varchar")]
        public string Message { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(10)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public Person Person { get; set; }
    }
}

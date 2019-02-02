using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.UI.Models
{
    public class Tweet
    {
        public int TweetId { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public string CreatedDate { get; set; }
        public bool IsSelf { get; set; }
    }
}
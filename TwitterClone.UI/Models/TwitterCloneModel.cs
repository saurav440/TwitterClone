using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.UI.Models
{
    public class TwitterCloneModel
    {
        public string UserName { get; set; }
        public int Tweets { get; set; }
        public int Followings { get; set; }
        public int Followers { get; set; }

        public List<Tweet> TweetList { get; set; }
    }
}
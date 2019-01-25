using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.DAL;

namespace TwitterClone.BAL
{
    public class TwitterCloneBO
    {
       // private readonly MyContext _context;

        //public TwitterCloneBO(MyContext context)
        //{
        //    _context = context;
        //}

        public bool IsUserExist(string userid)
        {
            using (TwitterCloneDBEntities _context = new TwitterCloneDBEntities())
            {
                var result = _context.Persons.Find(userid);

                if (result != null)
                    return true;
                else
                    return false;
            }
        }
        public bool ValidatedUser(string UserId, string Password)
        {
            using (TwitterCloneDBEntities _context = new TwitterCloneDBEntities())
            {
                var result = from user in _context.Persons
                             where user.User_id == UserId && user.Password == Password
                             select user;
                if (result.Count() > 0)
                    return true;
                else
                    return false;
            }           
        }

        public bool CreateAccount(Person item)
        {
            try
            {
                using (TwitterCloneDBEntities _context = new TwitterCloneDBEntities())
                {
                    _context.Persons.Add(item);
                    _context.SaveChanges();
                    return true;
                }  
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Tweet> GetAllTweet(string id)
        {
            using (TwitterCloneDBEntities _context = new TwitterCloneDBEntities())
            {
                var tweetList = from item in _context.Tweets
                                where item.user_id == id
                                select item;

                return tweetList;
            } 
        }
    }
}

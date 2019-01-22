using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TwitterClone.DAL
{
    public class MyContext :DbContext
    {
        public MyContext() : base("name=TCDBConn")
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
    }
}

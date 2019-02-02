using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.BAL;
using TwitterClone.UI.Models;
//using TwitterClone.DAL;

namespace TwitterClone.UI.Controllers
{
    [HandleError]
    [RoutePrefix("User")]
    public class UserController : Controller
    {
        TwitterCloneBO obj = new TwitterCloneBO();
       
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult SaveMessage(Tweet item)
        {
            var tweetObj = new TwitterClone.DAL.Tweet()
            {
                user_id = item.UserId,
                message = item.Message,
                tweet_id = item.TweetId,
                created = DateTime.Now
            };

             obj.SaveTweets(tweetObj);
            return Json(new { Userid = item.UserId }, JsonRequestBehavior.AllowGet);
        }

        [ActionName("Dashboard")]
        [Route("Dashboard/{id}")]
        public ActionResult TwitterDashboard(string id)
        {
            TwitterCloneModel viewModel = new TwitterCloneModel();
            if(Session["UserId"] != null)
            {
                var userDetails = obj.GetUserDetails(id);
                var tweetList = BuildTweetList(id);

                Session["UserName"] = userDetails.FullName;

                viewModel.UserName = userDetails.User_id;
                viewModel.Tweets = tweetList.Count;
                viewModel.Followings = obj.GetAllFollowing(id).Count;
                viewModel.Followers = obj.GetAllFollowers(id).Count;
                viewModel.TweetList = tweetList;

                return View("Dashboard", viewModel);
            }
            else
            {
                Exception ex = new Exception("Invalid Session.");
                HandleErrorInfo obj = new HandleErrorInfo(ex, "Admin", "TwitterDashboard");
                Logger.WriteLog(obj);
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public JsonResult DeleteTweet(int tweetId)
        {
            bool success = false;
            try
            {
                obj.DeleteTweet(tweetId);
                success = true;
            }
            catch(Exception ex)
            {
                HandleErrorInfo obj = new HandleErrorInfo(ex, "User", "DeleteTweet");
                Logger.WriteLog(obj);
            }
            
            return Json(new { Success = success }, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult Search(string name)
        {
            List<PersonDetail> searchList = new List<PersonDetail>();

            var userid = Convert.ToString(Session["UserId"]); 

            var result =  obj.GetSearchList(name);
            var followingList = obj.GetAllFollowing(userid);

            foreach (var item in result)
            {
                PersonDetail obj = new PersonDetail();
                obj.Name = item.FullName;
                obj.UserName = item.User_id;
                obj.IsFollowing = followingList.Count > 0 ? 
                                  followingList.Any(x =>x.Following_id == item.User_id) : false ;

                searchList.Add(obj);
            }
            return Json(searchList, JsonRequestBehavior.AllowGet);
            
        }
        [Route("Follow/{followingId}")]
        public ActionResult Follow(string followingId)
        {
            var userid = Convert.ToString(Session["UserId"]); 

            obj.FollowUser(userid, followingId);
            return RedirectToAction("Dashboard", new { id = userid });
        }

        [Route("UnFollow/{followingId}")]
        public ActionResult UnFollow(string followingId)
        {
            var userid = Convert.ToString(Session["UserId"]); ;

            obj.UnFollowUser(userid, followingId);
            return RedirectToAction("Dashboard", new { id = userid });
        }

        private List<Tweet> BuildTweetList(string useid)
        {
            List<Tweet> tweetList = new List<Tweet>();

            var response = obj.GetAllTweet(useid).ToList();
            
            foreach (var item in response)
            {
                Tweet tweetObj = new Tweet();

                tweetObj.UserId = item.user_id;
                tweetObj.Message = item.message;
                tweetObj.TweetId = item.tweet_id;

                if(item.created.ToString("MM/dd/yyyy") == DateTime.Now.ToString("MM/dd/yyyy"))
                {
                    tweetObj.CreatedDate = item.created.ToString("hh:mm tt");
                }
                else
                {
                    tweetObj.CreatedDate = item.created.ToString("dd MMM yyyy");
                }

                tweetList.Add(tweetObj);
            }

            return tweetList;
        }
    }
}
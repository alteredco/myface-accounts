using Microsoft.AspNetCore.Mvc;
using MyFace.Helpers;
using MyFace.Models.Request;
using MyFace.Models.Response;
using MyFace.Repositories;

namespace MyFace.Controllers
{
    [Route("feed")]
    public class FeedController
    {
        private readonly IPostsRepo _posts;
        private readonly IBasicAuthenticateHelper _basicAuthenticateHelper;

        public FeedController(IPostsRepo posts, IBasicAuthenticateHelper basicAuthenticateHelper)
        {
            _posts = posts;
            _basicAuthenticateHelper = basicAuthenticateHelper;
        }
        
        [HttpGet("")]
        public ActionResult<FeedModel> GetFeed([FromQuery] FeedSearchRequest searchRequest)
        {
            /*if (!_basicAuthenticateHelper.HandleAuthenticate(Request))
            {
                return Unauthorized();
            }*/
            
            var posts = _posts.SearchFeed(searchRequest);
            var postCount = _posts.Count(searchRequest);
            return FeedModel.Create(searchRequest, posts, postCount);
        }
    }
}
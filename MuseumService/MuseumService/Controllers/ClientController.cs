using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Linq;
using MuseumService.Models;

namespace MuseumService.Controllers
{
    /// <summary>
    /// 客户端使用接口，主要是统计功能
    /// </summary>
    [Route("client")]
    public class ClientController : ApiController
    {

        /// <summary>
        /// 获得所有用户3
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> GetDailyUser()
        {
            var db = new ModelContext();
            var ret = db.Users.AsEnumerable();
            //var ret = db.Users.ToLookup<User, int>(u => (u.SubscribeTime == null ? new DateTime(0) : u.SubscribeTime.Value).DayOfYear);
            return ret;
        }

        /// <summary>
        /// 统计每个地点的浏览时长
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Place> GetPlace()
        {
            var db = new ModelContext();

            var retList = db.Places.ToList();

            var placeLookUp = db.Recodes.Include("Place").ToLookup<Recode, int>(r => r.PlaceId);
            foreach (var p in placeLookUp)
            {
                var place = retList.FirstOrDefault(x => x.Id == p.Key);
                if (place == null)
                {
                    continue;
                }
                place.WatchTimes = p.Count();
            }
            return retList;
        }

        /// <summary>
        /// 获得所有的评论
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Discuss> GetDiscuss()
        {
            var db = new ModelContext();
            var retList = db.Discusses.Include("User");

            return retList;
        }
    }
}
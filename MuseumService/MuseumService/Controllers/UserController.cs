using MuseumService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MuseumService.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        /// <summary>
        /// 设置用户头衔
        /// </summary>
        /// <param name="openid">用户的OpenId</param>
        /// <param name="level">等级</param>
        /// <returns>请求正常返回1</returns>
        public int Get(string openid, int level)
        {
            var db = new ModelContext();
            var user = db.Users.FirstOrDefault(u => u.OpenId == openid);
            if (user == null)
            {
                return 0;
            }
            user.Level = level;
            return db.SaveChanges();
        }

        /// <summary>
        /// 获得用户的详细信息
        /// </summary>
        /// <param name="openId">用户的OpenId</param>
        /// <returns>正常返回用户模型。若未找到用户OpenId则返回空。</returns>
        public User Get(string openId)
        {
            var db = new ModelContext();
            var ret = db.Users.FirstOrDefault(u => u.OpenId == openId);
            if (ret == null)
            {
                Helper.ErrorControl.ExMessage(string.Format("{1}\tFind unregistered user ! User openid is {0} .", openId, DateTime.Now.ToString()), 10);
            }
            return ret;
        }


        public IEnumerable<User> Get()
        {
            var db = new ModelContext();
            return db.Users.AsEnumerable<User>();
        }

        /// <summary> 
        /// (空方法，实现Ajax跨域。)
        /// </summary>
        /// <returns></returns>
        public string Options()
        {

            return null; // HTTP 200 response with empty body 

        }

    }
}
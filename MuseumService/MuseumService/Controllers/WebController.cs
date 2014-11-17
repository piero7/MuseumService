using MuseumService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MuseumService.Controllers
{
    /// <summary>
    /// 微信网页部分调用接口
    /// </summary>
    public class WebController : ApiController
    {

        /// <summary>
        /// 查询用户是否需要跳转
        /// </summary>
        /// <param name="openId">目标用户的OpenId</param>
        /// <returns>若需要跳转返回"1" 。不需要跳转返回“0”。发生错误返回“-1;{错误原因}”</returns>
        public string Get(string openId)
        {
            var db = new ModelContext();
            var user = db.Users.Include("Card").FirstOrDefault(u => u.OpenId == openId);
            if (user == null)
            {
                Helper.ErrorControl.ExMessage(string.Format("{1}\tFind unregistered user ! User openid is {0} .", openId, DateTime.Now.ToString()), 10);
                return "-1;undefine user openid!";
            }
            if (user.Card == null)
            {
                Helper.ErrorControl.ExMessage(string.Format("{1}\tThe user hasn`t any card!! User id is {0} .", user.UserId, DateTime.Now.ToString()), 10);
                return "-1;The user hasn`t any card!";
            }

            if (user.IsNeedRedirect)
            {
                user.IsNeedRedirect = false;
                db.SaveChanges();
                return "1";
            }

            return "0;";

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
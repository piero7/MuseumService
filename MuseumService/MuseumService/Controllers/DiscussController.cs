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
    /// 讨论相关接口
    /// </summary>
    public class DiscussController : ApiController
    {
        /// <summary>
        /// 获得现有所的讨论
        /// </summary>
        /// <returns>Discuss实体类型，包含User类</returns>
        public IEnumerable<Discuss> Get()
        {
            var db = new ModelContext();
            return db.Discusses.Include("User").OrderByDescending(d => d.CreateTime).AsEnumerable();
        }

        /// <summary>
        /// 添加讨论记录
        /// </summary>
        /// <param name="item">讨论实体，将用户的OpenId放入实体中，系统会自动搜寻现有注册用户进行关联。</param>
        /// <returns>正常返回 1. 若无法找到现有注册用户的OpenId则返回0</returns>
        public int Post([FromBody] Discuss item)
        {
            var db = new ModelContext();
            item.CreateTime = DateTime.Now;

            var user = db.Users.FirstOrDefault(u => u.OpenId == item.OpenId);
            if (user == null)
            {
                return 0;
            }
            else
            {
                item.UserId = user.UserId;
            }
            db.Discusses.Add(item);

            return db.SaveChanges();
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
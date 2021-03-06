﻿using MuseumService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace MuseumService.Helper
{
    public class UserHelper
    {
        static public User GetUserInfo(User user)
        {
            var db = new ModelContext();
            // var user = db.UserSet.FirstOrDefault(u => u.OpenId == userOpenId);
            //if (userOpenId == null)
            //{
            //    throw new NotFindCustomerOpenIDException(userOpenId);
            //}

            //if (firm == null)
            //{
            //    throw new NotFindFirmTokenException();
            //}

            string url = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";
            var access = GetToken();
            url = string.Format(url, access, user.OpenId);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Timeout = 2000;
            req.Method = "GET";

            var res = (HttpWebResponse)req.GetResponse();
            var s = res.GetResponseStream();
            var sr = new StreamReader(s);
            var resString = sr.ReadToEnd();

            JavaScriptSerializer js = new JavaScriptSerializer();
            var dic = js.Deserialize<Dictionary<string, string>>(resString);
            if (dic.Keys.Contains("errcode"))
            {
                return null;
            }

            user.NickName = dic["nickname"];
            user.Sex = dic["sex"] == "1" ? Sex.男 : dic["sex"] == "2" ? Sex.女 : Sex.未知;
            user.City = dic["city"];
            user.Country = dic["country"];
            user.Province = dic["province"];
            user.Language = dic["language"];
            user.Headimgurl = dic["headimgurl"];
            db.SaveChanges();

            return user;
        }

        static public string GetToken()
        {
            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
            var context = new ModelContext();
            
            var token = context.AccessTokens.First();

            //现有token是否可用
            if (DateTime.Now.Subtract(token.GetTime.Value).TotalSeconds < 7000)
            {
                return token.Token;
            }
            string appid = System.Configuration.ConfigurationManager.AppSettings["AppId"].ToString();
            string appSecret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"].ToString();

            url = string.Format(url, appid, appSecret);

            #region  获得新的token
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url); ;
            req.Method = "GET";
            req.Timeout = 2000;

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);

            var retString = sr.ReadToEnd();

            JavaScriptSerializer js = new JavaScriptSerializer();
            var retDic = js.Deserialize<Dictionary<string, string>>(retString);

            string newToken = "";
            if (retDic.ContainsKey("access_token"))
            {
                newToken = retDic["access_token"];
            }
            #endregion
            token.Token = newToken;
            token.GetTime = DateTime.Now;
            context.SaveChanges();

            return newToken;
        }

    }
}
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
    /// 读卡器调用的相关接口
    /// </summary>
    public class ReaderController : ApiController
    {
        /// <summary>
        /// 推送标签读取记录
        /// </summary>
        /// <param name="cardNumber">标签的Id</param>
        /// <param name="placeId">读取天线的Id</param>
        /// <returns>正常执行返回1 出现问题返回0</returns>
        public int Get(string cardNumber, string placeId)
        {
            var db = new ModelContext();
            var card = db.Cards.FirstOrDefault(c => c.CardNumber == cardNumber);
            if (card == null)
            {
                Helper.ErrorControl.ExMessage(string.Format("{1}\tFind unregistered card ! Card id is {0} .", cardNumber, DateTime.Now.ToString()), 10);
                return 0;
            }

            var place = db.Places.FirstOrDefault(p => p.Name == placeId);
            if (placeId == null)
            {
                Helper.ErrorControl.ExMessage(string.Format("{1}\tFind unregistered plcae ! Place id is {0} .", placeId, DateTime.Now.ToString()), 10);
                return 0;
            }

            var user = db.Users.Include("Card").FirstOrDefault(u => u.Card.CardNumber == cardNumber);
            if (user == null)
            {
                Helper.ErrorControl.ExMessage(string.Format("{1}\tFind unregistered  relationship of user-card ! Card id is {0} .", cardNumber, DateTime.Now.ToString()), 10);
                return 0;
            }

            if (place.IsNeedRedirect)
            {
                user.IsNeedRedirect = true;
            }
            user.WatchTime += 1;
            db.Recodes.Add(new Recode
            {
                CardId = card.CardId,
                PlaceId = place.Id,
                UserId = user.UserId,
                Date = DateTime.Now,
            });

            var ret = db.SaveChanges();

            return ret > 0 ? 1 : 0;

        }
    }
}
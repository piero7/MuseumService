using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuseumService.Models
{

    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string OpenId { get; set; }

        public int? CardId { get; set; }

        [ForeignKey("CardId")]
        public Card Card { get; set; }

        public string NickName { get; set; }

        public bool subscribe { get; set; }

        [EnumDataType(typeof(Sex))]
        public Sex Sex { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string Language { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? SubscribeTime { get; set; }

        public string Headimgurl { get; set; }

        public int? Level { get; set; }

        public int? WatchTime { get; set; }

        public bool IsNeedRedirect { get; set; }

        public string Remarks { get; set; }
    }

    public class AccessToken
    {
        [Key]
        public int AcceccTokenId { get; set; }

        public string Token { get; set; }

        public DateTime? GetTime { get; set; }
    }

    public enum Sex
    {
        男 = 1,
        女 = 2,
        未知 = 0,
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuseumService.Models
{
    public class Place
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsNeedRedirect { get; set; }

        public int WatchTimes { get; set; }

        public string Remarks { get; set; }
    }



    public class Code
    {
        [Key]
        public int Id { get; set; }

        public string TwoDCodePath { get; set; }

        public string EventNumber { get; set; }

        public string TwoDCodeContent { get; set; }
        public DateTime CreateDate { get; set; }

        public bool IsLimit { get; set; }
    }



    public class Card
    {
        [Key]
        public int CardId { get; set; }

        public string TwoDCodePath { get; set; }

        public string EventNumber { get; set; }

        public int? PlaceId { get; set; }

        [ForeignKey("PlaceId")]
        public virtual Place LastPlace { get; set; }

        public string LastPalceStr { get; set; }

        public DateTime? LastData { get; set; }

        public bool IsNeedSkip { get; set; }

        public int? TotalUseTimes { get; set; }

        public string CardNumber { get; set; }

        public int? CodeId { get; set; }

        [ForeignKey("CodeId")]
        public virtual Code Code { get; set; }
    }

    public class Recode
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int PlaceId { get; set; }

        [ForeignKey("PlaceId")]
        public Place Place { get; set; }

        public int CardId { get; set; }

        [ForeignKey("CardId")]
        public Card Card { get; set; }

        public DateTime Date { get; set; }
    }
}
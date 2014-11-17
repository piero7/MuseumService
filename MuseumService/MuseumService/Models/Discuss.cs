using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuseumService.Models
{
    public class Discuss
    {
        [Key]
        public int DiscussId { get; set; }

        public string OpenId { get; set; }

        public string Content { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
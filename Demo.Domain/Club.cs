using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Domain
{
    public class Club
    {
        public Club()
        {
            Players = new List<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfEstablishment { get; set; }
        public string History { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public League League { get; set; }
        public List<Player> Players { get; set; }
    }
}

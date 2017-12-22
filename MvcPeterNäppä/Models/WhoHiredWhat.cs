using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPeterNäppä.Models
{
    [Table("HiredbyUser")]
    public class WhoHiredWhat
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string hiredvideo { get; set; }

    }
}
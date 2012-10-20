using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMNT.Models
{
    public class RememberList
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public List<Post> Posts { get; set; }


    }
}
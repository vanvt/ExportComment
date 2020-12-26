using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Model
{
    public class Comment
    {
        public object Properties { get; set; }
        public int? Id { get; set; }
        public int? version { get; set; }
        public string text { get; set; }
        public Author Author { get; set; }
        public List<Comment> comments { get; set; }
    }
}

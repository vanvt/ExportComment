using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Model
{
    public class PullRequest
    {
        public AuthorPr Author { get; set; }
    }
    public class AuthorPr
    {
        public  Author User { get; set; }
    }
}

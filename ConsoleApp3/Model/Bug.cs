using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Model
{
    public class Bug
    {
        public Author Assigineer { get; set; }
        public Author Reporter { get; set; }
        public Comment Comment { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinnerProjectManager
{
    public class FileErrors
    {
        public List<string> file { get; set; }
    }

    public class FileRoot
    {
        public string message { get; set; }
        public FileErrors errors { get; set; }
    }
}

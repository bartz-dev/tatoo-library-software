using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinnerProjectManager
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class FilesErrors
    {
        public List<object> collection_preview { get; set; }
        public List<object> scan { get; set; }
    }

    public class FilesRoot
    {
        public string message { get; set; }
        public FilesErrors errors { get; set; }
    }


}

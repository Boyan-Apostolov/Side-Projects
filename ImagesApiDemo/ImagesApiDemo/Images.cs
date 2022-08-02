using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesApiDemo
{
    public class Images
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }

        public ICollection<ImageItem> Photos { get; set; }

        public int Total_Results { get; set; }

        public string Next_Page { get; set; }
    }

    public class ImageItem
    {
        public int Id { get; set; }

        public ImageItemSrc Src { get; set; }

        public string Alt { get; set; }
    }

    public class ImageItemSrc
    {
        public string Original { get; set; }
    }
}

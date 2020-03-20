using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.CustomDTO
{
    public class BannerViewModel
    {
        public int ImageID { get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string ImageString { get; set; }
    }
}

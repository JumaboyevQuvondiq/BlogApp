using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Common.Helpers
{
    public static class ImageHelper
    {
        public static string MakeImageName(string filename)
        {
            string extension = Path.GetExtension(filename);
            string name = "IMG_" + Guid.NewGuid().ToString();
            return name + extension;
        }
    }
}

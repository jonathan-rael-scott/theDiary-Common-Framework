using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace theDiary.Tools.Development.HostFileManager
{
    internal static class Extensions
    {
        public static System.Windows.Forms.ImageList CreateImageList(this System.Windows.Forms.ImageList list, Type resourceType, System.Drawing.Size size)
        {
            if (list == null)
                list = new ImageList();
            list.Images.Clear();
            list.ImageSize = size;

            var properties = resourceType.GetProperties().ToArray();
            Dictionary<string, System.Drawing.Image> images = new Dictionary<string, System.Drawing.Image>();
            properties.Where(property => property.PropertyType.IsSubclassOf(typeof(System.Drawing.Image))).ForEach(prop => list.Images.Add(prop.Name, prop.GetValue(null, null).As<System.Drawing.Image>()));

            return list;
        }
    }
}

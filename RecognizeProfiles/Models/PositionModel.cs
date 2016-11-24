using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RecognizeProfiles.Models
{
    public class PositionModel
    {
        public Rectangle Rect { get; set; }
        public string HtmlName { get; set; }
        public string LanguageCode { get; set; }
    }
}

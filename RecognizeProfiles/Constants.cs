using RecognizeProfiles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecognizeProfiles
{
    public class Constants
    {
        public static List<ComboboxItem> LANGUAGES=new List<ComboboxItem>()
        {
            new ComboboxItem(){Id="jpn",Text="Japanese"},
            new ComboboxItem(){Id="eng",Text="English"},
        };
    }
}
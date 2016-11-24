using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecognizeProfiles.Models
{
    public class TemplateModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<PositionModel> Positions { get; set; }
    }
}

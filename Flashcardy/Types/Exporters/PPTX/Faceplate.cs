using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcardy.Types.Exporters.PPTX
{
    public class Faceplate
    {
        public Enums.PlateType Type { get; set; }

        public Faceplate() { }
        public Faceplate(Enums.PlateType type)
        {
            this.Type = type;
        }
    }
}
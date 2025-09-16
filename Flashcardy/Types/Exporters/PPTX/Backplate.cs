using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcardy.Types.Exporters.PPTX
{
    public class Backplate
    {
        public Enums.PlateType Type { get; set; }
        public Flashcard LinkedCard { get; set; }

        public Backplate() { }
        public Backplate(Enums.PlateType type, Flashcard linkedCard)
        {
            Type = type;
            LinkedCard = linkedCard;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcardy.Types.Exporters.PPTX
{
    public class Card
    {
        public Faceplate Faceplate;
        public Backplate Backplate;

        public Card() { }
        public Card(Faceplate faceplate, Backplate backplate)
        {
            Faceplate = faceplate;
            Backplate = backplate;
        }

        public Card(Enums.PlateType type, Flashcard linkedCard)
        {
            Faceplate = new Faceplate(type, linkedCard);
            Backplate = new Backplate(type, linkedCard);
        }
    }
}
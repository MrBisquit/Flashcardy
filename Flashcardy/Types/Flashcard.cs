using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcardy.Types
{
    public class Flashcard
    {
        public string Name          { get; set; } = string.Empty;
        public string Description   { get; set; } = string.Empty;
        public string Identifier    { get; set; } = string.Empty;
        public string Answer        { get; set; } = string.Empty;
        public string ID            { get; set; } = string.Empty;
    }
}

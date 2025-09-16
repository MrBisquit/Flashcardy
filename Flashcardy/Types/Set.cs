using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcardy.Types
{
    public class Set
    {
        public string ID                { get; set; } = string.Empty;

        public string Name              { get; set; } = string.Empty;
        public string Description       { get; set; } = string.Empty;
        public string Identifier        { get; set; } = string.Empty;
        public bool LinkedID            { get; set; } = true;
        public List<Flashcard> cards    { get; set; } = new();
    }

    public class SetOverview
    {
        public string ID                { get; set; } = string.Empty;

        public string Name              { get; set; } = string.Empty;
        public string Description       { get; set; } = string.Empty;
        public string Identifier        { get; set; } = string.Empty;
        public bool LinkedID            { get; set; } = true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcardy.Helpers
{
    public static class Create
    {
        public static Types.Set CreateSet()
        {
            return new()
            {
                ID = Guid.NewGuid().ToString(),
                Name = "Unnamed",
                Description = "Write a description here",
                Identifier = "Write something small here to differentiate this set from other sets",
                cards = new()
                {
                    CreateCard()
                }
            };
        }

        public static Types.Flashcard CreateCard()
        {
            return new()
            {
                ID = Guid.NewGuid().ToString(),
                Name = "Flashcard",
                Description = "An example flashcard",
                Answer = "The answer",
                Identifier = "A short identifier"
            };
        }
    }
}

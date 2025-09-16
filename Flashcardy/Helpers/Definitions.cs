using Flashcardy.Types;
using System.IO;

namespace Flashcardy.Helpers
{
    public static class Definitions
    {
        public static string AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "WTDawson", "Flashcardy");
        public static string SetsDir = Path.Combine(AppData, "sets");
        public static string IndexFile = Path.Combine(AppData, "index.json");

        public static Types.Index LoadedIndex = new();
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcardy.Helpers
{
    public static class Loading
    {
        public static void Init()
        {
            if(!Directory.Exists(Definitions.SetsDir))
                Directory.CreateDirectory(Definitions.SetsDir);

            if(File.Exists(Definitions.IndexFile))
                LoadIndex();
            else
                SaveIndex();
        }

        public static void LoadIndex()
        {
            Definitions.LoadedIndex = JsonConvert.DeserializeObject<Types.Index>(File.ReadAllText(Definitions.IndexFile));
        }

        public static void SaveIndex()
        {
            File.WriteAllText(Definitions.IndexFile, JsonConvert.SerializeObject(Definitions.LoadedIndex, Formatting.Indented));
        }

        public static Types.Set LoadSet(Types.SetOverview overview)
        {
            return JsonConvert.DeserializeObject<Types.Set>(File.ReadAllText(Path.Combine(Definitions.SetsDir, $"{overview.ID}.json")));
        }

        public static void SaveSet(Types.Set set)
        {
            File.WriteAllText(Path.Combine(Definitions.SetsDir, $"{set.ID}.json"), JsonConvert.SerializeObject(set, Formatting.Indented));
            for (int i = 0; i < Definitions.LoadedIndex.Sets.Count; i++)
            {
                if (Definitions.LoadedIndex.Sets[i].ID == set.ID)
                    Definitions.LoadedIndex.Sets[i] = GetOverview(set);
            }
            SaveIndex();
        }

        public static void RegisterSet(Types.SetOverview overview)
        {
            Definitions.LoadedIndex.Sets.Add(overview);
            SaveIndex();
        }

        public static Types.SetOverview GetOverview(Types.Set set)
        {
            return new()
            {
                ID = set.ID,
                Name = set.Name,
                Description = set.Description,
                Identifier = set.Identifier
            };
        }

        public static void DeleteSet(Types.SetOverview overview)
        {
            File.Delete(Path.Combine(Definitions.SetsDir, $"{overview.ID}.json"));
            for (int i = 0; i < Definitions.LoadedIndex.Sets.Count; i++)
            {
                if (Definitions.LoadedIndex.Sets[i].ID == overview.ID)
                    Definitions.LoadedIndex.Sets.Remove(Definitions.LoadedIndex.Sets[i]);
            }
            SaveIndex();
        }

        public static void DeleteSet(Types.Set set)
        {
            File.Delete(Path.Combine(Definitions.SetsDir, $"{set.ID}.json"));
            Types.SetOverview overview = new()
            {
                ID = set.ID
            };
            DeleteSet(overview);
        }

        public static (Types.Set, Types.SetOverview)? ImportSet(string file)
        {
            if(!File.Exists(file)) return null;
            try
            {
                Types.Set? set = JsonConvert.DeserializeObject<Types.Set>(File.ReadAllText(file));
                if (set == null) return null;
                set.ID = Guid.NewGuid().ToString(); // New ID so it doesn't get confused
                return (set, GetOverview(set));
            }
            catch { return null; }
        }

        public static void ExportSet(string file, Types.Set set)
        {
            set.ID = Guid.NewGuid().ToString(); // New ID so it doesn't get confused
            File.WriteAllText(file, JsonConvert.SerializeObject(set, Formatting.Indented));
        }
    }
}

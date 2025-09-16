using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcardy.Exporters.PPTX
{
    public static class PPTXExport
    {
        public static bool StartExport(Types.Set set, string path, int size, int mode)
        {
            Exporter exporter = new(set, path, size, mode);
            return exporter.Export();
        }

        public class Exporter
        {
            public Exporter(Types.Set set, string path, int size, int mode)
            {
                this.set = set;
                this.path = path;
                this.size = size;
                this.mode = mode;
            }

            internal Types.Set set;
            internal string path;
            internal int size;
            internal int mode;

            public bool Export()
            {
                return true;
            }
        }
    }
}
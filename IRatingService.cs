using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudInfo
{
    public interface IRatingService
    {
        IReadOnlyList<Student> Students { get; }

        void FillFromXML(string path);

        void SaveToXML(string path);

        void FillFromPDF(string[] paths);

        void Clear();
    }
}

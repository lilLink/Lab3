using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Lab3
{
    class EditionByCopiesCountComparer : IComparer<Edition>
    {
        public int Compare([NotNull] Edition x, [NotNull] Edition y)
        {
            return x.CopiesCount.CompareTo(y.CopiesCount);
        }
    }
}

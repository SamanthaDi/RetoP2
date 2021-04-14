using System;
using System.Collections.Generic;
using System.Text;

namespace retoP2.list
{
    public interface Iterator<T>
    {
        bool hasNext();
        T next();
    }
}

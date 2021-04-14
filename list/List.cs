using System;
using System.Collections.Generic;
using System.Text;

namespace retoP2.list
{
    interface List<G>
    {
        void add(G data);

        G get(int index);

        void delete(int index);

        int getSize();

        Iterator<G> getIterator();

        void insert(G data, Position position, Iterator<G> it);

        Iterator<G> getReverseIterator();
    }
}

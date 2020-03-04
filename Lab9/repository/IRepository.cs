using Lab10.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.repository
{
    interface IRepository<ID, E> where E: Entity<ID>
    {
        void save(E elem);
        E delete(ID id);
        void update(E elem);
        E findOne(ID id);
        IEnumerable<E> findAll();
        int size();
    }
}

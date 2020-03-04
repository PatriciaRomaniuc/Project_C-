using Lab10.domain.validator;
using Lab10.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.repository
{
    class InMemoryRepository<ID, E>: IRepository<ID,E> where E:Entity<ID>
    {
        IDictionary<ID, E> elems;
        IValidator<E> validator;

        public InMemoryRepository(IValidator<E> validator)
        {
            elems = new Dictionary<ID, E>();
            this.validator = validator;
        }
        public virtual void save(E elem)
        {
            if (elem != null)
            {
                try
                {
                    validator.validate(elem);
                    if (!elems.ContainsKey(elem.id))
                    {
                        elems.Add(elem.id, elem);
                    }
                    else
                    {
                        throw new RepositoryException("Exista deja o entitate cu acest id\n");
                    }
                }
                catch (ValidationException e)
                {
                    throw e;
                }
            }
        }

        public virtual E delete(ID id)
        {
            if (elems.ContainsKey(id))
            {
                E sters = elems[id];
                elems.Remove(id);
                return sters;
            }
            else
            {
                throw new RepositoryException("Entitatea nu a putut fi stearsa deoarece id-ul nu exista\n");
            }
        }

        public virtual void update(E elem)
        {
            try
            {
                validator.validate(elem);
                if (elems.ContainsKey(elem.id))
                {
                    elems[elem.id] = elem;
                }
                else
                {
                    throw new RepositoryException("Entitatea pentru care se face update nu exista cu acest id\n");
                }
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }

        public int size()
        {
            return elems.Count;
        }

        public E findOne(ID id)
        {
            if (elems.ContainsKey(id))
                return elems[id];
            return default(E);
        }

        public IEnumerable<E> findAll()
        {
            return elems.Values;
        }
    }

}

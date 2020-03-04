using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Lab10.domain;
using Lab10.domain.validator;

namespace Lab10.repository
{
    class InFileRepository<ID,E>:InMemoryRepository<ID,E> where E : Entity<ID>
    {
        protected string fileName;
        public delegate E CreateEntityFromString(string s);

        public InFileRepository(IValidator<E> vali, String fileName, CreateEntityFromString createEntity) : base(vali)
        {
            this.fileName = fileName;
            loadFromFile(createEntity);
        }

        protected void loadFromFile(CreateEntityFromString createEntity)
        {
            using (System.IO.TextReader reader = File.OpenText(fileName))
            {
                string linie;
                while ((linie = reader.ReadLine()) != null)
                {
                    E elem = createEntity(linie);
                    base.save(elem);
                }
            }
        }

    }

}

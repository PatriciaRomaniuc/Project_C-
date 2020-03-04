using Lab10.domain;
using Lab10.domain.validator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab10.repository
{
    class ElevRepository : InFileRepository<int, Elev>
    {
        private string fileName;

        public ElevRepository(IValidator<Elev> vali, string filename, CreateEntityFromString createEntity) : base(vali, filename, createEntity) => fileName = filename;

        private void writeToFile()
        {
            using (TextWriter writer = File.CreateText(fileName))
            {
                foreach (Elev elev in findAll())
                {
                    writer.WriteLine("{0}:{1}:{2}", elev.id, elev.nume,elev.scoala);
                }
            }
        }

        public override void save(Elev elem)
        {
            try
            {
                base.save(elem);
                writeToFile();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void update(Elev elem)
        {
            try
            {
                base.update(elem);
                writeToFile();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Elev delete(int id)
        {
            try
            {
                Elev e = base.delete(id);
                writeToFile();
                return e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}



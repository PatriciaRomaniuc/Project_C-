using Lab10.domain;
using Lab10.domain.validator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab10.repository
{
    class EchipaRepository:InFileRepository<int,Echipa>
    {
        private string fileName;

        public EchipaRepository(IValidator<Echipa> vali, string filename, CreateEntityFromString createEntity) : base(vali, filename, createEntity)
        {
           fileName = filename;
        }

        private void writeToFile()
        {
            using (TextWriter writer = File.CreateText(fileName))
            {
                foreach (Echipa echipa in findAll())
                {
                    writer.WriteLine("{0}:{1}", echipa.id, echipa.nume);
                }
            }
        }

        public override void save(Echipa elem)
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

        public override void update(Echipa elem)
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

        public override Echipa delete(int id)
        {
            try
            {
                Echipa e = base.delete(id);
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

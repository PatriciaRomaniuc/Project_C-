using Lab10.domain;
using Lab10.domain.validator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab10.repository
{
    class  JucatorRepository : InFileRepository<int, Jucator>
    {

        private string filen;

        public JucatorRepository(IValidator<Jucator> validator, string filename, CreateEntityFromString createEntity) : base(validator, filename, createEntity)
        {
            filen = filename;
        }

        private void writeToFile()
        {
            using (TextWriter writer = File.CreateText(filen))
            {
                foreach (Jucator jucator in findAll())
                {
                    writer.WriteLine("{0}:{1}:{2}:{3}:{4}", jucator.id, jucator.nume, jucator.scoala, jucator.echipa.id, jucator.echipa.nume);
                }
            }
        }

        public override void save(Jucator elem)
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

        public override void update(Jucator elem)
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

        public override Jucator delete(int id)
        {
            try
            {
                Jucator j = base.delete(id);
                writeToFile();
                return j;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

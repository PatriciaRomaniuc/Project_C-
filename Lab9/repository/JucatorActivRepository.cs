using Lab10.domain;
using Lab10.domain.validator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab10.repository
{
    class JucatorActivRepository : InFileRepository<int, JucatorActiv>
    {
        private string filen;

        public JucatorActivRepository(IValidator<JucatorActiv> validator, string filename, CreateEntityFromString createEntity) : base(validator, filename, createEntity)
        {
            filen = filename;
        }

      
        private void writeToFile()
        {
            using (TextWriter writer = File.CreateText(filen))
            {
                foreach (JucatorActiv jucatorActiv in findAll())
                {
                    writer.WriteLine("{0}:{1}:{2}:{3}:{4}", jucatorActiv.id, jucatorActiv.idJucator, jucatorActiv.idMeci, jucatorActiv.nrPuncteInscrise, jucatorActiv.tip);
                }
            }
        }

        public override void save(JucatorActiv elem)
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

        public override void update(JucatorActiv elem)
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

        public override JucatorActiv delete(int id)
        {
            try
            {
                JucatorActiv j = base.delete(id);
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

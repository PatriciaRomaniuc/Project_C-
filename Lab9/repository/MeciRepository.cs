using Lab10.domain;
using Lab10.domain.validator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab10.repository
{
    class MeciRepository : InFileRepository<int, Meci>
    {
        private string filen;

        public MeciRepository(IValidator<Meci> validator, string filename, CreateEntityFromString createEntity) : base(validator, filename, createEntity)
        {
            filen = filename;
        }


        private void writeToFile()
        {
            using (TextWriter writer = File.CreateText(filen))
            {
                foreach (Meci meci in findAll())
                {
                    writer.WriteLine("{0}:{1}:{2}:{3}:{4}:{5}", meci.id, meci.echipa1.id, meci.echipa1.nume, meci.echipa2.id, meci.echipa2.nume, meci.data.ToString("MM/dd/yyyy"));
                }
            }
        }

        public override void save(Meci elem)
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

        public override void update(Meci elem)
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

        public override Meci delete(int id)
        {
            try
            {
                Meci m = base.delete(id);
                writeToFile();
                return m;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

using Lab10.domain;
using Lab10.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10.service
{
    class JucatorActivService
    {
        public JucatorActivRepository repo;

        public JucatorActivService(JucatorActivRepository repo)
        {
            this.repo = repo;
        }
        public void save(int id, int idJucator, int idMeci, int nrPuncteInscrise, string tip)
        {
            try
            {
                repo.save(new JucatorActiv(id, idJucator, idMeci, nrPuncteInscrise, tip));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void delete(int id)
        {
            try
            {
                repo.delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void update(int id, int idJucator, int idMeci, int nrPuncteInscrise, string tip)
        {
            try
            {
                repo.update(new JucatorActiv(id, idJucator, idMeci, nrPuncteInscrise, tip));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int size()
        {
            return repo.size();
        }

        public JucatorActiv getOne(int id)
        {
            JucatorActiv j = repo.findOne(id);
            return j;
        }

        public IEnumerable<JucatorActiv> getAll()
        {
            return repo.findAll();
        }

        public List<String> jucatoriActiviEchipaMeci(int idMeci, int idEchipa, JucatorService serviceJucator)
        {
            var list = repo.findAll().Where(j =>
            {
                int idJ = j.idJucator;
                Jucator jucator = serviceJucator.getOne(idJ);
                return j.idMeci == idMeci && jucator.echipa.id == idEchipa && j.tip=="Participant";
            }).Select(j => serviceJucator.getOne(j.idJucator).ToString() + " " + j.tip).ToList();
            return list;
        }

        public String scorMeci(int idMeci, MeciService serviceMeci, JucatorService serviceJucator)
        {
            Meci meci = serviceMeci.getOne(idMeci);
            if (meci.ToString().Equals(""))
                return "";
            Echipa ec1 = meci.echipa1;
            Echipa ec2 = meci.echipa2;
            var result1 = repo.findAll().Where(j =>
            {
                Jucator jucator = serviceJucator.getOne(j.idJucator);
                return jucator.echipa.id == ec1.id && j.idMeci == meci.id;
            }).Select(j => j);

            int r1 = 0, r2 = 0;
            foreach (var m in result1)
                r1 = r1 + m.nrPuncteInscrise;

            var result2 = repo.findAll().Where(j =>
            {
                Jucator jucator = serviceJucator.getOne(j.idJucator);
                return jucator.echipa.id == ec2.id && j.idMeci == meci.id;
            }).Select(j => j);

            foreach (var m in result2)
                r2 = r2 + m.nrPuncteInscrise;
            string scor = r1 + "-" + r2 ;
           
            return scor;
        }

    }
}

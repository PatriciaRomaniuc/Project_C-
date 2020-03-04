using Lab10.domain;
using Lab10.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10.service
{
    class MeciService
    {
        private MeciRepository repo;

        public MeciService(MeciRepository repo)
        {
            this.repo = repo;
        }
        public void save(int id, int idEchipa1, string numeEchipa1, int idEchipa2, string numeEchipa2, DateTime data)
        {
            try
            {
                repo.save(new Meci(id, new Echipa(idEchipa1, numeEchipa1), new Echipa(idEchipa2, numeEchipa2), data));
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

        public void update(int id, int idEchipa1, string numeEchipa1, int idEchipa2, string numeEchipa2, DateTime data)
        {
            try
            {
                repo.update(new Meci(id, new Echipa(idEchipa1, numeEchipa1), new Echipa(idEchipa2, numeEchipa2), data));
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

        public Meci getOne(int id)
        {
            Meci m = repo.findOne(id);
            return m;
        }

        public IEnumerable<Meci> getAll()
        {
            return repo.findAll();
        }

        public List<Meci> meciuriPerioada(DateTime dataInceput, DateTime dataFinal)
        {
            var list = (List<Meci>)repo.findAll().Where(m => DateTime.Compare(m.data, dataFinal) < 0 && DateTime.Compare(m.data, dataInceput) > 0)
                .Select(m => m).ToList();
            return list;
        }
    }

}

using Lab10.domain;
using Lab10.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab10.service
{
    class JucatorService
    {
        private JucatorRepository repo;

        public JucatorService(JucatorRepository repo)
        {
            this.repo = repo;
        }
        public void save(int id, string nume, string scoala, int idEchipa, string numeEchipa)
        {
            try
            {
                repo.save(new Jucator(id, nume, scoala, new Echipa(idEchipa, numeEchipa)));
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

        public void update(int id, string nume, string scoala, int idEchipa, string numeEchipa)
        {
            try
            {
                repo.update(new Jucator(id, nume, scoala, new Echipa(idEchipa, numeEchipa)));
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

        public Jucator getOne(int id)
        {
            Jucator j = repo.findOne(id);
            return j;
        }

        public IEnumerable<Jucator> getAll()
        {
            return repo.findAll();
        }

        public List<Jucator> jucatoriEchipa(int idEchipa)
        {
            var list = repo.findAll().Where(j => j.echipa.id == idEchipa).Select(j => j).ToList();
            return list;
        }
    }
}

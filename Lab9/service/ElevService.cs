using Lab10.domain;
using Lab10.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.service
{
    class ElevService
    {
        private ElevRepository repo;

        public ElevService(ElevRepository repo)
        {
            this.repo = repo;
        }
        public void save(int id, string nume, string scoala)
        {
            try
            {
                repo.save(new Elev(id, nume, scoala));
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

        public void update(int id, string nume, string scoala)
        {
            try
            {
                repo.update(new Elev(id, nume, scoala));
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

        public Elev getOne(int id)
        {
            Elev e = repo.findOne(id);
            return e;
        }

        public IEnumerable<Elev> getAll()
        {
            return repo.findAll();
        }
    }
}

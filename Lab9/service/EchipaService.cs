using Lab10.domain;
using Lab10.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.service
{
    class EchipaService
    {
        private EchipaRepository repo;

        public EchipaService(EchipaRepository repo)
        {
            this.repo = repo;
        }
        public void save(int id, string nume)
        {
            try
            {
                repo.save(new Echipa(id, nume));
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
        public void update(int id, string nume)
        {
            try
            {
                repo.update(new Echipa(id, nume));
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

        public Echipa getOne(int id)
        {
            Echipa e = repo.findOne(id);
            return e;
        }

        public IEnumerable<Echipa> getAll()
        {
            return repo.findAll();
        }
    }
}

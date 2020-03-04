using Lab10.service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Lab10.domain;
using NUnit.Framework;

namespace Lab10.ui
{
    class Consola
    {
        private EchipaService echipaService;
        private ElevService elevService;
        private JucatorService jucatorService;
        private MeciService meciService;
        private JucatorActivService jucatorActivService;

        public Consola(EchipaService echipaService, ElevService elevService, JucatorService jucatorService, MeciService meciService, JucatorActivService jucatorActivService)
        {
            this.echipaService = echipaService;
            this.elevService = elevService;
            this.jucatorService = jucatorService;
            this.meciService = meciService;
            this.jucatorActivService = jucatorActivService;
        }

        private void scorMeci()
        {
            Console.WriteLine("Dati id meci:");
            int idMeci;
            bool ok = int.TryParse(Console.ReadLine(), out idMeci);
            if (ok)
            {
                string scor = jucatorActivService.scorMeci(idMeci, meciService, jucatorService);
                if(scor=="")
                    Console.WriteLine("nu exista meciul dat");

                Console.WriteLine(meciService.getOne(idMeci).ToString());
                Console.WriteLine(scor);
                
            }
            else
            {
                Console.WriteLine("Id-ul trebuie sa fie numeric");
            }
        }

        private void mecuriPerioada()
        {
            Console.WriteLine("Dati data dupa formatul: ll/zz/aaaa");
            Console.WriteLine("Dati data inceput:");
            DateTime dataInceput;
            bool ok = DateTime.TryParse(Console.ReadLine(), out dataInceput);
            Console.WriteLine("Dati data final:");
            DateTime dataFinal;
            ok = DateTime.TryParse(Console.ReadLine(), out dataFinal);
            if (ok)
            {
                foreach (Meci meci in meciService.meciuriPerioada(dataInceput, dataFinal))
                {
                    Console.WriteLine(meci);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Data nu este corecta");
            } 
        }

        private void jucatoriiActiviMeci()
        {
            Console.WriteLine("Dati id meci:");
            int idMeci;
            bool ok = int.TryParse(Console.ReadLine(), out idMeci);
            Console.WriteLine("Dati id echipa:");
            int idEchipa;
            ok = int.TryParse(Console.ReadLine(), out idEchipa);
            if (ok)
            {
                foreach (String jucator in jucatorActivService.jucatoriActiviEchipaMeci(idMeci, idEchipa, jucatorService))
                {
                    Console.WriteLine(jucator);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Id-ul trebuie sa fie numeric");
            }
        }
        private void jucatoriiUneiEchipe()
        {
            Console.WriteLine("Dati id echipa:");
            int id;
            bool ok = int.TryParse(Console.ReadLine(), out id);
            if (ok)
            {
                foreach (Jucator jucator in jucatorService.jucatoriEchipa(id))
                {
                    Console.WriteLine(jucator.ToString());
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Id-ul trebuie sa fie numeric");
            }


        }

        public void meniu()
        {
            Console.WriteLine("----Meniu----");
            Console.WriteLine("0.EXIT");
            Console.WriteLine("1.Toti jucatorii unei echipe date.");
            Console.WriteLine("2.Toti jucatorii activi ai unei echipe de la un anumit meci.");
            Console.WriteLine("3.Toate meciurile dintr-o anumita perioada calendaristica.");
            Console.WriteLine("4.Scorul de la un anumit meci.");
            Console.WriteLine();
        }
        public void run()
        {
            string x = "";
            while (x != "0")
            {
                meniu();

                Console.WriteLine("Introduceti comanda:");
                x = Console.ReadLine();
                if (x == "1")
                {
                    jucatoriiUneiEchipe();
                }
                if (x == "2")
                {
                    jucatoriiActiviMeci();
                }
                if (x == "3")
                {
                    mecuriPerioada();
                }
                if (x == "4")
                {
                    scorMeci();
                }
            }
        }
    }
}

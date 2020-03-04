using Lab10.domain;
using Lab10.domain.validator;
using Lab10.repository;
using Lab10.service;
using Lab10.ui;
using Lab10.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    class MainApp
    {
        public static Echipa CreateEchipaFromString(string linie)
        {
            string[] values = linie.Split(':');
            if (values.Length == 2)
            {
                int id;
                bool ok = int.TryParse(values[0], out id);
                if (ok)
                {
                    string nume = values[1];
                    return new Echipa(id, nume);
                }
            }
            return default(Echipa);
        }
        public static Elev CreateElevFromString(string linie)
        {
            string[] values = linie.Split(':');
            if (values.Length == 3)
            {
                int id;
                bool ok = int.TryParse(values[0], out id);
                if (ok)
                {
                    string nume = values[1];
                    string scoala = values[2];
                    return new Elev(id, nume, scoala);
                }
            }
            return default(Elev);
        }
        public static Jucator CreateJucatorFromString(string linie)
        {
            string[] values = linie.Split(':');
            if (values.Length == 5)
            {
                int id;
                bool ok = int.TryParse(values[0], out id);
                if (ok)
                {
                    string nume = values[1];
                    string scoala = values[2];
                    int idEchipa;
                    ok = int.TryParse(values[3], out idEchipa);
                    if (ok)
                    {
                        string numeEchipa = values[4];
                        return new Jucator(id, nume, scoala, new Echipa(idEchipa, numeEchipa));
                    }
                }
            }
            return default(Jucator);
        }

        public static JucatorActiv CreateJucatorActivFromString(string linie)
        {
            string[] values = linie.Split(':');
            if (values.Length == 5)
            {
                int id;
                bool ok = int.TryParse(values[0], out id);
                if (ok)
                {
                    int idJucator;
                    ok = int.TryParse(values[1], out idJucator);
                    if (ok)
                    {
                        int idMeci;
                        ok = int.TryParse(values[2], out idMeci);
                        if (ok)
                        {
                            int nrPuncteInscrise;
                            ok = int.TryParse(values[3], out nrPuncteInscrise);
                            if (ok)
                            {
                                string tip = values[4];
                                return new JucatorActiv(id, idJucator, idMeci, nrPuncteInscrise, tip);
                            }
                        }
                    }
                }
            }
            return default(JucatorActiv);

        }
        public static Meci CreateMeciFromString(string linie)
        {
            string[] values = linie.Split(':');
            if (values.Length == 6)
            {
                int id;
                bool ok = int.TryParse(values[0], out id);
                if (ok)
                {
                    int idEchipa1;
                    ok = int.TryParse(values[1], out idEchipa1);
                    string numeEchipa1 = values[2];
                    if (ok)
                    {
                        int idEchipa2;
                        ok = int.TryParse(values[3], out idEchipa2);
                        string numeEchipa2 = values[4];
                        if (ok)
                        {
                            DateTime data;
                            ok = DateTime.TryParse(values[5], out data);
                            if (ok)
                            {
                                return new Meci(id, new Echipa(idEchipa1, numeEchipa1), new Echipa(idEchipa2, numeEchipa2), data);
                            }
                        }
                    }
                }
            }
            return default(Meci);
        }

        static void Main(string[] args)
        {
            ValidateEchipa validateEchipa = new ValidateEchipa();
            ValidateElev validateElev = new ValidateElev();
            ValidateJucator validateJucator = new ValidateJucator();
            ValidateMeci validateMeci = new ValidateMeci();
            ValidateJucatorActiv validateJucatorActiv = new ValidateJucatorActiv();

            EchipaRepository echipaRepository = new EchipaRepository(validateEchipa, "C:\\Users\\pc\\source\\repos\\Lab9\\Lab9\\files\\echipe.txt", new InFileRepository<int, Echipa>.CreateEntityFromString(CreateEchipaFromString));
            ElevRepository elevRepository = new ElevRepository(validateElev, "C:\\Users\\pc\\source\\repos\\Lab9\\Lab9\\files\\elevi.txt", new InFileRepository<int, Elev>.CreateEntityFromString(CreateElevFromString));
            JucatorRepository jucatorRepository = new JucatorRepository(validateJucator, "C:\\Users\\pc\\source\\repos\\Lab9\\Lab9\\files\\jucatori.txt", new InFileRepository<int, Jucator>.CreateEntityFromString(CreateJucatorFromString));
            MeciRepository meciRepository = new MeciRepository(validateMeci, "C:\\Users\\pc\\source\\repos\\Lab9\\Lab9\\files\\meciuri.txt", new InFileRepository<int, Meci>.CreateEntityFromString(CreateMeciFromString));
            JucatorActivRepository jucatorActivRepository = new JucatorActivRepository(validateJucatorActiv, "C:\\Users\\pc\\source\\repos\\Lab9\\Lab9\\files\\jucatoriActivi.txt", new InFileRepository<int, JucatorActiv>.CreateEntityFromString(CreateJucatorActivFromString));

            EchipaService echipaService = new EchipaService(echipaRepository);
            ElevService elevService = new ElevService(elevRepository);
            JucatorService jucatorService = new JucatorService(jucatorRepository);
            MeciService meciService = new MeciService(meciRepository);
            JucatorActivService jucatorActivService = new JucatorActivService(jucatorActivRepository);


            Teste.RunTests(echipaService, elevService, jucatorActivService, jucatorService, meciService);

            Consola consola = new Consola(echipaService, elevService, jucatorService, meciService, jucatorActivService);

            consola.run();
        }
    }
}

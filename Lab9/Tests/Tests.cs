using System;
using System.Collections.Generic;
using System.Text;
using Lab10.service;
using System.Diagnostics;
namespace Lab10.Tests
{
    class Teste
    {
        
        public static void RunTests(EchipaService echipaService, ElevService elevService, JucatorActivService jucatorActivService, JucatorService jucatorService, MeciService meciService)
        {

            Debug.Assert(jucatorActivService.jucatoriActiviEchipaMeci(1, 1, jucatorService).Count != 0);
            Debug.Assert(jucatorActivService.jucatoriActiviEchipaMeci(1, 2, jucatorService).Count != 0);
            Debug.Assert(jucatorActivService.jucatoriActiviEchipaMeci(2, 1, jucatorService).Count != 0);
            Debug.Assert(jucatorActivService.jucatoriActiviEchipaMeci(2, 3, jucatorService).Count != 0);

            Debug.Assert(jucatorService.jucatoriEchipa(1).Count == 15);
            Debug.Assert(jucatorService.jucatoriEchipa(2).Count == 15);
            Debug.Assert(jucatorService.jucatoriEchipa(3).Count == 15);

            Debug.Assert(jucatorActivService.scorMeci(1, meciService, jucatorService) != "");
            Debug.Assert(jucatorActivService.scorMeci(2, meciService, jucatorService) != "");
            Debug.Assert(jucatorActivService.scorMeci(3, meciService, jucatorService) != "");

            Debug.Assert(meciService.meciuriPerioada(DateTime.Parse("12/01/2019"), DateTime.Parse("12/03/2019")).Count == 1);
            Debug.Assert(meciService.meciuriPerioada(DateTime.Parse("12/05/2012"), DateTime.Parse("12/02/2016")).Count == 0);
            Debug.Assert(meciService.meciuriPerioada(DateTime.Parse("12/02/2019"), DateTime.Parse("12/05/2019")).Count == 1);

        }
    }
}

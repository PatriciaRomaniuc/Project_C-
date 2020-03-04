using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.domain
{
    class JucatorActiv: Entity<int>
    {
        public int idJucator { set; get; }
        public int idMeci { set; get; }
        public int nrPuncteInscrise { set; get; }
        public string tip { set; get; }

        public JucatorActiv(int id,int idJucator, int idMeci, int nrPuncteInscrise, string tip)
        {
            base.id = id;
            this.idJucator = idJucator;
            this.idMeci = idMeci;
            this.nrPuncteInscrise = nrPuncteInscrise;
            this.tip = tip;
        }
        public override bool Equals(object obj)
        {
            if (obj is JucatorActiv)
            {
                JucatorActiv jucatorActiv = (JucatorActiv)obj;
                return jucatorActiv.id == this.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return id + " " + idJucator + " " + idMeci + " " + nrPuncteInscrise + " " + tip;
        }

        public static bool operator ==(JucatorActiv j1, JucatorActiv j2)
        {
            return j1.Equals(j2);
        }

        public static bool operator !=(JucatorActiv j1, JucatorActiv j2)
        {
            return !j1.Equals(j2);
        }
    }
}

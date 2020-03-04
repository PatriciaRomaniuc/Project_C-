using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.domain
{
    class Jucator: Elev
    {
        public Echipa echipa { set; get; }

        public Jucator(int id, string nume, string scoala, Echipa echipa) : base(id, nume, scoala)
        {
            this.echipa = echipa;
        }
        public override bool Equals(object obj)
        {
            if (obj is Jucator)
            {
                Jucator jucator = (Jucator)obj;
                return jucator.id == this.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + " " + echipa.ToString();
        }

        public static bool operator ==(Jucator j1, Jucator j2) => j1.Equals(j2);

        public static bool operator !=(Jucator j1, Jucator j2)
        {
            return !j1.Equals(j2);
        }
    }

}

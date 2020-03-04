using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.domain
{
    class Elev: Entity<int>
    {
        public string nume { set; get; }
        public string scoala { set; get; }

        public Elev(int id, string nume, string scoala)
        {
            base.id = id;
            this.nume = nume;
            this.scoala = scoala;
        }

        public override bool Equals(object obj)
        {
            if (obj is Elev)
            {
                Elev elev = (Elev)obj;
                return elev.id == this.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return id + " " + nume + " " + scoala;
        }

        public static bool operator ==(Elev e1, Elev e2)
        {
            return e1.Equals(e2);
        }

        public static bool operator !=(Elev e1, Elev e2)
        {
            return !e1.Equals(e2);
        }

    }
}

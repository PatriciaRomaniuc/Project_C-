using System;
using System.Collections.Generic;

namespace Lab10.domain
{
    class Echipa: Entity<int>
    {
        public string nume { set; get; }
        public Echipa( int id, string nume)
        {
            base.id = id;
            this.nume = nume;
        }
        public override bool Equals(object obj)
        {
            if(obj is Echipa)
            {
                Echipa echipa = (Echipa)obj;
                return echipa.id == this.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
        public override string ToString()
        {
            return id + " " + nume;
        }

        public static bool operator ==(Echipa e1, Echipa e2)
        {
            return e1.Equals(e2);
        }

        public static bool operator !=(Echipa e1, Echipa e2)
        {
            return !e1.Equals(e2);
        }
    }
}

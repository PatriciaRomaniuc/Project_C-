using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.domain
{
    class Meci:Entity<int>
    {
        public Echipa echipa1 { set; get; }
        public Echipa echipa2 { set; get; }
        public DateTime data { set; get; }

        public Meci(int id, Echipa echipa1, Echipa echipa2, DateTime data)
        {
            base.id = id;
            this.echipa1 = echipa1;
            this.echipa2 = echipa2;
            this.data = data;
        }

        public override bool Equals(object obj)
        {
            if (obj is Meci)
            {
                Meci meci = (Meci)obj;
                return meci.id == this.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();

        }
        public override string ToString()
        {
            return id + " " + echipa1.ToString() + " " + echipa2.ToString() + " " + data.ToString("MM/dd/yyyy");
        }

        public static bool operator ==(Meci m1, Meci m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(Meci m1, Meci m2)
        {
            return !m1.Equals(m2);
        }
    }
}

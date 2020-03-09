using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
    public enum Felhasznalo {sofőr, utas}
    class Ut
    {
        public Felhasznalo tipusa;
        public string Datum { get;}
        public int Uticel_id { get; }
        public int Felhasznalo_id { get; }

        public Ut(string sor)
        {
            string[] seged = sor.Split(';');
            switch (char.Parse(seged[0]))
            {
                case 'S':
                    tipusa = Felhasznalo.sofőr;
                    break;
                case 'U':
                    tipusa = Felhasznalo.utas;
                    break;
            }
            Datum = seged[1];
            Uticel_id = int.Parse(seged[2]);
            Felhasznalo_id = int.Parse(seged[3]);
        }
    }
}

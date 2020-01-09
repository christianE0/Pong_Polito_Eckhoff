using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongFertig
{
    public class Schlaeger
    {

        public int Hoehe { get; private set; }

        public int Breite { get; private set; }

        public int aktuelleXKoordinate { get; private set; }

        public int aktuelleYKoordinate { get; private set; }


        public void Bewegen(bool nachOben)
        {
            int invertierteBreite = nachOben ? -10 : +10;
            aktuelleYKoordinate += invertierteBreite;
        }


        public Schlaeger(int hoehe, int breite, int xKoordinate, int yKoordinate)
        {
            this.Hoehe = hoehe;
            this.Breite = breite;
            this.aktuelleXKoordinate = xKoordinate;
            this.aktuelleYKoordinate = yKoordinate;
        }

        public void PositionAnpassen(int xKoordinate, int yKoordinate)
        {
            this.aktuelleXKoordinate = xKoordinate;
            this.aktuelleYKoordinate = yKoordinate;
        
       }


       
    }
}

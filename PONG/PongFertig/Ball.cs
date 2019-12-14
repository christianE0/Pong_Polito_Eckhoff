using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongFertig
{
    public static class Ball
    {

        public static int Hoehe { get; private set; }

        public static int Breite { get; private set; }

        public static int aktuelleXKoordinate { get; private set; }

        public static int aktuelleYKoordinate { get; private set; }

        //Variable um zu prüfen ob der Ball rechtsläufig ist (nach rechts fliegt) oder nicht
        private static bool istBallRechtsläufig;

        public static void Bewegen(int breite, Schlaeger spieler1Schlaeger, Schlaeger spieler2Schlaeger)
        {
            PruefenObBallAbprallt(spieler1Schlaeger, spieler2Schlaeger);
            int invertierteBreite = istBallRechtsläufig ? +breite : -breite;
            Breite += invertierteBreite;
            aktuelleXKoordinate += invertierteBreite;
        }


        public static void InitialisiereBall(int xKoordinate, int yKoordinate)
        {
            //Die Breite des Balls bestimmen und in in die Mitte setzen
            Hoehe = 50;
            Breite = 50;
            aktuelleXKoordinate = xKoordinate;
            aktuelleYKoordinate = yKoordinate;

        }

        private static void PruefenObBallAbprallt(Schlaeger spieler1Schlaeger, Schlaeger spieler2Schlaeger)
        {
            if (spieler1Schlaeger.aktuelleXKoordinate == Ball.aktuelleXKoordinate && ((Ball.aktuelleYKoordinate >= (spieler1Schlaeger.aktuelleYKoordinate - spieler1Schlaeger.Hoehe)) && Ball.aktuelleYKoordinate <= (spieler1Schlaeger.aktuelleYKoordinate + spieler1Schlaeger.Hoehe)))
            {
                istBallRechtsläufig = !istBallRechtsläufig;
            }


            if ((spieler2Schlaeger.aktuelleXKoordinate - Ball.Breite / 4) <= Ball.aktuelleXKoordinate && ((Ball.aktuelleYKoordinate >= (spieler2Schlaeger.aktuelleYKoordinate - spieler2Schlaeger.Hoehe)) && Ball.aktuelleYKoordinate <= (spieler2Schlaeger.aktuelleYKoordinate + spieler2Schlaeger.Hoehe)))
            {
                istBallRechtsläufig = !istBallRechtsläufig;
            }
        }


        public static void PositionAnpassen(int xKoordinate, int yKoordinate)
        {
            aktuelleXKoordinate = xKoordinate;
            aktuelleYKoordinate = yKoordinate;
        }
    }
}

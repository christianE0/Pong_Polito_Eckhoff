using System;
using System.Drawing;
using System.Windows.Forms;

namespace PongFertig
{
    public partial class Form1 : Form
    {

        private Timer spielTimer;

        private Schlaeger Spieler1Schlaeger;

        private Schlaeger Spieler2Schlaeger;

        private Rectangle Spieler1SchlaegerRechteck;

        private Rectangle Spieler2SchlaegerRechteck;

        private Rectangle BallRechteck;


        public Form1()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Name = "Pong Spiel";
            this.Text = "Pong Spiel";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            InitializeComponent();
            this.Invalidate();
            
        }

        private void Ball_Tick(object sender, EventArgs e)
        {
            Ball.Bewegen(10, Spieler1Schlaeger, Spieler2Schlaeger);
            SpielGrafikenZeichnen();
            this.Invalidate();
        }


        /// <summary>
        /// Initialisiert den Spiel Timer der die Bewegung des Balls und der Schläger steuert (Game Loop)
        /// </summary>
        private void SpielTimerInitialisieren()
        {
            spielTimer = new Timer();
            spielTimer.Interval = 100;
            spielTimer.Tick += new EventHandler(Ball_Tick);
            spielTimer.Start();

        }

        private void SchlägerInitialisieren()
        {
            Spieler1Schlaeger = new Schlaeger(100, 20, 15, ((this.ClientSize.Height / 2)));
            Spieler2Schlaeger = new Schlaeger(100, 20, (this.ClientSize.Width - 15), ((this.ClientSize.Height / 2)));
        }

        private void BallInitialisieren()
        {
            Ball.InitialisiereBall((this.ClientSize.Width / 2), (this.ClientSize.Height / 2));
        }


        private void SpielGrafikenZeichnen()
        {

            if (Spieler1Schlaeger == null || Spieler2Schlaeger == null) SchlägerInitialisieren();
            
            var formGraphics = this.CreateGraphics();

            //Pinsel wird erstellt mit der Farbe rot
            SolidBrush SchwarzenAnstrich = new SolidBrush(Color.Black);

            //Pinsel wird erstellt mit der Farbe Blau
            SolidBrush BlauenAnstrich = new SolidBrush(Color.Blue);

            //Spielgrafiken erzeugen (Ball)
            BallRechteck = new Rectangle(Ball.aktuelleXKoordinate, Ball.aktuelleYKoordinate, 50, 50);
            formGraphics.FillEllipse(SchwarzenAnstrich, BallRechteck);

            //Spielgrafiken erzeugen (Schläger)
            Spieler1SchlaegerRechteck = new Rectangle(Spieler1Schlaeger.aktuelleXKoordinate, Spieler1Schlaeger.aktuelleYKoordinate, Spieler1Schlaeger.Breite, Spieler1Schlaeger.Hoehe);
            formGraphics.FillRectangle(BlauenAnstrich, Spieler1SchlaegerRechteck);

            Spieler2SchlaegerRechteck = new Rectangle(Spieler2Schlaeger.aktuelleXKoordinate, Spieler2Schlaeger.aktuelleYKoordinate, Spieler2Schlaeger.Breite, Spieler2Schlaeger.Hoehe);
            formGraphics.FillRectangle(BlauenAnstrich, Spieler2SchlaegerRechteck);

            // Ball und Schläger Positionen neu berechnen
            PositionenAnpassen();

            SchwarzenAnstrich.Dispose();
            BlauenAnstrich.Dispose();
            formGraphics.Dispose();
        }



        /// <summary>
        /// Aktuelle X / Y Koordinaten für den Ball und Schläger anpassen
        /// </summary>
        public void PositionenAnpassen()
        {
            if (Spieler1Schlaeger == null || Spieler2Schlaeger == null) SchlägerInitialisieren();
            // Aktuelle x/y Koordinaten speichern
            Spieler1Schlaeger.PositionAnpassen(Spieler1SchlaegerRechteck.X, Spieler1SchlaegerRechteck.Y);
            Spieler2Schlaeger.PositionAnpassen(Spieler2SchlaegerRechteck.X, Spieler2SchlaegerRechteck.Y);
            Ball.PositionAnpassen(BallRechteck.X, BallRechteck.Y);
        }


        /// <summary>
        /// Bei Fenster größen Änderungen, neu zeichnen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            SpielGrafikenZeichnen();
        }


        /// <summary>
        /// Tastatur drücken Ereignis (Tastatur Druck) - auswerten ob eine Bewegungn oder Spieler Aktion ausgeführt werden muss
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Switch case um Tastatur Eingaben auszuwerten
            switch (e.KeyCode)
            {
                case Keys.W:
                    Spieler1Schlaeger.Bewegen(true);
                    break;
                case Keys.S:
                    Spieler1Schlaeger.Bewegen(false);
                    break;
                case Keys.Up:
                    Spieler2Schlaeger.Bewegen(true);
                    break;
                case Keys.Down:
                    Spieler2Schlaeger.Bewegen(false);
                    break;
                default:
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SpielGrafikenZeichnen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Invalidate();
            SchlägerInitialisieren();
            BallInitialisieren();
            SpielTimerInitialisieren();
            SpielGrafikenZeichnen();
            this.Invalidate();
        }
    }
}

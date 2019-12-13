using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PONG
{
    public partial class Form1 : Form
    {
        public int BallWidht { get; set; }
        public int BallHeight { get; set; }

        public int SchlaegerLHoehe { get; set; }
        public int SchlaegerLBreite { get; set; }
        public int SchlaegerRHoehe { get; set; }
        public int SchlaegerRBreite { get; set; }

        private void ball_Tick(object sender, EventArgs e)
        {
            BallWidht += 10;
            LinkerBalken();
            RechterBalken();
            this.Invalidate();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //Pinsel wird erstellt mit der Farbe rot
            SolidBrush myBrush = new SolidBrush(Color.Black);
            SolidBrush schlägerBrush = new SolidBrush(Color.Blue);

            Graphics formGraphics;

            //Kreis wird erstellt
            formGraphics = this.CreateGraphics();

            //Kreis wird gemalt
            formGraphics.FillEllipse(myBrush, new Rectangle(BallWidht, BallHeight, 50, 50));
            Rectangle schläger_L = new Rectangle(SchlaegerLBreite, SchlaegerLHoehe, 25, 150);
            formGraphics.FillRectangle(schlägerBrush, schläger_L);
            Rectangle schläger_R = new Rectangle(SchlaegerRBreite, SchlaegerRHoehe, 25, 150);
            formGraphics.FillRectangle(schlägerBrush, schläger_R);
            myBrush.Dispose();
            formGraphics.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

     
namespace Fraktale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Kwadrat> K = new List<Kwadrat>();
        public List<Kwadrat_a> Ka = new List<Kwadrat_a>();
        public List<TrójkątSierpińskiego> T = new List<TrójkątSierpińskiego>();
        public List<KwadratSierpińskiego> Kw = new List<KwadratSierpińskiego>(); 
        public List<MojFraktal> Tr = new List<MojFraktal>();
        public List<MojKwadrat> MK = new List<MojKwadrat>();
        public List<Koch> KK = new List<Koch>();


        public struct linia
        {
            public Pen B;
            public Point P1;
            public Point p2;

            public linia(Pen pen, Point punkt1, Point punkt2)
            {
                B = pen;
                P1 = punkt1;
                p2 = punkt2;
            }
        }

        public class Koch
        {
            public PointF A, B, C;

            public Koch[] Grow()
            {
                Koch[] KK = new Koch[6];
                Koch T1, T2, T3, T4, T5, T6;
                T1 = new Koch();
                T2 = new Koch();
                T3 = new Koch();
                T4 = new Koch();
                T5 = new Koch();
                T6 = new Koch();

                T1.A = T6.B = TrzeciaLinii(A, B);
                T1.B = T4.A =  DwaTrzeciaLinii(A, B);

                T2.A = T6.A = TrzeciaLinii(A, C);
                T2.B = T5.B = DwaTrzeciaLinii(A, C);

                T3.A = T4.B = TrzeciaLinii(B, C);
                T3.B = T5.A = DwaTrzeciaLinii(B, C);

                T1.C = NewPoint(T3.A, T1.B);
                T2.C = NewPoint(T1.A, T2.A);
                T3.C = NewPoint(T2.B, T3.B);
                T4.C = B;
                T5.C = C;
                T6.C = A;

                KK[0] = T1;
                KK[1] = T2;
                KK[2] = T3;
                KK[3] = T4;
                KK[4] = T5;
                KK[5] = T6;

                return KK;
            }
            public PointF TrzeciaLinii(PointF a, PointF b) //Wekto
            {
                return new PointF(a.X + ((b.X - a.X) / 3), a.Y + ((b.Y - a.Y) / 3));
            }

            public PointF DwaTrzeciaLinii(PointF a, PointF b)
            {
                return new PointF(b.X - ((b.X - a.X) / 3), b.Y - ((b.Y - a.Y) / 3));
            }

            public PointF NewPoint(PointF a, PointF S)
            {
                return new PointF(2 * S.X - a.X, 2 * S.Y - a.Y);
            }
        }

        public class MojKwadrat
        {
            public PointF A, B, C, D;

            public MojKwadrat[] Grow()
            {
                MojKwadrat[] MK = new MojKwadrat[1];
                MojKwadrat K;
                //S = new MojKwadrat();
                K = new MojKwadrat();

                PointF Ssa = SrodekLinii(A, B);
                PointF Ssb = SrodekLinii(B, C);
                PointF Ssc = SrodekLinii(C, D);
                PointF Ssd = SrodekLinii(A, D);

                PointF Sa = SrodekLinii(Ssa, A);
                PointF Sb = SrodekLinii(B, Ssb);
                PointF Sc = SrodekLinii(Ssc, C);
                PointF Sd = SrodekLinii(D, Ssd);

                //PointF Sa = SrodekLinii(A, B);
                //PointF Sb = SrodekLinii(B, C);
                //PointF Sc = SrodekLinii(C, D);
                //PointF Sd = SrodekLinii(A, D);

                K.A = SrodekLinii(Sa, A);
                K.B = SrodekLinii(B, Sb);
                K.C = SrodekLinii(Sc, C);
                K.D = SrodekLinii(D, Sd);

                //K.A = TrzeciaLinii(A, D);
                //K.B = DwaTrzeciaLinii(A, B);
                //K.C = DwaTrzeciaLinii(B, C);
                //K.D = TrzeciaLinii(D, C);

                MK[0] = K;

                return MK;
            }

            public PointF SrodekLinii(PointF a, PointF b)
            {
                return new PointF((a.X + b.X) / 2, (a.Y + b.Y) / 2);
            }

            public PointF TrzeciaLinii(PointF a, PointF b) //Wektor
            {
                return new PointF(a.X + ((b.X - a.X) / 3), a.Y + ((b.Y - a.Y) / 3));
            }

            public PointF DwaTrzeciaLinii(PointF a, PointF b)
            {
                return new PointF(b.X - ((b.X - a.X) / 3), b.Y - ((b.Y - a.Y) / 3));
            }
        }

        public class KwadratSierpińskiego
        {
            public PointF A, B, C, D;

            public KwadratSierpińskiego[] Grow()
            {
                KwadratSierpińskiego[] Kw = new KwadratSierpińskiego[8];
                KwadratSierpińskiego Kw1, Kw2, Kw3, Kw4, Kw5, Kw6, Kw7, Kw8;
                Kw1 = new KwadratSierpińskiego();
                Kw2 = new KwadratSierpińskiego();
                Kw3 = new KwadratSierpińskiego();
                Kw4 = new KwadratSierpińskiego();
                Kw5 = new KwadratSierpińskiego();
                Kw6 = new KwadratSierpińskiego();
                Kw7 = new KwadratSierpińskiego();
                Kw8 = new KwadratSierpińskiego();

                Kw1.A = A;
                Kw1.B = Kw4.A = TrzeciaLinii(A, B);
                Kw1.D = Kw2.A = TrzeciaLinii(A, D);

                Kw2.D = Kw3.A = DwaTrzeciaLinii(A, D);

                Kw3.C = Kw5.D = TrzeciaLinii(D, C);
                Kw3.D = D;

                Kw4.B = Kw6.A = DwaTrzeciaLinii(A, B);

                Kw5.C = Kw8.D = DwaTrzeciaLinii(D, C);

                Kw6.B = B;
                Kw6.C = Kw7.B = TrzeciaLinii(B, C);

                Kw7.C = Kw8.B = DwaTrzeciaLinii(B, C);

                Kw8.C = C;

                Kw1.C = Kw2.B = Kw4.D = NewPoint(Kw1.A, SrodekLinii(Kw1.B,Kw1.D));
                Kw2.C = Kw3.B = Kw5.A = NewPoint(Kw2.A, SrodekLinii(Kw2.B,Kw2.D));
                Kw4.C = Kw6.D = Kw7.A = NewPoint(Kw4.A, SrodekLinii(Kw4.B,Kw4.D));
                Kw5.B = Kw7.D = Kw8.A = NewPoint(Kw8.C, SrodekLinii(Kw8.B,Kw8.D));

                Kw[0] = Kw1;
                Kw[1] = Kw2;
                Kw[2] = Kw3;
                Kw[3] = Kw4;
                Kw[4] = Kw5;
                Kw[5] = Kw6;
                Kw[6] = Kw7;
                Kw[7] = Kw8;

                return Kw;
            }

            public PointF SrodekLinii(PointF a, PointF b)
            {
                return new PointF((a.X + b.X) / 2, (a.Y + b.Y) / 2);
            }

            public PointF TrzeciaLinii(PointF a, PointF b) //Wekto
            {
                return new PointF(a.X + ((b.X - a.X) / 3), a.Y + ((b.Y - a.Y) / 3));
            }

            public PointF DwaTrzeciaLinii(PointF a, PointF b)
            {
                return new PointF(b.X - ((b.X - a.X) / 3), b.Y - ((b.Y - a.Y) / 3));
            }

            public PointF NewPoint(PointF a, PointF S)
            {
                return new PointF(2 * S.X - a.X, 2 * S.Y - a.Y);
            }

        }

        public class MojFraktal
        {
            public PointF A, B, C, D;
            public string S;
            public MojFraktal[] Grow(string Kwd)
            {
                if (Kwd == "K")
                {
                    MojFraktal[] Tr = new MojFraktal[9];
                    MojFraktal Tr1, Tr2, Tr3, Tr4, Kd1, Kd2, Kd3, Kd4, Kd5;
                    Tr1 = new MojFraktal();
                    Tr2 = new MojFraktal();
                    Tr3 = new MojFraktal();
                    Tr4 = new MojFraktal();
                    Kd1 = new MojFraktal();
                    Kd2 = new MojFraktal();
                    Kd3 = new MojFraktal();
                    Kd4 = new MojFraktal();
                    Kd5 = new MojFraktal();

                    Kd1.A = A;
                    Kd1.B = TrzeciaLinii(A, B);
                    Kd1.D = TrzeciaLinii(A, D);

                    Kd2.A = DwaTrzeciaLinii(A, D);
                    Kd2.C = TrzeciaLinii(D, C);
                    Kd2.D = D;

                    Kd4.A = Tr2.A = DwaTrzeciaLinii(A, B);
                    Kd4.B = B;
                    Kd4.C = Tr4.A = TrzeciaLinii(B, C);

                    Kd5.B = Tr4.B = DwaTrzeciaLinii(B, C);
                    Kd5.C = C;
                    Kd5.D = Tr3.B = DwaTrzeciaLinii(D, C);

                    Kd1.C = Tr1.A = Kd3.A = NewPoint(Kd1.A, SrodekLinii(Kd1.B, Kd1.D));
                    Kd2.B = Tr1.B = Kd3.D = NewPoint(Kd2.D, SrodekLinii(Kd2.A, Kd2.C));
                    Kd4.D = Tr2.B = Kd3.B = NewPoint(Kd4.B, SrodekLinii(Kd4.A, Kd4.C));
                    Kd5.A = Tr3.A = Kd3.C = NewPoint(Kd5.C, SrodekLinii(Kd5.B, Kd5.D));

                    Tr1.C = SrodekLinii(A, D);
                    Tr2.C = SrodekLinii(Kd1.B, Kd1.C);
                    Tr3.C = SrodekLinii(Kd2.B, Kd2.C);
                    Tr4.C = SrodekLinii(Kd3.B, Kd3.C);

                    Tr[0] = Kd1;
                    Tr[0].S = "K";
                    Tr[1] = Tr1;
                    Tr[1].S = "T";
                    Tr[2] = Kd2;
                    Tr[2].S = "K";
                    Tr[3] = Tr2;
                    Tr[3].S = "T";
                    Tr[4] = Kd3;
                    Tr[4].S = "K";
                    Tr[5] = Tr3;
                    Tr[5].S = "T";
                    Tr[6] = Kd4;
                    Tr[6].S = "K";
                    Tr[7] = Tr4;
                    Tr[7].S = "T";
                    Tr[8] = Kd5;
                    Tr[8].S = "K";

                    return Tr;
                }
                else
                {
                    MojFraktal[] T = new MojFraktal[3];
                    MojFraktal T1, T2, T3;
                    T1 = new MojFraktal();
                    T2 = new MojFraktal();
                    T3 = new MojFraktal();

                    T1.A = T3.C = SrodekLinii(C, A);
                    T1.B = T2.C = SrodekLinii(C, B);
                    T3.B = T2.A = SrodekLinii(A, B);

                    T3.A = A;
                    T2.B = B;
                    T1.C = C;

                    T[0] = T1;
                    T[0].S = "T";
                    T[1] = T2;
                    T[1].S = "T";
                    T[2] = T3;
                    T[2].S = "T";
                    return T;
                }
            }

            public PointF SrodekLinii(PointF a, PointF b)
            {
                return new PointF((a.X + b.X) / 2, (a.Y + b.Y) / 2);
            }

            public PointF TrzeciaLinii(PointF a, PointF b) //Wekto
            {
                return new PointF(a.X + ((b.X - a.X) / 3), a.Y + ((b.Y - a.Y) / 3));
            }
            public PointF DwaTrzeciaLinii(PointF a, PointF b)
            {
                return new PointF(b.X - ((b.X - a.X) / 3), b.Y - ((b.Y - a.Y) / 3));
            }
            public PointF NewPoint(PointF a, PointF S)
            {
                return new PointF(2 * S.X - a.X, 2 * S.Y - a.Y);
            }

        }

        public class TrójkątSierpińskiego
        {
            public PointF A, B, C;

            public TrójkątSierpińskiego[] Grow()
            {
                TrójkątSierpińskiego[] T = new TrójkątSierpińskiego[3];
                TrójkątSierpińskiego T1, T2, T3;
                T1 = new TrójkątSierpińskiego();
                T2 = new TrójkątSierpińskiego();
                T3 = new TrójkątSierpińskiego();

                T1.A = A;
                T1.B = T2.A = SrodekLinii(A,B);
                T1.C = T3.A = SrodekLinii(A,C);

                T2.B = B;
                T2.C = T3.B = SrodekLinii(B,C);

                T3.C = C;

                T[0] = T1;
                T[1] = T2;
                T[2] = T3;

                return T;
            }

            public PointF SrodekLinii(PointF a, PointF b)
            {
                return new PointF((a.X + b.X) / 2, (a.Y + b.Y) / 2);
            }
        }

        public class Kwadrat_a
        {
            public PointF A, B, C, D;

            public Kwadrat_a()
            {
                A = B = C = D = new PointF(0, 0);
            }

            public Kwadrat_a[] Grow()
            {
                Kwadrat_a[] Ka = new Kwadrat_a[4];
                Kwadrat_a Ka1, Ka2, Ka3 ,Ka4;
                Ka1 = new Kwadrat_a();
                Ka2 = new Kwadrat_a();
                Ka3 = new Kwadrat_a();
                Ka4 = new Kwadrat_a();

                Ka1.A = D;
                Ka1.C = NewPoint(A, D);

                Ka2.B = C;
                Ka2.D = NewPoint(B, C);

                Ka3.D = B;
                Ka3.B = NewPoint(C, B);

                Ka4.D = A;
                Ka4.B = NewPoint(D, A);

                Ka1.B = Ka2.A = SrodekLinii(D, Ka2.D);
                Ka3.A = Ka4.C = SrodekLinii(B, Ka4.B);

                Ka1.D = NewPoint(Ka1.B, SrodekLinii(Ka1.A, Ka1.C));
                Ka2.C = NewPoint(Ka2.A, SrodekLinii(Ka2.B, Ka2.D));
                Ka3.C = NewPoint(Ka3.A, SrodekLinii(Ka3.D, Ka3.B));
                Ka4.A = NewPoint(Ka4.C, SrodekLinii(Ka4.D, Ka4.B));
                Ka[0] = Ka1;
                Ka[1] = Ka2;
                Ka[2] = Ka4;
                Ka[3] = Ka3;
                return Ka; 
            }

            public PointF SrodekLinii(PointF a, PointF b)
            {
                return new PointF((a.X + b.X) / 2, (a.Y + b.Y) / 2);
            }
            public PointF NewPoint(PointF a, PointF S)
            {
                return new PointF(2 * S.X - a.X, 2 * S.Y - a.Y);
            }

        }

        public class Kwadrat
        {
            public PointF A, B, C, D;

            public Kwadrat()
            {
                A = B = C = D = new PointF(0, 0);
            }

            public Kwadrat[] Grow()
            {
                Kwadrat[] K = new Kwadrat[2];
                Kwadrat K1, K2;
                K1 = new Kwadrat();
                K2 = new Kwadrat();

                K1.A = D;
                K1.C = NewPoint(A, D);

                K2.B = C;
                K2.D = NewPoint(B, C);

                K1.B = K2.A = SrodekLinii(D, K2.D);

                K1.D = NewPoint(K1.B, SrodekLinii(K1.A, K1.C));
                K2.C = NewPoint(K2.A, SrodekLinii(K2.B, K2.D));
                K[0] = K1;
                K[1] = K2;
                return K;
            }

            public PointF SrodekLinii(PointF a, PointF b)
            {
                return new PointF((a.X + b.X) / 2, (a.Y + b.Y) / 2);
            }

            public PointF NewPoint(PointF a, PointF S)
            {
                return new PointF(2 * S.X - a.X, 2 * S.Y - a.Y);
            }

        }

        public List<linia> SpisKresek;
        public double DlugoscEuklidesowa(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SpisKresek = new List<linia>();
            SpisKresek.Add(new linia(new Pen(Brushes.Red), new Point(0, 0), new Point(100, 0)));
            SpisKresek.Add(new linia(new Pen(Brushes.Green), new Point(100, 0), new Point(100, 100)));
            SpisKresek.Add(new linia(new Pen(Brushes.Blue), new Point(100, 100), new Point(0, 100)));
            SpisKresek.Add(new linia(new Pen(Brushes.Yellow), new Point(0, 100), new Point(0, 0)));
            Rectangle rect = new Rectangle(0, 0, 100, 100);
            float startAngle = 0.0F;
            float sweepAngle = 360.0F;
            Bitmap BMP = new Bitmap(250, 250);
            Graphics A = Graphics.FromImage(BMP);
            foreach (linia i in SpisKresek)
            {
                A.DrawLine(i.B, i.P1, i.p2);
            }
            A.DrawArc(new Pen(Brushes.Pink), rect, startAngle, sweepAngle);
            pictureBox1.Image = BMP;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (K.Count == 0)
            {
                Kwadrat KRD = new Kwadrat();
                KRD.A = new Point(230, 100);
                KRD.B = new Point(300, 100);
                KRD.C = new Point(300, 170);
                KRD.D = new Point(230, 170);
                K.Add(KRD);
            }
            Bitmap BMP = new Bitmap(500, 500);
            Graphics D = Graphics.FromImage(BMP);
            foreach (Kwadrat i in K)
            {
                D.DrawLine(new Pen(Brushes.Black), i.A, i.B);
                D.DrawLine(new Pen(Brushes.Black), i.B, i.C);
                D.DrawLine(new Pen(Brushes.Black), i.C, i.D);
                D.DrawLine(new Pen(Brushes.Black), i.D, i.A);
            }
            pictureBox1.Image = BMP;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<Kwadrat> TEMP = new List<Kwadrat>();
            foreach (Kwadrat i in K)
            {
                Kwadrat[] T = i.Grow();
                TEMP.Add(i);
                foreach (Kwadrat j in T)
                {
                    TEMP.Add(j);
                }
            }
            K = TEMP;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Ka.Count == 0)
            {
                Kwadrat_a KRD = new Kwadrat_a();
                KRD.A = new Point(230, 140);
                KRD.B = new Point(260, 140);
                KRD.C = new Point(260, 170);
                KRD.D = new Point(230, 170);
                Ka.Add(KRD);
            }
            Bitmap BMP = new Bitmap(500, 300);
            Graphics D = Graphics.FromImage(BMP);
            foreach (Kwadrat_a i in Ka)
            {
                D.DrawLine(new Pen(Brushes.Black), i.A, i.B);
                D.DrawLine(new Pen(Brushes.Black), i.B, i.C);
                D.DrawLine(new Pen(Brushes.Black), i.C, i.D);
                D.DrawLine(new Pen(Brushes.Black), i.D, i.A);
            }
            pictureBox1.Image = BMP;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            List<Kwadrat_a> TEMP = new List<Kwadrat_a>();
            foreach (Kwadrat_a i in Ka)
            {
                Kwadrat_a[] T = i.Grow();
                TEMP.Add(i);
                foreach (Kwadrat_a j in T)
                {
                    TEMP.Add(j);
                }
            }
            Ka = TEMP;
        }

        //Trójkąt Sierpińskiego

        private void button12_Click(object sender, EventArgs e)
        {
            List<TrójkątSierpińskiego> TEMP = new List<TrójkątSierpińskiego>();
            foreach (TrójkątSierpińskiego i in T)
            {
                TrójkątSierpińskiego[] T = i.Grow();
                TEMP.Add(i);
                foreach (TrójkątSierpińskiego j in T)
                {
                    TEMP.Add(j);
                }
            }
            T = TEMP;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (T.Count == 0)
            {
                TrójkątSierpińskiego TRK = new TrójkątSierpińskiego();
                TRK.A = new Point(10,10);
                TRK.B = new Point(310,10);
                TRK.C = new Point(160,200);
                T.Add(TRK);
            }
            Bitmap BMP = new Bitmap(500, 300);
            Graphics D = Graphics.FromImage(BMP);
            foreach (TrójkątSierpińskiego i in T)
            {
                D.DrawLine(new Pen(Brushes.Black), i.A, i.B);
                D.DrawLine(new Pen(Brushes.Black), i.B, i.C);
                D.DrawLine(new Pen(Brushes.Black), i.C, i.A);
            }
            pictureBox1.Image = BMP;
        }

        //KwadratSierpińskiego
        private void button1_Click(object sender, EventArgs e)
        {
            if (Kw.Count == 0)
            {
                KwadratSierpińskiego KRD = new KwadratSierpińskiego();
                KRD.A = new Point(200, 50);
                KRD.B = new Point(400, 50);
                KRD.C = new Point(400, 250);
                KRD.D = new Point(200, 250);
                Kw.Add(KRD);
            }
            Bitmap BMP = new Bitmap(500, 300);
            Graphics D = Graphics.FromImage(BMP);
            foreach (KwadratSierpińskiego i in Kw)
            {
                D.DrawLine(new Pen(Brushes.Black), i.A, i.B);
                D.DrawLine(new Pen(Brushes.Black), i.B, i.C);
                D.DrawLine(new Pen(Brushes.Black), i.C, i.D);
                D.DrawLine(new Pen(Brushes.Black), i.D, i.A);
            }
            pictureBox1.Image = BMP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<KwadratSierpińskiego> TEMP = new List<KwadratSierpińskiego>();
            foreach (KwadratSierpińskiego i in Kw)
            {
                KwadratSierpińskiego[] Kw = i.Grow();
                TEMP.Add(i);
                foreach (KwadratSierpińskiego j in Kw)
                {
                    TEMP.Add(j);
                }
            }
            Kw = TEMP;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Tr.Count == 0)
            {
                MojFraktal KRD = new MojFraktal();
                KRD.A = new Point(200, 50);
                KRD.B = new Point(400, 50);
                KRD.C = new Point(400, 250);
                KRD.D = new Point(200, 250);
                KRD.S = "K";
                Tr.Add(KRD);
            }
            Bitmap BMP = new Bitmap(500, 300);
            Graphics D = Graphics.FromImage(BMP);
            foreach (MojFraktal i in Tr)
            {
                if (i.S == "K")
                {
                    D.DrawLine(new Pen(Brushes.Black), i.A, i.B);
                    D.DrawLine(new Pen(Brushes.Black), i.B, i.C);
                    D.DrawLine(new Pen(Brushes.Black), i.C, i.D);
                    D.DrawLine(new Pen(Brushes.Black), i.D, i.A);
                }
                else if(i.S == "T")
                {
                    D.DrawLine(new Pen(Brushes.Black), i.A, i.B);
                    D.DrawLine(new Pen(Brushes.Black), i.B, i.C);
                    D.DrawLine(new Pen(Brushes.Black), i.C, i.A);
                }
            }
            pictureBox1.Image = BMP;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<MojFraktal> TEMP = new List<MojFraktal>();
            
            foreach (MojFraktal i in Tr)
            {
                MojFraktal[] Tr = i.Grow(i.S);
                TEMP.Add(i);
                foreach (MojFraktal j in Tr)
                {
                    TEMP.Add(j);
                }
            }
            Tr = TEMP;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MK.Count == 0)
            {
                MojKwadrat KRD = new MojKwadrat();
                KRD.A = new Point(200, 50);
                KRD.B = new Point(400, 50);
                KRD.C = new Point(400, 250);
                KRD.D = new Point(200, 250);
                MK.Add(KRD);
            }
            Bitmap BMP = new Bitmap(500, 300);
            Graphics D = Graphics.FromImage(BMP);
            foreach (MojKwadrat i in MK)
            {
                D.DrawLine(new Pen(Brushes.Black), i.A, i.B);
                D.DrawLine(new Pen(Brushes.Black), i.B, i.C);
                D.DrawLine(new Pen(Brushes.Black), i.C, i.D);
                D.DrawLine(new Pen(Brushes.Black), i.D, i.A);
            }
            pictureBox1.Image = BMP;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            List<MojKwadrat> TEMP = new List<MojKwadrat>();
            foreach (MojKwadrat i in MK)
            {
                MojKwadrat[] MK = i.Grow();
                TEMP.Add(i);
                foreach (MojKwadrat j in MK)
                {
                    TEMP.Add(j);
                }
            }
            MK = TEMP;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (KK.Count == 0)
            {
                Koch KRD = new Koch();
                KRD.A = new Point(110,110);
                KRD.B = new Point(415,110);
                KRD.C = new Point(260, 300);
                KK.Add(KRD);
            }
            Bitmap BMP = new Bitmap(500, 400);
            Graphics D = Graphics.FromImage(BMP);
            foreach (Koch i in KK)
            {
                D.DrawLine(new Pen(Brushes.Gray), i.A, i.B);
                D.DrawLine(new Pen(Brushes.Gray), i.B, i.C);
                D.DrawLine(new Pen(Brushes.Gray), i.C, i.A);
                D.FillPolygon(Brushes.Gray, new PointF[3] {i.A,i.B,i.C });
            }
            pictureBox1.Image = BMP;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            List<Koch> TEMP = new List<Koch>();
            foreach (Koch i in KK)
            {
                Koch[] KK = i.Grow();
                TEMP.Add(i);
                foreach (Koch j in KK)
                {
                    TEMP.Add(j);
                }
            }
            KK = TEMP;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

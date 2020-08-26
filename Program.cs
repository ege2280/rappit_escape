using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TavsanKac
{
    class Program
    {
        private static List<Pozisyon> points = new List<Pozisyon>();
        public static int size = 4;
        static bool krt = true;
        static bool tlk = true;
        static bool atlk = true;
        static bool utlk = true;
        static char c1 = 'A';
        static int c2 = 1;

        public static void Main(string[] args)
        {

            krt = true;
            tlk = true;
            atlk = true;
            utlk = true;
            c1 = 'A';
            c2 = 1;
            Console.WriteLine("Boyut giriniz  4 un katları olacak şekilde, minumum 4 maksimum 16 ");
            size = Convert.ToInt32(Console.ReadLine());
            if (size < 4 || (size % 4 != 0))
                return;
            List<Konum> Konum = new List<Konum>();

            for (int i = 0; i <= size; i++)
            {
                c2 = 1;
                for (int j = 0; j <= size; j++)
                {
                    Konum.Add(new TavsanKac.Konum() { Y = c1.ToString(), X = c2.ToString() });
                    c2++;
                }

                c1++;

            }
            Random rnd = new Random();
            List<Engel> Engeller = new List<Engel>();
            List<Konum> EngelKonum = new List<Konum>();
            int ckrt = 1;
            while (krt)
            {


                int r = rnd.Next(Konum.Count);

                Engeller.Add(new Engel() { EngelAdi = "Kurt", EngelDurum = EngelDurum.Engelle, EngelKonum = Konum.ElementAt(r) });
                EngelKonum.Add(Konum.ElementAt(r));
                ckrt++;
                krt = ckrt == 4 ? false : true;
            }

            int catlk = 1;
            while (atlk)
            {

                int r = rnd.Next(Konum.Count);
                if (!EngelKonum.Contains(Konum.ElementAt(r)))
                {
                    Engeller.Add(new Engel() { EngelAdi = "Alt Tel", EngelDurum = EngelDurum.Zipla, EngelKonum = Konum.ElementAt(r) });
                    EngelKonum.Add(Konum.ElementAt(r));
                    catlk++;
                }
                atlk = catlk == 4 ? false : true;

            }
            int cutlk = 1;
            while (utlk)
            {

                int r = rnd.Next(Konum.Count);
                if (!EngelKonum.Contains(Konum.ElementAt(r)))
                {
                    Engeller.Add(new Engel() { EngelAdi = "Ust Tel", EngelDurum = EngelDurum.Egil, EngelKonum = Konum.ElementAt(r) });
                    EngelKonum.Add(Konum.ElementAt(r));
                    cutlk++;
                }
                utlk = cutlk == 4 ? false : true;

            }

            int ctlk = 1;
            while (tlk)
            {
                int r = rnd.Next(Konum.Count);
                if (!EngelKonum.Contains(Konum.ElementAt(r)))
                {
                    Engeller.Add(new Engel() { EngelAdi = "Tilki", EngelDurum = EngelDurum.Engelle, EngelKonum = Konum.ElementAt(r) });
                    EngelKonum.Add(Konum.ElementAt(r));
                    ctlk++;
                }
                tlk = ctlk == 4 ? false : true;

            }

            for (int j = 1; j <= size; j++)
            {
                Console.WriteLine("\n");
                for (int i = 1; i <= size; i++)
                {
                    Console.Write("  * ");
                }
            }
            bool _dowork = true;
            Console.WriteLine("Oyun başlıyor, (İleri “N”, Geri “P”, Sağ “R” Sol “L”, Zipla “J” Eğil “I kobinasyonlarını kullanabiliriz. Başlamak için O tuşuna basın");
            string O = Console.ReadLine();

            if (O == "O")
            {
                Konum akonum = new TavsanKac.Konum() { Y = "A", X = "1" };
                char aY = char.Parse(akonum.Y);
                int aX = Convert.ToInt32(akonum.X);
                EngelDurum engelDurum;
                while (_dowork)
                {
                    char tus = char.Parse(Console.ReadLine());
                    char maxY = Konum.Max(x => x.Y).FirstOrDefault();
                    int maxX = Convert.ToInt32(Konum.Max(x => x.X).FirstOrDefault());
                    char minY = Konum.Min(x => x.Y).FirstOrDefault();
                    int minX = Convert.ToInt32(Konum.Min(x => x.X).FirstOrDefault());
                    switch (tus)
                    {
                        case (char)Hareket.N:
                            char oay = aY;
                            if (oay++ <= maxY)
                            {

                                aY++;
                                engelDurum = Engeller.Where(x => x.EngelKonum.X == aX.ToString() && x.EngelKonum.Y == aY.ToString()).Select(y => y.EngelDurum).FirstOrDefault();
                                _dowork = HareketEt(engelDurum, ref tus);
                            }
                            else
                            {
                                Console.WriteLine("Harita bitti");
                                return;
                            }

                            break;
                        case (char)Hareket.P:
                            char oap = aY;
                            if (minY >= oap--)
                            {
                                aY--;
                                engelDurum = Engeller.Where(x => x.EngelKonum.X == aX.ToString() && x.EngelKonum.Y == aY.ToString()).Select(y => y.EngelDurum).FirstOrDefault();
                                _dowork = HareketEt(engelDurum, ref tus);
                            }
                            else
                            {
                                Console.WriteLine("Harita bitti");
                                return;
                            }
                            break;
                        case (char)Hareket.L:
                            int omix = aX;
                            if (minX >= omix--)
                            {
                                aX--;
                                engelDurum = Engeller.Where(x => x.EngelKonum.X == aX.ToString() && x.EngelKonum.Y == aY.ToString()).Select(y => y.EngelDurum).FirstOrDefault();
                                _dowork = HareketEt(engelDurum, ref tus);
                            }
                            else
                            {
                                Console.WriteLine("Harita bitti");
                                return;
                            }
                            break;
                        case (char)Hareket.R:
                            int amix = aX;
                            if (amix++ <= maxX)
                            {
                                aX++;
                                engelDurum = Engeller.Where(x => x.EngelKonum.X == aX.ToString() && x.EngelKonum.Y == aY.ToString()).Select(y => y.EngelDurum).FirstOrDefault();
                                _dowork = HareketEt(engelDurum, ref tus);
                            }
                            else
                            {
                                Console.WriteLine("Harita bitti");
                                return;
                            }
                            break;
                        case (char)Hareket.J:
                            engelDurum = Engeller.Where(x => x.EngelKonum.X == aX.ToString() && x.EngelKonum.Y == aY.ToString()).Select(y => y.EngelDurum).FirstOrDefault();
                            _dowork = HareketEt(engelDurum, ref tus);
                            break;
                        case (char)Hareket.I:
                            engelDurum = Engeller.Where(x => x.EngelKonum.X == aX.ToString() && x.EngelKonum.Y == aY.ToString()).Select(y => y.EngelDurum).FirstOrDefault();
                            _dowork = HareketEt(engelDurum, ref tus);
                            break;
                        default:
                            Console.WriteLine("Yanlış tuş");
                            break;
                    }
                }
            }

            Console.ReadLine();
        }
        public static bool HareketEt(EngelDurum engelDurum, ref char tus)
        {
            bool rlet = true;
            switch (engelDurum)
            {
                case EngelDurum.Engelle:
                    Console.WriteLine("Engellendiniz. Tekrar başlamak için T ye basın");
                    if (Console.ReadLine() == "T")
                        Main(new string[1]);
                    else
                        rlet = false;
                    break;
                case EngelDurum.Egil:
                    Console.WriteLine("Eğilmelisiniz");

                    tus = char.Parse(Console.ReadLine());
                    break;
                case EngelDurum.Zipla:
                    Console.WriteLine("Zıplamalısınız");

                    tus = char.Parse(Console.ReadLine());
                    break;
                default:
                    rlet = false;
                    break;
            }
            return rlet;
        }


    }
}



/*
 
    Console.CursorVisible = false;
            // Console.WriteLine("Boyut giriniz  4 un katları olacak şekilde, minumum 4 maksimum 16 ");
            size = 16;// Convert.ToInt32(Console.ReadLine());

          

    */

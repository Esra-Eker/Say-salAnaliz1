using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA
{
    class Program
    {
        static void Main(string[] args)
        {

            for (;;)
            {
                double xb, fxb;
                double xs, fxs;
                double xm=0, fxm;
                int iterasyon = 0;

                Console.WriteLine("------------------------------------------");
                
                Console.ForegroundColor = ConsoleColor.Blue;

                //Fonksiyon tanımlanır.
                Console.WriteLine("f(x) = x^3 - (7)x^2 + (14)x - 6");
                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine("------------------------------------------");

                Console.WriteLine("");

                Console.WriteLine("------------------------------------------");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("False Position Metodu");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Esra EKER");
                Console.WriteLine("17025047");
                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine("------------------------------------------");

                Console.WriteLine("");
 
                //Kullanıcı iterasyon sayısını ve aralık değerlerini girer.
                Console.Write("İterasyon Sayısını Giriniz : ");
                int k = Convert.ToInt32(Console.ReadLine());

                Console.Write("Xb Değerini Giriniz : ");
                xb = Convert.ToDouble(Console.ReadLine());

                Console.Write("Xs Değerini Giriniz : ");
                xs = Convert.ToDouble(Console.ReadLine());


                Console.WriteLine("");

                //xb ve xs in fonksiyondaki değerleri hesaplanır.
                fxb = Math.Pow(xb, 3) - (7) * (Math.Pow(xb, 2)) + (14) * xb - 6;
                fxs = Math.Pow(xs, 3) - (7) * (Math.Pow(xs, 2)) + (14) * xs - 6;

                //xm ve fonksiyondaki değeri hesaplanır.
                xm = (xb * fxs - xs * fxb) / (fxs - fxb);
                fxm = Math.Pow(xm, 3) - (7) * (Math.Pow(xm, 2)) + (14) * xm - 6;

                //Aralık değişmeden önceki iterasyon ekrana yazdırılır.
                Console.WriteLine("");
                Console.WriteLine("*** 1." + " iterasyon ***");
                Console.WriteLine("xm = " + xm);
                Console.WriteLine("f(xm) = " + fxm);

                for (int i = 2; i<= k; i++)
                {                    

                    //f(xb)*f(xm) çarpımı negatifse kök [xb,xm] aralığındadır, xs yerine xm yazılır ve f(xs) nin yeni değeri hesaplanır..
                    if (fxb*fxm<0)
                    {
                        xs = xm;
                        fxs = Math.Pow(xs, 3) - (7) * (Math.Pow(xs, 2)) + (14) * xs - 6; 
                    }

                    //f(xm)*f(xs) çarpımı negatifse kök [xm,xs] aralığındadır, xb yerine xm yazılır ve f(xb) nin yeni değeri hesaplanır..
                    else if (fxm*fxs<0)
                    {
                        xb = xm;
                        fxb = Math.Pow(xb, 3) - (7) * (Math.Pow(xb, 2)) + (14) * xb - 6;   
                    }

                    //İkisi de değilse çıkılır.
                    else
                    {
                        break;
                    }

                    //xs veya xb değerleri değiştiği için yeni bir xm değeri hesaplanır ve fonksiyonda yerine yazılır.
                    xm = (xb * fxs - xs * fxb) / (fxs - fxb);
                    fxm = Math.Pow(xm, 3) - (7) * (Math.Pow(xm, 2)) + (14) * xm - 6;

                    //İterasyon sonuçları ekrana yazdırılır.
                    Console.WriteLine("");
                    Console.WriteLine("*** " + i + "." + " iterasyon ***");
                    Console.WriteLine("xm = " + xm);
                    Console.WriteLine("f(xm) = " + fxm);


                    iterasyon++;

                }

                //f(xb)*f(xs) çarpımı pozitifse iterasyon durdurulur ve sonuçlar ekrana yazdırılır.
                //iterasyon!=0 ile iterasyonun döngü içinde devam edip etmediği kontrol edilir. Eğer devam ettiyse kök varlığı kontrolü yapılmaz.
                if (fxb * fxs > 0 && iterasyon != 0)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("f(xb)*f(xs) = " + "(" + fxb + ")" + "*" + "(" + fxs + ")" + " = " + (fxb * fxs) + " > " + 0 + " olduğundan " + (iterasyon + 1) + "." + " iterasyona devam edilmedi.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Yaklaşık X Değeri : " + xm);
                }

                //Döngü içinde iterasyon yapılmadıysa ve f(xb)*f(xs) pozitifse kök yoktur.
                else if(iterasyon == 0 && fxb * fxs > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("f(xb)*f(xs) = " + "("+ fxb + ")" + "*" + "(" + fxs + ")" + " = " + (fxb * fxs) + " > " + 0 + " olduğundan " + (iterasyon + 1) + "." + " iterasyona devam edilmedi.");
                    Console.WriteLine("[" + xb + "," + xs + "] " + "aralığında kök yoktur.");
                }

                //Hiçbiri gerçekleşmezse kullanıcının girdiği iterasyona kadar devam edilir ve sonuç ekrana yazdırılır.
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(iterasyon + 1 + "." + " İterasyon Sonucunda Yaklaşık X Değeri: " + xm);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.WriteLine("Tekrar hesaplama yapmak için bir tuşa basın.");
                Console.WriteLine("");

                Console.ReadKey();

                //Durma koşullarından biri olan |f(xm)|< epsilon u kullanıp kullanıcının epsilon değerini girmesiyle de işlemi durdurabilirdik. 



            }

        }
    }
}

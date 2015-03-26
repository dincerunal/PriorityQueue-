using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priority_Queuet
{



    class Program
    {
        public static void degistir(int[] hasta)
        {
            int d, counter, sonuc, i, temp;                         //döngülerde kullanılmak üzere counter ve i sıralama içinde temp degişkeni 
            Console.WriteLine("durumu degisen hastanın indisini giriniz");      //durumu değişen hastanın numarası isteniyor
            d = Convert.ToInt32(Console.ReadLine());
            if(d>10)
            {
                Console.WriteLine("hatalı numara girdiniz 0 ile 10 arasında ");         //kullanıcının yanlış değer girmesini önlemek için
                d = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("hastanın yeni aciliyet durumunu giriniz");           //hastanın yeni aciliyet durumu isteniyor
            hasta[d]= Convert.ToInt32(Console.ReadLine());
            if (hasta[d] > 5)                                                //kullanıcının yanlış değer girmesini önlemek için
            {
            Console.WriteLine("hatali durum girdiniz 1 ile 5 arasında ");
            hasta[d]= Convert.ToInt32(Console.ReadLine());
            }
            for (counter = (hasta.Length / 2) - 1; counter >= 0; counter--)             //for döngüsü içinde recursive fonk kullanıldı
            {
                sonuc = max(counter, hasta.Length, hasta);
            }
            for (i = hasta.Length - 1; i >= 1; i--)                             //for döngüsü içinde recursive fonk kullanılırken bu fonk gezici i değeri 1 azaltılarak gönderildi
            {
                temp = hasta[0];
                hasta[0] = hasta[i];
                hasta[i] = temp;
                sonuc = max(0, i - 1, hasta);

            }
            for (i = 0; i < 10; i++)                                        //son durumdaki  yeni aciliyet sırası ekrana yazdırıldı
            {
                Console.WriteLine("yeni aciliyet durum sıralaması");
                Console.WriteLine(hasta[i]);

            }





        }
        public static void delete(int[] hasta)      //tedavisi tamamlanan hastanın silinme işlemi
        { 
            int i;
            for (i = 0; i < 9; i++)        //tedavisi biten hasta ilk hasta olacağından ilk değer tutulmayarak diziden silindi
            { 
                hasta[i]=hasta[i+1];
            }
           
            for (i = 0; i < 10; i++)            //hasta tedavi edildikten  sonra kalan dizinin durumu
                Console.WriteLine(hasta[i]);
            
            
            
        }
        public static void ınsert(int acil,int [] hasta)        // yeni hasta geldiğinde hasta durumunu belirleyen fonksiyon
        {
            int counter, sonuc, i, temp, j;                         //döngülerde kullanılmak üzere counter ve i,j sıralama içinde temp degişkeni 
            
                hasta[9] = acil;                                    //ilk olarak yeni gelen hasta dizide en sonda tutulur

                for (counter = (hasta.Length / 2) - 1; counter >= 0; counter--)      //for döngüsü içinde recursive fonk kullanıldı
                {
                    sonuc = max(counter, hasta.Length, hasta);
                }
                for (i = hasta.Length - 1; i >= 1; i--)              //for döngüsü içinde recursive fonk kullanılırken bu fonk gezici i değeri 1 azaltılarak gönderildi
                {
                    temp = hasta[0];
                    hasta[0] = hasta[i];
                    hasta[i] = temp;
                    sonuc = max(0, i - 1, hasta);

                }
                Console.WriteLine("yeni siralama");                 //gelen hastayla oluşan yeni sıralama ekrana yazdırıldı
                for (j = 0; j < 10;j++ )
                    Console.WriteLine(hasta[j]);
                
          
        }
            
           

        
        public static int max(int kok, int node, int[] hasta)       //dizideki en acil hastayı bulan fonksiyon
        {
            bool bitis = false;
            int dugum, gecici;                                  //fonksiyonda arada kullanılacak değişkenler
            int sonuc;
            while ((kok * 2 <= node) && (!bitis))               //döngüde parent ile sol ve sağ cocuklar karşılaştırılıyor
            {
                if (kok * 2 == node)
                    dugum = kok * 2;
                else if (hasta[kok * 2] > hasta[kok * 2 + 1])
                    dugum = kok * 2;
                else
                    dugum = kok * 2 + 1;
                if (hasta[kok] < hasta[dugum])              
                {
                    gecici = hasta[kok];
                    hasta[kok] = hasta[dugum];
                    hasta[dugum] = gecici;
                    kok = dugum;
                }
                else
                    bitis = true;
                



            }

            sonuc = hasta[0];
            return sonuc;
            
        }

        static void Main(string[] args)
        {
            int counter, i, temp;                                   //döngülerde kullanılmak üzere counter ve i sıralama içinde temp degişkeni 
            char s;                                                 // switch case yapısında durum değerlendirmesi için 
            int[] hasta = { 3, 1, 5, 4, 3, 1, 1, 2, 2, 4 };         // ilk durum diziye atandı
            int sonuc,acil;                                         //sonuc ve acil isimlerinde ara değişkenler üretildi
            while (true)
            {
                Console.WriteLine("en acili bulmak icin m giriniz");        //en acil hasta durumu için m  case ini çalıştırmak için
                Console.WriteLine();
                Console.WriteLine("tedavi edilmiş hastayi silmek icin e giriniz");      //tedavi edilmiş hastayı silmek için e  case ini çalıştırmak için
                Console.WriteLine();
                Console.WriteLine("yeni hasta girişi için i giriniz");                  //yeni hasta girişi için  i case ini çalıştırmak için
                Console.WriteLine();
                Console.WriteLine("değişen hasta durumu icin k  giriniz");              // değişen hasta durumu için k  case ini çalıştırmak için
                s = Convert.ToChar(Console.ReadLine());


                switch (s)
                {
                    case 'm':

                        for (counter = (hasta.Length / 2) - 1; counter >= 0; counter--)         //for döngüsü içinde recursive fonk kullanıldı
                        {
                            sonuc = max(counter, hasta.Length, hasta);
                        }
                        for (i = hasta.Length - 1; i >= 1; i--)                 //for döngüsü içinde recursive fonk kullanılırken bu fonk gezici i değeri 1 azaltılarak gönderildi
                        {
                            temp = hasta[0];
                            hasta[0] = hasta[i];
                            hasta[i] = temp;
                            sonuc = max(0, i - 1, hasta);

                        }
                        Console.Write("en önceliklisi = ");                 // öncelik sırasına göre en baştaki değer döndürüldü
                        Console.WriteLine(hasta[0]);
                      

                        break;
                    case 'i':
                        Console.WriteLine("hastanın aciliyet durumunu girimiz 1 ile 5 arasında");       //yeni hasta girişi
                        acil = Convert.ToInt32(Console.ReadLine());                                     //yeni hastanın aciliyet değeri
                        if (acil > 5)
                        {
                            Console.WriteLine("hatalı giriş 1 ile 5  arasında");                    //kullanıcının yanlış değer girmesini önlemek için
                            acil = Convert.ToInt32(Console.ReadLine());
                        }
                        else
                        {
                            ınsert(acil,hasta);                         //ınsert fonksiyonuna dizi ile birlikte hastanın aciliyet durumu gönderildi
                        }
                        break;
                    case'e':
                        delete(hasta);                                  //tedavi edilmiş hasta  delete fonksiyonuna gönderilerek silindi
                        break;
                    case'k':
                        degistir(hasta);                            //acilde bekleyen hastanın yeni durumu

                        break;


                   

                  
                    






                }


                

                    Console.ReadKey();


            }
        }
    }
}

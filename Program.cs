﻿namespace DonemSonuOdevi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Kaç öğrenci kaydetmek istiyorsunuz:");
                int giris = int.Parse(Console.ReadLine());
                string[,] ogrenci = new string[giris + 1, 7];
                ogrenci[0, 0] = "Öğrenci Numarası";
                ogrenci[0, 1] = "Öğrenci Adı";
                ogrenci[0, 2] = "Öğrenci Soyadı";
                ogrenci[0, 3] = "Vize Notu";
                ogrenci[0, 4] = "Final Notu";
                ogrenci[0, 5] = "Ortalama";
                ogrenci[0, 6] = "Harf Notu";
                double toportalama = 0;
                int maxNot = int.MinValue;
                int minNot = int.MaxValue;

                for (int i = 1; i <= giris; i++)
                {
                    Console.WriteLine($"{i}.Öğrencinin numarasını giriniz");
                    long numara = long.Parse(Console.ReadLine());
                    Console.WriteLine($"{i}.Öğrencinin adını giriniz");
                    string isim = Console.ReadLine();
                    Console.WriteLine($"{i}.Öğrencinin soyadını giriniz");
                    string soyisim = Console.ReadLine();
                    int vize;
                    do
                    {
                        Console.WriteLine($"{i}.Öğrencinin vize notunu giriniz (0-100)");
                        vize = int.Parse(Console.ReadLine());
                        if (vize < 0 || vize > 100)
                            Console.WriteLine("Lütfen belirtilen değerler arasında bir değer giriniz.");

                    }
                    while (vize < 0 || vize > 100);
                    int final;
                    do
                    {
                        Console.WriteLine($"{i}.Öğrencinin final notunu giriniz (0-100)");
                        final = int.Parse(Console.ReadLine());
                        if (final < 0 || final > 100)
                            Console.WriteLine("Lütfen belirtilen değerler arasında bir değer giriniz.");
                    }
                    while (final < 0 || final > 100);

                    double ortalama = vize * 0.4 + final * 0.6;
                    toportalama += ortalama;
                    maxNot = Math.Max(maxNot, Math.Max(vize, final));
                    minNot = Math.Min(minNot, Math.Min(vize, final));
                    string harfnotu = ortalama >= 85 ? "AA" :
                                      ortalama >= 75 ? "BA" :
                                      ortalama >= 60 ? "BB" :
                                      ortalama >= 50 ? "CB" :
                                      ortalama >= 40 ? "CC" :
                                      ortalama >= 30 ? "DC" :
                                      ortalama >= 20 ? "DD" :
                                      ortalama >= 10 ? "FD" : "FF";



                    ogrenci[i, 0] = numara.ToString();
                    ogrenci[i, 1] = isim;
                    ogrenci[i, 2] = soyisim;
                    ogrenci[i, 3] = vize.ToString();
                    ogrenci[i, 4] = final.ToString();
                    ogrenci[i, 5] = ortalama.ToString("0.00");
                    ogrenci[i, 6] = harfnotu;
                }
                double sınıfOrtalaması = toportalama / giris;

                Console.WriteLine("\nGirilen Öğrenci Bilgileri:");
                for (int i = 0; i <= giris; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        Console.Write(ogrenci[i, j].PadRight(15));
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("\nSınıf Bilgileri:");
                Console.WriteLine($"Sınıf Ortalaması: {sınıfOrtalaması:0.00}");
                Console.WriteLine($"En Yüksek Not: {maxNot}");
                Console.WriteLine($"En Düşük Not: {minNot}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata oluştu: {ex.Message}"); 
            }



        }
    }
}

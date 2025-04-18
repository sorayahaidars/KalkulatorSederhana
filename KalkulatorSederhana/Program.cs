using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Kalkulator Sederhana ===");
            Console.WriteLine("Selamat datang di aplikasi kalkulator!");

            bool lanjut = true;
            while (lanjut)
            {
                Console.WriteLine("\nPilih operasi:");
                Console.WriteLine("1. Penjumlahan (+)");
                Console.WriteLine("2. Pengurangan (-)");
                Console.WriteLine("3. Perkalian (*)");
                Console.WriteLine("4. Pembagian (/)");
                Console.WriteLine("5. Keluar");

                Console.Write("\nMasukkan pilihan (1-5): ");
                int pilihan = Convert.ToInt32(Console.ReadLine());

                if (pilihan == 5)
                {
                    lanjut = false;
                    Console.WriteLine("Terima kasih telah menggunakan kalkulator sederhana!");
                    continue;
                }

                Console.Write("Masukkan angka pertama: ");
                double angka1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Masukkan angka kedua: ");
                double angka2 = Convert.ToDouble(Console.ReadLine());

                double hasil = 0;
                string operasi = "";

                switch (pilihan)
                {
                    case 1:
                        hasil = angka1 + angka2;
                        operasi = "+";
                        break;
                    case 2:
                        hasil = angka1 - angka2;
                        operasi = "-";
                        break;
                    case 3:
                        hasil = angka1 * angka2;
                        operasi = "*";
                        break;
                    case 4:
                        if (angka2 != 0)
                        {
                            hasil = angka1 / angka2;
                            operasi = "/";
                        }
                        else
                        {
                            Console.WriteLine("Error: Pembagian dengan nol tidak diperbolehkan!");
                            continue;
                        }
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid!");
                        continue;
                }

                Console.WriteLine($"\nHasil: {angka1} {operasi} {angka2} = {hasil}");
            }
        }
    }
}
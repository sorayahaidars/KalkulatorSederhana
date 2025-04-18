using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Kalkulator Scientific ===");
            Console.WriteLine("Selamat datang di aplikasi kalkulator scientific!");

            bool lanjut = true;
            while (lanjut)
            {
                Console.WriteLine("\nPilih operasi:");
                Console.WriteLine("1. Penjumlahan (+)");
                Console.WriteLine("2. Pengurangan (-)");
                Console.WriteLine("3. Perkalian (*)");
                Console.WriteLine("4. Pembagian (/)");
                Console.WriteLine("5. Pangkat (^)");
                Console.WriteLine("6. Akar Kuadrat (√)");
                Console.WriteLine("7. Sinus (sin)");
                Console.WriteLine("8. Cosinus (cos)");
                Console.WriteLine("9. Tangen (tan)");
                Console.WriteLine("10. Logaritma (log)");
                Console.WriteLine("11. Keluar");

                Console.Write("\nMasukkan pilihan (1-11): ");
                int pilihan = Convert.ToInt32(Console.ReadLine());

                if (pilihan == 11)
                {
                    lanjut = false;
                    Console.WriteLine("Terima kasih telah menggunakan kalkulator scientific!");
                    continue;
                }

                double hasil = 0;
                string operasi = "";
                double angka1 = 0;
                double angka2 = 0;

                // Operasi yang membutuhkan dua angka
                if (pilihan >= 1 && pilihan <= 5 || pilihan == 10)
                {
                    Console.Write("Masukkan angka pertama: ");
                    angka1 = Convert.ToDouble(Console.ReadLine());

                    if (pilihan != 10) // Khusus logaritma hanya butuh satu angka tambahan (basis)
                    {
                        Console.Write("Masukkan angka kedua: ");
                        angka2 = Convert.ToDouble(Console.ReadLine());
                    }
                }
                // Operasi yang membutuhkan satu angka
                else if (pilihan >= 6 && pilihan <= 9)
                {
                    Console.Write("Masukkan angka: ");
                    angka1 = Convert.ToDouble(Console.ReadLine());
                }

                switch (pilihan)
                {
                    case 1: // Penjumlahan
                        hasil = angka1 + angka2;
                        operasi = $"{angka1} + {angka2}";
                        break;
                    case 2: // Pengurangan
                        hasil = angka1 - angka2;
                        operasi = $"{angka1} - {angka2}";
                        break;
                    case 3: // Perkalian
                        hasil = angka1 * angka2;
                        operasi = $"{angka1} * {angka2}";
                        break;
                    case 4: // Pembagian
                        if (angka2 != 0)
                        {
                            hasil = angka1 / angka2;
                            operasi = $"{angka1} / {angka2}";
                        }
                        else
                        {
                            Console.WriteLine("Error: Pembagian dengan nol tidak diperbolehkan!");
                            continue;
                        }
                        break;
                    case 5: // Pangkat
                        hasil = Math.Pow(angka1, angka2);
                        operasi = $"{angka1} ^ {angka2}";
                        break;
                    case 6: // Akar Kuadrat
                        if (angka1 >= 0)
                        {
                            hasil = Math.Sqrt(angka1);
                            operasi = $"√{angka1}";
                        }
                        else
                        {
                            Console.WriteLine("Error: Tidak bisa menghitung akar kuadrat dari angka negatif!");
                            continue;
                        }
                        break;
                    case 7: // Sinus
                        // Konversi ke radian karena Math.Sin menggunakan radian
                        hasil = Math.Sin(angka1 * Math.PI / 180);
                        operasi = $"sin({angka1}°)";
                        break;
                    case 8: // Cosinus
                        hasil = Math.Cos(angka1 * Math.PI / 180);
                        operasi = $"cos({angka1}°)";
                        break;
                    case 9: // Tangen
                        hasil = Math.Tan(angka1 * Math.PI / 180);
                        operasi = $"tan({angka1}°)";
                        break;
                    case 10: // Logaritma
                        if (angka1 > 0)
                        {
                            hasil = Math.Log(angka1, angka2 > 0 ? angka2 : Math.E);
                            operasi = angka2 > 0 ? $"log{angka2}({angka1})" : $"ln({angka1})";
                        }
                        else
                        {
                            Console.WriteLine("Error: Logaritma hanya dapat dihitung untuk angka positif!");
                            continue;
                        }
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid!");
                        continue;
                }

                Console.WriteLine($"\nHasil: {operasi} = {hasil}");
            }
        }
    }
}
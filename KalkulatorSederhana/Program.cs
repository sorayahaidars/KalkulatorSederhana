using System;

namespace SimpleCalculator
{
    class Program
    {
        // Konstanta untuk warna
        static ConsoleColor PRIMARY_COLOR = ConsoleColor.Cyan;
        static ConsoleColor SECONDARY_COLOR = ConsoleColor.Yellow;
        static ConsoleColor ERROR_COLOR = ConsoleColor.Red;
        static ConsoleColor RESULT_COLOR = ConsoleColor.Green;

        static void Main(string[] args)
        {
            DisplayHeader();

            bool lanjut = true;
            while (lanjut)
            {
                DisplayMenu();

                int pilihan = GetUserChoice();

                if (pilihan == 5)
                {
                    lanjut = false;
                    DisplayColoredText("Terima kasih telah menggunakan kalkulator sederhana!", SECONDARY_COLOR);
                    Console.WriteLine("\nTekan tombol apa saja untuk keluar...");
                    Console.ReadKey();
                    continue;
                }

                double angka1 = GetDoubleInput("Masukkan angka pertama: ");
                double angka2 = GetDoubleInput("Masukkan angka kedua: ");

                CalculateAndDisplayResult(pilihan, angka1, angka2);
            }
        }

        static void DisplayHeader()
        {
            Console.Clear();
            DisplayColoredText("╔════════════════════════════════╗", PRIMARY_COLOR);
            DisplayColoredText("║      KALKULATOR SEDERHANA      ║", PRIMARY_COLOR);
            DisplayColoredText("╚════════════════════════════════╝", PRIMARY_COLOR);
            Console.WriteLine();
            DisplayColoredText("Selamat datang di aplikasi kalkulator sederhana!", SECONDARY_COLOR);
            Console.WriteLine();
        }

        static void DisplayMenu()
        {
            Console.WriteLine();
            DisplayColoredText("╭───── MENU OPERASI ─────╮", PRIMARY_COLOR);
            Console.WriteLine("│                        │");
            Console.WriteLine("│  1. Penjumlahan (+)    │");
            Console.WriteLine("│  2. Pengurangan (-)    │");
            Console.WriteLine("│  3. Perkalian (*)      │");
            Console.WriteLine("│  4. Pembagian (/)      │");
            Console.WriteLine("│  5. Keluar             │");
            Console.WriteLine("│                        │");
            DisplayColoredText("╰────────────────────────╯", PRIMARY_COLOR);
            Console.WriteLine();
        }

        static void CalculateAndDisplayResult(int pilihan, double angka1, double angka2)
        {
            double hasil = 0;
            string operasi = "";
            bool hasilValid = true;

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
                        DisplayError("Pembagian dengan nol tidak diperbolehkan!");
                        hasilValid = false;
                    }
                    break;
                default:
                    DisplayError("Pilihan tidak valid!");
                    hasilValid = false;
                    break;
            }

            if (hasilValid)
            {
                Console.WriteLine();
                DisplayColoredText("╭───── HASIL PERHITUNGAN ─────╮", RESULT_COLOR);
                Console.WriteLine();
                DisplayColoredText($"  {angka1} {operasi} {angka2} = {hasil}", RESULT_COLOR);
                Console.WriteLine();
                DisplayColoredText("╰───────────────────────────────╯", RESULT_COLOR);

                // Tunggu pengguna menekan tombol untuk melanjutkan
                Console.WriteLine("\nTekan tombol apa saja untuk melanjutkan...");
                Console.ReadKey();
                Console.Clear();
                DisplayHeader();
            }
        }

        static void DisplayColoredText(string text, ConsoleColor color)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = prevColor;
        }

        static void DisplayError(string message)
        {
            Console.WriteLine();
            DisplayColoredText("ERROR: " + message, ERROR_COLOR);
            Console.WriteLine("\nTekan tombol apa saja untuk melanjutkan...");
            Console.ReadKey();
            Console.Clear();
            DisplayHeader();
        }

        static int GetUserChoice()
        {
            while (true)
            {
                Console.Write("Masukkan pilihan (1-5): ");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice >= 1 && choice <= 5)
                    {
                        return choice;
                    }
                    DisplayError("Pilihan harus antara 1-5!");
                }
                catch (FormatException)
                {
                    DisplayError("Masukan harus berupa angka!");
                }
                catch (Exception ex)
                {
                    DisplayError($"Terjadi kesalahan: {ex.Message}");
                }
            }
        }

        static double GetDoubleInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                try
                {
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    DisplayError("Masukan harus berupa angka!");
                }
                catch (Exception ex)
                {
                    DisplayError($"Terjadi kesalahan: {ex.Message}");
                }
            }
        }
    }
}
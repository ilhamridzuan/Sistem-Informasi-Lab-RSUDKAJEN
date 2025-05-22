using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("KuotaDaftar.json")
            .Build();


        int batasAntrian = int.Parse(config["KuotaHarian"]);
        var sistem = new SistemPendaftaran(batasAntrian);

        while (true)
        {
            Console.WriteLine("=== SISTEM PENDAFTARAN LABORATORIUM RSUD KAJEN ===");
            Console.WriteLine("1. Pendaftaran");
            Console.WriteLine("2. Antrian");
            Console.WriteLine("3. Keluar");
            Console.Write("Pilih menu: ");
            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    sistem.DaftarPasien();
                    break;
                case "2":
                    sistem.LihatAntrian();
                    break;
                case "3":
                    Console.WriteLine("Terima kasih!");
                    return;
                default:
                    Console.WriteLine("Pilihan tidak tersedia.\n");
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;

public class SistemPendaftaran
{
    private List<Pasien> daftarAntrian = new List<Pasien>();
    private int batasAntrian;

    public SistemPendaftaran(int batas)
    {
        batasAntrian = batas;
    }

    public void DaftarPasien()
    {
        if (daftarAntrian.Count >= batasAntrian)
        {
            Console.WriteLine("Maaf, kuota pendaftaran hari ini sudah penuh.\n");
            return;
        }

        Console.Write("Masukkan Nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan NIK: ");
        string nik = Console.ReadLine();

        Console.Write("Masukkan Keluhan: ");
        string keluhan = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(nik) || string.IsNullOrWhiteSpace(keluhan))
        {
            Console.WriteLine("Data tidak boleh kosong.\n");
            return;
        }

        if (nik.Length != 16 || !long.TryParse(nik, out _))
        {
            Console.WriteLine("NIK harus 16 digit angka.\n");
            return;
        }

        Pasien p = new Pasien
        {
            NomorAntrian = daftarAntrian.Count + 1,
            Nama = nama,
            NIK = nik,
            Keluhan = keluhan,
            WaktuDaftar = DateTime.Now
        };

        daftarAntrian.Add(p);

        Console.WriteLine($"\nPendaftaran berhasil. Nomor antrian Anda: {p.NomorAntrian}\n");
    }

    public void LihatAntrian()
    {
        Console.WriteLine("\n=== DAFTAR ANTRIAN HARI INI ===");
        if (daftarAntrian.Count == 0)
        {
            Console.WriteLine("Belum ada pasien yang mendaftar.\n");
            return;
        }

        foreach (var p in daftarAntrian)
        {
            Console.WriteLine($"{p.NomorAntrian}. {p.Nama} | NIK: {p.NIK} | Keluhan: {p.Keluhan} | Waktu: {p.WaktuDaftar}");
        }
        Console.WriteLine();
    }
}

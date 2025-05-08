using System;

public class Antrian
{
    public string NamaPasien { get; set; } = "";
    public string JenisPemeriksaan { get; set; } = "";
    public DateTime TanggalDaftar { get; set; } = DateTime.Now;
    public string NomorAntrian { get; set; } = "";
}

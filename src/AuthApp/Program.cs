using System;

enum AppState
{
    Start,
    Login,
    Register,
    Success,
    Error,
    Exit
}

class Program
{
    static void Main()
    {
        AppState state = AppState.Start;

        while (state != AppState.Exit)
        {
            switch (state)
            {
                case AppState.Start:
                    Console.Clear();
                    Console.WriteLine("=== Aplikasi Login & Registrasi ===");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Register");
                    Console.WriteLine("3. Keluar");
                    Console.Write("Pilih menu: ");
                    string input = Console.ReadLine();

                    state = input switch
                    {
                        "1" => AppState.Login,
                        "2" => AppState.Register,
                        "3" => AppState.Exit,
                        _ => AppState.Error
                    };
                    break;

                case AppState.Login:
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    if (UserService.Login(username, password))
                        state = AppState.Success;
                    else
                        state = AppState.Error;
                    break;

                case AppState.Register:
                    Console.Write("Username baru: ");
                    string newUser = Console.ReadLine();
                    Console.Write("Password: ");
                    string newPass = Console.ReadLine();

                    if (UserService.Register(newUser, newPass))
                        Console.WriteLine("Registrasi berhasil!");
                    else
                        Console.WriteLine("Registrasi gagal.");

                    state = AppState.Start;
                    Pause();
                    break;

                case AppState.Success:
                    Console.WriteLine("Login berhasil! Selamat datang.");
                    state = AppState.Start;
                    Pause();
                    break;

                case AppState.Error:
                    Console.WriteLine("Terjadi kesalahan atau input tidak valid.");
                    state = AppState.Start;
                    Pause();
                    break;
            }
        }

        Console.WriteLine("Terima kasih telah menggunakan aplikasi ini.");
    }

    static void Pause()
    {
        Console.WriteLine("Tekan Enter untuk melanjutkan...");
        Console.ReadLine();
    }
}

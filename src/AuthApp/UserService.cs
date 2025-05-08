using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public static class UserService
{
    private static string dataFile = "users.json";

    public static List<User> LoadUsers()
    {
        try
        {
            if (!File.Exists(dataFile))
                return new List<User>();

            string json = File.ReadAllText(dataFile);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
        catch
        {
            Console.WriteLine("Gagal membaca data user. File rusak?");
            return new List<User>();
        }
    }

    public static void SaveUsers(List<User> users)
    {
        try
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dataFile, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Gagal menyimpan data user: {ex.Message}");
        }
    }

    public static bool Register(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Username dan password tidak boleh kosong.");
            return false;
        }

        var users = LoadUsers();
        if (users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Username sudah terdaftar.");
            return false;
        }

        users.Add(new User { Username = username, Password = password });
        SaveUsers(users);
        return true;
    }

    public static bool Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Username dan password tidak boleh kosong.");
            return false;
        }

        var users = LoadUsers();
        return users.Any(u => u.Username == username && u.Password == password);
    }
}

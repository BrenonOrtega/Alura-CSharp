// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text.Json;

Console.WriteLine("Hello, World!");

using var rsa = RSA.Create();

using var file = File.Create(@"..\\secretKeys.json");

await JsonSerializer
    .SerializeAsync(file,
        new { publicKey = rsa.ExportRSAPublicKey(), privateKey = rsa.ExportRSAPrivateKey() });

file.Close();
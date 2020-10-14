using KdbSharp.Data;
using KdbSharp.IPC;
using System;

namespace KdbSharp.RemoteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using var connection = args.Length > 0 ? new KdbConnection(args[0] ?? "localhost", 1234) : new KdbConnection("localhost", 1234);
            connection.Open();
            while (connection.IsOpen)
            {
                Console.Write("q)");
                var input = Console.ReadLine();
                if (input == @"\\")
                {
                    connection.Close();
                    connection.Open();
                }
                else
                {
                    var response = connection.Send(input);
                    Console.WriteLine(response switch
                    {
                        KdbLongAtom la => la.Value,
                        _ => throw new NotImplementedException(),
                    });
                }
            }
        }
    }
}

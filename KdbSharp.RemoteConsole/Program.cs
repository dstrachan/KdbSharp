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
            var result = connection.Send(new KdbGuidAtom(Guid.NewGuid()));
            Console.WriteLine(result);
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
                        KdbList x => x.Value,
                        KdbBoolAtom x => x.Value,
                        KdbBoolVector x => x.Value,
                        KdbGuidAtom x => x.Value,
                        KdbByteAtom x => x.Value,
                        KdbByteVector x => x.Value,
                        KdbShortAtom x => x.Value,
                        KdbShortVector x => x.Value,
                        KdbIntAtom x => x.Value,
                        KdbIntVector x => x.Value,
                        KdbLongAtom x => x.Value,
                        KdbLongVector x => x.Value,
                        KdbRealAtom x => x.Value,
                        KdbRealVector x => x.Value,
                        KdbFloatAtom x => x.Value,
                        KdbFloatVector x => x.Value,
                        KdbCharAtom x => x.Value,
                        KdbCharVector x => new string(x.Value),
                        KdbSymbolAtom x => x.Value,
                        KdbSymbolVector x => x.Value,
                        KdbTimestampAtom x => x.Value,
                        KdbTimestampVector x => x.Value,
                        KdbMonthAtom x => x.Value,
                        KdbMonthVector x => x.Value,
                        KdbDateAtom x => x.Value,
                        KdbDateVector x => x.Value,
                        KdbDatetimeAtom x => x.Value,
                        KdbDatetimeVector x => x.Value,
                        KdbTimespanAtom x => x.Value,
                        KdbTimespanVector x => x.Value,
                        KdbMinuteAtom x => x.Value,
                        KdbMinuteVector x => x.Value,
                        KdbSecondAtom x => x.Value,
                        KdbSecondVector x => x.Value,
                        KdbTimeAtom x => x.Value,
                        KdbTimeVector x => x.Value,
                        _ => throw new NotImplementedException(),
                    });
                }
            }
        }
    }
}

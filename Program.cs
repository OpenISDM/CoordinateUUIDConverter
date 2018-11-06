using System;
using System.Collections.Generic;
using System.Globalization;

namespace CoordinateUUIDConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                var consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong number of parameters");
                Console.ForegroundColor = consoleColor;
                Environment.Exit( 0 );
            }

            if (args[0].ToLower() != "-touuid" && args[0].ToLower() != "-tocoordinate")
            {
                var consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong of parameters");
                Console.ForegroundColor = consoleColor;
                Environment.Exit( 0 );
            }

            if (args[0].ToLower() == "-touuid")
            {
                List<Coordinate> coordinates = new List<Coordinate>();
                for (int i = 1; i < args.Length; i++)
                    try
                    {
                        string[] buffer = args[i].Split(',');

                        if (buffer.Length == 2)
                            coordinates.Add(new Coordinate(
                                float.Parse(buffer[0], CultureInfo.InvariantCulture.NumberFormat),
                                float.Parse(buffer[1], CultureInfo.InvariantCulture.NumberFormat),
                                1));
                        else
                            coordinates.Add(new Coordinate (
                                float.Parse(buffer[0], CultureInfo.InvariantCulture.NumberFormat),
                                float.Parse(buffer[1], CultureInfo.InvariantCulture.NumberFormat),
                                float.Parse(buffer[2], CultureInfo.InvariantCulture.NumberFormat)
                            ));
                    }
                    catch(Exception ex)
                    {
                        var consoleColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("The {0} coordinate format is incorrect. {1}", i, ex.Message);
                        Console.ForegroundColor = consoleColor;
                    }

                ToUUIDProcess(coordinates);
            }

            if (args[0].ToLower() == "-tocoordinate")
            {
                List<Guid> ids = new List<Guid>();
                for (int i = 1; i < args.Length; i++)
                    try
                    {
                        ids.Add(Guid.Parse(args[i]));
                    }
                    catch
                    {
                        var consoleColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("UUID format is incorrect.  {0}" ,args[i]);
                        Console.ForegroundColor = consoleColor;
                    }

                ToCoordinateProcess(ids);
            }
        }

        private static void ToUUIDProcess(List<Coordinate> coordinates)
        {
            foreach(Coordinate coordinate in coordinates)
                Console.WriteLine("({0},{1},{2}): {3}", 
                    coordinate.Latitude,
                    coordinate.Longitude, 
                    coordinate.Floor, 
                    coordinate.ToUUID());
        }

        private static void ToCoordinateProcess(List<Guid> ids)
        {
            foreach (Guid id in ids)
            {
                Coordinate coordinate = id.ToCoordinate();
                Console.WriteLine("UUID: {0}, ({1},{2},{3})", 
                    id.ToString(), 
                    coordinate.Latitude, 
                    coordinate.Longitude, 
                    coordinate.Floor);
            }
        }
    }
}

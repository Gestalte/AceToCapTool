using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AceToCapTool
{
    class Program
    {
        // NOTE: exe should be in !Workshop\@ace folder

        public static string AceFolderPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        public static string optionalsFolder = Path.Combine(AceFolderPath, "optionals");
        public static string addonsFolder = Path.Combine(AceFolderPath, "addons");

        static readonly List<string> OptionalDirectories = new List<string>
            {
                @"@ace_compat_rhs_afrf3\addons",
                @"@ace_compat_rhs_gref3\addons",
                @"@ace_compat_rhs_usf3\addons",
                @"@ace_noactionmenu\addons",
                @"@ace_nocrosshair\addons",
                @"@ace_nouniformrestrictions\addons",
                @"@ace_particles\addons",
                @"@ace_realisticdispersion\addons",
                @"@ace_tracers\addons",
            };

        static void Main(string[] args)
        {
            InputLoop();
        }

        static void InputLoop()
        {
            WriteColorLine("To copy optional files to addons folder type \"c\", to remove optional files type \"r\" to exit this program type \"e\".",
                ConsoleColor.DarkYellow, false, true);

            var key = Console.ReadKey().KeyChar.ToString().ToLower();

            EmptyLine();

            switch (key)
            {
                case "e":
                    Environment.Exit(0);
                    break;
                case "c":
                    AddOptionals();
                    break;
                case "r":
                    RemoveOptionals();
                    break;
            }

            EmptyLine();
            InputLoop();
        }

        static void WriteColorLine(string message, ConsoleColor color, bool emptyLineBefore = true, bool emptyLineAfter = false)
        {
            if (emptyLineBefore)
                EmptyLine();

            Console.ForegroundColor = color;
            Console.WriteLine(message);

            if (emptyLineAfter)
                EmptyLine();
        }

        static void EmptyLine()
        {
            Console.WriteLine("");
        }

        static List<string> getOptionalPathList()
            => OptionalDirectories
            .Select(m => Path.Combine(optionalsFolder, m))
            .SelectMany(GetAllFiles)
            .ToList();

        static void AddOptionals()
        {
            TryAction(() =>
            {
                getOptionalPathList()
                .ForEach(f => File.Copy(f, Path.Combine(addonsFolder, Path.GetFileName(f)), true));

                WriteColorLine("All Optional files have been copied.", ConsoleColor.Green);
            });
        }

        static void RemoveOptionals()
        {
            TryAction(() =>
            {
                getOptionalPathList()
               .Select(m => Path.GetFileName(m))
               .ToList()
               .ForEach(f => File.Delete(Path.Combine(addonsFolder, f)));

                WriteColorLine("All Optional files have been removed.", ConsoleColor.Green);
            });
        }

        static void TryAction(Action a)
        {
            try
            {
                a();
            }
            catch (Exception e)
            {
                WriteColorLine($"ERROR: {e.Message}", ConsoleColor.Red);
            }
        }

        static List<string> GetAllFiles(string path)
            => Directory.GetFiles(path).ToList();
    }
}

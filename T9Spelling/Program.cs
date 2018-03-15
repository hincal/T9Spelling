using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace T9Spelling
{
    public class Program
    {
        private static Dictionary<char, string> map = new Dictionary<char, string>
            {
                { 'a', "2" }, { 'b', "22" }, { 'c', "222" },
                { 'd', "3" }, { 'e', "33" }, { 'f', "333" },
                { 'g', "4" }, { 'h', "44" }, { 'i', "444" },
                { 'j', "5" }, { 'k', "55" }, { 'l', "555" },
                { 'm', "6" }, { 'n', "66" }, { 'o', "666" },
                { 'p', "7" }, { 'q', "77" }, { 'r', "777" }, { 's', "7777" },
                { 't', "8" }, { 'u', "88" }, { 'v', "888" },
                { 'w', "9" }, { 'x', "99" }, { 'y', "999" }, { 'z', "9999" },
                { ' ', "0" }
            };

        static void Main(string[] args)
        {
            var testFilePath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path)) + "\\TestFiles";
            var smallFilePath = $"{testFilePath}\\C-small-practice.in";
            var largeFilePath = $"{testFilePath}\\C-large-practice.in";

            ProcessFile(smallFilePath, 15);
            ProcessFile(largeFilePath, 1000);

            Console.WriteLine("Files have been processed.");
            Console.WriteLine();
            Console.WriteLine("Please press enter to continue...");
            Console.ReadLine();
        }

        /// <summary>
        /// This method generates T9 Spelled output file in the same directory with input file.
        /// </summary>
        /// <param name="filePath">Full path of input file</param>
        /// <returns>Full path of converted file</returns>
        public static string ProcessFile(string filePath, int maxLineLength)
        {
            var fileContent = File.ReadAllLines(filePath);
            if (!int.TryParse(fileContent.First(), out int fileSize))
                throw new FormatException();

            var output = new string[fileSize];

            for (int i = 1; i <= fileSize; i++)
            {
                var sb = new StringBuilder();

                var input = fileContent[i];
                //  Checking if line length is longer then desired length
                var lineLength = input.Count() > maxLineLength ? maxLineLength : input.Count();
                for (int j = 0; j < lineLength; j++)
                {
                    try
                    {
                        var ch = input[j];
                        //  Checking if current and previous chars are same..
                        if (j != 0 && map[input[j - 1]].First() == map[ch].First())
                            sb.Append(" ");
                        sb.Append(map[ch]);
                    }
                    catch (KeyNotFoundException)
                    {
                        continue;
                    }
                }
                output[i - 1] = String.Format("Case #{0}: {1}", i, sb.ToString().Trim());
            }

            var outputPath = filePath.Substring(0, filePath.LastIndexOf(".") + 1) + "out";
            File.WriteAllLines(outputPath, output);
            return outputPath;
        }
    }
}

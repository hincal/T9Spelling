using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

namespace T9Spelling.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestWithNonRecurringMap()
        {
            var folderPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path)) + "\\TestFiles";
            var inputFilePath = $"{folderPath}\\testFile.in";

            var input = new string[] { "1", "world" };
            var expected = new string[] { "Case #1: 96667775553" };

            File.WriteAllLines(inputFilePath, input);

            var outputPath = Program.ProcessFile(inputFilePath, 15);
            var actual = File.ReadAllLines(outputPath);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWithRecurringMap()
        {
            var folderPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path)) + "\\TestFiles";
            var inputFilePath = $"{folderPath}\\testFile.in";

            var input = new string[] { "1", "hello" };
            var expected = new string[] { "Case #1: 4433555 555666" };

            File.WriteAllLines(inputFilePath, input);

            var outputPath = Program.ProcessFile(inputFilePath, 15);
            var actual = File.ReadAllLines(outputPath);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWithSpaceAndRecurringMap()
        {
            var folderPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path)) + "\\TestFiles";
            var inputFilePath = $"{folderPath}\\testFile.in";

            var input = new string[] { "1", "hello world" };
            var expected = new string[] { "Case #1: 4433555 555666096667775553" };

            File.WriteAllLines(inputFilePath, input);

            var outputPath = Program.ProcessFile(inputFilePath, 15);
            var actual = File.ReadAllLines(outputPath);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWithIllegalCharacter()
        {
            var folderPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path)) + "\\TestFiles";
            var inputFilePath = $"{folderPath}\\testFile.in";

            var input = new string[] { "1", "hello world!" };
            var expected = new string[] { "Case #1: 4433555 555666096667775553" };

            File.WriteAllLines(inputFilePath, input);

            var outputPath = Program.ProcessFile(inputFilePath, 15);
            var actual = File.ReadAllLines(outputPath);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWithMultipleLines()
        {
            var folderPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path)) + "\\TestFiles";
            var inputFilePath = $"{folderPath}\\testFile.in";

            var input = new string[] { "2", "hello", "world" };
            var expected = new string[] { "Case #1: 4433555 555666", "Case #2: 96667775553" };

            File.WriteAllLines(inputFilePath, input);

            var outputPath = Program.ProcessFile(inputFilePath, 15);
            var actual = File.ReadAllLines(outputPath);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestForMaxLineLengthWithMultipleLines()
        {
            var folderPath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path)) + "\\TestFiles";
            var inputFilePath = $"{folderPath}\\testFile.in";

            var input = new string[] { "2", "hllo", "world" };
            var expected = new string[] { "Case #1: 44555 555666", "Case #2: 9666777555" };

            File.WriteAllLines(inputFilePath, input);

            var outputPath = Program.ProcessFile(inputFilePath, 4);
            var actual = File.ReadAllLines(outputPath);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

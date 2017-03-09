using System;
using System.IO;

namespace SomeApp
{
    class BadClass
    {
        static void Main(string[] args)
        {
            MultiTextWriter Writer = new MultiTextWriter();
            Writer.AddWriter(Console.Out);
            TextWriter fileWriter = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\tasty.txt");
            Writer.AddWriter(fileWriter);
            Console.SetOut(Writer);
            Program.Main(args);
            fileWriter.Close();
        }
    }
}

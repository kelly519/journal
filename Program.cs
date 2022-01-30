using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace berkay5
{
    class Program
    {
        private string JournalFile = "MyJournal.txt";
        public void Run()
        {
            DisplayIntro();
            CreateJournalFile();

            AddEntry();
            DisplayJournalContents();
            //ClearFile();
            //DisplayJournalContents();

            DisplayOutro();
            
        }

        private void CreateJournalFile() 
        {
            WriteLine($"Does file exist? {File.Exists("MyJournal.txt")}");
            if(!File.Exists("JournalFile"))
            {
                File.CreateText("JournalFile");
            }
        }

        private void DisplayIntro()
        {

            WriteLine("Jean-Luc Picard’s journal.");
            ReadKey(true);
        }

        private void DisplayOutro() 
        {
            WriteLine("Thanks for using the journal.");
            ReadKey(true);
        }

        private void WaitForKey ()
        {
            WriteLine("\nPress any key... ");
            ReadKey(true);
        }

        private void DisplayJournalContents()
        {
            string journalText = File.ReadAllText(JournalFile);
            WriteLine("\n=== Journal === ");
            WriteLine(journalText);
            WriteLine("====================");
            WaitForKey();
        }
        private void ClearFile() 
        {
            File.WriteAllText(JournalFile, "");
            WriteLine("\nJournal cleared!");
            WaitForKey();
        }

        private void AddEntry() 
        {
            WriteLine("\n What would you like to add: ");
            string newLine = ReadLine();
            File.AppendAllText(JournalFile, $"\nEntry:\n> {newLine}\n");
            WriteLine("The journal has been modified!");
            WaitForKey();
        }
    }
}

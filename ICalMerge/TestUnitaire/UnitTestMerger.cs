using ICalMerge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTestMerger
    {
        [TestMethod]
        public void TestMerger()
        {
            // Données qui vont servir à tester la fusion. Seulement les deux calendriers dev^ront être pris en compte
            string[] calendarLines1 = { "BEGIN:VEVENT", "SUMMARY:","DTSTART:","DTEND:", "END:VEVENT"};
            string[] unvalidFile = { "keyboard", "mouse", "Invalid data" };
            string[] calendarLines2 = { "BEGIN:VEVENT", "SUMMARY:", "DTSTART:", "DTEND:", "END:VEVENT" };

            string stringDesiredResult = "BEGIN:VEVENT\nSUMMARY:\nDTSTART:\nDTEND:\nEND:VEVENT\nBEGIN:VEVENT\nSUMMARY:\nDTSTART:\nDTEND:\nEND:VEVENT\n";

            // Regroupement des tableaux dans une liste.
            List<string[]> listData = new List<string[]>
            {
                calendarLines1,
                unvalidFile,
                calendarLines2
            };

            // Création d'un Merger. Il nous permettra de tester la fusion.
            Merger testedMerger = new Merger();

            // Parcourt les données à fusionner
            foreach(string[] stringDataArray in listData)
            {
                // Le Merger testera si les données sont valides.
                testedMerger.AddContentToFuse(stringDataArray);
            }

            Assert.AreEqual(stringDesiredResult, testedMerger.StrAllMergedLines);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICalMerge
{
    /// <summary>
    /// Cette classe permet de s'occuper de toute la partie concernant la fusion de fichier
    /// </summary>
    class Merger
    {
        // Variables constantes
        const string BACKSLASH_N = "\n";

        // Constantes - propriété fichier ical
        const string EVENT_PROPERTY_VEVENT = "VEVENT";
        const string EVENT_PROPERTY_BEGIN = "BEGIN";
        const string EVENT_PROPERTY_END = "END";
        const string END_VCALENDAR = "END:VCALENDAR";
        const string BEGIN_FUSED_CALENDAR = "BEGIN:VCALENDAR\nCALSCALE:GREGORIAN\n";

        // Contiendra tous les événements de touts les calendriers. Les premières lignes servent à définir le début du calendrier
        private string strAllMergedLines;

        // Encapsulation
        public string StrAllMergedLines { get => strAllMergedLines; set => strAllMergedLines = value; }

        /// <summary>
        /// Permet de fusionner tous le contenu des fichiers entrés en un string.
        /// </summary>
        public void FuseContent(ProgressBar pbLoadMerge, List<SourceComponents> listSources, SaveFileDialog sfdSaveMergedCalendar, Label lblFusion)
        {
            // On vide les données fusionnées pour la nouvelle fusion
            strAllMergedLines = "";
            strAllMergedLines += BEGIN_FUSED_CALENDAR;

            // Définit si la ligne traitée appartient à un événement
            bool boolIsCopyingEvent = false;

            // Parcourt tous les SourceComponents
            foreach (SourceComponents calendar in listSources)
            {
                // Parcourt les données des sources components
                foreach (string line in calendar.AllLines)
                {
                    // Vérifie si la  ligne correspond au début d'un événement
                    if (line.Split(':')[0] == EVENT_PROPERTY_BEGIN && line.Split(':')[1] == EVENT_PROPERTY_VEVENT)
                    {
                        boolIsCopyingEvent = true; // Définit que le programme doit copier les prochaine slignes non reconnues. Car elles appartiendront forcéement à un événement

                        // On ajoute la ligne à la chaîne de données à copier
                        StrAllMergedLines += line + BACKSLASH_N;

                    } // Vérifie si c'est la fin d'un événement
                    else if (line.Split(':')[0] == EVENT_PROPERTY_END && line.Split(':')[1] == EVENT_PROPERTY_VEVENT)
                    {
                        boolIsCopyingEvent = false;

                        // On ajoute la ligne à la chaîne de données à copier
                        StrAllMergedLines += line + BACKSLASH_N;

                        // Incrémentation de la valeur de la barre de progression.
                        pbLoadMerge.Value += 1;
                    }
                    else
                    {
                        // Vérifie 
                        if (boolIsCopyingEvent == true)
                        {
                            // On ajoute la ligne à la chaîne de données à copier
                            StrAllMergedLines += line + BACKSLASH_N;
                        }
                    }
                }
            }

            // On ajoute la donnée qui définit la fin d'un calendrier.
            StrAllMergedLines += END_VCALENDAR;
        }


    }
}

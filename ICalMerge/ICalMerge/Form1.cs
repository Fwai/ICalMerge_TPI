using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ICalMerge
{
    public partial class formIcal : Form
    {
        // Variables constantes
        const string BACKSLASH_N = "\n";
        // Sert à la fusion de fichiers
        const string BEGIN_FUSED_CALENDAR = "BEGIN:VCALENDAR\nCALSCALE:GREGORIAN\n";
        const string END_FUSED_FILE_MESSAGE1 = "Fusion terminée avec ";
        const string END_FUSED_FILE_MESSAGE2 = " événements exportés";

        // Propriété fichier ical
        const string EVENT_PROPERTY_VEVENT = "VEVENT";
        const string EVENT_PROPERTY_BEGIN = "BEGIN";
        const string EVENT_PROPERTY_END = "END";

        // Messages d'erreur
        const string ERROR_MAX_CREATED_FILES = "La limite de fichiers source a été atteinte";
        const string ERROR_MINIMUM_FILES = "Le programme nécessite deux sources au minimum";
        const string ERROR_INVALID_FILES = "Un ou plusieurs fichiers ne sont pas valides. Veuillez vérifier les sources KO.";
        const string ERROR_UNMATCHED_EVENT_NUMBER = "Le nombre d'événements fusionnés ne correspond pas au nombre d'événements à fusionner.";
        /* Définit une liste de sources. Les sources ont des composants visuels
           ainsi que des valeurs pouvant stocker le chemin d'une source définie par l'utilisateur. */
        List<SourceComponents> listSources;

        /// <summary>
        /// Constructeur de la classe formIcal.
        /// </summary>
        public formIcal()
        {
            InitializeComponent();

            listSources = new List<SourceComponents>();

            // Nous ajoutons deux champs source.
            AddSource();
            AddSource();
        }

        /// <summary>
        /// Permet d'ajouter un nouveau champ de source. Il s'ajoutera à la liste de sources.
        /// </summary>
        private void AddSource()
        {
            // Vérifie si l'on a atteint la limite de sources maximale.
            if (listSources.Count == 10)
            {
                // Comme il y'a déjà le maximum de sources, nous prévenons l'utilisateur grâce à un message box.
                MessageBox.Show(ERROR_MAX_CREATED_FILES);
            }
            else
            {
                // Création d'une nouvelle source
                SourceComponents newSource = new SourceComponents(pnlSources, Convert.ToSByte(listSources.Count()), pnlFusion, this, opfdChooseFile);
                listSources.Add(newSource);
            }

        }

        /// <summary>
        /// Permet d'initier la supression d'une source. Se produit seulement si il
        /// y en a plus que deux
        /// </summary>
        private void RemoveSource()
        {
            // Si l'utilisateur essaie de supprimer une des deux sources restantes.
            if (listSources.Count == 2)
            {
                // Il faut un minimum de deux sources donc on affiche un message d'erreur.
                MessageBox.Show(ERROR_MINIMUM_FILES);
            }
            else
            {
                // Permet de détruire la dernière source ajoutée.
                listSources[listSources.Count - 1].Destruct(pnlSources, pnlFusion, this);
                listSources[listSources.Count - 1] = null;
                listSources.RemoveAt(listSources.Count - 1);
            }

        }

        /// <summary>
        /// Se produit quand l'utilisateur clique sur le bouton d'ajout. permet d'appeler la méthode d'ajout de source
        /// </summary>
        /// <param name="sender">Désigne le contrôle qui apelle la méthode</param>
        /// <param name="e"></param>
        private void BtnAddSource_Click(object sender, EventArgs e)
        {
            AddSource();
        }

        /// <summary>
        /// Se produit lorsque l'on clique sur le bouton de supression d'une source
        /// </summary>
        /// <param name="sender">Désigne le contrôle qui apelle la méthode</param>
        /// <param name="e"></param>
        private void BtnRemoveSource_Click(object sender, EventArgs e)
        {
            RemoveSource();
        }

        /// <summary>
        /// La méthode se lance quand l'utilisateur clique sur le bouton"Fusionner"
        /// </summary>
        /// <param name="sender">Désigne le contrôle qui apelle la méthode</param>
        /// <param name="e"></param>
        private void BtnFusion_Click(object sender, EventArgs e)
        {
            MergeICSFiles();
        }

        /// <summary>
        /// Gère la fusion des données.
        /// </summary>
        private void MergeICSFiles()
        {
            // On vérifie si tous les fichiers sont valides
            foreach (SourceComponents calendar in listSources)
            {
                // Vérifie que le fichier concerné est valide
                if (calendar.IsFileValidated == false)
                {
                    MessageBox.Show(ERROR_INVALID_FILES);
                    return; // Si le fichier n'est pas valide, on arrête la méthode
                }
            }

            // Minimum de la barre de progression
            pbLoadMerge.Minimum = 0;
            // Mise à zéro du maximum de la barre de progression. Car de base elle est à 100
            pbLoadMerge.Maximum = 0;
            // Remet à zéro la valeur de la barre de progression
            pbLoadMerge.Value = 0;

            // Définition du maximum de la barre d eprogression. Correspond au nombre d'événement total à ajouter
            foreach (SourceComponents calendar in listSources)
            {
                // On modifie le mximum 
                pbLoadMerge.Maximum += calendar.EventsNumber;
            }

            // Contiendra tous les événements de touts les calendriers. Les premières lignes servent à définir le début du calendrier
            string strAllMergedLines = BEGIN_FUSED_CALENDAR;

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
                        strAllMergedLines += line + BACKSLASH_N;

                    } // Vérifie si c'est la fin d'un événement
                    else if (line.Split(':')[0] == EVENT_PROPERTY_END && line.Split(':')[1] == EVENT_PROPERTY_VEVENT)
                    {
                        boolIsCopyingEvent = false;

                        // On ajoute la ligne à la chaîne de données à copier
                        strAllMergedLines += line + BACKSLASH_N;

                        // Incrémentation de la valeur de la barre de progression.
                        pbLoadMerge.Value += 1;
                    }
                    else
                    {
                        // Vérifie 
                        if (boolIsCopyingEvent == true)
                        {
                            // On ajoute la ligne à la chaîne de données à copier
                            strAllMergedLines += line + BACKSLASH_N;
                        }
                    }
                }
            }

            // vérifie que le nombre d'événement traité correspond au nombre d'événements à traiter
            if (pbLoadMerge.Value== pbLoadMerge.Maximum)
            {
                // On ouvre la fenêtre d'importation et l'on vérifie que l'utilisateur aie correctement entré un emplacement et un nom de fichier.
                if (sfdSaveMergedCalendar.ShowDialog() == DialogResult.OK)
                {
                    // Avertissement à l'utilisateur pour dire que la fusion est terminée.
                    lblFusion.Text = END_FUSED_FILE_MESSAGE1 + Convert.ToString(pbLoadMerge.Value) + END_FUSED_FILE_MESSAGE2;

                    // On exporte les données dans à l'endroit choisi par l'utilisateur. Le nom de fichier est inclut dans le chemin.
                    File.WriteAllText(sfdSaveMergedCalendar.FileName, strAllMergedLines);

                    // On recharge tous les fichiers. Si un utilisateur a importé les calendriers dans un fichier source, il sera actualisé.
                    foreach (SourceComponents calendar in listSources)
                    {
                        calendar.VerifyFileIntegrity();
                    }
                }
            }
            else
            {
                // Si le nombre d'événements total à fusionner ne correspond pas au nombre d'événements ayant été fusionnés.
                MessageBox.Show(ERROR_UNMATCHED_EVENT_NUMBER);
            }
            
        }
    }
}

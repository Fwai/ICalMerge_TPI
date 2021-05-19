using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ICalMerge
{
    public partial class formIcal : Form
    {
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
                MessageBox.Show("La limite de fichiers source a été atteinte");
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
            if (listSources.Count == 2)
            {
                MessageBox.Show("Le programme nécessite deux sources au minimum");
            }
            else
            {
                listSources[listSources.Count - 1].Destruct(pnlSources, pnlFusion, this);
                listSources[listSources.Count - 1] = null;
                listSources.RemoveAt(listSources.Count - 1);
            }

        }

        /// <summary>
        /// Se produit quand l'utilisateur clique sur le bouton d'ajout. permet d'appeler la méthode d'ajout de source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddSource_Click(object sender, EventArgs e)
        {
            AddSource();
        }

        /// <summary>
        /// Se produit lorsque l'on clique sur le bouton de supression d'une source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveSource_Click(object sender, EventArgs e)
        {
            RemoveSource();
        }

        private void BtnFusion_Click(object sender, EventArgs e)
        {
            MergeICSFiles();
        }

        private void MergeICSFiles()
        {
            // On vérifie si tous les fichiers sont valides
            foreach (SourceComponents calendar in listSources)
            {
                // Vérifie que le fichier concerné est valide
                if(calendar.IsFileValidated == false)
                {
                    MessageBox.Show("Un ou plusieurs fichiers ne sont pas valides. Veuillez vérifier les sources KO.");
                    return; // Si le fichier n'est pas valide, on arrête la méthode
                }
            }

            // Contienndra tous les événements de touts les calendriers.
            List<string> allMergedLines = new List<string>();


            // Définit si la ligne traitée appartient à un événement
            bool copyingEvent = false;

            // Parcourt tous les SourceComponents
            foreach (SourceComponents calendar in listSources)
            {
                // Parcourt les données des sources components
                foreach (string line in calendar.AllLines)
                {
                    if (line.Split(':')[0] == "BEGIN" && line.Split(':')[1] == "VEVENT")
                    {
                        copyingEvent = true; // Définit que le programme doit copier les prochaine slignes non reconnues. Car elles appartiendront forcéement à un événement

                        // On ajoute la ligne à la liste de données à copier
                        allMergedLines.Add(line);
                    }
                    else if (line.Split(':')[0] == "END" && line.Split(':')[1] == "VEVENT")
                    {
                        copyingEvent = false;

                        // On ajoute la ligne à la liste de données à copier
                        allMergedLines.Add(line);
                    }
                    else
                    {
                        // Vérifie 
                        if (copyingEvent == true)
                        {
                            // On ajoute la ligne à la liste de données à copier
                            allMergedLines.Add(line);
                        }
                    }
                }
            }

            TextWriter tw = new StreamWriter(fbdChooseFolder.RootFolder + "SavedList.txt");

            foreach (String s in allMergedLines)
                tw.WriteLine(s);

            tw.Close();


        }
    }
}

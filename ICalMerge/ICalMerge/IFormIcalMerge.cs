using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ICalMerge
{
    public partial class IFormIcalMerge : Form
    {

        // Messages d'erreur
        const string ERROR_MAX_CREATED_FILES = "La limite de fichiers source a été atteinte";
        const string ERROR_MINIMUM_FILES = "Le programme nécessite deux sources au minimum";
        const string ERROR_INVALID_FILES = "Un ou plusieurs fichiers ne sont pas valides. Veuillez vérifier les sources KO.";

        // Constantes - Donne des informations sur le résultat de la fusion
        const string END_FUSED_FILE_MESSAGE1 = "Fusion terminée avec ";
        const string END_FUSED_FILE_MESSAGE2 = " événements exportés";
        const string ERROR_UNMATCHED_EVENT_NUMBER = "Le nombre d'événements fusionnés ne correspond pas au nombre d'événements à fusionner.";

        // Formulaire d'aide
        IFormHelp FhFormHelp;

        // Classe qui permet de gérer la fusion de fichiers
        Merger MergerObject;

        /* Définit une liste de sources. Les sources ont des composants visuels
           ainsi que des valeurs pouvant stocker le chemin d'une source définie par l'utilisateur. */
        private List<SourceComponents> listSources;

        /// <summary>
        /// Constructeur de la classe formIcal.
        /// </summary>
        public IFormIcalMerge()
        {
            InitializeComponent();

            listSources = new List<SourceComponents>();

            // Nous ajoutons deux champs source.
            AddSource();
            AddSource();

            // On créer un nouveau Merger pour qu'il puisse gérer la fusion.
            MergerObject = new Merger();

            // On créer un nouveau formulaire d'aide
            FhFormHelp = new IFormHelp();
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

            // Définition du maximum de la barre de progression. Correspond au nombre d'événement total à ajouter
            foreach (SourceComponents calendar in listSources)
            {
                // On modifie le mximum 
                pbLoadMerge.Maximum += calendar.EventsNumber;
            }

            MergerObject.FuseContent(pbLoadMerge, listSources, sfdSaveMergedCalendar, lblFusion);

            // vérifie que le nombre d'événement traité correspond au nombre d'événements à traiter
            if (pbLoadMerge.Value == pbLoadMerge.Maximum)
            {
                // On ouvre la fenêtre d'importation et l'on vérifie que l'utilisateur aie correctement entré un emplacement et un nom de fichier.
                if (sfdSaveMergedCalendar.ShowDialog() == DialogResult.OK)
                {
                    // Avertissement à l'utilisateur pour dire que la fusion est terminée.
                    lblFusion.Text = END_FUSED_FILE_MESSAGE1 + Convert.ToString(pbLoadMerge.Value) + END_FUSED_FILE_MESSAGE2;

                    // On exporte les données dans à l'endroit choisi par l'utilisateur. Le nom de fichier est inclut dans le chemin.
                    // l'Objet MERGER est utilisé pour la fusion des données.
                    File.WriteAllText(sfdSaveMergedCalendar.FileName, MergerObject.StrAllMergedLines);

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

        // Permet d'ouvrir le formulaire d'aide lorsque l'utilisateur clique sur le label "Aide".
        private void LblAide_Click(object sender, EventArgs e)
        {
            OpenformHelp();
        }

        /// <summary>
        /// S'active lorsque l'utilisateur clique sur son clavier. Cela vérifiera si il a cliqué sur F1.
        /// Si c'est le cas, la page d'aide s'ouvre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.F1)
            {
                OpenformHelp();
            }
        }

        /// <summary>
        /// Permet d'ouvrir une page d'aide.
        /// </summary>
        public void OpenformHelp()
        {
            FhFormHelp.Close();
            FhFormHelp = new IFormHelp();
            FhFormHelp.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

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
                SourceComponents newSource = new SourceComponents(pnlSources, Convert.ToSByte(listSources.Count()),pnlFusion,this,opfdOpenFile);
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
                listSources.RemoveAt(listSources.Count-1);
            }

        }

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

    }
}

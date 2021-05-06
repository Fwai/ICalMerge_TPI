using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICalMerge
{
    class SourceComponents
    {
        private Panel pnlContainer;

        // Ce sont tous les contrôles qui vont être affichés visuellement à l'utilisateur.
        private Label lblSourceName;
        private TextBox tbSourcePath;
        private Button btnBrowse;
        private Label lblEventResult;

        // Encapsulation des variables 
        public Label LblSourceName { get => lblSourceName; set => lblSourceName = value; }
        public TextBox TbSourcePath { get => tbSourcePath; set => tbSourcePath = value; }
        public Button BtnBrowse { get => btnBrowse; set => btnBrowse = value; }
        public Label LblEventResult { get => lblEventResult; set => lblEventResult = value; }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="pnlContainer">Permet de définir dans quel panel les contrôles vont se trouver</param>
        /// <param name="location">Définit à quelle position les contrôles se trouveront. Exemple : la position 0 définit la pemière position. La position 9 signifie la dixième et dernière position.</param>
        public SourceComponents(Panel pnlContainer, sbyte location)
        {
            this.pnlContainer = pnlContainer;
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ICalMerge
{
    class SourceComponents
    {
        // Définit l'espace entre vertical entre chaque ligne de contrôles de sources. Un contrôle est un élément visuel.
        const sbyte SPACE_BETWEEN_CONTROLS_LINES = 30;

        // Définit la police du premier label. Celui qui définira le numéro de la source. Exemple : "Source 5"
        const string SOURCE_LABEL_FONT = "Microsoft Sans Serif";

        // Contient "Source". Permet de le faire suivre du numéro de la source.
        const string SOURCE_TEXT = "Source ";

        // Text qui sera appliqué aux boutons d'exploration de fichiers
        const string EXPLORER_BUTTON_TEXT = "parcourir";

        // Text de base. Il est affiché en attendant qu'il soit changé par la vérification du nombre d'événements.
        const string DEFAULT_TEXT_EVENT_RESULT = "Analyse attendue";

        // Ce sont tous les contrôles qui vont être affichés visuellement à l'utilisateur.
        private Label lblSourceName; // Permet d'afficher le titre et le numéro de la source. Exemple "Source 2"
        private TextBox tbSourcePath; // Permet à l'utilisateur de voir le chemin de son fichier et de le changer à la main 
        private Button btnBrowse; // Permet à l'utilisateur d'ouvrir une fenêtre lui permettant d'importer un fichier
        private Label lblEventResult; // Permet d'afficher le nombre d'événements que contient le fichier.

        // Encapsulation des variables 
        public Label LblSourceName { get => lblSourceName; set => lblSourceName = value; }
        public TextBox TbSourcePath { get => tbSourcePath; set => tbSourcePath = value; }
        public Button BtnBrowse { get => btnBrowse; set => btnBrowse = value; }
        public Label LblEventResult { get => lblEventResult; set => lblEventResult = value; }



        /// <summary>
        /// Constructeur de la classe. Il permet de créer les contrôles et de les afficher
        /// </summary>
        /// <param name="pnlContainer">Permet de définir dans quel panel les contrôles vont se trouver.</param>
        /// <param name="location">Définit à quelle position les contrôles se trouveront. Exemple : la position 0 définit la pemière position. La position 9 signifie la dixième et dernière position.</param>
        /// <param name="pnlFusion">Définit la panel contenant les contrôles qui servent à la fusion. </param>
        /// <param name="mainForm">Définit le formulaire principal.</param>
        public SourceComponents(Panel pnlContainer, sbyte location, Panel pnlFusion, Form mainForm)
        {
            // On ajoute un espacement seulement pour les sources additionnelles. Les deux premières sources ont déjà une place suffisante.
            if (location>=2)
            {
                pnlContainer.Size = new System.Drawing.Size(pnlContainer.Size.Width, pnlContainer.Size.Height + 30);
                pnlFusion.Location = new System.Drawing.Point(pnlFusion.Location.X, pnlFusion.Location.Y+ 30);
                mainForm.Size = new System.Drawing.Size(mainForm.Size.Width, mainForm.Size.Height+30);
            }

            // Affichage des contrôles
            ShowSourceControls(pnlContainer, location);
        }


        /// <summary>
        /// Permet d'afficher tous les contrôles nécessaires à la récupération d'un fichier source.
        /// </summary>
        /// <param name="pnlContainer">Panel qui va contenir les contrôles</param>
        /// <param name="location"></param>
        private void ShowSourceControls(Panel pnlContainer, sbyte location)
        {
            // Affiche le premier label Ex : "Source 4"
            LblSourceName = new Label(); // On initialise le label
            LblSourceName.Font = new System.Drawing.Font(SOURCE_LABEL_FONT, 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblSourceName.Location = new System.Drawing.Point(0, location * SPACE_BETWEEN_CONTROLS_LINES);
            LblSourceName.Size = new System.Drawing.Size(68, 18);
            LblSourceName.Text = SOURCE_TEXT + Convert.ToString(location + 1);
            lblSourceName.AutoSize = true;

            // Ajout d'un textBox
            TbSourcePath = new TextBox(); // On initialise le textBox
            TbSourcePath.Location = new System.Drawing.Point(82, 1 + location * SPACE_BETWEEN_CONTROLS_LINES);
            TbSourcePath.Size = new System.Drawing.Size(457, 20);

            // Ajout du bouton de recherche de fichier
            BtnBrowse = new Button();
            BtnBrowse.Location = new System.Drawing.Point(545, 1+location*SPACE_BETWEEN_CONTROLS_LINES);
            BtnBrowse.Size = new System.Drawing.Size(75, 23);
            BtnBrowse.Text = EXPLORER_BUTTON_TEXT;
            BtnBrowse.UseVisualStyleBackColor = true;

            // Ajout du label permettant d'afficher le nombre d'événements
            LblEventResult = new Label();
            LblEventResult.AutoSize = true;
            LblEventResult.Font = new System.Drawing.Font(SOURCE_LABEL_FONT, 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblEventResult.Location = new System.Drawing.Point(626, 4+ location*SPACE_BETWEEN_CONTROLS_LINES);
            LblEventResult.Size = new System.Drawing.Size(110, 15);
            LblEventResult.Text = DEFAULT_TEXT_EVENT_RESULT;

            // Ajout des contrôles au panel
            pnlContainer.Controls.Add(LblSourceName);
            pnlContainer.Controls.Add(TbSourcePath);
            pnlContainer.Controls.Add(BtnBrowse);
            pnlContainer.Controls.Add(LblEventResult);
        }

        /// <summary>
        /// Permet de détruire tous ses contrôles et de rétablir 
        /// </summary>
        /// <param name="pnlContainer">Panel qui contient les contrôles de cet objet</param>
        /// <param name="pnlFusion">Panel en dessous de pnlContainer</param>
        /// <param name="mainForm">Formulaire principal</param>
        public void Destruct(Panel pnlContainer, Panel pnlFusion, Form mainForm)
        {
            pnlContainer.Size = new System.Drawing.Size(pnlContainer.Size.Width, pnlContainer.Size.Height - 30);
            pnlFusion.Location = new System.Drawing.Point(pnlFusion.Location.X, pnlFusion.Location.Y - 30);
            mainForm.Size = new System.Drawing.Size(mainForm.Size.Width, mainForm.Size.Height - 30);

            LblSourceName = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ICalMerge
{
    /// <summary>
    /// Cette classe permet de recevoir toutes les informations concernant les fich
    /// </summary>
    public class SourceComponents
    {
        // Définit l'espace entre vertical entre chaque ligne de contrôles de sources. Un contrôle est un élément visuel.
        const sbyte SPACE_BETWEEN_CONTROLS_LINES = 30;

        // Définit la police du premier label. Celui qui définira le numéro de la source. Exemple : "Source 5"
        const string SOURCE_LABEL_FONT = "Microsoft Sans Serif";

        // Contient "Source". Permet de le faire suivre du numéro de la source.
        const string SOURCE_TEXT = "Source ";

        // Texte qui sera appliqué aux boutons d'exploration de fichiers
        const string EXPLORER_BUTTON_TEXT = "parcourir";

        // Texte de base. Il est affiché en attendant qu'il soit changé par la vérification du nombre d'événements.
        const string DEFAULT_TEXT_EVENT_RESULT = "Analyse attendue";

        // Texte du message d'erreur si l'utilisateur entre un fichier qui n'est pas au format .ics
        const string ERROR_MESSAGE_WRONG_FILE_TYPE = "Le type de fichier n'est pas valide. Veuillez insérer uniquement des fichiers avec l'extension .ics";

        // Contient le nom du type de fichier voulu. Donc "ics". Il est le numéro 1 car à l'avenir il se pourrait que quelqu'un reprenne le programme et veuille fusionner d'autre type de fichiers.
        const string FILE_TYPE1 = "ics";

        // Texte à afficher si le fichier importé invalide
        const string INVALID_FILE_PATH = "KO: Chemin invalide"; // Chemin invalide
        const string INVALID_FILE_CONTENT = "KO: 0 événement";

        //Texte à afficher si le fichier importé est valide
        const string VALID_FILE_CALENDAR_OK = "OK: ";
        const string VALID_FILE_CALENDAR_SINGLE = " événement";
        const string VALID_FILE_CALENDAR_MULTIPLE = " événements";

        // Propriété fichier ical
        const string EVENT_PROPERTY_VEVENT = "VEVENT";
        const string EVENT_PROPERTY_BEGIN = "BEGIN";
        const string FILE_EXTENSION_NAME = "ics";


        // Ce sont tous les contrôles qui vont être affichés visuellement à l'utilisateur.
        private Label lblSourceName; // Permet d'afficher le titre et le numéro de la source. Exemple "Source 2"
        private TextBox tbSourcePath; // Permet à l'utilisateur de voir le chemin de son fichier et de le changer à la main 
        private Button btnBrowse; // Permet à l'utilisateur d'ouvrir une fenêtre lui permettant d'importer un fichier
        private Label lblEventResult; // Permet d'afficher le nombre d'événements que contient le fichier.
        private OpenFileDialog opfdOpenFile; // Permet de recevoir un chemin de fichier

        // Contient les lignes du fichier
        private string[] allLines;

        // contient le nombre d'événements du fichier. Il aurait été possible d'utiliser un ushort, mais dans ces cas extrêmes il pourraît être possible qu'un calendrier contienne plus que 65'535
        private int eventsNumber;

        // Sert à définir si le fichier a été validé
        private bool isFileValidated;

        // Liste des contrôles servant à ajouter une source.
        List<Control> listControls;

        // Encapsulation des variables 
        public Label LblSourceName { get => lblSourceName; set => lblSourceName = value; }
        public TextBox TbSourcePath { get => tbSourcePath; set => tbSourcePath = value; }
        public Button BtnBrowse { get => btnBrowse; set => btnBrowse = value; }
        public Label LblEventResult { get => lblEventResult; set => lblEventResult = value; }
        public OpenFileDialog OpfdOpenFile { get => opfdOpenFile; set => opfdOpenFile = value; }
        public int EventsNumber { get => eventsNumber; set => eventsNumber = value; }
        public bool IsFileValidated { get => isFileValidated; set => isFileValidated = value; }
        public string[] AllLines { get => allLines; set => allLines = value; }



        /// <summary>
        /// Constructeur de la classe. Il permet de créer les contrôles et de les afficher
        /// </summary>
        /// <param name="pnlContainer">Permet de définir dans quel panel les contrôles vont se trouver.</param>
        /// <param name="location">Définit à quelle position les contrôles se trouveront. Exemple : la position 0 définit la pemière position. La position 9 signifie la dixième et dernière position.</param>
        /// <param name="pnlFusion">Définit la panel contenant les contrôles qui servent à la fusion. </param>
        /// <param name="mainForm">Définit le formulaire principal.</param>
        public SourceComponents(Panel pnlContainer, sbyte location, Panel pnlFusion, Form mainForm, OpenFileDialog opfdOpenFile)
        {
            isFileValidated = false;
            this.opfdOpenFile = opfdOpenFile;
            // On ajoute un espacement seulement pour les sources additionnelles. Les deux premières sources ont déjà une place suffisante.
            if (location >= 2)
            {
                // On redimensionne le formulaire contenant les SourceComponents, le formulaire principal et le panel servant à la fusion.
                // Cela permet de faire la place nécessaire à l'ajout d'une source.
                pnlContainer.Size = new System.Drawing.Size(pnlContainer.Size.Width, pnlContainer.Size.Height + SPACE_BETWEEN_CONTROLS_LINES);
                pnlFusion.Location = new System.Drawing.Point(pnlFusion.Location.X, pnlFusion.Location.Y + SPACE_BETWEEN_CONTROLS_LINES);
                mainForm.MaximumSize = new System.Drawing.Size(mainForm.Size.Width, mainForm.Size.Height + SPACE_BETWEEN_CONTROLS_LINES);
                mainForm.MinimumSize = new System.Drawing.Size(mainForm.Size.Width, mainForm.Size.Height + SPACE_BETWEEN_CONTROLS_LINES);
                mainForm.Size = new System.Drawing.Size(mainForm.Size.Width, mainForm.Size.Height + SPACE_BETWEEN_CONTROLS_LINES);
            }

            // Affichage des contrôles
            ShowSourceControls(pnlContainer, location);
        }


        /// <summary>
        /// Permet d'afficher tous les contrôles nécessaires à la récupération d'un fichier source.
        /// </summary>
        /// <param name="pnlContainer">Panel qui va contenir les contrôles</param>
        /// <param name="location">numéro de la position</param>
        private void ShowSourceControls(Panel pnlContainer, sbyte location)
        {
            // Affiche le premier label Ex : "Source 4"
            LblSourceName = new Label(); // On initialise le label
            LblSourceName.Font = new System.Drawing.Font(SOURCE_LABEL_FONT, 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblSourceName.Location = new System.Drawing.Point(0, location * SPACE_BETWEEN_CONTROLS_LINES + 1);
            LblSourceName.Size = new System.Drawing.Size(68, 18);
            LblSourceName.Text = SOURCE_TEXT + Convert.ToString(location + 1);
            lblSourceName.AutoSize = true;

            // Ajout d'un textBox
            TbSourcePath = new TextBox(); // On initialise le textBox
            TbSourcePath.Location = new System.Drawing.Point(82, 1 + location * SPACE_BETWEEN_CONTROLS_LINES + 1);
            TbSourcePath.Size = new System.Drawing.Size(457, 20);
            TbSourcePath.BackColor = System.Drawing.SystemColors.Window;
            tbSourcePath.AllowDrop = true; // Fait en sorte que le contrôle accepte de "glisser déposer"
            tbSourcePath.DragOver += AllowDrop; // On ajoute la méthode permettant d'autoriser le glisser déposer.
            TbSourcePath.DragDrop += DropFileOver; // Permet de déposer un fichier sur le contrôle;
            tbSourcePath.TextChanged += TextBoxTextChanged; // Vérifie l'intégrité du fichier entré à chaque modification de texte.
            // On ajoute la méthode qui permettra de choisir un fichier via un OpenFiledialog
            TbSourcePath.MouseDoubleClick += ClickOpenFile;

            // Ajout du bouton de recherche de fichier
            BtnBrowse = new Button();
            BtnBrowse.Location = new System.Drawing.Point(545, 1 + location * SPACE_BETWEEN_CONTROLS_LINES);
            BtnBrowse.Size = new System.Drawing.Size(75, 23);
            BtnBrowse.Text = EXPLORER_BUTTON_TEXT;
            BtnBrowse.UseVisualStyleBackColor = true;
            BtnBrowse.MouseClick += ClickOpenFile; // On ajoute la méthode qui permettra de choisir un fichier via un OpenFiledialog

            // Ajout du label permettant d'afficher le nombre d'événements
            LblEventResult = new Label();
            LblEventResult.AutoSize = true;
            LblEventResult.Font = new System.Drawing.Font(SOURCE_LABEL_FONT, 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblEventResult.Location = new System.Drawing.Point(626, 4 + location * SPACE_BETWEEN_CONTROLS_LINES);
            LblEventResult.Size = new System.Drawing.Size(110, 15);
            LblEventResult.Text = DEFAULT_TEXT_EVENT_RESULT;

            // Ajout des contrôles au panel
            pnlContainer.Controls.Add(LblSourceName);
            pnlContainer.Controls.Add(TbSourcePath);
            pnlContainer.Controls.Add(BtnBrowse);
            pnlContainer.Controls.Add(LblEventResult);

            listControls = new List<Control>();
            // On regroupe les contrôles dans une liste
            listControls.Add(LblSourceName);
            listControls.Add(tbSourcePath);
            listControls.Add(btnBrowse);
            listControls.Add(lblEventResult);


        }

        /// <summary>
        /// Permet de détruire tous ses contrôles et de rétablir 
        /// </summary>
        /// <param name="pnlContainer">Panel qui contient les contrôles de cet objet</param>
        /// <param name="pnlFusion">Panel en dessous de pnlContainer</param>
        /// <param name="mainForm">Formulaire principal</param>
        public void Destruct(Panel pnlContainer, Panel pnlFusion, Form mainForm)
        {
            pnlContainer.Size = new System.Drawing.Size(pnlContainer.Size.Width, pnlContainer.Size.Height - SPACE_BETWEEN_CONTROLS_LINES);
            pnlFusion.Location = new System.Drawing.Point(pnlFusion.Location.X, pnlFusion.Location.Y - SPACE_BETWEEN_CONTROLS_LINES);
            mainForm.MinimumSize = new System.Drawing.Size(mainForm.Size.Width, mainForm.Size.Height - SPACE_BETWEEN_CONTROLS_LINES);
            mainForm.MaximumSize = new System.Drawing.Size(mainForm.Size.Width, mainForm.Size.Height - SPACE_BETWEEN_CONTROLS_LINES);
            mainForm.Size = new System.Drawing.Size(mainForm.Size.Width, mainForm.Size.Height - SPACE_BETWEEN_CONTROLS_LINES);


            foreach (Control control in listControls)
            {
                control.Hide();
            }
        }

        /// <summary>
        /// Permet d'ouvrir une boîte de dialogue qui permettra à l'utilisateur de choisir un fichier.
        /// </summary>
        /// <param name="sender">Contrôle qui appelle la méthode</param>
        /// <param name="e">Détermine le type de méthode. Permet de donner les informations
        /// sur la manière dont l'utilisateur utilise la souris</param>
        private void ClickOpenFile(object sender, MouseEventArgs e)
        {
            // Vérifie que l'utilisateur aie importé un fichier
            if (opfdOpenFile.ShowDialog() == DialogResult.OK)
            {
                TbSourcePath.Text = opfdOpenFile.FileName;
            }
        }

        /// <summary>
        /// Cette méthode sert à glisser un fichier .ics sur un champ de texte.
        /// Cette méthode a été crée grâce au tutoriel d'André de Mattos Ferraz sur https://www.c-sharpcorner.com/
        /// Lien : https://www.c-sharpcorner.com/blogs/drag-and-drop-file-on-windows-forms1
        /// </summary>
        /// <param name="sender">Objet qui appelle la méthode</param>
        /// <param name="e">objet qui contient les méthodes permettant de gérer le glisser-déposer</param>
        private void AllowDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Cette méthode sert à déposer un fichier sur l'objet qui l'appelle (sender). 
        /// La méthode vérifie que le fichier déposé soit au bon format
        /// Une partie de la méthode a été créee grâce au tutoriel d'André de Mattos Ferraz sur https://www.c-sharpcorner.com/
        /// Lien : https://www.c-sharpcorner.com/blogs/drag-and-drop-file-on-windows-forms1
        /// </summary>
        /// <param name="sender">Objet qui appelle la méthode</param>
        /// <param name="e">objet qui contient les méthodes permettant de gérer le glisser-déposer</param>
        private void DropFileOver(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // Reçoit tous les fichiers déposés
            if (files != null && files.Any())
            {
                // Vérification de l'extension du fichier
                if (files.First().Split('.')[files.First().Split('.').Length - 1] == FILE_TYPE1)
                {
                    tbSourcePath.Text = files.First(); // Choisit le premier fichier
                }
                else
                {
                    // L'extension n'est pas valide, donc nous mettons l'utilisateur au courant
                    MessageBox.Show(ERROR_MESSAGE_WRONG_FILE_TYPE);
                }
            }
        }

        /// <summary>
        /// Événement qui s'active à chaque fois que la zone de texte est modifiée.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            VerifyFileIntegrity();
        }

        /// <summary>
        /// Vérifie les critères suivants:
        /// - La validité du chemin du fichier
        /// - La validité du type de fichier
        /// - La validité du contenu du fichier
        /// - Le nombre d'événement que contient le fichier
        /// </summary>
        public void VerifyFileIntegrity()
        {
            // Remise à zéro du nombre d'événements
            EventsNumber = 0;

            //Vérifie que le chemin du fichier est valide
            if (File.Exists(tbSourcePath.Text))
            {

                AllLines = File.ReadAllLines(tbSourcePath.Text);

                foreach (string line in AllLines)
                {
                    if (line.Split(':')[0] == EVENT_PROPERTY_BEGIN && line.Split(':')[1] == EVENT_PROPERTY_VEVENT)
                    {
                        EventsNumber++;
                    }
                }
                switch (EventsNumber)
                {
                    case 0:
                        // Comme le fichier ne contient aucun événements, c'est un KO et on l'affiche à l'utilisateur
                        lblEventResult.Text = INVALID_FILE_CONTENT;
                        isFileValidated = false; // On s'assure que le fichier soit considéré comme invalide.
                        break;

                    case 1:
                        lblEventResult.Text = VALID_FILE_CALENDAR_OK + Convert.ToString(EventsNumber) + VALID_FILE_CALENDAR_SINGLE;
                        isFileValidated = true; // On définit le fichier comme valide
                        break;

                    default:
                        lblEventResult.Text = VALID_FILE_CALENDAR_OK + Convert.ToString(EventsNumber) + VALID_FILE_CALENDAR_MULTIPLE;
                        isFileValidated = true;// On définit le fichier comme valide
                        break;
                }
            }
            else
            {
                // comme le chemin very le fichier est invalide, c'est un KO et on l'affiche à l'utilisateur
                lblEventResult.Text = INVALID_FILE_PATH;
            }
        }
    }
}


namespace ICalMerge
{
    partial class IFormHelp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IFormHelp));
            this.lblIntro = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblText1 = new System.Windows.Forms.Label();
            this.btnAddSource = new System.Windows.Forms.Button();
            this.btnRemoveSource = new System.Windows.Forms.Button();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblText2 = new System.Windows.Forms.Label();
            this.pnlSource = new System.Windows.Forms.Panel();
            this.lbltext3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbLoadMerge = new System.Windows.Forms.ProgressBar();
            this.btnFusion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCloseHelp = new System.Windows.Forms.Button();
            this.ofdExample = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.Location = new System.Drawing.Point(163, 72);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(475, 40);
            this.lblIntro.TabIndex = 0;
            this.lblIntro.Text = "Le programme sert à fusionner plusieurs calendriers ical entre eux.\r\nPour cela, i" +
    "l vous faudra suivre les étapes ci-dessous.";
            this.lblIntro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Aide ICalMerge";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(14, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(773, 2);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblStep1
            // 
            this.lblStep1.AutoSize = true;
            this.lblStep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep1.Location = new System.Drawing.Point(276, 136);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(248, 24);
            this.lblStep1.TabIndex = 3;
            this.lblStep1.Text = "1. Nombre de calendriers";
            this.lblStep1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblText1
            // 
            this.lblText1.AutoSize = true;
            this.lblText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText1.Location = new System.Drawing.Point(124, 160);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(553, 80);
            this.lblText1.TabIndex = 4;
            this.lblText1.Text = "Vous devrez définir le nombre de calendriers à fusionner.\r\nPour cela vous avez de" +
    "ux boutons qui permettent d\'en ajouter et d\'en effacer.\r\nMinimum: deux sources\r\n" +
    "Maximum: dix sources";
            this.lblText1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAddSource
            // 
            this.btnAddSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSource.Location = new System.Drawing.Point(320, 248);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(160, 34);
            this.btnAddSource.TabIndex = 7;
            this.btnAddSource.Text = "Ajouter une source";
            this.btnAddSource.UseVisualStyleBackColor = true;
            // 
            // btnRemoveSource
            // 
            this.btnRemoveSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveSource.Location = new System.Drawing.Point(320, 248);
            this.btnRemoveSource.Name = "btnRemoveSource";
            this.btnRemoveSource.Size = new System.Drawing.Size(160, 34);
            this.btnRemoveSource.TabIndex = 8;
            this.btnRemoveSource.Text = "Retirer une source";
            this.btnRemoveSource.UseVisualStyleBackColor = true;
            // 
            // lblStep2
            // 
            this.lblStep2.AutoSize = true;
            this.lblStep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblStep2.Location = new System.Drawing.Point(272, 308);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(256, 24);
            this.lblStep2.TabIndex = 9;
            this.lblStep2.Text = "2. Importation des sources";
            this.lblStep2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblText2
            // 
            this.lblText2.AutoSize = true;
            this.lblText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText2.Location = new System.Drawing.Point(143, 332);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(514, 40);
            this.lblText2.TabIndex = 10;
            this.lblText2.Text = "Vous pourrez importer les fichiers en appuyant sur le bouton \"parcourir\".\r\nVous p" +
    "ouvez tester cette fonctionnalité via l\'exemple suivant:";
            this.lblText2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlSource
            // 
            this.pnlSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSource.Location = new System.Drawing.Point(23, 375);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.Size = new System.Drawing.Size(755, 26);
            this.pnlSource.TabIndex = 13;
            // 
            // lbltext3
            // 
            this.lbltext3.AutoSize = true;
            this.lbltext3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltext3.Location = new System.Drawing.Point(132, 406);
            this.lbltext3.Name = "lbltext3";
            this.lbltext3.Size = new System.Drawing.Size(536, 100);
            this.lbltext3.TabIndex = 14;
            this.lbltext3.Text = resources.GetString("lbltext3.Text");
            this.lbltext3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(277, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "3. Fusion des calendriers";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbLoadMerge
            // 
            this.pbLoadMerge.Location = new System.Drawing.Point(245, 687);
            this.pbLoadMerge.Name = "pbLoadMerge";
            this.pbLoadMerge.Size = new System.Drawing.Size(310, 23);
            this.pbLoadMerge.TabIndex = 17;
            this.pbLoadMerge.Value = 50;
            // 
            // btnFusion
            // 
            this.btnFusion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusion.Location = new System.Drawing.Point(245, 592);
            this.btnFusion.Name = "btnFusion";
            this.btnFusion.Size = new System.Drawing.Size(310, 38);
            this.btnFusion.TabIndex = 16;
            this.btnFusion.Text = "Fusionner";
            this.btnFusion.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 549);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(626, 40);
            this.label3.TabIndex = 18;
            this.label3.Text = "Le bouton \"Fusionner\" vous permettra de lancer la fusion.\r\nPour pouvoir l\'utilise" +
    "r, il vous faut avoir importé toutes les sources et qu\'elles soient \"OK\".";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 644);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(686, 40);
            this.label4.TabIndex = 19;
            this.label4.Text = "Pendant la fusion, une barre de progression vous permettra de suivre la progressi" +
    "on de la fusion.\r\nVoici à quoi elle ressemble quand elle est chargée à 50%.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(148, 739);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(505, 60);
            this.label5.TabIndex = 20;
            this.label5.Text = "Lorsque la fusion sera terminée,\r\nil vous faudra choisir le nom du fichier, ainsi" +
    " que l\'endroit où le stocker.\r\nAprès cela, il vous suffira de cliquer sur \"ok\" p" +
    "our terminer l\'exportation.\r\n";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCloseHelp
            // 
            this.btnCloseHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseHelp.Location = new System.Drawing.Point(628, 836);
            this.btnCloseHelp.Name = "btnCloseHelp";
            this.btnCloseHelp.Size = new System.Drawing.Size(160, 34);
            this.btnCloseHelp.TabIndex = 21;
            this.btnCloseHelp.Text = "Fermer l\'aide";
            this.btnCloseHelp.UseVisualStyleBackColor = true;
            this.btnCloseHelp.Click += new System.EventHandler(this.BtnCloseHelp_Click);
            // 
            // ofdExample
            // 
            this.ofdExample.FileName = "openFileDialog1";
            this.ofdExample.Filter = "Calendrier|*.ics|Tous les fichiers|*.*";
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 882);
            this.Controls.Add(this.btnCloseHelp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbLoadMerge);
            this.Controls.Add(this.btnFusion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbltext3);
            this.Controls.Add(this.pnlSource);
            this.Controls.Add(this.lblText2);
            this.Controls.Add(this.lblStep2);
            this.Controls.Add(this.btnRemoveSource);
            this.Controls.Add(this.btnAddSource);
            this.Controls.Add(this.lblText1);
            this.Controls.Add(this.lblStep1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIntro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 921);
            this.MinimumSize = new System.Drawing.Size(816, 921);
            this.Name = "FormHelp";
            this.ShowIcon = false;
            this.Text = "Aide";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.Button btnAddSource;
        private System.Windows.Forms.Button btnRemoveSource;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.Panel pnlSource;
        private System.Windows.Forms.Label lbltext3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbLoadMerge;
        private System.Windows.Forms.Button btnFusion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCloseHelp;
        private System.Windows.Forms.OpenFileDialog ofdExample;
    }
}
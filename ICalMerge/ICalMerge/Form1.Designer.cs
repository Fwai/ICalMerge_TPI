namespace ICalMerge
{
    partial class formIcal
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddSource = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemoveSource = new System.Windows.Forms.Button();
            this.pnlSources = new System.Windows.Forms.Panel();
            this.pnlFusion = new System.Windows.Forms.Panel();
            this.lblFusion = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnFusion = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.pnlFusion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddSource
            // 
            this.btnAddSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSource.Location = new System.Drawing.Point(17, 15);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(160, 34);
            this.btnAddSource.TabIndex = 6;
            this.btnAddSource.Text = "Ajouter une source";
            this.btnAddSource.UseVisualStyleBackColor = true;
            this.btnAddSource.Click += new System.EventHandler(this.BtnAddSource_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRemoveSource);
            this.panel2.Controls.Add(this.btnAddSource);
            this.panel2.Location = new System.Drawing.Point(-2, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 65);
            this.panel2.TabIndex = 8;
            // 
            // btnRemoveSource
            // 
            this.btnRemoveSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveSource.Location = new System.Drawing.Point(183, 15);
            this.btnRemoveSource.Name = "btnRemoveSource";
            this.btnRemoveSource.Size = new System.Drawing.Size(160, 34);
            this.btnRemoveSource.TabIndex = 7;
            this.btnRemoveSource.Text = "Retirer une source";
            this.btnRemoveSource.UseVisualStyleBackColor = true;
            this.btnRemoveSource.Click += new System.EventHandler(this.BtnRemoveSource_Click);
            // 
            // pnlSources
            // 
            this.pnlSources.Location = new System.Drawing.Point(12, 83);
            this.pnlSources.Name = "pnlSources";
            this.pnlSources.Size = new System.Drawing.Size(755, 68);
            this.pnlSources.TabIndex = 9;
            // 
            // pnlFusion
            // 
            this.pnlFusion.Controls.Add(this.lblFusion);
            this.pnlFusion.Controls.Add(this.progressBar1);
            this.pnlFusion.Controls.Add(this.btnFusion);
            this.pnlFusion.Location = new System.Drawing.Point(12, 157);
            this.pnlFusion.Name = "pnlFusion";
            this.pnlFusion.Size = new System.Drawing.Size(743, 128);
            this.pnlFusion.TabIndex = 8;
            // 
            // lblFusion
            // 
            this.lblFusion.AutoSize = true;
            this.lblFusion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFusion.Location = new System.Drawing.Point(237, 102);
            this.lblFusion.Name = "lblFusion";
            this.lblFusion.Size = new System.Drawing.Size(276, 16);
            this.lblFusion.TabIndex = 2;
            this.lblFusion.Text = "Fusion terminée avec succès : X événements";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(215, 66);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(310, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // btnFusion
            // 
            this.btnFusion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusion.Location = new System.Drawing.Point(215, 22);
            this.btnFusion.Name = "btnFusion";
            this.btnFusion.Size = new System.Drawing.Size(310, 38);
            this.btnFusion.TabIndex = 0;
            this.btnFusion.Text = "Fusionner";
            this.btnFusion.UseVisualStyleBackColor = true;
            // 
            // formIcal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 297);
            this.Controls.Add(this.pnlSources);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlFusion);
            this.Name = "formIcal";
            this.ShowIcon = false;
            this.Text = "IcalMerge";
            this.panel2.ResumeLayout(false);
            this.pnlFusion.ResumeLayout(false);
            this.pnlFusion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlSources;
        private System.Windows.Forms.Panel pnlFusion;
        private System.Windows.Forms.Label lblFusion;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnFusion;
        private System.Windows.Forms.Button btnRemoveSource;
    }
}


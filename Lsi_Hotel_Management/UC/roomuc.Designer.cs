
namespace Lsi_Hotel_Management.UC
{
    partial class roomuc
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbnum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbnum
            // 
            this.lbnum.AutoSize = true;
            this.lbnum.BackColor = System.Drawing.Color.Blue;
            this.lbnum.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbnum.Location = new System.Drawing.Point(3, 64);
            this.lbnum.Name = "lbnum";
            this.lbnum.Size = new System.Drawing.Size(18, 19);
            this.lbnum.TabIndex = 0;
            this.lbnum.Text = "0";
            this.lbnum.Click += new System.EventHandler(this.lbnum_Click);
            // 
            // roomuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Controls.Add(this.lbnum);
            this.Name = "roomuc";
            this.Size = new System.Drawing.Size(125, 83);
            this.Load += new System.EventHandler(this.roomuc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbnum;
    }
}

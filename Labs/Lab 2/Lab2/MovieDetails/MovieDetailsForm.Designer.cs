namespace MovieDetails
{
    partial class MovieDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDescript = new System.Windows.Forms.TextBox();
            this.labelLength = new System.Windows.Forms.Label();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.labelMins = new System.Windows.Forms.Label();
            this.ckBoxOwned = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(69, 45);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(30, 15);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.AcceptsTab = true;
            this.textBoxTitle.Location = new System.Drawing.Point(139, 42);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(425, 20);
            this.textBoxTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description";
            // 
            // textBoxDescript
            // 
            this.textBoxDescript.AcceptsTab = true;
            this.textBoxDescript.Location = new System.Drawing.Point(139, 68);
            this.textBoxDescript.Multiline = true;
            this.textBoxDescript.Name = "textBoxDescript";
            this.textBoxDescript.Size = new System.Drawing.Size(425, 100);
            this.textBoxDescript.TabIndex = 3;
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLength.Location = new System.Drawing.Point(61, 174);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(45, 15);
            this.labelLength.TabIndex = 4;
            this.labelLength.Text = "Length";
            // 
            // textBoxLength
            // 
            this.textBoxLength.AcceptsTab = true;
            this.textBoxLength.Location = new System.Drawing.Point(139, 174);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(80, 20);
            this.textBoxLength.TabIndex = 5;
            // 
            // labelMins
            // 
            this.labelMins.AutoSize = true;
            this.labelMins.Location = new System.Drawing.Point(225, 177);
            this.labelMins.Name = "labelMins";
            this.labelMins.Size = new System.Drawing.Size(48, 13);
            this.labelMins.TabIndex = 6;
            this.labelMins.Text = "*Minutes";
            // 
            // ckBoxOwned
            // 
            this.ckBoxOwned.AutoSize = true;
            this.ckBoxOwned.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBoxOwned.Location = new System.Drawing.Point(139, 200);
            this.ckBoxOwned.Name = "ckBoxOwned";
            this.ckBoxOwned.Size = new System.Drawing.Size(65, 19);
            this.ckBoxOwned.TabIndex = 7;
            this.ckBoxOwned.Text = "Owned";
            this.ckBoxOwned.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(363, 273);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(464, 273);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // movieDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.ckBoxOwned);
            this.Controls.Add(this.labelMins);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.labelLength);
            this.Controls.Add(this.textBoxDescript);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.titleLabel);
            this.Name = "movieDetails";
            this.Text = "Movie Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDescript;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.TextBox textBoxLength;
        private System.Windows.Forms.Label labelMins;
        private System.Windows.Forms.CheckBox ckBoxOwned;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}


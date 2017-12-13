namespace Election
{
    partial class FormsBasedUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnConstituency = new System.Windows.Forms.Button();
            this.btnCandidates = new System.Windows.Forms.Button();
            this.btnParty = new System.Windows.Forms.Button();
            this.btnWinner = new System.Windows.Forms.Button();
            this.lstRelevant = new System.Windows.Forms.ListBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnPartyWin = new System.Windows.Forms.Button();
            this.cboCons = new System.Windows.Forms.ComboBox();
            this.btnConCan = new System.Windows.Forms.Button();
            this.btnElectedCandidates = new System.Windows.Forms.Button();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(357, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 59);
            this.label1.TabIndex = 1;
            this.label1.Text = "Election";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(12, 102);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(266, 51);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open Files";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.Enabled = false;
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(12, 182);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(266, 51);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load Data";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnConstituency
            // 
            this.btnConstituency.BackColor = System.Drawing.Color.Red;
            this.btnConstituency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConstituency.Enabled = false;
            this.btnConstituency.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConstituency.ForeColor = System.Drawing.Color.White;
            this.btnConstituency.Location = new System.Drawing.Point(590, 93);
            this.btnConstituency.Name = "btnConstituency";
            this.btnConstituency.Size = new System.Drawing.Size(260, 66);
            this.btnConstituency.TabIndex = 4;
            this.btnConstituency.Text = "View Constituency Winner";
            this.btnConstituency.UseVisualStyleBackColor = false;
            this.btnConstituency.Click += new System.EventHandler(this.btnConstituency_Click);
            // 
            // btnCandidates
            // 
            this.btnCandidates.BackColor = System.Drawing.Color.Lime;
            this.btnCandidates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCandidates.Enabled = false;
            this.btnCandidates.ForeColor = System.Drawing.Color.White;
            this.btnCandidates.Location = new System.Drawing.Point(308, 262);
            this.btnCandidates.Name = "btnCandidates";
            this.btnCandidates.Size = new System.Drawing.Size(260, 60);
            this.btnCandidates.TabIndex = 5;
            this.btnCandidates.Text = "All Candidates";
            this.btnCandidates.UseVisualStyleBackColor = false;
            this.btnCandidates.Click += new System.EventHandler(this.btnCandidates_Click);
            // 
            // btnParty
            // 
            this.btnParty.BackColor = System.Drawing.Color.Lime;
            this.btnParty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnParty.Enabled = false;
            this.btnParty.ForeColor = System.Drawing.Color.White;
            this.btnParty.Location = new System.Drawing.Point(308, 328);
            this.btnParty.Name = "btnParty";
            this.btnParty.Size = new System.Drawing.Size(260, 63);
            this.btnParty.TabIndex = 6;
            this.btnParty.Text = "All Parties";
            this.btnParty.UseVisualStyleBackColor = false;
            this.btnParty.Click += new System.EventHandler(this.btnParty_Click);
            // 
            // btnWinner
            // 
            this.btnWinner.BackColor = System.Drawing.Color.Lime;
            this.btnWinner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWinner.Enabled = false;
            this.btnWinner.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWinner.ForeColor = System.Drawing.Color.White;
            this.btnWinner.Location = new System.Drawing.Point(590, 262);
            this.btnWinner.Name = "btnWinner";
            this.btnWinner.Size = new System.Drawing.Size(260, 63);
            this.btnWinner.TabIndex = 7;
            this.btnWinner.Text = "Overall Candidate Winner";
            this.btnWinner.UseVisualStyleBackColor = false;
            this.btnWinner.Click += new System.EventHandler(this.btnWinner_Click);
            // 
            // lstRelevant
            // 
            this.lstRelevant.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRelevant.FormattingEnabled = true;
            this.lstRelevant.ItemHeight = 24;
            this.lstRelevant.Location = new System.Drawing.Point(308, 423);
            this.lstRelevant.Name = "lstRelevant";
            this.lstRelevant.Size = new System.Drawing.Size(542, 172);
            this.lstRelevant.TabIndex = 8;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.Red;
            this.lblProgress.Location = new System.Drawing.Point(12, 68);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(429, 23);
            this.lblProgress.TabIndex = 10;
            this.lblProgress.Text = "Please select each file individually that you wish to use.";
            // 
            // btnPartyWin
            // 
            this.btnPartyWin.BackColor = System.Drawing.Color.Lime;
            this.btnPartyWin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPartyWin.Enabled = false;
            this.btnPartyWin.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartyWin.ForeColor = System.Drawing.Color.White;
            this.btnPartyWin.Location = new System.Drawing.Point(590, 328);
            this.btnPartyWin.Name = "btnPartyWin";
            this.btnPartyWin.Size = new System.Drawing.Size(260, 63);
            this.btnPartyWin.TabIndex = 11;
            this.btnPartyWin.Text = "Election Winner";
            this.btnPartyWin.UseVisualStyleBackColor = false;
            this.btnPartyWin.Click += new System.EventHandler(this.btnPartyWin_Click);
            // 
            // cboCons
            // 
            this.cboCons.FormattingEnabled = true;
            this.cboCons.Location = new System.Drawing.Point(308, 93);
            this.cboCons.Name = "cboCons";
            this.cboCons.Size = new System.Drawing.Size(260, 48);
            this.cboCons.TabIndex = 12;
            // 
            // btnConCan
            // 
            this.btnConCan.BackColor = System.Drawing.Color.Red;
            this.btnConCan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConCan.Enabled = false;
            this.btnConCan.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConCan.ForeColor = System.Drawing.Color.White;
            this.btnConCan.Location = new System.Drawing.Point(590, 165);
            this.btnConCan.Name = "btnConCan";
            this.btnConCan.Size = new System.Drawing.Size(260, 66);
            this.btnConCan.TabIndex = 13;
            this.btnConCan.Text = "View Constituency Candidates";
            this.btnConCan.UseVisualStyleBackColor = false;
            this.btnConCan.Click += new System.EventHandler(this.btnConCan_Click);
            // 
            // btnElectedCandidates
            // 
            this.btnElectedCandidates.BackColor = System.Drawing.Color.Lime;
            this.btnElectedCandidates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnElectedCandidates.Enabled = false;
            this.btnElectedCandidates.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElectedCandidates.ForeColor = System.Drawing.Color.White;
            this.btnElectedCandidates.Location = new System.Drawing.Point(308, 196);
            this.btnElectedCandidates.Name = "btnElectedCandidates";
            this.btnElectedCandidates.Size = new System.Drawing.Size(260, 60);
            this.btnElectedCandidates.TabIndex = 14;
            this.btnElectedCandidates.Text = "Elected Candidates";
            this.btnElectedCandidates.UseVisualStyleBackColor = false;
            this.btnElectedCandidates.Click += new System.EventHandler(this.btnElectedCandidates_Click);
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::Election.Properties.Resources.Windows_Close_Program_icon1;
            this.picClose.Location = new System.Drawing.Point(824, 9);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(58, 49);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 15;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Election.Properties.Resources.People_Voting;
            this.pictureBox1.Location = new System.Drawing.Point(0, 262);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(278, 350);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormsBasedUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(894, 609);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.btnElectedCandidates);
            this.Controls.Add(this.btnConCan);
            this.Controls.Add(this.cboCons);
            this.Controls.Add(this.btnPartyWin);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lstRelevant);
            this.Controls.Add(this.btnWinner);
            this.Controls.Add(this.btnParty);
            this.Controls.Add(this.btnCandidates);
            this.Controls.Add(this.btnConstituency);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "FormsBasedUI";
            this.Text = "FormsBasedUI";
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnConstituency;
        private System.Windows.Forms.Button btnCandidates;
        private System.Windows.Forms.Button btnParty;
        private System.Windows.Forms.Button btnWinner;
        private System.Windows.Forms.ListBox lstRelevant;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnPartyWin;
        private System.Windows.Forms.ComboBox cboCons;
        private System.Windows.Forms.Button btnConCan;
        private System.Windows.Forms.Button btnElectedCandidates;
        private System.Windows.Forms.PictureBox picClose;
    }
}
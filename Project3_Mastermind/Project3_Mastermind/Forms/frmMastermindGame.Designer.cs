namespace Project3_Mastermind
{
    partial class frmMastermind
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnNameOk = new System.Windows.Forms.Button();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.grpDifficulty = new System.Windows.Forms.GroupBox();
            this.pnlGameControls = new System.Windows.Forms.Panel();
            this.pnlSolutionBoard = new System.Windows.Forms.Panel();
            this.pnlGuessBoard = new System.Windows.Forms.Panel();
            this.pnlHintBoard = new System.Windows.Forms.Panel();
            this.btnChoiceConfirm = new System.Windows.Forms.Button();
            this.pnlIntro = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblCurrentPlayer = new System.Windows.Forms.Label();
            this.btnRules = new System.Windows.Forms.Button();
            this.pnlPlayerGuessArea = new System.Windows.Forms.Panel();
            this.lblPlayerArea = new System.Windows.Forms.Label();
            this.grpDifficulty.SuspendLayout();
            this.pnlGameControls.SuspendLayout();
            this.pnlIntro.SuspendLayout();
            this.pnlPlayerGuessArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(3, 34);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(127, 13);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to Mastermind!!";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(21, 93);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // btnNameOk
            // 
            this.btnNameOk.Location = new System.Drawing.Point(155, 93);
            this.btnNameOk.Name = "btnNameOk";
            this.btnNameOk.Size = new System.Drawing.Size(75, 23);
            this.btnNameOk.TabIndex = 2;
            this.btnNameOk.Text = "OK";
            this.btnNameOk.UseVisualStyleBackColor = true;
            this.btnNameOk.Click += new System.EventHandler(this.btnNameOk_Click);
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(152, 26);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(110, 13);
            this.lblDifficulty.TabIndex = 4;
            this.lblDifficulty.Text = "Choose your difficulty:";
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.Color.LimeGreen;
            this.btnEasy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEasy.Location = new System.Drawing.Point(53, 59);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(75, 23);
            this.btnEasy.TabIndex = 5;
            this.btnEasy.Text = "Easy";
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.BackColor = System.Drawing.Color.Yellow;
            this.btnMedium.Location = new System.Drawing.Point(164, 59);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(75, 23);
            this.btnMedium.TabIndex = 6;
            this.btnMedium.Text = "Medium";
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnHard
            // 
            this.btnHard.BackColor = System.Drawing.Color.Red;
            this.btnHard.Location = new System.Drawing.Point(281, 59);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(75, 23);
            this.btnHard.TabIndex = 7;
            this.btnHard.Text = "Hard";
            this.btnHard.UseVisualStyleBackColor = false;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // grpDifficulty
            // 
            this.grpDifficulty.Controls.Add(this.lblDifficulty);
            this.grpDifficulty.Controls.Add(this.btnHard);
            this.grpDifficulty.Controls.Add(this.btnEasy);
            this.grpDifficulty.Controls.Add(this.btnMedium);
            this.grpDifficulty.Location = new System.Drawing.Point(335, 55);
            this.grpDifficulty.Name = "grpDifficulty";
            this.grpDifficulty.Size = new System.Drawing.Size(412, 88);
            this.grpDifficulty.TabIndex = 8;
            this.grpDifficulty.TabStop = false;
            this.grpDifficulty.Text = "Difficulty Levels";
            // 
            // pnlGameControls
            // 
            this.pnlGameControls.Controls.Add(this.pnlSolutionBoard);
            this.pnlGameControls.Controls.Add(this.pnlGuessBoard);
            this.pnlGameControls.Controls.Add(this.pnlHintBoard);
            this.pnlGameControls.Location = new System.Drawing.Point(18, 331);
            this.pnlGameControls.Name = "pnlGameControls";
            this.pnlGameControls.Size = new System.Drawing.Size(1169, 413);
            this.pnlGameControls.TabIndex = 9;
            // 
            // pnlSolutionBoard
            // 
            this.pnlSolutionBoard.Location = new System.Drawing.Point(1031, 120);
            this.pnlSolutionBoard.Name = "pnlSolutionBoard";
            this.pnlSolutionBoard.Size = new System.Drawing.Size(133, 290);
            this.pnlSolutionBoard.TabIndex = 11;
            // 
            // pnlGuessBoard
            // 
            this.pnlGuessBoard.Location = new System.Drawing.Point(15, 120);
            this.pnlGuessBoard.Name = "pnlGuessBoard";
            this.pnlGuessBoard.Size = new System.Drawing.Size(1010, 290);
            this.pnlGuessBoard.TabIndex = 11;
            // 
            // pnlHintBoard
            // 
            this.pnlHintBoard.Location = new System.Drawing.Point(15, 3);
            this.pnlHintBoard.Name = "pnlHintBoard";
            this.pnlHintBoard.Size = new System.Drawing.Size(1010, 111);
            this.pnlHintBoard.TabIndex = 10;
            // 
            // btnChoiceConfirm
            // 
            this.btnChoiceConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChoiceConfirm.Location = new System.Drawing.Point(70, 119);
            this.btnChoiceConfirm.Name = "btnChoiceConfirm";
            this.btnChoiceConfirm.Size = new System.Drawing.Size(146, 23);
            this.btnChoiceConfirm.TabIndex = 11;
            this.btnChoiceConfirm.Text = "Confirm";
            this.btnChoiceConfirm.UseVisualStyleBackColor = true;
            this.btnChoiceConfirm.Click += new System.EventHandler(this.btnChoiceConfirm_Click);
            // 
            // pnlIntro
            // 
            this.pnlIntro.Controls.Add(this.lblWelcome);
            this.pnlIntro.Controls.Add(this.txtName);
            this.pnlIntro.Controls.Add(this.btnNameOk);
            this.pnlIntro.Location = new System.Drawing.Point(12, 12);
            this.pnlIntro.Name = "pnlIntro";
            this.pnlIntro.Size = new System.Drawing.Size(249, 147);
            this.pnlIntro.TabIndex = 10;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(1066, 23);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 38);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(91, 171);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(35, 13);
            this.lblDisplayName.TabIndex = 12;
            this.lblDisplayName.Text = "label3";
            // 
            // lblCurrentPlayer
            // 
            this.lblCurrentPlayer.AutoSize = true;
            this.lblCurrentPlayer.Location = new System.Drawing.Point(9, 171);
            this.lblCurrentPlayer.Name = "lblCurrentPlayer";
            this.lblCurrentPlayer.Size = new System.Drawing.Size(76, 13);
            this.lblCurrentPlayer.TabIndex = 13;
            this.lblCurrentPlayer.Text = "Current Player:";
            // 
            // btnRules
            // 
            this.btnRules.Location = new System.Drawing.Point(935, 23);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(90, 38);
            this.btnRules.TabIndex = 14;
            this.btnRules.Text = "Rules";
            this.btnRules.UseVisualStyleBackColor = true;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // pnlPlayerGuessArea
            // 
            this.pnlPlayerGuessArea.Controls.Add(this.lblPlayerArea);
            this.pnlPlayerGuessArea.Controls.Add(this.btnChoiceConfirm);
            this.pnlPlayerGuessArea.Location = new System.Drawing.Point(295, 146);
            this.pnlPlayerGuessArea.Name = "pnlPlayerGuessArea";
            this.pnlPlayerGuessArea.Size = new System.Drawing.Size(526, 183);
            this.pnlPlayerGuessArea.TabIndex = 15;
            // 
            // lblPlayerArea
            // 
            this.lblPlayerArea.AutoSize = true;
            this.lblPlayerArea.Location = new System.Drawing.Point(37, 0);
            this.lblPlayerArea.Name = "lblPlayerArea";
            this.lblPlayerArea.Size = new System.Drawing.Size(219, 13);
            this.lblPlayerArea.TabIndex = 25;
            this.lblPlayerArea.Text = "Player Guess Area! Make your guesses here!";
            // 
            // frmMastermind
            // 
            this.AcceptButton = this.btnChoiceConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1197, 749);
            this.Controls.Add(this.pnlPlayerGuessArea);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.lblCurrentPlayer);
            this.Controls.Add(this.lblDisplayName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnlIntro);
            this.Controls.Add(this.pnlGameControls);
            this.Controls.Add(this.grpDifficulty);
            this.Name = "frmMastermind";
            this.Text = "Mastermind!!";
            this.Load += new System.EventHandler(this.frmMastermind_Load);
            this.grpDifficulty.ResumeLayout(false);
            this.grpDifficulty.PerformLayout();
            this.pnlGameControls.ResumeLayout(false);
            this.pnlIntro.ResumeLayout(false);
            this.pnlIntro.PerformLayout();
            this.pnlPlayerGuessArea.ResumeLayout(false);
            this.pnlPlayerGuessArea.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnNameOk;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.GroupBox grpDifficulty;
        private System.Windows.Forms.Panel pnlGameControls;
        private System.Windows.Forms.Button btnChoiceConfirm;
        private System.Windows.Forms.Panel pnlIntro;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblCurrentPlayer;
        private System.Windows.Forms.Button btnRules;
        private System.Windows.Forms.Panel pnlPlayerGuessArea;
        private System.Windows.Forms.Label lblPlayerArea;
        private System.Windows.Forms.Panel pnlGuessBoard;
        private System.Windows.Forms.Panel pnlSolutionBoard;
        private System.Windows.Forms.Panel pnlHintBoard;
    }
}


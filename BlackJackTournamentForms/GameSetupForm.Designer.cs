namespace BlackJackTournamentForms
{
    partial class GameSetupForm
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
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.PlayerChipsLabel = new System.Windows.Forms.Label();
            this.PlayerListLabel = new System.Windows.Forms.Label();
            this.PlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.PlayerCoinsTextBox = new System.Windows.Forms.TextBox();
            this.PlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.AddPlayerButton = new System.Windows.Forms.Button();
            this.GameSetupHeader = new System.Windows.Forms.Label();
            this.StartTournamentButton = new System.Windows.Forms.Button();
            this.PlayerListBox = new System.Windows.Forms.ListBox();
            this.PlayerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerNameLabel
            // 
            this.PlayerNameLabel.AutoSize = true;
            this.PlayerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerNameLabel.Location = new System.Drawing.Point(6, 39);
            this.PlayerNameLabel.Name = "PlayerNameLabel";
            this.PlayerNameLabel.Size = new System.Drawing.Size(135, 25);
            this.PlayerNameLabel.TabIndex = 0;
            this.PlayerNameLabel.Text = "Player Name";
            // 
            // PlayerChipsLabel
            // 
            this.PlayerChipsLabel.AutoSize = true;
            this.PlayerChipsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerChipsLabel.Location = new System.Drawing.Point(6, 110);
            this.PlayerChipsLabel.Name = "PlayerChipsLabel";
            this.PlayerChipsLabel.Size = new System.Drawing.Size(134, 25);
            this.PlayerChipsLabel.TabIndex = 1;
            this.PlayerChipsLabel.Text = "Player Chips";
            // 
            // PlayerListLabel
            // 
            this.PlayerListLabel.AutoSize = true;
            this.PlayerListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerListLabel.Location = new System.Drawing.Point(338, 111);
            this.PlayerListLabel.Name = "PlayerListLabel";
            this.PlayerListLabel.Size = new System.Drawing.Size(113, 25);
            this.PlayerListLabel.TabIndex = 2;
            this.PlayerListLabel.Text = "Player List";
            // 
            // PlayerNameTextBox
            // 
            this.PlayerNameTextBox.Location = new System.Drawing.Point(6, 67);
            this.PlayerNameTextBox.Name = "PlayerNameTextBox";
            this.PlayerNameTextBox.Size = new System.Drawing.Size(222, 20);
            this.PlayerNameTextBox.TabIndex = 3;
            this.PlayerNameTextBox.Text = "Player 1";
            // 
            // PlayerCoinsTextBox
            // 
            this.PlayerCoinsTextBox.Location = new System.Drawing.Point(6, 138);
            this.PlayerCoinsTextBox.Name = "PlayerCoinsTextBox";
            this.PlayerCoinsTextBox.Size = new System.Drawing.Size(77, 20);
            this.PlayerCoinsTextBox.TabIndex = 4;
            this.PlayerCoinsTextBox.Text = "3";
            this.PlayerCoinsTextBox.TextChanged += new System.EventHandler(this.PlayerCoinsTextBox_TextChanged);
            // 
            // PlayerGroupBox
            // 
            this.PlayerGroupBox.Controls.Add(this.AddPlayerButton);
            this.PlayerGroupBox.Controls.Add(this.PlayerNameLabel);
            this.PlayerGroupBox.Controls.Add(this.PlayerChipsLabel);
            this.PlayerGroupBox.Controls.Add(this.PlayerCoinsTextBox);
            this.PlayerGroupBox.Controls.Add(this.PlayerNameTextBox);
            this.PlayerGroupBox.Location = new System.Drawing.Point(38, 111);
            this.PlayerGroupBox.Name = "PlayerGroupBox";
            this.PlayerGroupBox.Size = new System.Drawing.Size(272, 279);
            this.PlayerGroupBox.TabIndex = 6;
            this.PlayerGroupBox.TabStop = false;
            this.PlayerGroupBox.Text = "Player Info";
            // 
            // AddPlayerButton
            // 
            this.AddPlayerButton.Location = new System.Drawing.Point(6, 202);
            this.AddPlayerButton.Name = "AddPlayerButton";
            this.AddPlayerButton.Size = new System.Drawing.Size(152, 34);
            this.AddPlayerButton.TabIndex = 5;
            this.AddPlayerButton.Text = "Add Player";
            this.AddPlayerButton.UseVisualStyleBackColor = true;
            this.AddPlayerButton.Click += new System.EventHandler(this.AddPlayerButton_Click);
            // 
            // GameSetupHeader
            // 
            this.GameSetupHeader.AutoSize = true;
            this.GameSetupHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameSetupHeader.Location = new System.Drawing.Point(35, 34);
            this.GameSetupHeader.Name = "GameSetupHeader";
            this.GameSetupHeader.Size = new System.Drawing.Size(305, 31);
            this.GameSetupHeader.TabIndex = 7;
            this.GameSetupHeader.Text = "TOURNAMENT SETUP";
            // 
            // StartTournamentButton
            // 
            this.StartTournamentButton.Location = new System.Drawing.Point(194, 410);
            this.StartTournamentButton.Name = "StartTournamentButton";
            this.StartTournamentButton.Size = new System.Drawing.Size(208, 37);
            this.StartTournamentButton.TabIndex = 8;
            this.StartTournamentButton.Text = "Start Tournament";
            this.StartTournamentButton.UseVisualStyleBackColor = true;
            this.StartTournamentButton.Click += new System.EventHandler(this.StartTournamentButton_Click);
            // 
            // PlayerListBox
            // 
            this.PlayerListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerListBox.FormattingEnabled = true;
            this.PlayerListBox.ItemHeight = 25;
            this.PlayerListBox.Location = new System.Drawing.Point(343, 139);
            this.PlayerListBox.MultiColumn = true;
            this.PlayerListBox.Name = "PlayerListBox";
            this.PlayerListBox.Size = new System.Drawing.Size(262, 229);
            this.PlayerListBox.TabIndex = 9;
            // 
            // GameSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, 459);
            this.Controls.Add(this.PlayerListBox);
            this.Controls.Add(this.StartTournamentButton);
            this.Controls.Add(this.GameSetupHeader);
            this.Controls.Add(this.PlayerGroupBox);
            this.Controls.Add(this.PlayerListLabel);
            this.Name = "GameSetupForm";
            this.Text = "GameSetupForm";
            this.Load += new System.EventHandler(this.GameSetupForm_Load);
            this.PlayerGroupBox.ResumeLayout(false);
            this.PlayerGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlayerNameLabel;
        private System.Windows.Forms.Label PlayerChipsLabel;
        private System.Windows.Forms.Label PlayerListLabel;
        private System.Windows.Forms.TextBox PlayerNameTextBox;
        private System.Windows.Forms.TextBox PlayerCoinsTextBox;
        private System.Windows.Forms.GroupBox PlayerGroupBox;
        private System.Windows.Forms.Label GameSetupHeader;
        private System.Windows.Forms.Button AddPlayerButton;
        private System.Windows.Forms.Button StartTournamentButton;
        private System.Windows.Forms.ListBox PlayerListBox;
    }
}
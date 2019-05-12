using BlackJackTounamentClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJackTournamentForms
{
    public partial class GameSetupForm : Form
    {
        public CPlayerList PlayerList { get; set; } = new CPlayerList();
        public GameSetupForm()
        {
            InitializeComponent();
        }
                
        private void GameSetupForm_Load(object sender, EventArgs e)
        {

        }

        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            if (HandlingForm.CheckSetupName(PlayerNameTextBox) && HandlingForm.CheckSetupCoins(PlayerCoinsTextBox))
            {
                CPlayer NewPlayer = new CPlayer(PlayerNameTextBox.Text, int.Parse(PlayerCoinsTextBox.Text));
                PlayerList.AddPlayer(NewPlayer.Name, NewPlayer.Chips);
                PlayerListBox.Items.Add(NewPlayer.Name + " Chips:" + NewPlayer.Chips);
            }
            else
            {
                return;
            }
        }

        private void StartTournamentButton_Click(object sender, EventArgs e)
        {
            GameForm TheGame = new GameForm(PlayerList);
            TheGame.ShowDialog();
        }

        private void PlayerCoinsTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

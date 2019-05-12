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
    /// <summary>
    /// Form where the game is played.
    /// </summary>
    public partial class GameForm : Form
    {
        /// <summary>
        /// Places for card images, deck of cards for the game, initial objects fro dealer, player and player list.
        /// </summary>
        public List<PictureBox> DealerSlots { get; set; } 
        public List<PictureBox> PlayerSlots1 { get; set; }
        public List<PictureBox> PlayerSlots2 { get; set; }
        public CDeck Deck { get; set; } = new CDeck(8);
        public CDealer Dealer { get; set; } = new CDealer();
        public CPlayer Player { get; set; } = new CPlayer();
        private CPlayerList PlayerList { get; set; }

        /// <summary>
        /// Initialize form with PlayerList object.
        /// </summary>
        public GameForm(CPlayerList PlayerList)
        {
            this.PlayerList = PlayerList;
            InitializeComponent();
        }

        /// <summary>
        /// Initialize Card positions in the form. Next player from the player list and update form with player name and amount of chips.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_Load(object sender, EventArgs e)
        {
            DealerSlots = new List<PictureBox>() { DealerSlot1, DealerSlot2, DealerSlot3, DealerSlot4, DealerSlot5, DealerSlot6, DealerSlot7 };
            PlayerSlots1 = new List<PictureBox>() { PlayerSlot1, PlayerSlot2, PlayerSlot3, PlayerSlot4, PlayerSlot5, PlayerSlot6, PlayerSlot7 };
            PlayerSlots2 = new List<PictureBox>() { DoubleSlot1, DoubleSlot2, DoubleSlot3, DoubleSlot4, DoubleSlot5, DoubleSlot6, DoubleSlot7 };
            Player = PlayerList.GetNextPlayer();
            PlayerNameLabel.Text = Player.Name;
            ChipsAmountLabel.Text = Player.Chips.ToString();
        }

        /// <summary>
        /// Each round starts with an initial deal where dealer takes one card and player is given two cards. If player gets BlackJack the round ends there.
        /// The game continues according to the choises player has.
        /// </summary>
        private void InitialDeal()
        {
            HandlingForm.SplitMode = 0;
            HandlingForm.ShowHideSlots(PlayerSlots2, false);
            HandlingForm.DisableButton(StartGameButton);
            Dealer.ResetDealerCards();
            Player.ResetPlayerCards();
            HandlingForm.CardsToForm(Dealer.GetDealerCard(Deck), DealerSlots);
            HandlingForm.CardsToForm(Player.GetCard1(Deck), PlayerSlots1);
            HandlingForm.CardsToForm(Player.GetCard1(Deck), PlayerSlots1);
            if(Dealer.CheckBlackJack(Player.GetCardList1()))
            {
                HandlingForm.Messaging(InfoLabel, Info2Label, "You Got BlackJack!", " ");
                HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, true);
                HandlingForm.EnableButton(StartGameButton);
            }

            else if (Dealer.SplitChange(Player.GetCardList1()))
            {
                HandlingForm.Messaging(InfoLabel, Info2Label, "You Have: " + CDealer.CountResult(Player.GetCardList1()), "You Can Split Or Double!");
                HandlingForm.EnableButton(SplitButton); HandlingForm.EnableButton(MoreButton); HandlingForm.EnableButton(StayButton); HandlingForm.EnableButton(DoubleButton);        
            }

            else
            {
                HandlingForm.Messaging(InfoLabel, Info2Label, "You Have: " + CDealer.CountResult(Player.GetCardList1()), "You Can Double!");
                HandlingForm.EnableButton(MoreButton); HandlingForm.EnableButton(StayButton); HandlingForm.EnableButton(DoubleButton);
            }
        }

        /// <summary>
        /// Dealer will end the round by playing after the player has stayed, doubled or splitted (and not over drawn both sets of cards). The final result of the round is calculated after the turn.
        /// </summary>
        private void DealerTurn()
        {   
            int score = HandlingForm.CardsToForm(Dealer.GetDealerCard(Deck), DealerSlots);
                        
            while (score < 17) {
               score = HandlingForm.CardsToForm(Dealer.GetDealerCard(Deck), DealerSlots);
            }

            if (HandlingForm.SplitMode == 2)
            {
                string message1 = "Slot 1 Dealer Wins";
                string message2 = "Slot 2 Dealer Wins";
                int PlayerSlot1Score = CDealer.CountResult(Player.GetCardList1());
                int PlayerSlot2Score = CDealer.CountResult(Player.GetCardList2());

                if(PlayerSlot1Score < 22)
                {
                    if (HandlingForm.BlackJack1)
                    {
                    message1 = "Slot 1 Player Wins With BlackJack";
                    HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, true);
                    }
                    else if(score > 21 || PlayerSlot1Score > score)
                    {
                        message1 = "Slot 1 Player Wins";
                        HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, true);
                    }
                    else if(score < 22 && score > PlayerSlot1Score)
                    {
                        HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, false);
                        message1 = "Slot 1 Dealer Wins";
                    }
                    
                }
                else
                {
                    message1 = "Slot 1 Over Draw";
                    HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, false);
                }

                if (PlayerSlot2Score < 22)
                {
                    if (HandlingForm.BlackJack2)
                    {
                    message2 = "Slot 2 Player Wins With BlackJack";
                    HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, true);
                    }
                    else if(score > 21 || PlayerSlot2Score > score)
                    {
                        message2 = "Slot 2 Player Wins";
                        HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, true);
                    }
                    else if (score < 22 && score > PlayerSlot2Score)
                    {
                        HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, false);
                        message2 = "Slot 2 Dealer Wins";
                    }

                }
                else
                {
                    message2 = "Slot 2 Over Draw";
                    HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, false);
                }

                HandlingForm.Messaging(InfoLabel, Info2Label, message1, message2);
            }

            else if (score > 21)
            {
                HandlingForm.Messaging(InfoLabel, Info2Label, "You Win!", "Dealer: " + CDealer.CountResult(Dealer.DealerCards) + " Player:" + CDealer.CountResult(Player.GetCardList1()));
                HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, true);
            }

            else
            {
                if (score < CDealer.CountResult(Player.GetCardList1()))
                {
                    HandlingForm.Messaging(InfoLabel, Info2Label, "You Win!", "Dealer: " + CDealer.CountResult(Dealer.DealerCards) + " Player:" + CDealer.CountResult(Player.GetCardList1()));
                    HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, true);
                }
                else
                {
                    HandlingForm.Messaging(InfoLabel, Info2Label, "Dealer Win!", "Dealer: " + CDealer.CountResult(Dealer.DealerCards) + " Player:" + CDealer.CountResult(Player.GetCardList1()));
                    HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, false);
                }
            }
            HandlingForm.EnableButton(StartGameButton); HandlingForm.DisableButton(MoreButton); HandlingForm.DisableButton(StayButton); HandlingForm.DisableButton(DoubleButton); HandlingForm.DisableButton(SplitButton);
            CheckIfNextPlayer();
        }

        /// <summary>
        /// Check if current player has any chips left. If there are no chips left, it's the next players turn. 
        /// If there are no players left the tournament ends and GameForm will close.
        /// </summary>
        private void CheckIfNextPlayer()
        {
            if(Player != null && Player.Chips <= 0)
            {
                Player = PlayerList.GetNextPlayer();
                if (Player == null)
                {
                    MessageBox.Show("No more players. Tournament ends");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Player run out of chips. Switching to next player.");
                    PlayerNameLabel.Text = Player.Name;
                    ChipsAmountLabel.Text = Player.Chips.ToString();
                }
            }
        }

        /// <summary>
        /// Start next round. Reads the bet player has placed, resets the doubled property of a player and starts initial deal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            Player.Bet = int.Parse(BetTextBox.Text);
            Player.Doubled = false;
            //BetTextBox.ReadOnly = true;
            InitialDeal();
        }

        /// <summary>
        /// Player takes additional card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoreButton_Click(object sender, EventArgs e)
        {
            HandlingForm.DisableButton(SplitButton);
            HandlingForm.DisableButton(DoubleButton);

            if (HandlingForm.SplitMode == 2)
            {
                PlayerSlots2[HandlingForm.VisibilityCounter].Visible = true;
                HandlingForm.VisibilityCounter++;
                
                if (HandlingForm.CardsToForm(Player.GetCard2(Deck), PlayerSlots2) > 21)
                {
                    Info2Label.Text = "You Over Draw";
                    DealerTurn();
                    HandlingForm.EnableButton(StartGameButton);
                    HandlingForm.DisableButton(SplitButton);
                    HandlingForm.DisableButton(DoubleButton);
                    HandlingForm.DisableButton(StayButton);
                    HandlingForm.DisableButton(MoreButton);
                }

                else if (Dealer.CheckBlackJack(Player.GetCardList2()))
                {
                    HandlingForm.BlackJack2 = true;
                    Info2Label.Text = "Slot 2 BlackJack";
                    DealerTurn();
                }
                else
                {
                    InfoLabel.Text = "You have: " + CDealer.CountResult(Player.GetCardList2());
                    
                }
            }

            else if(HandlingForm.SplitMode == 1)
            {
                if (HandlingForm.CardsToForm(Player.GetCard1(Deck), PlayerSlots1) > 21)
                {
                    HandlingForm.Messaging(InfoLabel, Info2Label, "You Over Draw!", "Now Playing The Second Set Of Cards");
                    HandlingForm.SplitMode = 2;
                }

                else if (Dealer.CheckBlackJack(Player.GetCardList1()))
                {
                    HandlingForm.BlackJack1 = true;
                    HandlingForm.Messaging(InfoLabel, Info2Label, "Slot 1 BlackJack", "Now Playing The Second Set Of Cards");
                    HandlingForm.SplitMode = 2;
                }
                 else
                {
                    HandlingForm.Messaging(InfoLabel, Info2Label, "You have: " + CDealer.CountResult(Player.GetCardList1()), "Now Playing The First Set Of Cards");
                }
            }

            else if (HandlingForm.CardsToForm(Player.GetCard1(Deck), PlayerSlots1) > 21)
            {
                HandlingForm.Messaging(InfoLabel, Info2Label, "Dealer Win", "You have: " + CDealer.CountResult(Player.GetCardList1()));
                HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, false);
           
                HandlingForm.EnableButton(StartGameButton);
                HandlingForm.DisableButton(SplitButton);
                HandlingForm.DisableButton(DoubleButton);
                HandlingForm.DisableButton(StayButton);
                HandlingForm.DisableButton(MoreButton);
            }
            else
            {
                HandlingForm.Messaging(InfoLabel, Info2Label, "You have: " + CDealer.CountResult(Player.GetCardList1()), "Dealer have: " + CDealer.CountResult(Dealer.DealerCards));
            }
            CheckIfNextPlayer();
        }

        /// <summary>
        /// Player proceeds to dealers turn. In case player has split cards dealer gets the turn only after both sets of player cards have been played.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StayButton_Click(object sender, EventArgs e)
        {
            HandlingForm.DisableButton(SplitButton);
            HandlingForm.DisableButton(DoubleButton);
            if(HandlingForm.SplitMode == 1)
            {
                HandlingForm.SplitMode = 2;
                HandlingForm.Messaging(InfoLabel, Info2Label, "You have: " + CDealer.CountResult(Player.GetCardList2()), "Now Playing The Second Set Of Cards");
            }
            else
            {
                HandlingForm.DisableButton(SplitButton); HandlingForm.DisableButton(DoubleButton); HandlingForm.DisableButton(StayButton); HandlingForm.DisableButton(MoreButton);
                DealerTurn();
            }
        }

        /// <summary>
        /// Player doubles the bet and takes one more card before proceeding dealers turn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleButton_Click(object sender, EventArgs e)
        {
            HandlingForm.DisableButton(SplitButton);
            HandlingForm.DisableButton(DoubleButton);
            Player.Doubled = true;
            if (HandlingForm.CardsToForm(Player.GetCard1(Deck), PlayerSlots1) > 21)
            {
                HandlingForm.Messaging(InfoLabel, Info2Label, "Dealer Win!", "You have: " + CDealer.CountResult(Player.GetCardList1()));
                HandlingForm.ChicpsToForm(Player, ChipsAmountLabel, false);
                HandlingForm.EnableButton(StartGameButton); HandlingForm.DisableButton(SplitButton); HandlingForm.DisableButton(DoubleButton); HandlingForm.DisableButton(StayButton); HandlingForm.DisableButton(MoreButton);
            }
            else
            {
                HandlingForm.Messaging(InfoLabel, Info2Label, "You have: " + CDealer.CountResult(Player.GetCardList1()), "Dealer have: " + CDealer.CountResult(Dealer.DealerCards));
                DealerTurn();
            }
            CheckIfNextPlayer();

        }

        /// <summary>
        /// Player splits cards.
        /// SplitMode is turned to 1.
        /// Some initial variables are reset to original values.
        /// Imagebox for players second set of cards is turned visible before adding the image of a card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplitButton_Click(object sender, EventArgs e)
        {
            HandlingForm.DisableButton(DoubleButton);
            HandlingForm.DisableButton(SplitButton);
            HandlingForm.SplitMode = 1;
            HandlingForm.VisibilityCounter = 1;
            HandlingForm.BlackJack1 = false;
            HandlingForm.BlackJack2 = false;
            List<CCard> sl = new List<CCard>();
            sl = Player.SetSplit();
            List<CCard> s2 = new List<CCard>() { sl[0] };
            List<CCard> s3 = new List<CCard>() { sl[1] };
            PlayerSlots2[0].Visible = true;
            HandlingForm.CardsToForm(s2, PlayerSlots1);
            HandlingForm.CardsToForm(s3, PlayerSlots2);
            HandlingForm.Messaging(InfoLabel, Info2Label, "You have: " + CDealer.CountResult(Player.GetCardList1()), "Now Playing The First Set Of Cards");
        }       
    }
}
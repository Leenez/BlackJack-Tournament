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
    public partial class HandlingForm : Form
    {
        private static string ImageFolderPath { get; set; } = Application.StartupPath + "\\card_images\\";
        public static int SplitMode { get; set; } = 0;
        public static int SplitResult1 = 0;
        public static int SplitResult2 = 0;
        public static int VisibilityCounter { get; set; } = 1;
        public static bool BlackJack1 = false;
        public static bool BlackJack2 = false;
        public HandlingForm()
        {
            InitializeComponent();
        }

        private void HandlingForm_Load(object sender, EventArgs e)
        {

        }

        public static bool CheckSetupName(TextBox namebox)
        {   

            if (namebox.TextLength < 2)
            {
                MessageBox.Show("Name needs to be at least 2 characters long");
                return false;
            }
            if (namebox.Text.GetType() != typeof(String))
            {
                MessageBox.Show("Name needs to be a string");
                return false;
            }
            return true;
        }

        public static bool CheckSetupCoins(TextBox coinbox)
        {
            int basex;
            if (!(int.TryParse(coinbox.Text, out basex)))
            {
                MessageBox.Show("Amount of chips need to be an integer");
                return false;
            }
            if (int.Parse(coinbox.Text) < 1)
            {
                MessageBox.Show("Player needs at least 1 chip");
                return false;
            }
            return true;
        }

        public static void ChicpsToForm(CPlayer p, Label l, bool add)
        {
            l.Text = p.ChangeChips(add).ToString();
        }

        public static int CardsToForm(List<CCard> cardlist, List<PictureBox> slotlist)
        {
            ClearSlots(slotlist);
            for (int i = 0; i < cardlist.Count; i++)
            {
                slotlist[i].Image = Image.FromFile(ImageFolderPath + cardlist[i].CardName());
            }
            return CDealer.CountResult(cardlist);
        }

        private static void ClearSlots(List<PictureBox> l)
        {
            using (var e1 = l.GetEnumerator())
            
            {
                while (e1.MoveNext())
                {
                    var item1 = e1.Current;
                    
                    item1.Image = null;
                    
                }

            }
        }

        public static void ShowHideSlots(List<PictureBox> l , bool b)
        {
            using (var e1 = l.GetEnumerator())
            
            {
                while (e1.MoveNext())
                {
                    var item1 = e1.Current;
                   
                    item1.Visible = b;
                }

            }
        }

        public static string Message(int msgcode)
        {
            switch (msgcode)
            {
                case 1:
                    return "You got BlackJack!";
                case 2:
                    return "Dealer got BlackJack!";
                case 3:
                    return "You Win!";
                case 4:
                    return "Dealer Wins";
                case 5:
                    return "You have: ";
                case 6:
                    return "You can now split";
                case 7:
                    return "Dealer and You Win!";
                case 8:
                    return "Playing first set";
                case 9:
                    return "Playing second set";
                default:
                    return "Error";
            }
        }

        public static void EnableButton(Button b)

        {
            b.Enabled = true;
            b.BackColor = Color.LightGreen;
        }

        /// <summary>
        /// Disable buttons
        /// </summary>
        /// <param name="b">Button to disable</param>

        public static void DisableButton(Button b)
        {
            b.Enabled = false;
            b.BackColor = Color.LightGray;
        }

        public static void Messaging(Label l1, Label l2, string msg1, string msg2)
        {
            l1.Text = msg1;
            l2.Text = msg2;
        }
    }
}

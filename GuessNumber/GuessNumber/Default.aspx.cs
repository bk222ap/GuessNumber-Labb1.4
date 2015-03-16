using GuessNumber.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuessNumber
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NewGame(object sender, EventArgs e)
        {
            Session["number"] = null;
            NewGamePlaceHolder.Visible = false;
            GuessTextBox.Enabled = true;
            SubmitGuessButton.Enabled = true;
            ClientMessageLabel.Text = "";
            SubmitedGuessesLabel.Text = "Guesses:";
            GuessTextBox.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                String sessionName = "number";
                // ADD TO SESSION VAIABLE!!!!
                SecretNumber sn = null;
                if (Session[sessionName] == null)
                {
                    sn = new SecretNumber();
                    Session[sessionName] = sn;
                }
                else
                {
                    sn = (SecretNumber) Session[sessionName];
                }
                

                try
                {
                    int number = int.Parse(GuessTextBox.Text);
                    Outcome outcome = sn.Makeguess(number);
                    GuessTextBox.Text = "";

                    switch (outcome)
                    {
                        case Outcome.Indefinite:
                            ClientMessageLabel.Text = "Ngt blev fel här";
                            break;
                        case Outcome.Low:
                            ClientMessageLabel.Text = "Too low.";
                            break;
                        case Outcome.High:
                            ClientMessageLabel.Text = "Too high.";
                            break;
                        case Outcome.Correct:
                            ClientMessageLabel.Text = "Correct! It took " + sn.Count  +  " guesses.";
                            NewGamePlaceHolder.Visible = true;
                            GuessTextBox.Enabled = false;
                            SubmitGuessButton.Enabled = false;
                            break;
                        case Outcome.NoMoreGuesses:
                            break;
                        case Outcome.PreviousGuess:
                            ClientMessageLabel.Text = "Still wrong.";
                            break;
                        default:
                            break;
                    }
                    if (!sn.CanMakeGuess)
                    {
                        ClientMessageLabel.Text = "No more guesses. The number was: " + sn.Number;
                        NewGamePlaceHolder.Visible = true;
                        GuessTextBox.Enabled = false;
                        SubmitGuessButton.Enabled = false;
                    }
                    SubmitedGuessesLabel.Text += number + " ";
                    
                }
                catch (Exception)
                {
                }                
            }
        }
    }
}
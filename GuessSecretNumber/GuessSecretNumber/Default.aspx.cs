using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GuessSecretNumber.Model;

namespace GuessSecretNumber
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {

            int guess = int.Parse(GuessBox.Text);

            //nytt secretnumber-objekt skapas om det inte redan finns en session startad med ett spel.
            SecretNumber game;

            if(Session["gameSession"] == null)
            {
                game = new SecretNumber();
            }
            else
            {
                game = (SecretNumber)Session["gameSession"];
            }

            Outcome guessStatus = game.MakeGuess(guess);
            
            //if-satser som kollar vad som kom tillbaka från secretNumber-objektet och meddelar användaren på lämpligt sätt
            if(guessStatus == Outcome.PreviousGuess)
            {
                GuessOutcome.Text = "redan gissat";
            }
            else if (guessStatus == Outcome.NoMoreGuesses)
            {
                GuessOutcome.Text = "Gissat för många gånger";
            }
            else if(guessStatus == Outcome.High)
            {
                GuessOutcome.Text = "För högt";
            }
            else if(guessStatus == Outcome.Low)
            {
                GuessOutcome.Text = "För lågt";
            }
            
            else if(guessStatus == Outcome.Correct)
            {
                GuessOutcome.Text = "RÄTT";
            }
            else
            {
                throw new ApplicationException();
            }

            Session["gameSession"] = game;


        }
    }
}
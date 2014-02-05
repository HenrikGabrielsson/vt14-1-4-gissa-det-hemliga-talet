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
            if (IsValid)
            {

                int guess = int.Parse(GuessBox.Text);

                //nytt secretnumber-objekt skapas om det inte redan finns en session startad med ett spel.
                SecretNumber game;

                if (Session["gameSession"] == null)
                {
                    game = new SecretNumber();
                }
                else
                {
                    game = (SecretNumber)Session["gameSession"];
                }

                //gissningen görs och kollas. Antalet gissningar uppdateras på sidan
                Outcome guessStatus = game.MakeGuess(guess);

                GuessesMade.Text = "Gjorda gissningar: ";
                foreach (int prevGuess in game.PreviousGuesses)
                {
                    GuessesMade.Text += String.Format(" {0}", prevGuess);
                }

                //switch som kollar vad som kom tillbaka från secretNumber-objektet och meddelar användaren på lämpligt sätt
                switch (guessStatus)
                {
                    case Outcome.PreviousGuess:
                        GuessOutcome.Text = "Du har redan gissat på det talet.";
                        break;

                    case Outcome.High:
                        GuessOutcome.Text = "För högt.";
                        break;

                    case Outcome.Low:
                        GuessOutcome.Text = "För lågt";
                        break;

                    //sessionen förstörs om man får slut på gissningar eller vinner.
                    case Outcome.NoMoreGuesses:
                        GuessOutcome.Text = String.Format("Du har slut på gissningar. Det hemliga talet var {0} ", game.Number);
                        Session.Abandon();

                        break;

                    case Outcome.Correct:
                        GuessOutcome.Text = String.Format("Du vann efter {0} försök!", game.Count);
                        Session.Abandon();
                        break;
                }

                //game sparas alltid på nytt
                Session["gameSession"] = game;
            }

        }
    }
}            
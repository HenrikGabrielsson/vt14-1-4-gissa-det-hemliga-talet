﻿using System;
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

            //nytt secretnumber-objekt skapas
            SecretNumber game = new SecretNumber();

            Outcome guessStatus = game.MakeGuess(guess);

            GuessBox.Text = String.Format("{0}", (int)game.Outcome);


        }
    }
}
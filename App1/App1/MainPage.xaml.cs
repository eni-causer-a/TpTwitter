using App1.Services;
using Module5TP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ITwitterService twitterService = new TwitterServiceImpl();

        public MainPage()
        {
            InitializeComponent();
            btnConnexion.Clicked += Connection_Clicked;
        }

        private void Connection_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Connection is clicked");
            this.errorLabel.Text = null;
            this.errorLabel.IsVisible = false;

            Boolean isRemind = this.memorise.IsToggled;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                this.errorLabel.Text = "La connexion internet est indisponible";
                this.errorLabel.IsVisible = true;
                return;
            }

            string messageError = this.checkConnection();
            if (messageError != null)
            {
                //Une erreur rencontrée sur formulaire
                this.errorLabel.Text = messageError;
                this.errorLabel.IsVisible = true;
            }
            else
            {
                //Vérification des identifiants
                if (this.twitterService.authenticate(this.identifiant.Text.ToString(), this.motDePasse.Text.ToString()))
                {
                    successConnection();
                }
                else
                {
                    this.errorLabel.Text = "Identifiants inconnus.";
                    this.errorLabel.IsVisible = true;
                }
            }
        }

        private string checkConnection()
        {
            Boolean hasError = false;
            StringBuilder messageErrors = new StringBuilder();
            try
            {
                if (this.identifiant.Text == null || string.IsNullOrEmpty(this.identifiant.Text.ToString()))
                {
                    hasError = true;
                    messageErrors.Append("Veuillez renseigner un identifiant. \n");
                }
                else if (this.identifiant.Text.Length < 3)
                {
                    hasError = true;
                    messageErrors.Append("Veuillez renseigner un identifiant avec plus de 3 caractères. \n");
                }
                if (this.motDePasse.Text == null || string.IsNullOrEmpty(this.motDePasse.Text.ToString()))
                {
                    hasError = true;
                    messageErrors.Append("Veuillez renseigner un mot de passe. \n");
                }
                else if (this.motDePasse.Text.Length < 6)
                {
                    hasError = true;
                    messageErrors.Append("Veuillez renseigner un mot de passe avec plus de 6 caractères. \n");
                }
            }
            catch (Exception exception)
            {
                hasError = true;
                messageErrors.Append(exception.Message);
            }
            if (hasError)
            {
                return messageErrors.ToString();
            }
            else
            {
                return null;
            }
        }
        private async void successConnection()
        {
            await Navigation.PushAsync(new ListTweett());
        }
    }
}


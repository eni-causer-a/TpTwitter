using App1.models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Module5TP.Services
{
    public class TwitterServiceImpl : ITwitterService
    {
        private string CORRECT_USER = "nakimm";
        private string CORRECT_PSWD = "nakimm";

        public bool authenticate(string user, string password)
        {
            return CORRECT_USER.Equals(user) && CORRECT_PSWD.Equals(password);
        }

        public ObservableCollection<Tweet> getTweets(string str)
        {
            ObservableCollection<Tweet> tweets = new ObservableCollection<Tweet>();

            tweets.Add(new Tweet { Identifiant = "1", DateCreation = "06/06/66 06:66", IdentifiantUtilisateur = "1", NomUtilisateur = "Nakim", PseudoUtilisateur = "@NakimZebi", Texte = "L'histoire tout entière n'est qu'une transformation de la nature humaine." });
            tweets.Add(new Tweet { Identifiant = "2", DateCreation = "06/04/66 06:66", IdentifiantUtilisateur = "1", NomUtilisateur = "Nakim", PseudoUtilisateur = "@NakimZebi", Texte = "La lecture est un stratagème qui dispense de réfléchir." });
            tweets.Add(new Tweet { Identifiant = "3", DateCreation = "06/06/66 06:66", IdentifiantUtilisateur = "1", NomUtilisateur = "Nakim", PseudoUtilisateur = "@NakimZebi", Texte = "Tout ce que je sais, c'est que je ne sais rien." });

            return tweets;
        }
    }
}
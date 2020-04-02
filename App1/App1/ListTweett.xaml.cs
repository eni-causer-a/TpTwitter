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
    [DesignTimeVisible(false)]
    public partial class ListTweett : ContentPage
    {
        private TwitterServiceImpl twitterService;

        public ListTweett()
        {
            InitializeComponent();

            twitterService = new TwitterServiceImpl();

            this.tweetListList.ItemsSource = twitterService.getTweets("");
        }
    }
}
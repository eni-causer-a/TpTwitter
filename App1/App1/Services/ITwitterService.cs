
using App1.models;

using System.Collections.ObjectModel;

namespace App1.Services
{
    public interface ITwitterService
    {
        bool authenticate(string user, string password);

        ObservableCollection<Tweet> getTweets(string str);
    }
}
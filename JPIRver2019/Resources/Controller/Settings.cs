using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace JPIRver2019.Resources.Controller
{
    public static class Settings
    {

        private const string IdUrlBase = "url_base";
        private static ISettings AppSettings => CrossSettings.Current;

        public static string email
        {
            get => AppSettings.GetValueOrDefault(nameof(email), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(email), value);
        }

        public static string pass
        {
            get => AppSettings.GetValueOrDefault(nameof(pass), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(pass), value);
        }

        public static string url
        {
            get => AppSettings.GetValueOrDefault(nameof(url), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(url), value);
        }

        public static string estado
        {
            get => AppSettings.GetValueOrDefault(nameof(estado), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(estado), value);
        }

    }
    
}
﻿using neKot_app.Models;
using neKot_app.Views;
using neKot_app.Views.Profile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace neKot_app.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public Command OpenAchivementsCommand {get;}
        public Command RegisterAgainCommand { get;  }
        public Command CheckAuthCommand {get;}
        public Command OpenTutorCommand {get;}
        public Command OpenDilary{get;}
     

        string profileImage = "https://i.pinimg.com/736x/27/aa/5a/27aa5a2ff02558ef7d099355ed79b022.jpg";
        public string ProfileImage
        {
            get => profileImage;
            set
            {
                if (value == profileImage)
                {
                    return;
                }
                profileImage = value;
                OnPropertyChanged(nameof(ProfileImage));
            }
        }
        public string FullName
        {
            get
            {
                string fullname = CurrentUser?.FirstName + " " + CurrentUser?.LastName;                
                return fullname;
            }           
        }
        public ProfileViewModel()
        {
            OpenAchivementsCommand = new Command(async() => await ExecuteOpenAchivementsCommand());
            RegisterAgainCommand = new Command(async () => await ExecuteRegisterAgainCommand());
            CheckAuthCommand = new Command(async() => await ExecuteCheckAuthCommand());
            CheckAuthCommand.Execute(0);
            OpenTutorCommand = new Command(async() => await ExecuteOpenTutorCommand());
            OpenDilary = new Command(async() => await OpenBrowser());
        }
        private async Task ExecuteOpenAchivementsCommand()
        {
             await Shell.Current.GoToAsync(nameof(AchivementPage));
        }

        private async Task ExecuteRegisterAgainCommand()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
        private async Task ExecuteCheckAuthCommand()
        {
            if (CurrentUser == null)
            {
                await Shell.Current.GoToAsync(nameof(AuthPage));
                return;
            }
        }
        private async Task ExecuteOpenTutorCommand()
        {
             await Shell.Current.GoToAsync(nameof(TutorsListPage));
        }
         private async Task OpenBrowser()
        {

            var uri = "http://strategico-dev.ru/diary/1";
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
    
}

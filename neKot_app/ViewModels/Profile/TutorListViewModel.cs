﻿using neKot_app.Models;
using neKot_app.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace neKot_app.ViewModels.Profile
{
   public class TutorListViewModel : BaseViewModel
    {
          
    
        public Command LoadItemsCommand { get; }
        public Command AppearItemsCommamd { get; }
        public Command BackCommand { get;  }
        public ObservableCollection<TutorModel> Achivements { get; set; }
        


        public TutorListViewModel()
        {
            Title = "Тьюторы";
            Achivements = new ObservableCollection<TutorModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AppearItemsCommamd = new Command(async() => await ExecuteAppearItemsCommand());
            BackCommand = new Command(async() => await ExecuteBackCommand());
        }

        private async Task ExecuteLoadItemsCommand()
        {
            //IsBusy = true;
            //Achivements.Clear();
            //try
            //{
            //    await UpdateAchievement();
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}
            //finally
            //{
            //    IsBusy = false;
            //}
        }

        private async Task ExecuteBackCommand()
        {
            await Shell.Current.GoToAsync("///Profile");
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
        private async Task ExecuteAppearItemsCommand()
        {
            Achivements.Clear();
            Achivements.Add(new TutorModel(){ avatar = "", first_name = "Cat", last_name = "meow", description = "a", email = "caaa"});
            IsBusy = false;
            //try
            //{
            //    await UpdateAchievements();
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}
            //finally
            //{
            //    IsBusy = false;
            //}
        }

        private async Task UpdateAchievements()
        {
            Achivements.Clear();
            Achivements.Add(new TutorModel(){ avatar = "", first_name = "Cat", last_name = "meow", description = "a", email = "caaa"});
            IsBusy = false;
            // if (CurrentUser == null)
            //{
            //    await Shell.Current.GoToAsync("///LoginPage");
            //    return;
            //}
            //List<Achivement> achivements = await achivementsSearch.GetAchivementsByName(CurrentUser);
            //foreach (var item in achivements)
            //{
            //    Achivements.Add(item);
            //}
        }
    }
    
}
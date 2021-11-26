﻿using PhamDucThangT2009M1UWP.Entities;
using PhamDucThangT2009M1UWP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PhamDucThangT2009M1UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContacts : Page
    {
        private ContactModel contactModel = new ContactModel();
        public AddContacts()
        {
            this.InitializeComponent();
            this.Loaded += AddContacts_Loaded;
        }

        private void AddContacts_Loaded(object sender, RoutedEventArgs e)
        {
            DatabaseMigration.UpdateDatabase();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var contact = new Contact()
            {
                phoneNumber = txtPhoneNumber.Text,
                name = txtName.Text              
            };
            var resutl = contactModel.Save(contact);
            ContentDialog contentDialog = new ContentDialog();
            if (resutl)
            {
                contentDialog.Title = "Actions success";
                contentDialog.Content = "Contact Saved!";
                contentDialog.PrimaryButtonText = "Ok";
                await contentDialog.ShowAsync();                
            }
            else
            {
                contentDialog.Title = "Actions fails";
                contentDialog.Content = "Please try again!";
                contentDialog.PrimaryButtonText = "Ok";
                await contentDialog.ShowAsync();
            }
        }
    }
}

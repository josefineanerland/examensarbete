using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NotesApp.Models;

namespace NotesApp.Views
{
    public partial class NewNotePage : ContentPage
    {
        public Note Note { get; set; }

        public NewNotePage()
        {
            InitializeComponent();

            Note = new Note
            {
                Title = "Note name",
                Text = "This is an note description.",
                Date = DateTime.Now
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddNote", Note);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
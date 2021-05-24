using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NotesApp.Models;
using NotesApp.ViewModels;

namespace NotesApp.Views
{
    public partial class NoteDetailPage : ContentPage
    {
        NoteDetailViewModel viewModel;

        public Note Note { get; set; }

        public NoteDetailPage(NoteDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public NoteDetailPage()
        {
            InitializeComponent();

            var note = new Note
            {
                Title = "Note",
                Date = DateTime.Now,
                Text = "This is a note description."
            };

            viewModel = new NoteDetailViewModel(note);
            BindingContext = viewModel;
        }

        async void EditNote_Clicked(object sender, EventArgs e)
        {
                await Navigation.PushModalAsync(new NavigationPage(new NewNotePage()));
        }
    }
}
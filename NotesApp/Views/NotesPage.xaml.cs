using System;
using NotesApp.Models;
using NotesApp.ViewModels;
using Xamarin.Forms;

namespace NotesApp.Views
{
    public partial class NotesPage : ContentPage
    {
        NotesViewModel viewModel;

        public NotesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new NotesViewModel();
        }

        async void OnNoteSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var note = (Note)layout.BindingContext;
            await Navigation.PushAsync(new NoteDetailPage(new NoteDetailViewModel(note)));
        }

        async void AddNote_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewNotePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Notes.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}
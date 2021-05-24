using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using NotesApp.Models;
using NotesApp.Views;

namespace NotesApp.ViewModels
{
    public class NotesViewModel : BaseViewModel
    {
        public ObservableCollection<Note> Notes { get; set; }
        public Command LoadNotesCommand { get; set; }

        public NotesViewModel()
        {
            Title = "Browse";
            Notes = new ObservableCollection<Note>();
            LoadNotesCommand = new Command(async () => await ExecuteLoadNotesCommand());

            MessagingCenter.Subscribe<NewNotePage, Note>(this, "AddNote", async (obj, note) =>
            {
                var newNote = note as Note;
                Notes.Add(newNote);
                await DataStore.AddNoteAsync(newNote);
            });
        }

        async Task ExecuteLoadNotesCommand()
        {
            IsBusy = true;

            try
            {
                Notes.Clear();
                var notes = await DataStore.GetNotesAsync(true);
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
using System;

using NotesApp.Models;

namespace NotesApp.ViewModels
{
    public class NoteDetailViewModel : BaseViewModel
    {
        public Note Note { get; set; }
        public NoteDetailViewModel(Note note = null)
        {
            Title = note?.Title;
            Note = note;
        }
    }
}

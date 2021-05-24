using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesApp.Models;

namespace NotesApp.Services
{
    public class MockDataStore : IDataStore<Note>
    {
        readonly List<Note> notes;

        public MockDataStore()
        {
            notes = new List<Note>()
            {
                new Note { Id = Guid.NewGuid().ToString(), Title = "Test", Text="Testar att skriva en text.", Date = DateTime.Now },
                new Note { Id = Guid.NewGuid().ToString(), Title = "Testar", Text="Du visste väl att du även kan klicka på About Me i menyn?", Date = DateTime.Now },
                new Note { Id = Guid.NewGuid().ToString(), Title = "Testing", Text="Testar att skriva en text som är aningens längre än dom tidigare då jag vill se hur det kommer att se ut när texten är längre.", Date = DateTime.Now },
            };
        }

        public async Task<bool> AddNoteAsync(Note note)
        {
            notes.Add(note);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateNoteAsync(Note note)
        {
            var oldNote = notes.Where((Note arg) => arg.Id == note.Id).FirstOrDefault();
            notes.Remove(oldNote);
            notes.Add(note);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteNoteAsync(string id)
        {
            var oldNote = notes.Where((Note arg) => arg.Id == id).FirstOrDefault();
            notes.Remove(oldNote);

            return await Task.FromResult(true);
        }

        public async Task<Note> GetNoteAsync(string id)
        {
            return await Task.FromResult(notes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Note>> GetNotesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(notes);
        }
    }
}
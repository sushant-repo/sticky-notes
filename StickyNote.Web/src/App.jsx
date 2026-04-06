import './App.css'
import SearchField from './components/SearchField'
import AddNote from './components/AddNote'
import { useState } from 'react'
import Note from './components/Note';

function App() {
  const [notes, setNotes] = useState([]);
  const [editNote, setEditNote] = useState(null);

  function handleSearch(value){
    console.log("Search from component: ", value)
  }

  function handleSave(payload){
    console.log(payload);
    const maxId = notes.length > 0 
    ? Math.max(...notes.map(n => n.Id))
    : 0;
    const newId = maxId + 1;
    setNotes([...notes, {...payload, Id: newId}]);
  }

  function deleteNote(id){
    console.log(id)
    setNotes(prev => prev.filter(note => note.Id !== id)); 
  }

  function updateNote(note){
    console.log(note);
    var updatedNote = notes.find(x => x.Id === note.Id);
    updatedNote = {...updatedNote, ...note};
    setNotes(prev => prev.map(n => n.Id === note.Id ? {...n, ...note} : n));
    setEditNote(null);
  }
  

  return (
    <>
    <section>
      <SearchField onSearch={handleSearch}/>
    </section>
    <section>
      <h1 className='text-left'>Sticky Notes</h1>
    </section>
    <section>
      <AddNote onSave={handleSave} note={editNote} onCancel={() => setEditNote(null)} onUpdate={updateNote}/>
    </section>
    <section>
      {notes?.length > 0 && (
        <div className="flex gap-2 my-4">
      {notes?.map((note, index) => (
        <Note key={index} note={note} onDelete={deleteNote} onEdit={(note) => setEditNote(note)} />
      ))}

        </div>
      )}
    </section>
    </>
  )
}

export default App

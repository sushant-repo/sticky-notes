import { useEffect, useState } from "react";

export default function AddNote({onSave, note, onCancel, onUpdate}){
    const [title, setTitle] = useState(note?.Title ?? "");
    const [content, setContent] = useState(note?.Description ?? "");
    const [colour, setColour] = useState(note?.Colour ?? null);


    useEffect(() => {
        setTitle(note?.Title ?? "");
        setContent(note?.Description ?? "");
        setColour(note?.Colour ?? null);
    }, [note]);

    function handleSubmit(e){
        e.preventDefault();

        if(!note){
            handleSave();
        }else{
            handleUpdate();
        }
    }

    function handleSave(){
        onSave?.({
            Title: title,
            Description: content, 
            Colour: colour,
            CreatedDateTime: "10-11-2026 11:30 PM",
        });
        reset();
    }

    function reset(){
        setTitle("");
        setContent("");
        setColour(null);
    }

    function handleCancel(){
        reset();
        onCancel?.();
    }

    function handleUpdate(){
        const updated = {
            Id: note.Id,
            Title: title,
            Description: content,
            Colour: colour,
            CreatedDateTime: "10-11-2026 11:30 PM",
            UpdatedDateTime: "11-11-2026 10:10 AM"
        };

        reset();
        onUpdate?.(updated);
    }

    const colours = [
        {Id: 1, Title: "Red", Code: "#f06868"},
        {Id: 2, Title: "Green", Code: "#3ebb68"},
        {Id: 3, Title: "Blue", Code: "#6897ff"},
        {Id: 4, Title: "Pink", Code: "#ee39ee"},
    ]

   function buttonLabel(){
    return !!note ? "Update Note" : "Add Note";
   }

    function bgColour(c){
        return {
            backgroundColor: c.Code,
            height: colour?.Title === c.Title ? "30px" : "25px",
            width: colour?.Title === c.Title ? "30px" : "25px",
            transition: "all 0.3s ease"
        }
    }

    return (
        <form className="flex flex-col p-2 border rounded" onSubmit={handleSubmit}>
            <input type="text" className="outline-none mb-2 text-lg" value={title} onChange={(e) => setTitle(e.target.value)} placeholder="Title" />
            <textarea value={content} className="outline-none" onChange={(e) => setContent(e.target.value)} placeholder="Take a note" rows="4"/>
            <div className="flex justify-between">
                {colours?.length > 0 && (
                    <div className="flex items-center">
                    {colours?.map((colour, index) =>  (
                        <button key={index}
                        type="button"
                        className="cursor-pointer mr-2 outline rounded-full"
                        style={bgColour(colour)}
                        onClick={() => setColour(colour)}></button>
                    ))}
                </div>
                )}

{!note && (
    <input type="submit" value="Add Note" className="transition-all duration-200 hover:bg-yellow-600 cursor-pointer bg-yellow-500 text-black px-3 py-1  rounded w-fit "/>
)}

{!!note && (
<div className="self-end flex gap-2">
    <input type="submit" value="Update Note" className="transition-all duration-200 hover:bg-yellow-600 cursor-pointer bg-yellow-500 text-black px-3 py-1  rounded w-fit "/>
    <input type="button" value="Cancel" onClick={handleCancel} className="transition-all duration-200  cursor-pointer bg-gray-200 text-black px-3 py-1  rounded w-fit "/>
    </div>
)}

            </div>
        </form>
    );
}
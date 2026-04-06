import { faPencil, faTrash } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export default function Note({note, onDelete, onEdit}){

    return (
        <div style={{background: note.Colour?.Code ?? "lightgrey"}}
         className="group text-left min-w-50 max-w-100 rounded-sm p-2 text-black relative">
            <div className="text-lg">{note.Title}</div>
            <div className="text-base mb-4">{note.Description}</div>
            <div className="text-[10px]">{note.CreatedDateTime}</div>

            <div className="flex gap-2 absolute text-xs top-2 right-2 opacity-0 group-hover:opacity-100 transition-opacity">
                <button
                    type="button"
                    className="text-blue-600 cursor-pointer"
                    onClick={() => onEdit?.(note)}
                >
                    <FontAwesomeIcon icon={faPencil}/>
                </button>
                <button
                    type="button"
                    className="text-red-600 cursor-pointer"
                    onClick={() => onDelete?.(note.Id)}
                >
                    <FontAwesomeIcon icon={faTrash} />
                </button>
            </div>
        </div>
    )
}
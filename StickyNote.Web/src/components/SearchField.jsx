import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSearch, faXmark } from "@fortawesome/free-solid-svg-icons";
import { useState } from "react";
export default function SearchField({onSearch}){
    const [search, setSearch] = useState("");

    function handleInput(value){
        setSearch(value);
        onSearch?.(value);
    }

    function handleClear(){
        setSearch("");
        onSearch?.("");
    }
    return (<>
    <div className="flex items-center border rounded border-gray-300
        px-3 py-2 
        transition-all duration-200
        focus-within:border-blue-500
        focus-within:ring-2
        focus-within:ring-blue-200">
        <FontAwesomeIcon icon={faSearch} className="mr-2"/>
        <input type="text"
            value={search}
            onChange={(e) => handleInput(e.target.value)}
            className="grow outline-none "
            placeholder="Search..."/>
         
         {search && (
         <button type="button" onClick={handleClear}
            className="ml-2 text-gray-500 hover:text-black cursor-pointer">
            <FontAwesomeIcon icon={faXmark} />
         </button>
         )}
    </div>
    </>
    );
}
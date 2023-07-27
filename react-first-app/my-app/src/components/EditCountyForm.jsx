import { useState, useEffect } from "react";
import Button from "./Button";
import Navbar from "./NavBar";
import { useParams, useNavigate } from 'react-router-dom';
import { getCounty, updateCounty } from '../services/CountyService'

const EditCountyForm = () => {

    const { id } = useParams();
    const [name, setName] = useState("");
    
    const navigate = useNavigate();

    const fetchCountyDetails = async () =>{
        let county = await getCounty(id);
        setName(county.Name);
    } 

    const cancelEdit = (event) =>{
        event.preventDefault();
        let cancel = window.confirm("Are you sure you want to cancel edit county?");
        if(cancel) navigate("/");
    }

    useEffect(() => {
        fetchCountyDetails();
    }, []);

    const handleSubmit = (event) => {
        event.preventDefault();

        if(updateCounty(id, name)){
            alert("User was updated!");
            navigate("/");
        }
        else{
            alert("Something went wrong, please try again!");
        }

    }


    return (
        <div className='container'>
            <Navbar />
            <form>
                <input
                    className="form-control"
                    type="text"
                    id="name"
                    placeholder="Input first name"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
                <Button onClick={handleSubmit}  text="Submit" ></Button>
                <Button onClick={cancelEdit} text="Cancel"></Button>
            </form>
        </div>
    )
}

export default EditCountyForm;
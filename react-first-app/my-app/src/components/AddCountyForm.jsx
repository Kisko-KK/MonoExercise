import Button from "./Button";
import Navbar from "./NavBar";
import { useNavigate } from 'react-router-dom';
import { addNewCounty } from '../services/CountyService'

const AddCountyForm = () =>{
  const navigate = useNavigate();

  const addCounty= async (county) => {
    if (await addNewCounty(county)){
      alert('Student has been added!');
      navigate('/');
    }
    else{
      console.log("Couldnt add!");
    }
  };  

    const handleSubmit = (event) =>{
        event.preventDefault();
        let county = {
          Name: document.getElementById("name").value
        };
        addCounty(county);
    }

    return (
      <div className='container'>
        <Navbar />
        <h3>Add new county</h3>
        <form className="form">
        <div>
          <input
            className="form-control"
            type="text"
            id="name"
            placeholder="Input name"
          />
        </div>
        <Button onClick={handleSubmit} text="Submit" ></Button>
      </form>
      </div>
    )
}

export default AddCountyForm;
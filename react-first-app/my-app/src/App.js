import './App.css';
import Table from './components/Table';
import {  useState, useEffect } from 'react';
import {  deleteCounty as removeCounty, getCounties as fetchCounties } from './services/CountyService';
import Navbar from './components/NavBar';
function App() {

const [counties, setCounties] = useState([]);

const getCounties = async () => {
  let response = await fetchCounties();
  setCounties(response);
};

useEffect(() =>  {
  getCounties()
}, []);


 const deleteCounty = (id) => {
  if (removeCounty(id)){
    setCounties(counties.filter((county) => county.Id !== id));
  }
  else{
    console.log("Couldnt delete!");
  }
}


  return (
    <div className='container'>
      <Navbar></Navbar>
      <h1 className='text-center'>Counties</h1>
      <Table counties={counties} deleteCounty={deleteCounty} /> 
    </div>
  );
}

export default App;

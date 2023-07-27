import { useNavigate } from "react-router-dom"
import Button from "./Button"

const Table = ( {counties,  deleteCounty } ) => {

    const navigate = useNavigate();

    const removeCounty = (id) =>{
        let toDelete = window.confirm("Are you sure you want to delete this county?");
        if (toDelete){
            deleteCounty(id);
        }
    }

    return <table className="table table-striped table-sm">
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th></th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            {counties.map((company, index) => (
                <tr key={index}>
                    <td>{company.Id}</td>
                    <td>{company.Name}</td>
                    <td><Button onClick={() => removeCounty(company.Id)} text="Delete"></Button></td>
                    <td><Button onClick={() => navigate(`/edit/${company.Id}`)}text="Edit"></Button></td>
                </tr>
            ))}
        </tbody>
    </table>
}

export default Table
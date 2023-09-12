import React, { useEffect, useState } from "react";
import axios from "axios";
import { Link } from "react-router-dom";

const deleteRazmjenaUrl =
  "https://razmjenaapi.azurewebsites.net/api/RazmjenaAPI";

export const DeleteRazmjenaForm = () => {
  const [razmjene, setRazmjene] = useState([]);
  const [id, setId] = useState("");

  useEffect(() => {
    fetchRazmjene();
  }, []);

  const fetchRazmjene = async () => {
    try {
      const response = await axios.get(deleteRazmjenaUrl);
      const razmjenaData = response.data.result;
      setRazmjene(razmjenaData);
    } catch (error) {
      console.log(error);
    }
  };

  const handleDelete = async () => {
    try {
      await axios.delete(`${deleteRazmjenaUrl}/${id}`);
      fetchRazmjene();
      setId("");
    } catch (error) {
      console.log(error);
    }
  };

  const handleInput = (e) => {
    setId(e.target.value);
  };
  return (
    <>
      <main>
        <div className="list">
          <h1>Unesite ID razmjene koju želite izbrisati</h1>
          <form onSubmit={(e) => e.preventDefault()}>
            <div className="input">
              <label htmlFor="razmjena_id">ID:</label>
              <input
                type="number"
                name="razmjena_id"
                id="razmjena_id"
                placeholder="ID razmjene"
                value={id}
                onChange={handleInput}
              />
            </div>
          </form>
          <div className="form-buttons">
            <button type="button" onClick={handleDelete}>
              Izbriši
            </button>
            <Link to="/razmjene">
              <button onClick={fetchRazmjene}>Popis Razmjena</button>
            </Link>
          </div>
        </div>
      </main>
    </>
  );
};

import React, { useEffect } from "react";
import { useState } from "react";
import { Link } from "react-router-dom";
import axios from "axios";

const getRazmjeneUrl = "https://razmjenaapi.azurewebsites.net/api/RazmjenaAPI";

export const Razmjene = () => {
  const [razmjene, SetRazmjene] = useState([]);
  const fetchRazmjene = async () => {
    try {
      const response2 = await axios(getRazmjeneUrl);
      const razmjenaData = response2.data.result;
      SetRazmjene(razmjenaData);
    } catch (error) {
      console.log(error.response2);
    }
  };
  useEffect(() => {
    fetchRazmjene();
  }, []);
  return (
    <>
      <main>
        <h1>Popis razmjena</h1>
        <ul className=" student-list">
          <li className="student row-titles">
            <span>ID</span>
            <span>ID studenta</span>
            <span>Država</span>
            <span>Sveučilište</span>
            <span>Datum početka</span>
            <span>Datum završetka</span>{" "}
          </li>
          {razmjene.map((razmjena) => {
            const { id, studentId, drzava, sveuciliste, datumOd, datumDo } =
              razmjena;
            return (
              <li key={id} className="student">
                <h3>{id}</h3>
                <h3>{studentId}</h3>
                <h3>{drzava}</h3>
                <h3>{sveuciliste}</h3>
                <h3>{datumOd}</h3>
                <h3>{datumDo}</h3>
              </li>
            );
          })}
          <li className="edit-create-buttons">
            <Link to="/create/razmjena">
              <button>Create</button>
            </Link>
            <Link to="/delete/razmjena">
              <button>Delete</button>
            </Link>
            <Link to={"/edit/razmjena"}>
              <button>Edit</button>
            </Link>
          </li>
        </ul>
      </main>
    </>
  );
};

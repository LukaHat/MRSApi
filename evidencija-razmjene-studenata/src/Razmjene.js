import React, { useEffect } from "react";
import { useState } from "react";
import { Link } from "react-router-dom";
import axios from "axios";

const getRazmjeneUrl = "https://razmjenaapi.azurewebsites.net/api/RazmjenaAPI";

function formatDateToDMY(dateString) {
  const date = new Date(dateString);
  const day = date.getDate();
  const month = date.getMonth() + 1; // Months are 0-based
  const year = date.getFullYear();

  // Add leading zeros if needed
  const formattedDay = day < 10 ? `0${day}` : day;
  const formattedMonth = month < 10 ? `0${month}` : month;

  return `${formattedDay}-${formattedMonth}-${year}`;
}

export const Razmjene = () => {
  const [razmjene, setRazmjene] = useState([]);
  const fetchRazmjene = async () => {
    try {
      const response = await axios.get(getRazmjeneUrl);
      const razmjenaData = response.data.result.map((razmjena) => ({
        ...razmjena,
        datumOd: formatDateToDMY(razmjena.datumOd),
        datumDo: formatDateToDMY(razmjena.datumDo),
      }));
      setRazmjene(razmjenaData);
    } catch (error) {
      console.log(error);
    }
  };
  useEffect(() => {
    fetchRazmjene();
  }, []);
  return (
    <>
      <main>
        <ul className="list">
          <h1 className="sub-title">Popis razmjena</h1>
          <li className="row-titles">
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
              <li key={id} className="rows">
                <h3>{id}</h3>
                <h3>{studentId}</h3>
                <h3>{drzava}</h3>
                <h3>{sveuciliste}</h3>
                <h3>{datumOd}</h3>
                <h3>{datumDo}</h3>
              </li>
            );
          })}
          <li className="crud-buttons">
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

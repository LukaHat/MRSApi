import React, { useState } from "react";
import axios from "axios";
import { Link } from "react-router-dom";

const createRazmjenaUrl =
  "https://razmjenaapi.azurewebsites.net/api/RazmjenaAPI";

export const CreateRazmjenaForm = () => {
  const [id, setId] = useState("");
  const [studentId, setStudentId] = useState("");
  const [drzava, setDrzava] = useState("");
  const [sveuciliste, setSveuciliste] = useState("");
  const [datumOd, setDatumOd] = useState("");
  const [datumDo, setDatumDo] = useState("");

  const handleCreate = async () => {
    const newRazmjena = {
      id: 0,
      studentId,
      drzava,
      sveuciliste,
      datumOd,
      datumDo,
    }; // Set id to 0

    try {
      await axios.post(createRazmjenaUrl, newRazmjena);
      // Clear input fields after successful creation
      setStudentId("");
      setDrzava("");
      setSveuciliste("");
      setDatumOd("");
      setDatumDo("");
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
      <h1>Unesite podatke za novu razmjenu</h1>
      <form>
        <div>
          <label htmlFor="razmjena_studentId">Id studenta na razmjeni:</label>
          <input
            type="text"
            name="razmjena_studentId"
            id="razmjena_studentId"
            placeholder="ID studenta"
            value={studentId}
            onChange={(e) => setStudentId(e.target.value)}
          />
        </div>
        <div>
          <label htmlFor="razmjena_drzava">Drzava studenta na razmjeni:</label>
          <input
            type="text"
            name="razmjena_drzava"
            id="razmjena_drzava"
            placeholder="drzava studenta"
            value={drzava}
            onChange={(e) => setDrzava(e.target.value)}
          />
        </div>
        <div>
          <label htmlFor="razmjena_sveuciliste">
            Sveuciliste studenta na razmjeni:
          </label>
          <input
            type="text"
            name="razmjena_sveuciliste"
            id="razmjena_sveuciliste"
            placeholder="sveuciliste studenta"
            value={sveuciliste}
            onChange={(e) => setSveuciliste(e.target.value)}
          />
        </div>
        <div>
          <label htmlFor="razmjena_datumOd">Datum početka razmjene:</label>
          <input
            type="date"
            name="razmjena_datumOd"
            id="razmjena_datumOd"
            placeholder="datumOd studenta"
            value={datumOd}
            onChange={(e) => setDatumOd(e.target.value)}
          />
        </div>
        <div>
          <label htmlFor="razmjena_datumDo">Datum kraja razmjene:</label>
          <input
            type="date"
            name="razmjena_datumDo"
            id="razmjena_datumDo"
            placeholder="datumDo studenta"
            value={datumDo}
            onChange={(e) => setDatumDo(e.target.value)}
          />
        </div>
        <div>
          <button type="button" onClick={handleCreate}>
            Kreiraj razmjenu
          </button>
        </div>
      </form>
      <Link to="/razmjene">
        <button>Povratak na popis razmjena</button>
      </Link>
    </>
  );
};

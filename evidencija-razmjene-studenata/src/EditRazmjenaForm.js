import React, { useEffect, useState } from "react";
import axios from "axios";
import { Link } from "react-router-dom";

const editRazmjenaUrl = "https://razmjenaapi.azurewebsites.net/api/RazmjenaAPI";

export const EditRazmjenaForm = () => {
  const [id, setId] = useState("");
  const [studentId, setStudentId] = useState("");
  const [drzava, setDrzava] = useState("");
  const [sveuciliste, setSveuciliste] = useState("");
  const [datumOd, setDatumOd] = useState("");
  const [datumDo, setDatumDo] = useState("");

  useEffect(() => {
    const fetchRazmjenaData = async () => {
      if (id) {
        try {
          const response = await axios.get(`${editRazmjenaUrl}/${id}`);
          const razmjenaData = response.data;
          setStudentId(razmjenaData.studentId);
          setDrzava(razmjenaData.drzava);
          setSveuciliste(razmjenaData.sveuciliste);
          setDatumOd(razmjenaData.datumOd);
          setDatumDo(razmjenaData.datumDo);
        } catch (error) {
          console.log(error);
        }
      }
    };

    fetchRazmjenaData();
  }, [id]);

  const handleEdit = async () => {
    const editedRazmjena = {
      id,
      studentId,
      drzava,
      sveuciliste,
      datumOd,
      datumDo,
    };
    try {
      await axios.put(`${editRazmjenaUrl}/${id}`, editedRazmjena);

      setId("");
      setStudentId("");
      setDrzava("");
      setSveuciliste("");
      setDatumOd("");
      setDatumDo("");
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <>
      <main>
        <div className="list">
          <h1>Uredite podatke o razmjenama</h1>
          <form>
            <div className="input">
              <label htmlFor="razmjena_id">ID:</label>
              <input
                type="text"
                name="razmjena_id"
                id="razmjena_id"
                placeholder="ID Razmjene"
                value={id}
                onChange={(e) => setId(e.target.value)}
              />
            </div>
            <div className="input">
              <label htmlFor="razmjena_studentId">
                Id studenta na razmjeni:
              </label>
              <input
                type="text"
                name="razmjena_studentId"
                id="razmjena_studentId"
                placeholder="ID studenta"
                value={studentId}
                onChange={(e) => setStudentId(e.target.value)}
              />
            </div>
            <div className="input">
              <label htmlFor="razmjena_drzava">
                Drzava studenta na razmjeni:
              </label>
              <input
                type="text"
                name="razmjena_drzava"
                id="razmjena_drzava"
                placeholder="drzava studenta"
                value={drzava}
                onChange={(e) => setDrzava(e.target.value)}
              />
            </div>
            <div className="input">
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
            <div className="input">
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
            <div className="input">
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
          </form>
          <div className="form-buttons">
            <button type="button" onClick={handleEdit}>
              Spremi promjene
            </button>
            <Link to="/razmjene">
              <button>Popis razmjena</button>
            </Link>
          </div>
        </div>
      </main>
    </>
  );
};

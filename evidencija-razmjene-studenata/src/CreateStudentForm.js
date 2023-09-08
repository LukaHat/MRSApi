import React, { useState } from "react";
import axios from "axios";
import { Link } from "react-router-dom";

const createStudentUrl = "https://razmjenaapi.azurewebsites.net/api/StudentAPI";

export const CreateStudentForm = () => {
  const [ime, setIme] = useState("");
  const [prezime, setPrezime] = useState("");
  const [jmbag, setJmbag] = useState("");

  const handleCreate = async () => {
    const newStudent = { id: 0, ime, prezime, jmbag }; // Set id to 0

    try {
      await axios.post(createStudentUrl, newStudent);
      // Clear input fields after successful creation
      setIme("");
      setPrezime("");
      setJmbag("");
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
      <main>
        <h1>Unesite podatke za novog studenta</h1>
        <form>
          <div>
            <label htmlFor="student_ime">Ime:</label>
            <input
              type="text"
              name="student_ime"
              id="student_ime"
              placeholder="Ime Studenta"
              value={ime}
              onChange={(e) => setIme(e.target.value)}
            />
          </div>
          <div>
            <label htmlFor="student_prezime">Prezime:</label>
            <input
              type="text"
              name="student_prezime"
              id="student_prezime"
              placeholder="Prezime Studenta"
              value={prezime}
              onChange={(e) => setPrezime(e.target.value)}
            />
          </div>
          <div>
            <label htmlFor="student_jmbag">JMBAG:</label>
            <input
              type="text"
              name="student_jmbag"
              id="student_jmbag"
              placeholder="JMBAG Studenta"
              value={jmbag}
              onChange={(e) => setJmbag(e.target.value)}
            />
          </div>
          <div>
            <button type="button" onClick={handleCreate}>
              Kreiraj studenta
            </button>
          </div>
          <Link to="/studenti">
            <button>Popis studenata</button>
          </Link>
        </form>
      </main>
    </>
  );
};

import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link } from "react-router-dom";

const editStudentUrl = "https://razmjenaapi.azurewebsites.net/api/StudentAPI";

export const EditStudentForm = () => {
  const [id, setId] = useState(""); // State variable for id
  const [ime, setIme] = useState("");
  const [prezime, setPrezime] = useState("");
  const [jmbag, setJmbag] = useState("");

  useEffect(() => {
    // Fetch the student data based on the id whenever id changes
    const fetchStudentData = async () => {
      if (id) {
        try {
          const response = await axios.get(`${editStudentUrl}/${id}`);
          const studentData = response.data;
          setIme(studentData.ime);
          setPrezime(studentData.prezime);
          setJmbag(studentData.jmbag);
        } catch (error) {
          console.error(error);
        }
      }
    };

    fetchStudentData();
  }, [id]);

  const handleEdit = async () => {
    const editedStudent = { id, ime, prezime, jmbag };

    try {
      await axios.put(`${editStudentUrl}/${id}`, editedStudent);
      // Handle successful edit

      // Clear input fields by resetting state to empty strings
      setId("");
      setIme("");
      setPrezime("");
      setJmbag("");
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
      <h1>Uredite podatke studenta</h1>
      <form>
        <div>
          <label htmlFor="student_id">ID:</label>
          <input
            type="text"
            name="student_id"
            id="student_id"
            placeholder="ID Studenta"
            value={id}
            onChange={(e) => setId(e.target.value)} // Update id state on input change
          />
        </div>
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
          <button type="button" onClick={handleEdit}>
            Spremi promjene
          </button>
        </div>
      </form>
      <Link to="/studenti">
        <button>Povratak na popis studenata</button>
      </Link>
    </>
  );
};

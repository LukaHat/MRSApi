import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link } from "react-router-dom";

const getStudentUrl = "https://razmjenaapi.azurewebsites.net/api/StudentAPI";

export const DeleteStudentForm = () => {
  const [students, setStudents] = useState([]);
  const [id, setId] = useState("");

  useEffect(() => {
    fetchStudents();
  }, []);

  const fetchStudents = async () => {
    try {
      const response = await axios.get(getStudentUrl);
      const studentData = response.data.result;
      setStudents(studentData);
    } catch (error) {
      console.error(error);
    }
  };

  const handleDelete = async () => {
    try {
      await axios.delete(`${getStudentUrl}/${id}`);
      fetchStudents();
      setId("");
    } catch (error) {
      console.error(error);
    }
  };

  const handleInput = (e) => {
    setId(e.target.value);
  };

  return (
    <>
      <main>
        <div className="list">
          <h1>Unesite ID studenta kojeg želite izbrisati</h1>
          <form onSubmit={(e) => e.preventDefault()}>
            <div className="input">
              <label htmlFor="student_id">ID:</label>
              <input
                type="number"
                name="student_id"
                id="student_id"
                placeholder="ID Studenta"
                value={id}
                onChange={handleInput}
              />
            </div>
          </form>
          <div className="form-buttons">
            <button type="button" onClick={handleDelete}>
              Izbriši
            </button>
            <Link to="/studenti">
              <button onClick={fetchStudents}>Popis studenata</button>
            </Link>
          </div>
        </div>
      </main>
    </>
  );
};

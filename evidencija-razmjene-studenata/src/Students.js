import React, { useEffect } from "react";
import { useState } from "react";
import { Link } from "react-router-dom";
import axios from "axios";

const getStudentUrl = "https://razmjenaapi.azurewebsites.net/api/StudentAPI";

export const Students = () => {
  const [students, setStudents] = useState([]);
  const fetchStudents = async () => {
    try {
      const response1 = await axios(getStudentUrl);
      const studentData = response1.data.result;
      setStudents(studentData);
    } catch (error) {
      console.log(error.response1);
    }
  };
  useEffect(() => {
    fetchStudents();
  }, []);
  return (
    <>
      <main>
        <ul className="list">
          <h1 className="sub-title">Studenti na razmjeni</h1>
          <li className="row-titles">
            <span>Id</span>
            <span>Ime</span>
            <span>Prezime</span>
            <span>JMBAG</span>
          </li>
          {students.map((student) => {
            const { id, ime, prezime, jmbag } = student;
            return (
              <li key={id} className="rows">
                <h3>{id}</h3>
                <h3>{ime}</h3>
                <h3>{prezime}</h3>
                <h3>{jmbag}</h3>
              </li>
            );
          })}
          <li className="crud-buttons">
            <Link to="/create/student">
              <button>Dodaj</button>
            </Link>
            <Link to="/delete/student">
              <button>Obriši</button>
            </Link>
            <Link to={"/edit/student"}>
              <button>Uredi</button>
            </Link>
          </li>
        </ul>
      </main>
    </>
  );
};

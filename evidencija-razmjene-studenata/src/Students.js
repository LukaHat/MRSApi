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
      <h1>Studenti na razmjeni</h1>
      <ul className="student-list">
        {students.map((student) => {
          const { id, ime, prezime, jmbag } = student;
          return (
            <li key={id} className="student">
              <h3>Id: {id}</h3>
              <h3>Ime: {ime}</h3>
              <h3>Prezime: {prezime}</h3>
              <h3>JMBAG: {jmbag}</h3>
            </li>
          );
        })}
        <li className="edit-create-buttons">
          <Link to="/create/student">
            <button>Create</button>
          </Link>
          <Link to="/delete/student">
            <button>Delete</button>
          </Link>
          <Link to={"/edit/student"}>
            <button>Edit</button>
          </Link>
        </li>
      </ul>
    </>
  );
};

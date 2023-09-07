import React from "react";
import { Route, Routes } from "react-router-dom";
import { Home } from "./Home";
import { Students } from "./Students";
import { Razmjene } from "./Razmjene";
import { ErrorPage } from "./ErrorPage";
import { Header } from "./Header";
import { Footer } from "./Footer";
import { DeleteRazmjenaForm } from "./DeleteRazmjenaForm";
import { DeleteStudentForm } from "./DeleteStudentForm";
import { EditStudentForm } from "./EditStudentForm";
import { EditRazmjenaForm } from "./EditRazmjenaForm";
import { CreateRazmjenaForm } from "./CreateRazmjenaForm";
import { CreateStudentForm } from "./CreateStudentForm";
//styles
import "./dist/css/styles.min.css";

const App = () => {
  return (
    <>
      <Header />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/studenti" element={<Students />} />
        <Route path="/razmjene" element={<Razmjene />} />
        <Route path="/edit/razmjena" element={<EditRazmjenaForm />} />
        <Route path="/edit/student" element={<EditStudentForm />} />
        <Route path="/create/student" element={<CreateStudentForm />} />
        <Route path="/create/razmjena" element={<CreateRazmjenaForm />} />
        <Route path="/delete/student" element={<DeleteStudentForm />} />
        <Route path="/delete/razmjena" element={<DeleteRazmjenaForm />} />
        <Route path="*" element={<ErrorPage />}></Route>
      </Routes>
      <Footer />
    </>
  );
};

export default App;

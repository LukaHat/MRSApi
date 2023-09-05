import React from "react";
import { Route, Routes } from "react-router-dom";
import { Home } from "./Home";
import { Students } from "./Students";
import { Razmjene } from "./Razmjene";
import { ErrorPage } from "./ErrorPage";
import { Header } from "./Header";
import { Footer } from "./Footer";

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
        <Route path="*" element={<ErrorPage />}></Route>
      </Routes>
      <Footer />
    </>
  );
};

export default App;

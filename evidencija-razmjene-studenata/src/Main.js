import React from "react";
import { Link } from "react-router-dom";

export const Main = () => {
  return (
    <>
      <main>
        <h1>Evidencija studenata na razmjeni</h1>
        <button>
          <Link to="/studenti">Pregledaj podatke o studentima</Link>
        </button>
        <button>
          <Link to="/razmjene">Pregledaj podatke o razmjenama</Link>
        </button>
      </main>
    </>
  );
};

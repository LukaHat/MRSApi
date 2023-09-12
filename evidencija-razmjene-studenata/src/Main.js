import React from "react";
import { Link } from "react-router-dom";
import studentsImage from "./assets/student.png";

export const Main = () => {
  return (
    <>
      <main className="home-page">
        <article>
          <section>
            <h1>Evidencija studenata na razmjeni</h1>
          </section>

          <section className="main-link-buttons">
            <Link to="/studenti">
              <button>Podaci o studentima</button>
            </Link>
            <Link to="/razmjene">
              <button>Podaci o razmjenama</button>
            </Link>
          </section>
        </article>
        <img src={studentsImage} alt="students" />
      </main>
    </>
  );
};

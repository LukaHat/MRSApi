import React from "react";
import { Link } from "react-router-dom";

export const Main = () => {
  return (
    <>
      <main>
        <article>
          <section>
            <h1>Evidencija studenata na razmjeni</h1>
            <p>
              Ova stranica napravljena je kako bi se olakšala evidencija
              studenata na razmjeni.
              <br />
              Putem ove stranice omogućen je pregled, brisanje, ažuriranje te
              brisanje podataka o studentima i razmjenama.
            </p>
          </section>
        </article>
        <section className="main-link-buttons">
          <Link to="/studenti">
            <button>Podaci o studentima</button>
          </Link>
          <Link to="/razmjene">
            <button>Podaci o razmjenama</button>
          </Link>
        </section>
      </main>
    </>
  );
};

import React from "react";
import { Link } from "react-router-dom";

export const Header = () => {
  return (
    <>
      <nav>
        <ul className="header-nav">
          <li>
            <Link to="/">
              <h1>Evidencija Razmjena</h1>
            </Link>
          </li>
          <li>
            <Link to="/studenti">Studenti</Link>
            <Link to="/razmjene">Razmjene</Link>
          </li>
        </ul>
      </nav>
    </>
  );
};

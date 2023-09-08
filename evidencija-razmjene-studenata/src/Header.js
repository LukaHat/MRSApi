import React from "react";
import { Link } from "react-router-dom";

export const Header = () => {
  return (
    <>
      <nav>
        <ul className="header-nav">
          <li>
            <Link to="/">
              <h2>Evidencija Razmjena</h2>
            </Link>
          </li>
          <li className="main-nav">
            <Link to="/studenti">Studenti</Link>
            <Link to="/razmjene">Razmjene</Link>
          </li>
        </ul>
      </nav>
    </>
  );
};

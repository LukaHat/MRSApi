import React from "react";
import { Link } from "react-router-dom";
import img from "../src/assets/main-logo.png";

export const Header = () => {
  return (
    <>
      <nav>
        <ul>
          <li className="main-title">
            <Link to="/">
              <img src={img} alt="student exchange logo" />
              <h2>Evidencija Razmjena</h2>
            </Link>
          </li>
          <li id="nav-links">
            <Link to="/studenti">Studenti</Link>
            <Link to="/razmjene">Razmjene</Link>
          </li>
        </ul>
      </nav>
    </>
  );
};

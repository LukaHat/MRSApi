import React from "react";
import { Link } from "react-router-dom";

export const Footer = () => {
  return (
    <>
      <footer>
        <small>
          <p>
            <Link to="https://github.com/LukaHat/MRSApi" target="_blank">
              Github repozitorij stranice
            </Link>
          </p>
          <p>Stranica je napravljena u svrhe završnoga rada</p>
        </small>
      </footer>
    </>
  );
};

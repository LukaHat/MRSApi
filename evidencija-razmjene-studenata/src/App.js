import React from "react";
import { BrowserRouter as Router, Route, Link, Routes } from "react-router-dom";
import StudentList from "./StudentList";

export default function App() {
  return (
    <Router>
      <div>
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route
            path="/https://razmjenaapi.azurewebsites.net/api/StudentAPI"
            exact
            component={StudentList}
          />
        </Routes>
      </div>
    </Router>
  );
}

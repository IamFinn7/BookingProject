import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import "./App.css";
import Register from "./auth/Register";
// import Login from "./auth/Login";

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Register />} />
        {/* <Route path="/login" element={<Login />} /> */}
      </Routes>
    </Router>
  );
};

export default App;

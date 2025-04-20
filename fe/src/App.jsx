import React from "react";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
} from "react-router-dom";
import "./App.css";
import Register from "./auth/Register";
import Login from "./auth/Login";
import { useAuth } from "./contexts/AuthContext.jsx";
import Dashboard from "./auth/Dashboard.jsx";

const App = () => {
  const { isAuthenticated } = useAuth();

  return (
    <Router>
      <Routes>
        <Route
          path="/register"
          element={
            !isAuthenticated ? <Register /> : <Navigate to="/" />
          }
        />
        <Route
          path="/login"
          element={!isAuthenticated ? <Login /> : <Navigate to="/" />}
        />
        <Route path="/" element={<Dashboard />} />
      </Routes>
    </Router>
  );
};

export default App;

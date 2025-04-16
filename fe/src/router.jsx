import React, { Profiler } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Login from "./pages/Login";
import Register from "./pages/Register";
import Home from "./pages/Home";

const Router = () => {
  const onRenderCallback = (
    id,
    phase,
    actualDuration,
    baseDuration,
    startTime,
    commitTime
  ) => {
    console.log(`${id} rendered in ${actualDuration}ms`);
  };

  return (
    <Routes>
      <Route path="/" element={<Navigate to="/login" />} />
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route path="/home" element={<Home />} />

      {/* Cung cấp id cho Profiler */}
      <Route
        path="/profile"
        element={
          <Profiler id="ProfilePage" onRender={onRenderCallback}>
            {/* Các component bên trong */}
            <div>Profile Content</div>
          </Profiler>
        }
      />
    </Routes>
  );
};

export default Router;

import React, { useState } from "react";
import { Container, Typography, Button, Box } from "@mui/material";
import InputField from "../components/InputField";
import { Link, useNavigate } from "react-router-dom";
import api from "../services/api";

const Register = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirm, setConfirm] = useState("");
  const navigate = useNavigate();

  const handleRegister = async () => {
    if (password !== confirm) {
      alert("Passwords do not match!");
      return;
    }

    try {
      await api.post("/access/register", {
        email,
        password,
      });

      alert("Registration successful! You can now log in.");
      navigate("/login");
    } catch (error) {
      alert(
        "Registration failed: " + error.response?.data?.message ||
          "Unknown error"
      );
    }
  };

  return (
    <Container maxWidth="sm">
      <Box mt={10}>
        <Typography variant="h4" align="center" gutterBottom>
          Register
        </Typography>
        <InputField
          label="Email"
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <InputField
          label="Password"
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <InputField
          label="Confirm Password"
          type="password"
          value={confirm}
          onChange={(e) => setConfirm(e.target.value)}
        />
        <Button
          fullWidth
          variant="contained"
          color="primary"
          onClick={handleRegister}
        >
          Register
        </Button>
        <Typography align="center" mt={2}>
          Already have an account? <Link to="/login">Login</Link>
        </Typography>
      </Box>
    </Container>
  );
};

export default Register;

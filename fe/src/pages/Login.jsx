import React, { useState } from "react";
import { Container, Typography, Button, Box } from "@mui/material";
import InputField from "../components/InputField";
import { Link, useNavigate } from "react-router-dom";
import api from "../services/api";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const response = await api.post("/access/login", { email, password });
      const { tokens, user } = response.data;

      // ✅ Lưu token và userId vào localStorage
      localStorage.setItem("token", tokens.accessToken);
      localStorage.setItem("refreshToken", tokens.refreshToken);
      localStorage.setItem("userId", user.userId);

      // ✅ Chuyển qua trang dashboard/profile
      navigate("/profile");
    } catch (error) {
      setError("Đăng nhập thất bại. Vui lòng kiểm tra email và mật khẩu");
    }
  };

  return (
    <Container maxWidth="sm">
      <Box mt={10}>
        <Typography variant="h4" align="center" gutterBottom>
          Login
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
        <Button
          fullWidth
          variant="contained"
          color="primary"
          onClick={handleLogin}
        >
          Login
        </Button>
        <Typography align="center" mt={2}>
          Don't have an account? <Link to="/register">Register</Link>
        </Typography>
      </Box>
    </Container>
  );
};

export default Login;

import React, { useEffect, useState } from "react";
import { Container, Typography, Button, Box } from "@mui/material";
import api from "../services/api";
import { useNavigate } from "react-router-dom";

const Home = () => {
  const [userInfo, setUserInfo] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const res = await api.get("/access/profile"); // Giả sử có endpoint này
        setUserInfo(res.data);
      } catch (err) {
        alert("Token hết hạn hoặc không hợp lệ");
        navigate("/login");
      }
    };

    fetchData();
  }, []);

  const handleLogout = () => {
    localStorage.removeItem("token");
    navigate("/login");
  };

  return (
    <Container maxWidth="sm">
      <Box mt={10}>
        <Typography variant="h4" gutterBottom>
          Welcome!
        </Typography>
        {userInfo && (
          <>
            <Typography>Email: {userInfo.email}</Typography>
          </>
        )}
        <Button
          variant="outlined"
          color="error"
          onClick={handleLogout}
          sx={{ mt: 3 }}
        >
          Logout
        </Button>
      </Box>
    </Container>
  );
};

export default Home;

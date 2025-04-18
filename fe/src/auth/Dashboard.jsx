import { Button } from "antd";
import { useAuth } from "../contexts/AuthContext.jsx";

const Dashboard = () => {
  const { UserData, logout } = useAuth();

  const handleLogout = async () => {
    await logout();
  }
  
  return (
    <>
      <Button onClick={logout}>Logout</Button>
    </>
  );
};

export default Dashboard;

import { Button, Layout } from "antd";
import { useAuth } from "../contexts/AuthContext.jsx";
import CustomHeader from "../components/header.jsx";

const { Header } = Layout;

const Dashboard = () => {
  const { UserData, logout } = useAuth();

  const handleLogout = async () => {
    await logout();
  };

  return (
    <Layout>
      <Header style={{ background: "white" }}>
        <CustomHeader></CustomHeader>
      </Header>
    </Layout>
    // <>
    //   <Button onClick={logout}>Logout</Button>
    // </>
  );
};

export default Dashboard;

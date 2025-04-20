import React from "react";
import { Menu, Typography, Flex, Button, Popover } from "antd";
import { geekblue } from "@ant-design/colors";
import { MenuOutlined, ShoppingCartOutlined } from "@ant-design/icons";
import { Link } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext.jsx";
import { useNavigate } from "react-router-dom";

const menuItems = [
  { key: "home", label: <Link to="/dashboard">Trang chủ</Link> },
  { key: "about", label: <Link to="/dashboard">About</Link> },
  { key: "rooms", label: <Link to="/dashboard">Rooms</Link> },
  { key: "news", label: <Link to="/dashboard">News</Link> },
  { key: "pages", label: <Link to="/dashboard">Pages</Link> },
];

const CustomHeader = () => {
  const { logout, isAuthenticated } = useAuth();
  const navigate = useNavigate();

  const handleLogout = async () => {
    await logout();
    navigate("/");
  };

  const handleNavigate = (path) => {
    navigate(path);
  };

  const menuIcons = (
    <Menu style={{ border: "none" }}>
      <Menu.Item key="profile" style={{ padding: 0, background: "none" }}>
        <Button
          type="text"
          onClick={() => handleNavigate("/profile")}
          style={{
            width: "100%",
            textAlign: "left",
            padding: "8px 16px",
            fontSize: "18px",
            fontWeight: "500",
          }}
        >
          Tài khoản
        </Button>
      </Menu.Item>
      <Menu.Item key="logout" style={{ padding: 0, background: "none" }}>
        <Button
          type="text"
          danger
          onClick={handleLogout}
          style={{
            width: "100%",
            textAlign: "left",
            padding: "8px 16px",
            fontSize: "18px",
            fontWeight: "500",
          }}
        >
          Đăng xuất
        </Button>
      </Menu.Item>
    </Menu>
  );

  return (
    <Flex align="center" justify="space-between" style={{ height: "100%" }}>
      <div style={{ flex: "0 0 20%" }}>
        <Typography.Title level={3} type="secondary" style={{ margin: 0 }}>
          Logo HERE
        </Typography.Title>
      </div>

      <Menu
        mode="horizontal"
        selectable={false}
        style={{
          flex: "0 0 60%",
          fontSize: "18px",
          fontWeight: "500",
          justifyContent: "center",
          border: "none",
        }}
        items={menuItems}
      />

      <Flex
        justify="flex-end"
        gap={35}
        align="center"
        style={{ flex: "0 0 20%" }}
      >
        <Button
          icon={<ShoppingCartOutlined />}
          onClick={() => {
            if (isAuthenticated) {
              navigate("/cart");
            } else {
              navigate("/login");
            }
          }}
          style={{
            fontSize: "25px",
            fontWeight: "500",
            border: "none",
            padding: "1.25rem",
          }}
        />

        {isAuthenticated ? (
          <Popover content={menuIcons} placement="bottomLeft">
            <Button
              icon={<MenuOutlined style={{ fontSize: "20px" }} />}
              style={{
                fontSize: "17px",
                fontWeight: "bold",
                border: "none",
                padding: "1.25rem",
              }}
            />
          </Popover>
        ) : (
          <Button
            onClick={() => navigate("/login")}
            style={{
              fontSize: "17px",
              fontWeight: "500",
              background: geekblue[6],
              color: "white",
              padding: "1.25rem",
            }}
          >
            Đăng nhập
          </Button>
        )}
      </Flex>
    </Flex>
  );
};

export default CustomHeader;

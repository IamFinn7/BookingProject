import React, { useState } from "react";
import { Menu, Typography, Flex, Button, Popover } from "antd";
import { MenuOutlined } from "@ant-design/icons";
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

const HeaderMenu = () => {
  const { logout } = useAuth();
  const navigate = useNavigate();

  const handleLogout = async () => {
    await logout();
    navigate("/login");
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
    <Flex align="center" justify="space-between">
      <Typography.Title level={3} type="secondary" style={{ margin: 0 }}>
        Logo HERE
      </Typography.Title>

      <Menu
        mode="horizontal"
        selectable={false}
        style={{
          flex: 1,
          fontSize: "18px",
          fontWeight: 500,
          justifyContent: "center",
        }}
        items={menuItems}
      />

      <Popover content={menuIcons} placement="bottomLeft">
        <Button
          icon={<MenuOutlined />}
          style={{ fontSize: "20px", border: "none" }}
        />
      </Popover>
    </Flex>
  );
};

export default HeaderMenu;

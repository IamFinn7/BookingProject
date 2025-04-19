import React from "react";
import { Card, Flex, Typography, Form, Input, Button, Row, Col } from "antd";
import { geekblue } from "@ant-design/colors";
import { Link } from "react-router-dom";
import useLogin from "../hooks/useLogin";

const Login = () => {
  const { loading, loginUser, contextHolder } = useLogin();

  const handleLogin = async (values) => {
    await loginUser(values);
  };

  return (
    <Row style={{ height: "100vh" }} align="middle" justify="center">
      <Col>
        <Card className="form-container">
          {contextHolder}
          <Flex vertical flex={1}>
            <Typography.Title
              level={3}
              strong
              className="title"
              style={{
                textAlign: "center",
                paddingBottom: "2vh",
                marginTop: "1vh",
              }}
            >
              Đăng nhập
            </Typography.Title>
            <Form layout="vertical" onFinish={handleLogin} autoComplete="off">
              <Form.Item
                name="email"
                rules={[
                  {
                    required: true,
                    message: "Hãy nhập email!",
                  },
                  {
                    type: "email",
                    message: "Email không hợp lệ!",
                  },
                ]}
              >
                <Input size="large" placeholder="Email của bạn" />
              </Form.Item>
              <Form.Item
                name="password"
                rules={[
                  {
                    required: true,
                    message: "Hãy nhập mật khẩu!",
                  },
                ]}
              >
                <Input.Password size="large" placeholder="Mật khẩu" />
              </Form.Item>
              <Form.Item>
                <Button
                  type={`${loading ? "" : "primary"}`}
                  htmlType="submit"
                  size="large"
                  block
                  style={{
                    background: geekblue[6],
                    color: "white",
                  }}
                >
                  Đăng nhập
                </Button>
              </Form.Item>
              <Form.Item style={{ textAlign: "center", marginBottom: "1vh" }}>
                <Typography.Text>
                  Bạn chưa có tài khoản?{" "}
                  <Link to="/register" style={{ color: geekblue[6] }}>
                    Đăng ký
                  </Link>
                </Typography.Text>
              </Form.Item>
            </Form>
          </Flex>
        </Card>{" "}
      </Col>
    </Row>
  );
};

export default Login;

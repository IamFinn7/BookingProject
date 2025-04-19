import React from "react";
import {
  Card,
  Flex,
  Typography,
  Form,
  Input,
  Button,
  Spin,
  Row,
  Col,
} from "antd";
import { geekblue } from "@ant-design/colors";
import { Link } from "react-router-dom";
import useSignup from "../hooks/useSignup";

const Register = () => {
  const { loading, registerUser, contextHolder } = useSignup();
  const handleRegister = (values) => {
    registerUser(values);
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
              Tạo tài khoản
            </Typography.Title>
            <Form
              layout="vertical"
              onFinish={handleRegister}
              autoComplete="off"
            >
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
              <Form.Item
                name="passwordConfirm"
                rules={[
                  {
                    required: true,
                    message: "Hãy nhập lại mật khẩu!",
                  },
                ]}
              >
                <Input.Password size="large" placeholder="Nhập lại mật khẩu" />
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
                  {loading ? <Spin /> : "Đăng ký"}
                </Button>
              </Form.Item>
              <Form.Item style={{ textAlign: "center", marginBottom: "1vh" }}>
                <Typography.Text>
                  Đã có tài khoản?{" "}
                  <Link to="/login" style={{ color: geekblue[6] }}>
                    Đăng nhập
                  </Link>
                </Typography.Text>
              </Form.Item>
            </Form>
          </Flex>
        </Card>
      </Col>
    </Row>
  );
};

export default Register;

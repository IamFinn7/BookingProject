import { useState } from "react";
import { useAuth } from "../contexts/AuthContext.jsx";
import { message } from "antd";

const useSignup = () => {
  const { login } = useAuth();
  const [loading, setLoading] = useState(false);
  const [messageApi, contextHolder] = message.useMessage();

  const registerUser = async (values) => {
    if (values.password !== values.passwordConfirm) {
      messageApi.error("Mật khẩu không trùng khớp");
      return;
    }

    try {
      setLoading(true);

      const { passwordConfirm, ...payload } = values;

      console.log("📦 Dữ liệu gửi đi:", values);

      const res = await fetch("https://localhost:7242/api/access/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(values),
      });

      const data = await res.json();
      if (res.status === 200) {
        messageApi.success("Đăng ký tài khoản thành công !");
        login(data.token, data.user);
      } else if (res.status === 400) {
        messageApi.error(data.message);
      } else {
        messageApi.error("Đăng ký không thành công !");
      }
    } catch (error) {
      messageApi.error("Lỗi kết nối !");
    } finally {
      setLoading(false);
    }
  };

  return { loading, registerUser, contextHolder };
};

export default useSignup;

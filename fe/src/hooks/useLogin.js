import { useState } from "react";
import { useAuth } from "../contexts/AuthContext.jsx";
import { message } from "antd";

const useLogin = () => {
  const { login } = useAuth();
  const [loading, setLoading] = useState(false);
  const [messageApi, contextHolder] = message.useMessage();

  const loginUser = async (values) => {
    try {
      setLoading(true);

      const { passwordConfirm, ...payload } = values;

      const res = await fetch("https://localhost:7242/api/access/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(values),
      });

      const data = await res.json();
      console.log("🧪 Toàn bộ data từ API:", data);
      if (res.status === 200) {
        const accessToken = data.tokens.accessToken;
        const user = data.user;

        login(accessToken, user);

        messageApi.success("Đăng nhập thành công !");
      } else if (res.status === 401) {
        messageApi.error("Tài khoản hoặc mật khẩu sai !");
      } else {
        messageApi.error("Đăng nhập không thành công !");
      }
    } catch (error) {
      messageApi.error("Lỗi kết nối !");
    } finally {
      setLoading(false);
    }
  };

  return { loading, loginUser, contextHolder };
};

export default useLogin;

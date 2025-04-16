import { useEffect, useState } from "react";
import api from "../services/api";

export default function Profile() {
  const [id, setId] = useState(""); // Chắc chắn setId nhận string
  const [error, setError] = useState("");

  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const response = await api.get("/access/profile");

        // Kiểm tra cấu trúc dữ liệu trả về
        if (response.data && typeof response.data.id === "string") {
          setId(response.data.id); // Đảm bảo id là string
        } else {
          setError("Dữ liệu không hợp lệ");
        }
      } catch (err) {
        setError("Token hết hạn hoặc không hợp lệ");
      }
    };
    fetchProfile();
  }, []);

  return (
    <div style={{ padding: 20 }}>
      <h2>Trang Cá Nhân</h2>
      {error ? <p style={{ color: "red" }}>{error}</p> : <p>ID: {id}</p>}{" "}
      {/* In ra id thay vì email */}
    </div>
  );
}

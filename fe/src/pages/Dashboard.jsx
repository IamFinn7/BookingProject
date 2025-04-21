import { useEffect, useState } from "react";
import axios from "axios";
import { Layout, Row, Col, message } from "antd";
import CustomHeader from "../components/header.jsx";
import RoomCard from "../components/RoomCard.jsx";

const { Header, Content } = Layout;

const Dashboard = () => {
  const [rooms, setRooms] = useState([]);
  const [loading, setLoading] = useState(false);

  const fetchRooms = async () => {
    try {
      setLoading(true);
      const response = await axios.get("https://localhost:7242/api/hotels");

      const hotels = response.data.metadata;

      const roomData = hotels.map((hotel) => ({
        id: hotel.id,
        title: hotel.name,
        address: `${hotel.address}, ${hotel.city}, ${hotel.country}`,
        description: hotel.description || "Không có mô tả",
        star: hotel.star,
        image: hotel.images[0],
        rating: hotel.rating,
        amenities: hotel.amenities,
      }));

      setRooms(roomData);
    } catch (error) {
      console.error("Error fetching rooms:", error);
      message.error("Không thể tải danh sách phòng");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchRooms();
  }, []);

  return (
    <Layout>
      <Header style={{ background: "white", height: "10vh" }}>
        <CustomHeader />
      </Header>
      <Content style={{ padding: "2rem" }}>
        <Row gutter={[16, 16]}>
          {rooms.map((room) => (
            <Col span={24} key={room.id}>
              <RoomCard room={room} />
            </Col>
          ))}
        </Row>
      </Content>
    </Layout>
  );
};

export default Dashboard;

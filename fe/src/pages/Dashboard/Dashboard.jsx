import { useEffect, useState } from "react";
import axios from "axios";
import { API_URLS } from "../../config";
import { Layout, Row, Col, message } from "antd";
import CustomHeader from "../../components/header.jsx";
import HotelCard from "./HotelCard.jsx";

const { Header, Content } = Layout;

const Dashboard = () => {
  const [hotels, setHotels] = useState([]);
  const [loading, setLoading] = useState(false);

  const fetchHotels = async () => {
    try {
      setLoading(true);
      const response = await axios.get(API_URLS.hotels);

      const hotels = response.data.metadata;

      const hotelData = hotels.map((hotel) => ({
        id: hotel.id,
        name: hotel.name,
        address: `${hotel.address}, ${hotel.city}, ${hotel.country}`,
        description: hotel.description || "Không có mô tả",
        star: hotel.star,
        image: hotel.images[0],
        rating: hotel.rating,
        amenities: hotel.amenities,
      }));

      setHotels(hotelData);
    } catch (error) {
      console.error("Error fetching hotels:", error);
      message.error("Không thể tải danh sách khách sạn");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchHotels();
  }, []);

  return (
    <Layout>
      <Header style={{ background: "white", height: "10vh" }}>
        <CustomHeader />
      </Header>
      <Content style={{ padding: "2rem" }}>
        <Row gutter={[16, 16]}>
          {hotels.map((hotel) => (
            <Col span={24} key={hotel.id}>
              <HotelCard hotel={hotel} />
            </Col>
          ))}
        </Row>
      </Content>
    </Layout>
  );
};

export default Dashboard;

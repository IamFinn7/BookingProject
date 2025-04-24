import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Layout, Spin } from "antd";
import axios from "axios";
import CustomHeader from "../../components/header.jsx";
import HotelImages from "./Images.jsx";
import HotelInfo from "./HotelInfo/Index.jsx";
import Rooms from "./RoomInfo/Index.jsx";
import { API_URLS } from "../../config.js";

const { Header, Content } = Layout;

const HotelDetail = () => {
  const { id } = useParams();
  const [hotel, setHotel] = useState(null);
  const [rooms, setRooms] = useState(null);
  const [loading, setLoading] = useState(false);
  const [previewVisible, setPreviewVisible] = useState(false);

  const fetchHotelDetail = async () => {
    try {
      setLoading(true);
      const response = await axios.get(`${API_URLS.hotels}/${id}`);
      setHotel(response.data.metadata);
    } catch (error) {
      console.error("Error fetching hotel detail:", error);
    } finally {
      setLoading(false);
    }
  };

  const fetchRooms = async () => {
    try {
      const response = await axios.get(`${API_URLS.hotels}/${id}/rooms`);
      setRooms(response.data.metadata);
    } catch (error) {
      console.error("Error fetching hotel's rooms:", error);
    }
  };

  useEffect(() => {
    if (id) {
      fetchHotelDetail();
      fetchRooms();
    }
  }, [id]);

  if (loading || !hotel) return <Spin tip="Đang tải dữ liệu..." />;

  return (
    <Layout>
      <Header style={{ background: "white", height: "10vh" }}>
        <CustomHeader />
      </Header>
      <Content>
        <div style={{ padding: "2rem" }}>
          <HotelImages
            hotel={hotel}
            previewVisible={previewVisible}
            setPreviewVisible={setPreviewVisible}
          />

          <HotelInfo hotel={hotel} />

          <Rooms rooms={rooms} />
        </div>
      </Content>
    </Layout>
  );
};

export default HotelDetail;

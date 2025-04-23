import React, { useState } from "react";
import { Card, Col, Row, Typography, Button, Image, Space } from "antd";
import { LeftOutlined, RightOutlined } from "@ant-design/icons";
import SquareFootIcon from "@mui/icons-material/SquareFoot";
import SmokeFreeIcon from "@mui/icons-material/SmokeFree";

const { Title, Text } = Typography;

const Rooms = ({ rooms }) => {
  const [imageIndices, setImageIndices] = useState({});

  const handleNextImage = (roomId, imagesLength) => {
    setImageIndices((prev) => ({
      ...prev,
      [roomId]: (prev[roomId] + 1) % imagesLength || 0,
    }));
  };

  const handlePrevImage = (roomId, imagesLength) => {
    setImageIndices((prev) => ({
      ...prev,
      [roomId]: (prev[roomId] - 1 + imagesLength) % imagesLength || 0,
    }));
  };

  return (
    <>
      {rooms.map((room) => {
        const currentIndex = imageIndices[room.id] || 0;
        const images = room.images || [];

        return (
          <Card key={room.id} style={{ marginTop: "1rem" }}>
            <Title level={3} style={{ fontWeight: 700, margin: 0 }}>
              {room.name || "Phòng không tên"}
            </Title>

            <Row gutter={48} style={{ marginTop: "1.5rem" }}>
              <Col span={8}>
                <div style={{ position: "relative", textAlign: "center" }}>
                  <Image
                    src={
                      images[currentIndex] || "https://via.placeholder.com/300"
                    }
                    alt="Room"
                    style={{ borderRadius: 25 }}
                  />

                  <Button
                    shape="circle"
                    icon={<LeftOutlined />}
                    onClick={() => handlePrevImage(room.id, images.length)}
                    style={{
                      position: "absolute",
                      top: "50%",
                      left: 10,
                      transform: "translateY(-50%)",
                      backgroundColor: "rgba(0, 0, 0, 0.3)",
                      color: "#fff",
                      border: "none",
                    }}
                  />

                  <Button
                    shape="circle"
                    icon={<RightOutlined />}
                    onClick={() => handleNextImage(room.id, images.length)}
                    style={{
                      position: "absolute",
                      top: "50%",
                      right: 10,
                      transform: "translateY(-50%)",
                      backgroundColor: "rgba(0, 0, 0, 0.3)",
                      color: "#fff",
                      border: "none",
                    }}
                  />
                </div>

                <Row style={{ marginTop: "1rem" }}>
                  <Space style={{ fontSize: 18, fontWeight: 500, gap: 12 }}>
                    <SquareFootIcon style={{ fontSize: 30 }} />
                    {room.area || "Không rõ"} m²
                  </Space>
                </Row>

                <Row style={{ marginTop: "0.25rem" }}>
                  <Space style={{ fontSize: 18, fontWeight: 500, gap: 12 }}>
                    <SmokeFreeIcon style={{ fontSize: 30 }} />
                    {room.isSmokingAllowed ? "Có hút thuốc" : "Không hút thuốc"}
                  </Space>
                </Row>
              </Col>

              <Col span={16}>
                <Text>{room.description}</Text>
              </Col>
            </Row>
          </Card>
        );
      })}
    </>
  );
};

export default Rooms;

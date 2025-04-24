import React, { useState } from "react";
import { Card, Col, Row, Typography, Button, Image, Space } from "antd";
import { LeftOutlined, RightOutlined } from "@ant-design/icons";
import SquareFootIcon from "@mui/icons-material/SquareFoot";
import SmokeFreeIcon from "@mui/icons-material/SmokeFree";
import { getAmenityIcon } from "../../../utils/amenityIcons.jsx";
import { gray } from "@ant-design/colors";
import PriceTable from "./Price.jsx";

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

        const amenitiesToDisplay = room.amenities?.slice(0, 6) || [];
        const leftColumn = amenitiesToDisplay.filter(
          (_, index) => index % 2 === 0
        );
        const rightColumn = amenitiesToDisplay.filter(
          (_, index) => index % 2 !== 0
        );

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
                  <Space
                    style={{
                      gap: 12,
                    }}
                  >
                    <div
                      style={{
                        display: "flex",
                        alignItems: "center",
                        justifyContent: "center",
                      }}
                    >
                      <SquareFootIcon style={{ fontSize: 30 }} />
                    </div>
                    <Text style={{ fontSize: 17, fontWeight: 500 }}>
                      {room.area ? `${room.area} m²` : "Chưa rõ diện tích"}
                    </Text>
                  </Space>
                </Row>

                <Row style={{ marginTop: "0.5rem" }}>
                  <Space
                    style={{
                      gap: 12,
                    }}
                  >
                    <div
                      style={{
                        display: "flex",
                        alignItems: "center",
                        justifyContent: "center",
                      }}
                    >
                      <SmokeFreeIcon style={{ fontSize: 30 }} />
                    </div>
                    <Text style={{ fontSize: 17, fontWeight: 500 }}>
                      {room.isSmokingAllowed
                        ? "Có hút thuốc"
                        : "Không hút thuốc"}
                    </Text>
                  </Space>
                </Row>

                <Row style={{ marginTop: "1rem", color: gray[3] }}>
                  {[leftColumn, rightColumn].map((col, index) => (
                    <Col key={index} span={12}>
                      {col.map((item, idx) => (
                        <div
                          key={idx}
                          style={{
                            display: "flex",
                            alignItems: "center",
                            gap: 8,
                            marginBottom: "0.75rem",
                            fontWeight: 500,
                          }}
                        >
                          {React.cloneElement(getAmenityIcon(item), {
                            style: { fontSize: 20 },
                          })}
                          <Text style={{ fontSize: 15, color: gray[3] }}>
                            {item}
                          </Text>
                        </div>
                      ))}
                    </Col>
                  ))}
                </Row>
              </Col>

              <Col span={16}>
                <PriceTable></PriceTable>
                {/* <PriceTable roomPrices={room.prices} /> */}
              </Col>
            </Row>
          </Card>
        );
      })}
    </>
  );
};

export default Rooms;

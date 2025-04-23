import React from "react";
import { Col, Row, Card, Button, Space, Typography } from "antd";
import { SignatureFilled, EnvironmentFilled } from "@ant-design/icons";
import { geekblue } from "@ant-design/colors";

const { Title, Text } = Typography;

const CardComponent = ({ hotel, leftColumn, rightColumn, getAmenityIcon }) => {
  return (
    <>
      {/* Đánh giá */}
      <Col span={8}>
        <Card style={{ height: "17rem" }}>
          <Row
            align="middle"
            gutter={[12, 12]}
            style={{ padding: "12px 16px" }}
          >
            <Col span={2} style={{ textAlign: "right", padding: 0 }}>
              <SignatureFilled style={{ fontSize: 24, color: geekblue[7] }} />
            </Col>
            <Col span={5} flex="auto">
              <Row align="middle" style={{ marginBottom: 4 }}>
                <Text
                  strong
                  style={{
                    fontSize: 26,
                    color: geekblue[6],
                    lineHeight: "32px",
                  }}
                >
                  {hotel.rating.averageRating}
                </Text>
                <Text
                  strong
                  style={{ fontSize: 18, marginLeft: 4, color: geekblue[4] }}
                >
                  / 10
                </Text>
              </Row>
            </Col>
            <Col span={17}>
              <Title
                level={5}
                style={{ margin: 0, fontWeight: 600, fontSize: 20 }}
              >
                Rất tốt
              </Title>
              <Row align="middle">
                <Button
                  type="text"
                  style={{
                    fontSize: 18,
                    padding: 0,
                    textDecoration: "none",
                    backgroundColor: "transparent",
                    color: geekblue[6],
                    fontWeight: 700,
                  }}
                  onClick={() => alert("Clicked!")}
                >
                  {hotel.rating.reviewCount} đánh giá &gt;
                </Button>
              </Row>
            </Col>
          </Row>
        </Card>
      </Col>

      {/* Bản đồ - Địa chỉ */}
      <Col span={8}>
        <Card style={{ height: "17rem" }}>
          <Row style={{ display: "flex", alignItems: "flex-end" }}>
            <Col span={12}>
              <Title level={4} style={{ margin: 0, fontWeight: 700 }}>
                Trong khu vực
              </Title>
            </Col>
            <Col span={12} style={{ textAlign: "right" }}>
              <Button
                type="text"
                style={{
                  fontSize: 17,
                  padding: 0,
                  textDecoration: "none",
                  backgroundColor: "transparent",
                  color: geekblue[6],
                  fontWeight: 700,
                }}
                onClick={() => alert("Clicked!")}
              >
                Xem bản đồ &gt;
              </Button>
            </Col>
          </Row>
          <Row style={{ marginTop: "1.75rem" }}>
            <Space style={{ fontSize: 17, fontWeight: 500, gap: 12 }}>
              <EnvironmentFilled />
              {hotel.address}
            </Space>
          </Row>
        </Card>
      </Col>

      {/* Tiện nghi */}
      <Col span={8}>
        <Card style={{ height: "17rem" }}>
          <Row style={{ display: "flex", alignItems: "flex-end" }}>
            <Col span={12}>
              <Title level={4} style={{ margin: 0, fontWeight: 700 }}>
                Tiện nghi
              </Title>
            </Col>
            <Col span={12} style={{ textAlign: "right" }}>
              <Button
                type="text"
                style={{
                  fontSize: 17,
                  padding: 0,
                  textDecoration: "none",
                  backgroundColor: "transparent",
                  color: geekblue[6],
                  fontWeight: 700,
                }}
                onClick={() => alert("Clicked!")}
              >
                Xem thêm &gt;
              </Button>
            </Col>
          </Row>
          <Row style={{ marginTop: "1.75rem" }}>
            {[leftColumn, rightColumn].map((col, index) => (
              <Col key={index} span={12}>
                {col.map((item, idx) => (
                  <div
                    key={idx}
                    style={{
                      display: "flex",
                      alignItems: "center",
                      gap: 12,
                      marginBottom: "1.25rem",
                      fontWeight: 500,
                    }}
                  >
                    {getAmenityIcon(item)}
                    <Text style={{ fontSize: 16 }}>{item}</Text>
                  </div>
                ))}
              </Col>
            ))}
          </Row>
        </Card>
      </Col>
    </>
  );
};

export default CardComponent;

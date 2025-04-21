import { Card, Typography, Button, Space, Row, Col, Rate, Tag } from "antd";
import { SignatureFilled, EnvironmentOutlined } from "@ant-design/icons";
import { geekblue, volcano } from "@ant-design/colors";
import { useNavigate } from "react-router-dom";

const { Title, Paragraph, Text } = Typography;

const RoomCard = ({ room }) => {
  const navigate = useNavigate();

  return (
    <Card
      size="small"
      hoverable
      onClick={() => navigate(`/hotel/${room.id}`)}
      style={{ marginBottom: 20 }}
    >
      <Row style={{ height: "250px" }}>
        <Col xs={24} sm={8} md={6} style={{ height: "100%" }}>
          <img
            alt="room"
            src={room.image}
            style={{ width: "100%", height: "100%", objectFit: "cover" }}
          />
        </Col>

        <Col
          xs={24}
          sm={8}
          md={14}
          style={{
            height: "100%",
            paddingLeft: 20,
            paddingRight: 20,
          }}
        >
          <Title level={3} style={{ marginBottom: 12 }}>
            {room.title}
          </Title>

          <Space style={{ marginBottom: 10 }}>
            <Rate allowHalf disabled value={room.star} count={room.star} />
          </Space>

          <Paragraph type="secondary">
            <Space>
              <EnvironmentOutlined style={{ color: volcano[7] }} />
              {room.address}
            </Space>
          </Paragraph>

          <Paragraph>{room.description}</Paragraph>

          <Space wrap style={{ marginTop: 10 }}>
            {room.amenities.map((item, idx) => (
              <Text
                key={idx}
                style={{
                  background: "#f0f0f0",
                  padding: "4px 8px",
                  borderRadius: 4,
                }}
              >
                {item}
              </Text>
            ))}
          </Space>
        </Col>

        <Col
          xs={24}
          sm={8}
          md={4}
          style={{
            height: "100%",
            display: "flex",
            flexDirection: "column",
            justifyContent: "space-between",
            alignItems: "flex-end",
            padding: 20,
            borderLeft: "1px solid #f0f0f0",
          }}
        >
          <div style={{ textAlign: "right" }}>
            <Text strong style={{ fontSize: 20, color: geekblue[7] }}>
              {room.rating.averageRating}
              <SignatureFilled style={{ marginLeft: "8px" }} />
            </Text>{" "}
            <br />
            <Text type="secondary">
              <span style={{ marginRight: "4px" }}>
                {room.rating.reviewCount}
              </span>
              <span>đánh giá</span>
            </Text>
          </div>

          <Tag color="red" style={{ marginTop: 16 }}>
            {/* {availabilityNote} */}
            Chỉ còn 1 phòng giá này
          </Tag>

          <div style={{ textAlign: "right", marginBottom: "1rem" }}>
            <Title level={4} style={{ marginBottom: 0, marginTop: "1.25rem" }}>
              {/* {price.toLocaleString()} {currency} */}
              416.763
            </Title>
            <Text type="secondary" style={{ fontSize: "13px" }}>
              Giá mỗi đêm chưa gồm thuế và phí
            </Text>
          </div>

          <Button
            style={{
              background: volcano[4],
              color: "white",
              fontSize: "17px",
              fontWeight: 500,
              padding: "1.25rem 0.75rem",
              border: "none",
            }}
          >
            Chọn phòng
          </Button>
        </Col>
      </Row>
    </Card>
  );
};

export default RoomCard;

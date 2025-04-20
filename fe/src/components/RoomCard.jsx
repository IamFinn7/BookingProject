import { Card, Typography, Button, Space, Row, Col, Rate, Tag } from "antd";

const { Title, Paragraph, Text } = Typography;

const RoomCard = ({ room }) => {
  return (
    <Card size="small" hoverable style={{ marginBottom: 20 }}>
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
            <Rate allowHalf disabled defaultValue={room.rating} />
          </Space>

          <Paragraph type="secondary">📍 {room.address}</Paragraph>

          <Paragraph>{room.description}</Paragraph>

          {/* Tiện nghi */}
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
            <Text strong style={{ fontSize: 20 }}>
              {/* {rating} */}
              7.5 rất tốt
            </Text>{" "}
            <br />
            <Text type="secondary">
              {/* {reviews.toLocaleString()} nhận xét */}
              4.047 nhận xét
            </Text>
          </div>

          <Tag color="red" style={{ marginTop: 16 }}>
            {/* {availabilityNote} */}
            Chỉ còn 1 phòng giá này
          </Tag>

          <div style={{ textAlign: "right", marginTop: 12 }}>
            <Text type="secondary" style={{ fontSize: "13px" }}>
              Giá mỗi đêm chưa gồm thuế và phí
            </Text>
            <Title level={4} style={{ marginBottom: 0 }}>
              {/* {price.toLocaleString()} {currency} */}
              416.763
            </Title>
          </div>
        </Col>

        {/* <Col xs={24} sm={16} md={18}>
          <Title level={4}>{room.title}</Title>
          <Paragraph>{room.description}</Paragraph>
          <Space direction="vertical">
            <Paragraph>
              <b>{room.pricePerNight}</b> / 1 night
            </Paragraph>
            <Paragraph>
              <b>{room.pricePerWeek}</b> / 7 nights
            </Paragraph>
            <Space wrap>
              {room.amenities.map((item, idx) => (
                <span key={idx} style={{ marginRight: "8px" }}>{item}</span>
              ))}
            </Space>
            <Button type="primary" style={{ marginTop: "10px" }}>
              Book now
            </Button>
          </Space>
        </Col> */}
      </Row>
    </Card>
  );
};

export default RoomCard;

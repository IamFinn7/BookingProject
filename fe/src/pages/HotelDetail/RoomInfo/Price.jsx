import React from "react";
import { Row, Col, Typography, Divider, Tag } from "antd";
import { geekblue } from "@ant-design/colors";

const { Text } = Typography;

const PriceTable = ({ roomPrices = [] }) => {
  // Dữ liệu mẫu nếu không có props
  const sampleData = [
    {
      title: "Le Premier - Room Only",
      description: [
        "Không bao gồm bữa sáng",
        "1 giường đôi",
        "Miễn phí DRINKS, BICYCLE",
        "Miễn phí hủy phòng trước 24 May 12:59",
      ],
      guests: 2,
      adults: 2,
      special: "Đặc biệt dành cho bạn!",
      originalPrice: "600.117 VND",
      discountPrice: "450.088 VND",
      note: "Chưa bao gồm thuế và phí",
      left: "Chỉ còn 4 phòng",
    },
    {
      title: "Le Premier - Room Only",
      description: [
        "Không bao gồm bữa sáng",
        "1 giường đôi",
        "Thanh Toán Tại Khách Sạn",
        "Thanh toán khi bạn nhận phòng tại nơi ở",
        "Miễn phí DRINKS, BICYCLE",
        "Áp dụng chính sách hủy phòng",
      ],
      guests: 2,
      adults: 2,
      special: "Đặc biệt dành cho bạn!",
      originalPrice: "600.117 VND",
      discountPrice: "450.088 VND",
      note: "Chưa bao gồm thuế và phí",
      left: "Chỉ còn 4 phòng",
    },
  ];

  const data = roomPrices.length > 0 ? roomPrices : sampleData;

  return (
    <>
      <Row
        style={{
          fontWeight: 600,
          marginBottom: 12,
          background: geekblue[0],
        }}
      >
        <Col span={10} style={{fontSize: 17, fontWeight: 700}}>Lựa chọn phòng</Col>
        <Col span={4}>Khách</Col>
        <Col span={6}>Giá/phòng/đêm</Col>
        <Col span={3}></Col>
      </Row>

      {data.map((item, index) => (
        <Row key={index} style={{ marginBottom: 24 }}>
          <Col span={14}>
            <Text strong>{item.title}</Text>
            <div style={{ marginTop: 8 }}>
              {item.description.map((desc, i) => (
                <div key={i}>
                  <Text>{desc}</Text>
                </div>
              ))}
            </div>
          </Col>

          <Col span={5} style={{ textAlign: "center" }}>
            <div>{item.guests}</div>
            <div>{item.adults}</div>
            <Tag color="red" style={{ marginTop: 8 }}>
              {item.special}
            </Tag>
          </Col>

          <Col span={5} style={{ textAlign: "right" }}>
            <Text delete>{item.originalPrice}</Text>
            <br />
            <Text strong style={{ fontSize: 16 }}>
              {item.discountPrice}
            </Text>
            <br />
            <Text type="secondary">{item.note}</Text>
            <br />
            <Text type="danger">{item.left}</Text>
          </Col>
        </Row>
      ))}
    </>
  );
};

export default PriceTable;

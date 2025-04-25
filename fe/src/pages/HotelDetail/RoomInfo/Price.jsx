import React from "react";
import { Row, Col, Typography, Divider, Tag, Button, Space } from "antd";
import { blue, geekblue } from "@ant-design/colors";
import KingBedOutlinedIcon from "@mui/icons-material/KingBedOutlined";
import PersonIcon from "@mui/icons-material/Person";
import ChildCareIcon from "@mui/icons-material/ChildCare";

const { Text } = Typography;

const PriceTable = ({ roomPrices = [] }) => {
  // Dữ liệu mẫu nếu không có props
  const sampleData = [
    {
      title: "Le Premier - Room Only",
      description: ["Không bao gồm bữa sáng"],
      //  "1 giường đôi",
      //   "Miễn phí DRINKS, BICYCLE",
      //   "Miễn phí hủy phòng trước 24 May 12:59",
      //  "1 giường đôi",
      // "Thanh Toán Tại Khách Sạn",
      // "Thanh toán khi bạn nhận phòng tại nơi ở",
      // "Miễn phí DRINKS, BICYCLE",
      // "Áp dụng chính sách hủy phòng",
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
      description: ["Không bao gồm bữa sáng"],
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
          padding: "1rem 0.75rem",
          background: geekblue[0],
          borderTopLeftRadius: 8,
          borderTopRightRadius: 8,
          border: "1px solid #e0e0e0",
        }}
      >
        <Col
          span={10}
          style={{ fontSize: 17, fontWeight: 700, textAlign: "left" }}
        >
          Lựa chọn phòng
        </Col>
        <Col
          span={4}
          style={{ fontSize: 17, fontWeight: 700, textAlign: "center" }}
        >
          Khách
        </Col>
        <Col
          span={6}
          style={{ fontSize: 17, fontWeight: 700, textAlign: "right" }}
        >
          Giá/phòng/đêm
        </Col>
        <Col span={4}></Col>
      </Row>

      {data.map((item, index) => {
        const isLast = index === data.length - 1;
        return (
          <Row
            key={index}
            style={{
              padding: "1.25rem 0.75rem",
              border: "1px solid #e0e0e0",
              borderTop: "none",
              borderBottomLeftRadius: isLast ? 8 : 0,
              borderBottomRightRadius: isLast ? 8 : 0,
            }}
          >
            <Col span={10}>
              <Text type="secondary" strong style={{ display: "block" }}>
                {item.title}
              </Text>
              <Text
                style={{
                  fontSize: 17,
                  fontWeight: 700,
                  display: "block",
                  margin: "0.5rem 0",
                }}
              >
                {item.description[0]}
              </Text>
              <div
                style={{
                  display: "flex",
                  alignItems: "center",
                  gap: 8,
                  fontWeight: 500,
                }}
              >
                <KingBedOutlinedIcon style={{ fontSize: 20 }} />
                <Text style={{ fontSize: 15 }}>1 giường đôi</Text>
              </div>
            </Col>

            <Col span={4}>
              <div
                style={{
                  height: "100%",
                  display: "flex",
                  alignItems: "center",
                  justifyContent: "center",
                  gap: 5,
                  fontWeight: 500,
                }}
              >
                <PersonIcon style={{ fontSize: 20 }} />
                <Text style={{ fontSize: 15 }}>{item.guests}</Text>
                <ChildCareIcon style={{ fontSize: 20 }} />
                <Text style={{ fontSize: 15 }}>{item.adults}</Text>
              </div>
            </Col>

            <Col span={6} style={{ textAlign: "right" }}>
              <Tag color="red" style={{ marginTop: 8 }}>
                {item.special}
              </Tag>
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

            <Col span={4} style={{ textAlign: "center" }}>
              <Button>ABC</Button>
            </Col>
          </Row>
        );
      })}
    </>
  );
};

export default PriceTable;

import React from "react";
import { Typography, Row, Col, Button, Rate } from "antd";
import { volcano, geekblue } from "@ant-design/colors";
import { getAmenityIcon } from "../../../utils/amenityIcons.jsx";
import { accommodationType } from "../../../utils/accommodationTypes.js";
import Description from "./Description.jsx";
import CardComponent from "./Card.jsx";

const { Title, Text } = Typography;

const HotelInfo = ({ hotel }) => {
  const amenitiesToDisplay = hotel.amenities?.slice(0, 8) || [];
  const leftColumn = amenitiesToDisplay.slice(0, 4);
  const rightColumn = amenitiesToDisplay.slice(4, 8);

  const description = `Khách sạn Boutique Le House nằm ở khu vực / thành phố Phường Phước Mỹ. Lễ tân phục vụ 24/24 giờ để phục vụ bạn, từ khi nhận phòng đến khi trả phòng, hoặc bất kỳ sự hỗ trợ nào bạn cần. Nếu bạn muốn thêm, đừng ngần ngại hỏi lễ tân, chúng tôi luôn sẵn sàng phục vụ bạn. Wifi có sẵn trong các khu vực công cộng của khách sạn để giúp bạn kết nối với gia đình và bạn bè.`;

  return (
    <>
      <Row gutter={16}>
        <Col span={16}>
          <Title level={2} style={{ margin: 0, fontWeight: 700 }}>
            {hotel.name}
          </Title>

          <div
            style={{
              display: "flex",
              alignItems: "center",
              gap: 12,
              marginTop: "1rem",
            }}
          >
            <div
              style={{
                background: geekblue[1],
                color: geekblue[7],
                borderRadius: 14,
                padding: "4px 12px",
                fontWeight: 500,
                minWidth: "fit-content",
              }}
            >
              {accommodationType[hotel.type]}
            </div>
            <Rate allowHalf disabled value={hotel.star} count={hotel.star} />
          </div>
        </Col>

        <Col
          span={5}
          style={{
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
            textAlign: "right",
          }}
        >
          <Text type="secondary" style={{ fontSize: 15, fontWeight: 500 }}>
            Giá/phòng/đêm từ
          </Text>
          <Title
            level={3}
            style={{ margin: 0, fontWeight: 700, color: volcano[5] }}
          >
            444.592 VND
          </Title>
        </Col>

        <Col
          span={3}
          style={{
            display: "flex",
            flexDirection: "column",
            justifyContent: "center",
            padding: "0rem 1.5rem",
          }}
        >
          <Button
            style={{
              background: volcano[5],
              color: "white",
              fontSize: 18,
              fontWeight: 500,
              padding: "1.5rem 0rem",
              border: "none",
            }}
          >
            Chọn phòng
          </Button>
        </Col>
      </Row>

      <Row gutter={24} style={{ marginTop: "2rem" }}>
        <CardComponent
          hotel={hotel}
          leftColumn={leftColumn}
          rightColumn={rightColumn}
          getAmenityIcon={getAmenityIcon}
        />
      </Row>

      <Description description={description} />
    </>
  );
};

export default HotelInfo;

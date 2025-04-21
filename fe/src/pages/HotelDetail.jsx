import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import {
  Typography,
  Spin,
  Descriptions,
  Image,
  Row,
  Col,
  Button,
  Modal,
} from "antd";

const accommodationTypeMapByIndex = {
  0: "Khách sạn",
  1: "Nhà dân (Homestay)",
  2: "Nhà trọ",
  3: "Căn hộ",
  4: "Biệt thự",
  5: "Khu nghỉ dưỡng",
};

const { Title, Paragraph } = Typography;

const HotelDetail = () => {
  const { id } = useParams();
  const [hotel, setHotel] = useState(null);
  const [loading, setLoading] = useState(false);
  const [previewVisible, setPreviewVisible] = useState(false);

  const fetchHotelDetail = async () => {
    try {
      setLoading(true);
      const response = await axios.get(
        `https://localhost:7242/api/hotels/${id}`
      );
      setHotel(response.data.metadata);
    } catch (error) {
      console.error("Error fetching hotel detail:", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchHotelDetail();
  }, [id]);

  if (loading || !hotel) return <Spin tip="Đang tải dữ liệu..." />;

  return (
    <div style={{ padding: "2rem" }}>
      {hotel.images && hotel.images.length > 0 && (
        <div style={{ marginBottom: "2rem" }}>
          <Row gutter={16}>
            <Col span={10}>
              <Image
                src={hotel.images[0]}
                width="80vh"
                height="50vh"
                style={{ objectFit: "cover", borderRadius: 8 }}
              />
            </Col>

            <Col span={14}>
              <Row gutter={[8, 8]}>
                {hotel.images.slice(1, 4).map((img, idx) => (
                  <Col span={8} key={idx}>
                    <Image
                      src={img}
                      width="100%"
                      height="100%"
                      style={{ objectFit: "cover", borderRadius: 8 }}
                    />
                  </Col>
                ))}
              </Row>

              <Row gutter={[8, 8]} style={{ marginTop: "8px" }}>
                {hotel.images.slice(4, 6).map((img, idx) => (
                  <Col span={8} key={idx}>
                    <Image
                      src={img}
                      width="100%"
                      height="100%"
                      style={{ objectFit: "cover", borderRadius: 8 }}
                    />
                  </Col>
                ))}

                {hotel.images.length > 6 && (
                  <Col span={8}>
                    <div
                      style={{
                        position: "relative",
                        width: "100%",
                        height: "100%",
                        overflow: "hidden",
                      }}
                    >
                      <Image
                        src={hotel.images[5]}
                        width="100%"
                        height="100%"
                        style={{
                          objectFit: "cover",
                          borderRadius: 8,
                          opacity: 0.6,
                        }}
                      />
                      <Button
                        type="primary"
                        style={{
                          position: "absolute",
                          bottom: 8,
                          left: "50%",
                          transform: "translateX(-50%)",
                          width: "90%",
                        }}
                        onClick={() => setPreviewVisible(true)}
                      >
                        Xem tất cả hình ảnh
                      </Button>
                    </div>
                  </Col>
                )}
              </Row>
            </Col>
          </Row>

          <Modal
            title="Tất cả hình ảnh"
            open={previewVisible}
            onCancel={() => setPreviewVisible(false)}
            footer={null}
            width="80%"
          >
            <Image.PreviewGroup>
              <Row gutter={[16, 16]}>
                {hotel.images.map((img, idx) => (
                  <Col span={6} key={idx}>
                    <Image src={img} width="100%" style={{ borderRadius: 8 }} />
                  </Col>
                ))}
              </Row>
            </Image.PreviewGroup>
          </Modal>
        </div>
      )}

      <div style={{ background: "red" }}>
        <Row gutter={16}>
          {/* Cột 1 */}
          <Col span={8}>
            <Title level={3}>{hotel.name}</Title>
            <div>Loại hình: {accommodationTypeMapByIndex[hotel.type]}</div>
          </Col>

          {/* Cột 2 */}
          <Col span={8}>
            <div style={{ marginBottom: 16 }}>Cột 2 - Hàng 1</div>
            <div>Cột 2 - Hàng 2</div>
          </Col>

          {/* Cột 3 */}
          <Col span={8}>
            <div style={{ marginBottom: 16 }}>Cột 3 - Hàng 1</div>
            <div>Cột 3 - Hàng 2</div>
          </Col>
        </Row>
      </div>
      {/* 
      <Title level={2}>{hotel.name}</Title>
      <Paragraph>{hotel.description}</Paragraph>
      <Descriptions bordered column={1}>
        <Descriptions.Item label="Địa chỉ">
          {hotel.address}, {hotel.city}, {hotel.country}
        </Descriptions.Item>
        <Descriptions.Item label="Số sao">{hotel.star}</Descriptions.Item>
        <Descriptions.Item label="Tiện ích">
          {hotel.amenities?.join(", ")}
        </Descriptions.Item>
      </Descriptions> */}
    </div>
  );
};

export default HotelDetail;

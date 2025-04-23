import React from "react";
import { Image, Row, Col, Button, Modal } from "antd";

const HotelImages = ({ hotel, previewVisible, setPreviewVisible }) => {
  return (
    <>
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
                        color="default"
                        style={{
                          position: "absolute",
                          bottom: 8,
                          left: "50%",
                          transform: "translateX(-50%)",
                          width: "90%",
                          border: "none",
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
            title={
              <span style={{ fontSize: 24, fontWeight: 600 }}>
                Tất cả hình ảnh
              </span>
            }
            open={previewVisible}
            onCancel={() => setPreviewVisible(false)}
            footer={null}
            width="80%"
            style={{ top: 0, padding: 0 }}
            bodyStyle={{
              maxHeight: "calc(100vh - 250px)",
              overflowY: "auto",
              padding: 24,
            }}
            centered
          >
            <Image.PreviewGroup>
              <Row gutter={[16, 16]}>
                {hotel.images.map((img, idx) => (
                  <Col span={6} key={idx}>
                    <Image
                      src={img}
                      width="100%"
                      style={{ borderRadius: 8 }}
                      preview={true}
                    />
                  </Col>
                ))}
              </Row>
            </Image.PreviewGroup>
          </Modal>
        </div>
      )}
    </>
  );
};

export default HotelImages;

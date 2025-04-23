import React, { useState } from "react";
import { Card, Typography, Button, Modal } from "antd";
import { geekblue } from "@ant-design/colors";

const { Paragraph } = Typography;

const Description = ({ description }) => {
  const [isModalVisible, setIsModalVisible] = useState(false);

  return (
    <>
      <Card style={{ marginTop: "1rem" }}>
        <Paragraph
          ellipsis={{
            rows: 2,
            expandable: false,
          }}
          style={{ marginBottom: 8, fontSize: 18, fontWeight: 400 }}
        >
          {description}
        </Paragraph>

        <Button
          type="text"
          style={{
            fontSize: 18,
            padding: 0,
            textDecoration: "none",
            backgroundColor: "transparent",
            color: geekblue[6],
            fontWeight: 500,
          }}
          onClick={() => setIsModalVisible(true)}
        >
          Xem thêm &gt;
        </Button>
      </Card>

      <Modal
        title={
          <span style={{ fontSize: 24, fontWeight: 600 }}>
            Giới thiệu Gold Plaza Hotel Da Nang
          </span>
        }
        open={isModalVisible}
        onCancel={() => setIsModalVisible(false)}
        footer={null}
        centered
        width={800}
      >
        <Paragraph style={{ fontSize: 16, lineHeight: "28px" }}>
          {description}
        </Paragraph>
      </Modal>
    </>
  );
};

export default Description;

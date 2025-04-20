import { Layout, Row, Col } from "antd";
import CustomHeader from "../components/header.jsx";
import RoomCard from "../components/RoomCard";

const { Header, Content } = Layout;

const rooms = [
  {
    id: 1,
    title: "Standard Twin Room Private Shared Bathroom",
    description:
      "Diam phasellus vestibulum lorem sed risus ultricies tristique.",
    image:
      "https://pix8.agoda.net/hotelImages/38358514/0/a0536d9e6ca23ec600851ccdca57a567.jpg?ce=0&s=1024x",
    pricePerNight: "$29",
    pricePerWeek: "$100",
    amenities: ["2 Sleeps", "1 bunk bed"],
  },
  {
    id: 2,
    title: "Standard 6 Bed Female Dorm Shared Bathroom",
    description:
      "Diam phasellus vestibulum lorem sed risus ultricies tristique.",
    image:
      "https://pix8.agoda.net/hotelImages/38358514/0/a0536d9e6ca23ec600851ccdca57a567.jpg?ce=0&s=1024x",
    pricePerNight: "$19",
    pricePerWeek: "$80",
    amenities: ["2 Sleeps", "1 bunk bed"],
  },
  {
    id: 3,
    title: "Standard 6 Bed Female Dorm Shared Bathroom",
    description:
      "Diam phasellus vestibulum lorem sed risus ultricies tristique.",
    image:
      "https://pix8.agoda.net/hotelImages/38358514/0/a0536d9e6ca23ec600851ccdca57a567.jpg?ce=0&s=1024x",
    pricePerNight: "$19",
    pricePerWeek: "$80",
    amenities: ["2 Sleeps", "1 bunk bed"],
  },
  {
    id: 4,
    title: "Standard 6 Bed Female Dorm Shared Bathroom",
    description:
      "Diam phasellus vestibulum lorem sed risus ultricies tristique.",
    image:
      "https://pix8.agoda.net/hotelImages/38358514/0/a0536d9e6ca23ec600851ccdca57a567.jpg?ce=0&s=1024x",
    pricePerNight: "$19",
    pricePerWeek: "$80",
    amenities: ["2 Sleeps", "1 bunk bed"],
  },
  // add more rooms...
];

const Dashboard = () => {
  return (
    <Layout>
      <Header style={{ background: "white", height: "10vh" }}>
        <CustomHeader />
      </Header>
      <Content style={{ padding: "2rem" }}>
        <Row gutter={[16, 16]}>
          {rooms.map((room) => (
            <Col span={24} key={room.id}>
              <RoomCard room={room} />
            </Col>
          ))}
        </Row>
      </Content>
    </Layout>
  );
};

export default Dashboard;

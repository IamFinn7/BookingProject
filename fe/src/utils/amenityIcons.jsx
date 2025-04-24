import WifiIcon from "@mui/icons-material/Wifi";
import AcUnitIcon from "@mui/icons-material/AcUnit";
import RestaurantIcon from "@mui/icons-material/Restaurant";
import ElevatorIcon from "@mui/icons-material/Elevator";
import LocalBarIcon from "@mui/icons-material/LocalBar";
import LocalParkingIcon from "@mui/icons-material/LocalParking";
import PoolIcon from "@mui/icons-material/Pool";
import FitnessCenterIcon from "@mui/icons-material/FitnessCenter";
import SpaIcon from "@mui/icons-material/Spa";
import TvIcon from "@mui/icons-material/Tv";
import FreeBreakfastIcon from "@mui/icons-material/FreeBreakfast";
import LocalLaundryServiceIcon from "@mui/icons-material/LocalLaundryService";
import SmokeFreeIcon from "@mui/icons-material/SmokeFree";
import MeetingRoomIcon from "@mui/icons-material/MeetingRoom";
import ShowerIcon from "@mui/icons-material/Shower";
import LiquorIcon from "@mui/icons-material/Liquor";
import HelpOutlineIcon from "@mui/icons-material/HelpOutline";

const amenityIconMap = {
  WiFi: <WifiIcon />,
  Internet: <WifiIcon />,
  "Máy lạnh": <AcUnitIcon />,
  "Điều hòa": <AcUnitIcon />,
  "Air Conditioning": <AcUnitIcon />,
  "Nhà hàng": <RestaurantIcon />,
  Restaurant: <RestaurantIcon />,
  "Thang máy": <ElevatorIcon />,
  Elevator: <ElevatorIcon />,
  "Quầy bar": <LocalBarIcon />,
  Bar: <LocalBarIcon />,
  "Chỗ đậu xe": <LocalParkingIcon />,
  "Bãi đậu xe": <LocalParkingIcon />,
  Parking: <LocalParkingIcon />,
  "Hồ bơi": <PoolIcon />,
  "Swimming Pool": <PoolIcon />,
  "Phòng gym": <FitnessCenterIcon />,
  Gym: <FitnessCenterIcon />,
  "Fitness center": <FitnessCenterIcon />,
  Spa: <SpaIcon />,
  "Truyền hình cáp": <TvIcon />,
  TV: <TvIcon />,
  "Bữa sáng miễn phí": <FreeBreakfastIcon />,
  "Free breakfast": <FreeBreakfastIcon />,
  "Dịch vụ giặt ủi": <LocalLaundryServiceIcon />,
  "Laundry service": <LocalLaundryServiceIcon />,
  "Không hút thuốc": <SmokeFreeIcon />,
  "Non-smoking": <SmokeFreeIcon />,
  "Phòng họp": <MeetingRoomIcon />,
  "Meeting room": <MeetingRoomIcon />,

  Minibar: <LiquorIcon />,
  "Quầy đồ uống": <LiquorIcon />,
  "Tủ lạnh mini": <LiquorIcon />,

  Shower: <ShowerIcon />,
  "Vòi sen": <ShowerIcon />,
  "Phòng tắm vòi sen": <ShowerIcon />,
};

export const getAmenityIcon = (amenityName) =>
  amenityIconMap[amenityName.trim()] || <HelpOutlineIcon />;

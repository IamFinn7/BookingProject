import WifiIcon from "@mui/icons-material/Wifi";
import AcUnitIcon from "@mui/icons-material/AcUnit";
import RestaurantIcon from "@mui/icons-material/Restaurant";
import ElevatorIcon from "@mui/icons-material/Elevator";
import LocalBarIcon from "@mui/icons-material/LocalBar";
import HelpOutlineIcon from "@mui/icons-material/HelpOutline";

const amenityIconMap = {
  "WiFi": <WifiIcon />,
  "Máy lạnh": <AcUnitIcon />,
  "Nhà hàng": <RestaurantIcon />,
  "Thang máy": <ElevatorIcon />,
  "Quầy bar": <LocalBarIcon />,
};

export const getAmenityIcon = (amenityName) =>
  amenityIconMap[amenityName] || <HelpOutlineIcon />;

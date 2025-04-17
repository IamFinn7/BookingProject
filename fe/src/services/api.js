import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7242/api",
});

// // ✅ Gửi token trong mỗi request
// api.interceptors.request.use((config) => {
//   const token = localStorage.getItem("token");
//   if (token) {
//     config.headers.Authorization = `Bearer ${token}`;
//   }
//   return config;
// });

api.interceptors.request.use;
(function (response) {
  return response.data ? response.data : { statusCode: response.status };
}),
  function (error) {
    let res = {};
    if (error.response) {
      res.data = error.response.data;
      res.status = error.response.status;
      res.headers = error.response.headers;
    } else if (error.request) {
      console.log(error.request);
    } else {
      console.log("Error", error.message);
    }
    return res;
  };

export default api;

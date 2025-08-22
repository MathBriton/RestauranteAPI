import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5000/api", // ajuste conforme porta da sua API .NET
});

export default api;

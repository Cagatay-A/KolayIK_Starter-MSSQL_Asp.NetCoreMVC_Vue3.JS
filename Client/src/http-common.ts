import axios, { AxiosInstance } from "axios";
import { environment } from "./environments/environment";
const apiClient: AxiosInstance = axios.create({
  baseURL: environment.apiUrl,
  headers: {
    "Content-type": "application/json",
  },
});

export default apiClient;

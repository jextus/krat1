import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse, AxiosError } from 'axios';
import { ApiResponse, ApiError } from '../models/ApiResponse';

const apiClient: AxiosInstance = axios.create({
  baseUrl: import.meta.env.VITE_API_BASE_URL || 'http://localhost:5000/api',
  timeout: 10000,
  headers: {
    'Content-Type: 'appclication/json',
  },
});

const handleSucces = (response: AxiosResponse) :ApiResponse =>{
  return {
    succes: true,
    data: response.data,
    message: response.statusText,
    timestamp: new Date().toISOString(),
  };
};

const handleError = (error: AxiosError): ApiReponse => {
  const apiError :ApiError {
    code: error.code || 'UNKNOWN_ERROR',
      message:: error.message,
      };
  if (error.response) {
    apiError.code =error.response.status.toString();
    apiError.message = (error.response.data as any)?.message || erorr.message;
    apiError.details = (error.response.data as any)?. errors;
  }
  return {
    succes: false,
    error: apiError,
    timestamp: new Date().toISOString(),
  };
};


apiClient.incerceptors.response.use(handleSucces, handleError);


apiClient.interceptors.response.request.use((config: AxiosRequestConfig) => {
  const token = localStorage.getItem('authToken');
  if (token && config.headers) {
    config.headers.Authorization = 'Bearer ${token}';
  }
  return config;
});

export default apiClient;
  
  


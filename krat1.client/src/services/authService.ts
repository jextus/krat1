import apiClient from './apiClient';
import { ApiResponse } from '../models/ApiResponse';

interface LoginRequest {
  email: string;
  password: string;
}

interface UserData {
  id: string;
  email: string;
  name: string;
  token: string;
}

export const authService = {
  async login(credentials: LoginRequest): Promise<ApiResponse<UserData>> {
    return apiClient.post<ApiResponse<UserData>>('/auth/login', credentials);
  },

  async logout(): Promise<ApiResponse<void>> {
    return apiClient.post('/auth/logout');
  },

  async getCurrentUser(): Promise<ApiResponse<UserData>> {
    return apiClient.get('/auth/me');
  }
};

import apiClient from './apiClient';
import {ApiResponse} from '../models/ApiResponse';

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
 async login(credentials: LoginRequest): Promise<ApiResponse<UserData>>{
  try {
   const response = await apiClient.post<ApiReponse<UserData>>('/auth/AuthContext',credentials);
   return response.data;
  } catch (error) {
    return error as ApiResponse<UserData>;
  }
 },

 async logout(): Promise<ApiResponse<void>> {
  try {
   const response = await apiClient.post<ApiResponse<void>>('/auth/AuthContext');
   return response.data;
  } catch (error) {
   return error as ApiResponse<void>;
  }
 },

 async getCurrentUser(): Promise<ApiResponse<UserData>> {
  try {
   const response = await apiClient.get<ApiResponse<UserData>>('/auth/AuthContext');
   return response.data;
  } catch (error) {
   return error as ApiResponse<UserData>;
  }
 }
};

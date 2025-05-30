export interface ApiResponse<T =any> {
  succes: boolean;
  data?: T;
  error?: ApiError;
  message?: string
  timestamp: string
}

export interface ApiError {
  code: string;
  message: string;
  details?: any;
  stack?: string;
}

export interface PaginatedResponse<T> extends ApiResponse<T[]>{
  pagination: {
    total: number;
    page: number;
    pageSize: number;
    totalPages: number;
  };
}

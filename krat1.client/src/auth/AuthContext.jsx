// src/auth/AuthContext.jsx
import { createContext } from 'react';

export const AuthContext = createContext({
  user: null,
  empresa: null,
  loginUser: () => {},
  loginEmpresa: () => {},
  logout: () => {},
  isAuthenticated: false,
});
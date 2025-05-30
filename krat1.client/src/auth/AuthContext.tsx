
import React, { useState } from 'react';
import { AuthContext } from './AuthContext';
import axios from 'axios';

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [empresa, setEmpresa] = useState(null);

  const loginUser = async (credentials) => {
    try {
      const response = await axios.post('/api/Usuario/LoginUsuario', credentials);
      setUser(response.data.user);
      localStorage.setItem('user', JSON.stringify(response.data.user));
      localStorage.setItem('token', response.data.token);
      return { success: true };
    } catch (error) {
      return { success: false, message: error.response?.data?.message || 'Error al iniciar sesión' };
    }
  };

  const loginEmpresa = async (credentials) => {
    try {
      const response = await axios.post('/api/Empresa/LoginEmpresa', credentials);
      setEmpresa(response.data.empresa);
      localStorage.setItem('empresa', JSON.stringify(response.data.empresa));
      localStorage.setItem('token', response.data.token);
      return { success: true };
    } catch (error) {
      return { success: false, message: error.response?.data?.message || 'Error al iniciar sesión' };
    }
  };

  const logout = () => {
    setUser(null);
    setEmpresa(null);
    localStorage.removeItem('user');
    localStorage.removeItem('empresa');
    localStorage.removeItem('token');
  };

  const isAuthenticated = !!user || !!empresa;

  return (
    <AuthContext.Provider value={{ user, empresa, loginUser, loginEmpresa, logout, isAuthenticated }}>
      {children}
    </AuthContext.Provider>
  );
};

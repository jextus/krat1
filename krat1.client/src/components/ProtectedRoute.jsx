// src/components/ProtectedRoute.jsx
import React from 'react';
import { Navigate } from 'react-router-dom';
import { useAuth } from '../auth/AuthContext';

const ProtectedRoute = ({ children, role }) => {
  const { isAuthenticated, user, empresa } = useAuth();

  if (!isAuthenticated) {
    return <Navigate to="/login" replace />;
  }

  if (role === 'empresa' && !empresa) {
    return <Navigate to="/login" replace />;
  }

  if (role === 'usuario' && !user) {
    return <Navigate to="/login" replace />;
  }

  return children;
};

export default ProtectedRoute;
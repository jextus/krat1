// src/pages/HomePage.jsx
import React from 'react';
import { Link } from 'react-router-dom';
import { useAuth } from '../auth/AuthContext';

const HomePage = () => {
  const { isAuthenticated } = useAuth();

  return (
    <div className="home-page">
      <h1>Bienvenido a nuestra aplicación</h1>
      {!isAuthenticated && (
        <div className="auth-options">
          <Link to="/login" className="auth-button">
            Iniciar sesión
          </Link>
        </div>
      )}
    </div>
  );
};

export default HomePage;
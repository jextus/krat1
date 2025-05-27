// src/pages/HomePage.jsx
import React from 'react';
import { Link } from 'react-router-dom';
import { useAuth } from '../auth/AuthContext';

const HomePage = () => {
  const { isAuthenticated } = useAuth();

  return (
    <div className="home-page">
      <h1>Bienvenido a nuestra aplicaci�n</h1>
      {!isAuthenticated && (
        <div className="auth-options">
          <Link to="/login" className="auth-button">
            Iniciar sesi�n
          </Link>
        </div>
      )}
    </div>
  );
};

export default HomePage;
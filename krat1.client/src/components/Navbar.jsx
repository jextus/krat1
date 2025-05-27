// src/components/Navbar.jsx
import React from 'react';
import { Link } from 'react-router-dom';
import { useAuth } from '../auth/AuthContext';

const Navbar = () => {
  const { user, empresa, isAuthenticated, logout } = useAuth();

  return (
    <nav className="navbar">
      <div className="navbar-brand">
        <Link to="/">Mi Aplicación</Link>
      </div>
      
      <div className="navbar-links">
        {isAuthenticated ? (
          <>
            {empresa && (
              <Link to="/empresa/dashboard">Dashboard Empresa</Link>
            )}
            {user && (
              <Link to="/usuario/dashboard">Dashboard Usuario</Link>
            )}
            <button onClick={logout} className="logout-button">
              Cerrar sesión
            </button>
          </>
        ) : (
          <Link to="/login">Iniciar sesión</Link>
        )}
      </div>
    </nav>
  );
};

export default Navbar;
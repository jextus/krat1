// src/pages/UsuarioDashboard.jsx
import React from 'react';
import { useAuth } from '../auth/AuthContext';

const UsuarioDashboard = () => {
  const { user, logout } = useAuth();

  return (
    <div className="dashboard">
      <h1>Panel de Usuario</h1>
      <div className="user-info">
        <h2>Bienvenido, {user?.nombre}</h2>
        <p>Email: {user?.email}</p>
      </div>
      <button onClick={logout}>Cerrar sesión</button>
      {/* Aquí puedes agregar más componentes específicos para usuarios */}
    </div>
  );
};

export default UsuarioDashboard;
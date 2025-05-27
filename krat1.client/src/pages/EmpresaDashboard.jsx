// src/pages/EmpresaDashboard.jsx
import React from 'react';
import { useAuth } from '../auth/AuthContext';

const EmpresaDashboard = () => {
  const { empresa, logout } = useAuth();

  return (
    <div className="dashboard">
      <h1>Panel de Empresa</h1>
      <div className="user-info">
        <h2>Bienvenido, {empresa?.nit}</h2>
        <p>Razón social: {empresa?.razonSocial}</p>
      </div>
      <button onClick={logout}>Cerrar sesión</button>
     
    </div>
  );
};

export default EmpresaDashboard;
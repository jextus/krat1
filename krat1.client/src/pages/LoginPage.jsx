
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../auth/AuthContext';
import EmpresaLogin from '../components/Login/EmpresaLogin';
import UsuarioLogin from '../components/Login/UsuarioLogin';

const LoginPage = () => {
  const [activeTab, setActiveTab] = useState('usuario');
  const navigate = useNavigate();
  const { isAuthenticated } = useAuth();

  if (isAuthenticated) {
    navigate('/dashboard');
    return null;
  }

  return (
    <div className="login-container">
      <div className="tabs">
        <button 
          className={activeTab === 'usuario' ? 'active' : ''}
          onClick={() => setActiveTab('usuario')}
        >
          Usuario
        </button>
        <button 
          className={activeTab === 'empresa' ? 'active' : ''}
          onClick={() => setActiveTab('empresa')}
        >
          Empresa
        </button>
      </div>

      {activeTab === 'usuario' ? <UsuarioLogin /> : <EmpresaLogin />}
    </div>
  );
};

export default LoginPage;
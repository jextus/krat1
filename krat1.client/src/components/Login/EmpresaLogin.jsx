// src/components/Login/EmpresaLogin.jsx
import React, { useState } from 'react';
import { useAuth } from '../../auth/AuthContext.jsx';
import { useNavigate } from 'react-router-dom';

const EmpresaLogin = () => {
  const [loginData, setLoginData] = useState({
    nit: '',
    contrasena: ''
  });
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);
  const { loginEmpresa } = useAuth();
  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setLoginData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError('');

    const result = await loginEmpresa(loginData);
    
    if (result.success) {
      navigate('/empresa/dashboard');
    } else {
      setError(result.message);
    }
    
    setLoading(false);
  };

  return (
    <form onSubmit={handleSubmit}>
      <div className="form-group">
        <label>NIT:</label>
        <input
          type="text"
          name="nit"
          value={loginData.nit}
          onChange={handleChange}
          required
        />
      </div>
      <div className="form-group">
        <label>Contraseña:</label>
        <input
          type="password"
          name="contrasena"
          value={loginData.contrasena}
          onChange={handleChange}
          required
        />
      </div>
      {error && <div className="error-message">{error}</div>}
      <button type="submit" disabled={loading}>
        {loading ? 'Cargando...' : 'Iniciar Sesión como Empresa'}
      </button>
    </form>
  );
};

export default EmpresaLogin;
import { useState } from 'react';
import { authService } from '../services/authService';
import { ApiResponse } from '../models/ApiResponse';

const LoginPage = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [loading, setLoading] = useState(false);
  const [apiResponse, setApiResponse] = useState<ApiResponse | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setApiResponse(null);

    const response: ApiResponse = await authService.login({ email, password });
    setApiResponse(response);

    if (response.success) {
      // Guardar token y redirigir
      localStorage.setItem('authToken', response.data.token);
      window.location.href = '/dashboard';
    }

    setLoading(false);
  };

  return (
    <div className="login-container">
      <h2>Iniciar Sesión</h2>
      
      {apiResponse && !apiResponse.success && (
        <div className="alert alert-danger">
          Error: {apiResponse.error?.message}
          {apiResponse.error?.details && (
            <pre>{JSON.stringify(apiResponse.error.details, null, 2)}</pre>
          )}
        </div>
      )}

      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Email:</label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>

        <div className="form-group">
          <label>Contraseña:</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>

        <button type="submit" disabled={loading}>
          {loading ? 'Cargando...' : 'Iniciar Sesión'}
        </button>
      </form>
    </div>
  );
};

export default LoginPage;

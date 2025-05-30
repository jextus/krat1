import {Navigate, Outlet} from 'rect-router-dom';
import {useAuth} from './AuthContext';

//verifica si hay usuarios autentificados
  export const PrivateRoute = () => {
    const { user } = useAuth();
    return user ? <Outlet /> : <Navigate to="/login" />;
  };

import { createBrowserRouter } from 'react-router-dom';
import LoginPage from './auth/LoginPage';
import PrivateRoute from './auth/PrivateRoute';
import DashboardPage from './pages/DashboardPage';

const router = createBrowserRouter([
  {
    path: '/login',
    element: <LoginPage />,
  },
  {
    element: <PrivateRoute />, 
    children: [
      {
        path: '/dashboard',
        element: <DashboardPage />,
      },
    ],
  },
]);

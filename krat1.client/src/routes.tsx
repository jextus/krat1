import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import HomePage from './pages/HomePage';

// Importa otras páginas...

const router = createBrowserRouter([
  {
    path: "/",
    element: <HomePage />,
  },

]);

function AppRoutes() {
  return <RouterProvider router={router} />;
}

export default AppRoutes;

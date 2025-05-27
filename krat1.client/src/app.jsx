    // src/App.jsx
    import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
    import { AuthProvider } from "./auth/AuthProvider";
    import Navbar from "./components/Navbar";
    import HomePage from "./pages/HomePage";
    import LoginPage from "./pages/LoginPage";
    import EmpresaDashboard from "./pages/EmpresaDashboard";
    import UsuarioDashboard from "./pages/UsuarioDashboard";
    import ProtectedRoute from "./components/ProtectedRoute";

    function App() {
      return (
        <Router>
          <AuthProvider>
            <Navbar />
            <main className="main-content">
              <Routes>
                {/* Ruta raíz que muestra el HomePage */}
                <Route path="/" element={<HomePage />} />
                <Route path="/login" element={<LoginPage />} />
                <Route 
                  path="/empresa/dashboard" 
                  element={
                    <ProtectedRoute role="empresa">
                      <EmpresaDashboard />
                    </ProtectedRoute>
                  } 
                />
                <Route 
                  path="/usuario/dashboard" 
                  element={
                    <ProtectedRoute role="usuario">
                      <UsuarioDashboard />
                    </ProtectedRoute>
                  } 
                />
                {/* Redirección para rutas no encontradas */}
                <Route path="*" element={<Navigate to="/" />} />
              </Routes>
            </main>
          </AuthProvider>
        </Router>
      );
    }

    export default App;

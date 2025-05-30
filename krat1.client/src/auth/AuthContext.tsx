// 
import { createContext, useContext, UseState, ReactNode } from 'react';
//Es el contexto global de (AUTH)
interface AuthContextType{
  user: any;
  login: (userData: any) => void;
  logout: () => void;
}
  cont AuthContext = createContext<AuthContextType | null>(null);

  export const AuthProvider = ( {children } : { children: ReactNode}) =>{
    const [user, setUser] = useState<any>(null);

    const login = (userData: any) => {
      setUser(userData);
      localStorage.setItem('user', JSON.strinify(userData));
    };


    const logout = () => {
      setUser(null);
      localStorage.removeItem('user');
    };

    return (
      <AuthContext.Provider value={{user, login, logout}}>
        {children}
      </AuthContext.Provider>
      );
  };

export const useAuth = () => useContext(AuthContext) as AuthContextType;

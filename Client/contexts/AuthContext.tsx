import React, { createContext, useContext, useState } from "react";
import { post } from "../ajax";

interface AuthContextProps {
  userId?: string;
  token?: string;
  signIn: (username: string, password: string) => Promise<void>;
}

const AuthContext = createContext<AuthContextProps>({} as AuthContextProps);

export const useAuth = () => {
  return useContext(AuthContext);
};

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [token, setToken] = useState<string>();
  const [id, setId] = useState<string>();

  const signIn = (email: string, password: string) => {
    return new Promise<void>((resolve, reject) => {
      post("/User/Login", { email: email, password: password }).then(
        (response) => {
          if (response.status == 200) {
            setId(response.data);
            resolve();
          }
          reject();
        }
      );
    });
  };

  return (
    <AuthContext.Provider value={{ userId: id, token: token, signIn: signIn }}>
      {children}
    </AuthContext.Provider>
  );
}

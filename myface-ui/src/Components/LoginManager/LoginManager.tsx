import React, {createContext, ReactNode, useState} from "react";
/*import {authHeader} from "../../Api/authHeader";*/

export const LoginContext = createContext({
    isLoggedIn: false,
    isAdmin: false,
    username: "",
    password: "",
    logIn: (username: string, password: string) => {},
    logOut: () => {},
});

interface LoginManagerProps {
    children: ReactNode
}

export function LoginManager(props: LoginManagerProps): JSX.Element {
    const [loggedIn, setLoggedIn] = useState(true);
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    
    function logIn(username: string, password: string) {
        setLoggedIn(true);
        setUsername(username);
        setPassword(password);
    }
    
    function logOut() {
        setLoggedIn(false);
        setUsername("");
        setPassword("");
    }
    
/*    function getAll():JSX.Element {
        const request = {
            method: 'GET',
            headers: authHeader()
        };
        return fetch(`${config.apiUrl}/users`, request).then(handleResponse);
    }
    
    function handleResponse(response){
        response.text().then(text => {
            const data = text && JSON.parse(text);
            if(!response.ok){
               if(response.status === 401){
                   logOut();
                   location.reload(true); 
               }
                const error = (data && data.message)|| response.statusText;
                return Promise.reject(error);
            }
            return data;
        });
    }*/
    
    
    const context = {
        isLoggedIn: loggedIn,
        isAdmin: loggedIn,
        username: username,
        password: password,
        logIn: logIn,
        logOut: logOut,
    };
    
    return (
        <LoginContext.Provider value={context}>
            {props.children}
        </LoginContext.Provider>
    );
}
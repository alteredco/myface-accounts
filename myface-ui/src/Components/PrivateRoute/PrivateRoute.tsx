import React from "react";
import {RouteComponentProps, Route, Redirect} from "react-router-dom";

interface Props {
    Component: React.FC<RouteComponentProps>
    path: string;
    exact?: boolean;
}

/*
export function PrivateRoute({Component, path, exact = false }:Props):JSX.Element{
    const isAuth = !!localStorage.getItem(ACCESS_TOKEN);
    const message = 'Please login to view this page';
    return (
        <Route 
            exact = {exact}
            path = {path}
            render = {(props: RouteComponentProps) => 
                isAuth ? (
                    <Component {...props} />
                ) : (
                    <Redirect 
                        to={{
                            pathname: NonAuthRoutes.login,
                            state: {
                                message,
                                requestedPath: path
                            }
                    }}
                    />
                )
                
            }
        />
        )
    
}
*/


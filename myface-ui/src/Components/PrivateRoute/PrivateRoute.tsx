import React from "react";
import {Route, Redirect} from "react-router-dom";
import {Profile} from "../../Pages/Profile/Profile";

/*
export function PrivateRoute({component: Profile}) {
    <Route render={props => (
       localStorage.getItem('user')
        ? <Profile {props.id} />
        :<Redirect to={{ pathname: '/login', state: {from: props.location} }} />
    )}/>
}*/

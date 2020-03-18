export function authHeader(): String|null {
    let user:string = JSON.parse(localStorage.getItem('user'));
    
    if(user && user.authdata){
        return{ 'Authorization': 'Basic '+ user.authdata };
    } else {
        return {};
    }
}
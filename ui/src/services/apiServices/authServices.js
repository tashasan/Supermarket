import { postRequest } from "../axiosRequest";
import endPoint from "./endPointAdressess";

export const login = async (username,password) => {
    return await postRequest(`${endPoint.auth.LOGIN_URL}/${username}/${password}`)
};

export const logout = async () => {
    const d = new Date();
    d.setTime(d.getTime() + (1 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = "token" + "=;" + expires;
};
export function setCookie(cname, cvalue, exmins) {
    // const d = new Date();
    // d.setTime(d.getTime() + (exmins * 60 * 1000));
    // let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";secure;SameSite=Lax";
};
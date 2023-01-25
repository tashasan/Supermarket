import ActionTypes from "./actionTypes"
import {
    login,
    logout,
    setCookie
} from "../../../services/apiServices/authServices";

const loginAction = (username, password) => {
    return async (dispatch) => {
        await login(username, password)
            .then(async (response) => {
                console.log(response)
                const result = response.data
                const keys = ["password", "createdAt", "updatedAt", "deletedAt", "baskets"];
                keys.map((e) => delete result[e]);
                const data = {};
                Object.keys(result).forEach(e => {
                    data[e] = result[e];
                });
                setCookie("token", result.id, 90)
                return await dispatch(loginMessage(data));
            })
    };
};
const loginMessage = (data) => {
    return { type: ActionTypes.auth.LOGIN_ACTION, payload: { data } };
};
const logoutAction = () => {
    return (dispatch) => {
        logout().then(() => {
            dispatch({ type: ActionTypes.auth.LOGOUT_ACTION });
        });
    };
};
const authActions = {
    loginAction,
    logoutAction
};

export default authActions;

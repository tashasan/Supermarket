import ActionTypes from "../actions/actionTypes";
import { initialState } from "./initialState";

const authReducer = (state = initialState.auth, action) => {
	switch (action.type) {
		case ActionTypes.auth.LOGIN_ACTION:
			return {
				...state,
				auth: action.payload.token,
				currentUser: action.payload.data,
			};
		case ActionTypes.auth.LOGOUT_ACTION:
			return {
				...state,
				auth: "",
				currentUser: ""
			};
		default:
			return state;
	};
};

export default authReducer;

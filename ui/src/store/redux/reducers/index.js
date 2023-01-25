import { combineReducers } from "redux";
import authReducer from "./authReducer";
import basketReducer from "./basketReducer";
import productReducer from "./productReducer";
const reducers = combineReducers({
    auth: authReducer,
    basket: basketReducer,
    product: productReducer
});

export default reducers;

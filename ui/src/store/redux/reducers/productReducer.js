import ActionTypes from "../actions/actionTypes";
import { initialState } from "./initialState";

const productReducer = (state = initialState.product, action) => {

    switch (action.type) {
        case ActionTypes.product.CREATE_ACTION_PRODUCT:
            return {
                ...state,
                product: initialState.product.product
            };
        case ActionTypes.product.UPDATE_ACTION_PRODUCT:
            return {
                ...state,
                product: {},
                getById: {}
            };
        case ActionTypes.product.GETBYID_ACTION_PRODUCT:
            return {
                ...state,
                getById: action.payload.data,
            };
        case ActionTypes.product.GETALL_ACTION_PRODUCT:
            return {
                ...state,
                getAll: action.payload.data
            };
        default:
            return state;
    };
};

export default productReducer;
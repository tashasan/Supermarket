import ActionTypes from "../actions/actionTypes";
import { initialState } from "./initialState";

const basketReducer = (state = initialState.basket, action) => {

    switch (action.type) {
        case ActionTypes.basket.CREATE_ACTION_BASKET:
            return {
                ...state,
                basket: initialState.basket.basket
            };
        case ActionTypes.basket.UPDATE_ACTION_BASKET:
            return {
                ...state,
                basket: {},
                getById: {}
            };
        case ActionTypes.basket.GETBYID_ACTION_BASKET:
            return {
                ...state,
                getById: action.payload.data,
            };
        case ActionTypes.basket.PURCHASE_ACTION_BASKET:
            return {
                ...state,
                getById: {}
            };
        case ActionTypes.basket.GETBASKETITEMS_ACTION:
            return {
                ...state,
                basketItems: action.payload.data
            };
        default:
            return state;
    };
};

export default basketReducer;
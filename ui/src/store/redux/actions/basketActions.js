import { create, update, remove, getById, purchase, getBasketItems } from "../../../services/apiServices/basketServices";
import ActionTypes from "./actionTypes";

const createAction = (id, createData) => {
    return async (dispatch) => {
        await create(id, createData)
            .then(async (res) => {
                console.log(res)
                await dispatch(createReducer(res.data.id))
            })
    };
};
const createReducer = () => {
    return { type: ActionTypes.basket.CREATE_ACTION_BASKET };
};
const updateAction = (quantity, id) => {
    return async (dispatch) => {
        await update(quantity, id)
            .then(async (res) => {
                console.log(res)
                await dispatch(updateReducer());
            })
    };
};
const updateReducer = () => {
    return { type: ActionTypes.basket.UPDATE_ACTION_BASKET };
};
const removeAction = (id) => {
    return async () => {
        await remove(id)
    };
};
const getByIdAction = (id) => {
    return async (dispatch) => {
        await getById(id)
            .then(async (res) => {
                let response = res.data;
                dispatch(getBasketItemsAction(response.id))
                const keys = ["createdAt", "updatedAt", "deletedAt"];
                keys.map((e) => delete response[e]);
                await dispatch(getByIdReducer(response));
            })
    };
};
const getByIdReducer = (data) => {
    return { type: ActionTypes.basket.GETBYID_ACTION_BASKET, payload: { data } };
};
const purchaseAction = (id, data) => {
    return async (dispatch) => {
        await purchase(id, data)
            .then(async (res) => {
                let response = res.data;
                await dispatch(purchaseReducer(response));
            })
    };
};
const purchaseReducer = (data) => {
    return { type: ActionTypes.basket.PURCHASE_ACTION_BASKET, payload: { data } };
};
const getBasketItemsAction = (id) => {
    return async (dispatch) => {
        await getBasketItems(id)
            .then(async (res) => {
                console.log(res)
                let response = res.data;
                const keys = ["basket", "product", "createdAt", "updatedAt", "deletedAt"];
                Object.keys(response).forEach(i => {
                    keys.map((e) => delete response[i][e]);
                });
                await dispatch(getBasketItemsReducer(response));
            })
    };
};
const getBasketItemsReducer = (data) => {
    return { type: ActionTypes.basket.GETBASKETITEMS_ACTION, payload: { data } };
};

const basketActions = {
    createAction,
    updateAction,
    removeAction,
    getByIdAction,
    purchaseAction,
    getBasketItemsAction
};
export default basketActions;
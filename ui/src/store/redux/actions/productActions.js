import { create, update, remove, getById, getAll } from "../../../services/apiServices/productServices";
import ActionTypes from "./actionTypes";

const createAction = (createData) => {
    return async (dispatch) => {
        await create(createData)
            .then(async (res) => {
                if (res.data.code === 200) {
                    await dispatch(createReducer());
                }
            })
    };
};
const createReducer = () => {
    return { type: ActionTypes.product.CREATE_ACTION_PRODUCT };
};
const updateAction = (updateData, id) => {
    return async (dispatch) => {
        await update(updateData, id)
            .then(async (res) => {
                console.log(res)
                await dispatch(updateReducer());
            })
    };
};
const updateReducer = () => {
    return { type: ActionTypes.product.UPDATE_ACTION_PRODUCT };
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
                const keys = ["createdAt", "updatedAt", "deletedAt", "basketItems", "categories"];
                keys.map((e) => delete response[e]);
                await dispatch(getByIdReducer(response));
            })
    };
};
const getByIdReducer = (data) => {
    return { type: ActionTypes.product.GETBYID_ACTION_PRODUCT, payload: { data } };
};
const getAllAction = () => {
    return async (dispatch) => {
        await getAll()
            .then(async (res) => {
                let response = res.data;
                const keys = ["createdAt", "updatedAt", "deletedAt", "basketItems", "categories"];
                Object.keys(response).forEach(i => {
                    keys.map((e) => delete response[i][e]);
                });
                await dispatch(getAllReducer(response));
            })
    };
};
const getAllReducer = (data) => {
    return { type: ActionTypes.product.GETALL_ACTION_PRODUCT, payload: { data } };
};


const careerActions = {
    createAction,
    updateAction,
    removeAction,
    getAllAction,
    getByIdAction
};
export default careerActions;
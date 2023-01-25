import { removeRequest, getRequest, postRequest, putRequest } from "../axiosRequest";
import endPoint from "./endPointAdressess";

export const create = async (id, createData) => {
    return await postRequest(`${endPoint.basket.CREATE_BASKET}/${id}`, createData)
};
export const update = async (quantity, id) => {
    return await putRequest(`${endPoint.basket.UPDATE_BASKET}/${id}/${quantity}`);
};
export const remove = async (id) => {
    return await removeRequest(`${endPoint.basket.REMOVE_BASKET}/${id}`);
};
export const getBasketItems = async (id) => {
    return await getRequest(`${endPoint.basket.GETBASKETITEMS_BASKET}/${id}`);
};
export const purchase = async (id, data) => {
    return await postRequest(`${endPoint.basket.PURCHASE_BASKET}/${id}`, data);
};
export const getById = async (id) => {
    return await getRequest(`${endPoint.basket.GETBYID_BASKET}/${id}`);
};
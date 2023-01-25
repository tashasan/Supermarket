import { removeRequest, getRequest, postRequest, putRequest } from "../axiosRequest";
import endPoint from "./endPointAdressess";

export const create = async (createData) => {
    return await postRequest(endPoint.product.CREATE_PRODUCT, createData)
};
export const update = async (updateData, id) => {
    return await putRequest(`${endPoint.product.UPDATE_PRODUCT}/${id}`, updateData);
};
export const remove = async (id) => {
    return await removeRequest(`${endPoint.product.REMOVE_PRODUCT}/${id}`);
};
export const getById = async (id) => {
    return await getRequest(`${endPoint.product.GETBYID_PRODUCT}/${id}`);
};
export const getAll = async () => {
    return await getRequest(endPoint.product.GETALL_PRODUCT);
};
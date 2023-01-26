import axios from "./axios";
// Normally I do axios.interceptor controls here, handling global alert about response messages and adding bearer token if jwt expires.

export const postRequest = async (URL, Data) => {
    return await axios.post(URL, Data)
};
export const putRequest = async (URL, Data) => {
    return await axios.put(URL, Data);
};
export const removeRequest = async (URL, Data) => {
    return await axios.delete(URL, Data);
};
export const getRequest = async (URL) => {
    return await axios.get(URL);
};
export const getFiltredReqeust = async (URL, Data) => {
    return await axios.get(URL, Data);
};
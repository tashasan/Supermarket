import HandleAlert from "../hooks/useAlert";
import { AlertType } from "../utils/ComponentEnums";
import axios from "./axios";

const match = document.cookie.match(new RegExp('(^| )' + 'token' + '=([^;]+)'));
let token = match === null ? "" : match[2]
let axiosInterceptor = null;
let prevRequest = null;

function AxiosRequest() {
    axios.interceptors.request.use(
        (config) => {
            const token = document.cookie.match(new RegExp('(^| )' + 'token' + '=([^;]+)'));
            if (token) {
                config.headers.Authorization = `Bearer ${token.at(2)}`;
            }
            return config;
        },
        (error) => {
            return Promise.reject(error);
        }
    );
};
function AxiosResponse() {
    let message = ""
    axiosInterceptor = axios.interceptors.response.use(async function (response) {
        if (response?.data?.data?.token === undefined) {
            message = response?.data?.message
            HandleAlert(message, AlertType.Success)
        }
        return response
    }, async function (error) {
        message = error?.response?.data
        HandleAlert(message, AlertType.Error)
        return error
    })
};
export const postRequest = async (URL, Data) => {
    if (!!axiosInterceptor || axiosInterceptor === 0) {
        axios.interceptors.response.eject(axiosInterceptor);
    }
    AxiosResponse();
    AxiosRequest();
    return await axios.post(URL, Data)
};
export const putRequest = async (URL, Data) => {
    let message = ""
    if (!!axiosInterceptor || axiosInterceptor === 0) {
        axios.interceptors.response.eject(axiosInterceptor);
    }
    axiosInterceptor = axios.interceptors.response.use(function (response) {

        message = response?.data?.message
        HandleAlert(message, AlertType.Success)
        return response
    }, async function (error) {
        message = error?.response?.data
        HandleAlert(message, AlertType.Error)
        return error
    })
    return await axios.put(URL, Data);
};
export const removeRequest = async (URL, Data) => {
    let message = ""
    if (!!axiosInterceptor || axiosInterceptor === 0) {
        axios.interceptors.response.eject(axiosInterceptor);
    }
    axiosInterceptor = axios.interceptors.response.use(function (response) {
        message = response?.data?.message
        HandleAlert(message, AlertType.Success)
        return response
    }, async function (error) {
        message = error?.response?.data
        HandleAlert(message, AlertType.Error)
        return error
    })
    return await axios.delete(URL, Data);
};
export const getRequest = async (URL) => {
    return await axios.get(URL);
};
export const getFiltredReqeust = async (URL, Data) => {
    return await axios.get(URL, Data);
};
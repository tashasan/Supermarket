import axios from "axios";
const BASE_URL = "https://localhost:7009/api/";
export const getToken = () =>
	document.cookie.match(new RegExp('(^| )' + 'token' + '=([^;]+)'))
		? document.cookie.match(new RegExp('(^| )' + 'token' + '=([^;]+)')).at(2)
		: "";
export const getAuthorizationHeader = () => `Bearer ${getToken()}`;
const headers = {
	Accept: "application/json",
	"Content-Type": "application/json",
	"Access-Control-Allow-Origin": "*",
	"Authorization": `Bearer ${getAuthorizationHeader()}`
}

export default axios.create({
	baseURL: BASE_URL,
	headers: headers,
	withCredentials: true
})

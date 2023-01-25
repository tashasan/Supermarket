const auth = {
    LOGIN_URL: "Auth/Login"
};
const product = {
    CREATE_PRODUCT: "Product/Create",
    UPDATE_PRODUCT: "Product/Update",
    REMOVE_PRODUCT: "Product/Delete",
    GETBYID_PRODUCT: "Product/GetById",
    GETALL_PRODUCT: "Product/GetAll"
};
const basket = {
    CREATE_BASKET: "Basket/Create",
    UPDATE_BASKET: "Basket/Update",
    REMOVE_BASKET: "Basket/Delete",
    GETBASKETITEMS_BASKET: "Basket/GetBasketItems",
    PURCHASE_BASKET: "Basket/Purchase",
    GETBYID_BASKET: "Basket/GetBasketId",
};

const endPoint = {
    auth,
    product,
    basket
};

export default endPoint;
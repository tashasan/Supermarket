const auth = {
    LOGIN_ACTION: "LOGIN_ACTION",
    LOGOUT_ACTION: "LOGOUT_ACTION"
}
const product = {
    CREATE_ACTION_PRODUCT: "CREATE_ACTION_PRODUCT",
    UPDATE_ACTION_PRODUCT: "UPDATE_ACTION_PRODUCT",
    DELETE_ACTION_PRODUCT: "DELETE_ACTION_PRODUCT",
    GETBYID_ACTION_PRODUCT: "GETBYID_ACTION_PRODUCT",
    GETALL_ACTION_PRODUCT: "GETALL_ACTION_PRODUCT"
}
const basket = {
    CREATE_ACTION_BASKET: "CREATE_ACTION_BASKET",
    UPDATE_ACTION_BASKET: "UPDATE_ACTION_BASKET",
    DELETE_ACTION_BASKET: "DELETE_ACTION_BASKET",
    GETBYID_ACTION_BASKET: "GETBYID_ACTION_BASKET",
    PURCHASE_ACTION_BASKET: "PURCHASE_ACTION_BASKET",
    GETBASKETITEMS_ACTION: "GETBASKETITEMS_ACTION"
}

const ActionTypes = {
    auth,
    product,
    basket
};

export default ActionTypes;
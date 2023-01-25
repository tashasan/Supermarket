const match = document.cookie.match(new RegExp('(^| )' + 'token' + '=([^;]+)'));
const id = match === null ? "" : match[2]

export const initialState = {
    auth: {
        currentUser: id
    },
    product: {
        product: { productName: "", categoryId: 0, productStock: 0, productUnitPrice: 0 },
        getById: [],
        getAll: []
    },
    basket: {
        basket: { quantity: 0, productId: 0 },
        getById: [],
        purchase: { paymentType: 1 },
        basketItems: []
    }

}
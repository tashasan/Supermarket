import React, { useEffect, useState } from "react"
import { DetailsList, SelectionMode, Stack, PrimaryButton, CommandBar } from "@fluentui/react";
import Actions from "../../store/redux/actions";
import { useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";

const columnProps = {
    tokens: { childrenGap: 20 },
    style: { root: { width: 100 } }
}
export default function Basket() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const [paymentTypes, setPaymentType] = useState("");
    const currentUser = useSelector((e) => e.auth.currentUser)
    const basketId = useSelector((e) => e.basket.getById.id)
    const basketItems = useSelector((e) => e.basket.basketItems)
    const columns = [
        {
            key: "id",
            name: "Id",
            fieldName: "id",
            minWidth: 10,
            maxWidth: 50,
            isRowHeader: true,
        },
        {
            key: "productId",
            name: "Product",
            fieldName: "productId",
            minWidth: 50,
            maxWidth: 100,
            isRowHeader: true
        },
        {
            key: "quantity",
            name: "Quantity",
            fieldName: "quantity",
            minWidth: 50,
            maxWidth: 100,
            isRowHeader: true
        },
        {
            key: "totalPrice",
            name: "TotalPrice",
            fieldName: "totalPrice",
            minWidth: 50,
            maxWidth: 100,
            isRowHeader: true
        },
        {
            key: "process",
            name: "Action",
            fieldName: "Action",
            minWidth: 100,
            maxWidth: 300,
            isRowHeader: true,
            onRender: (item) => (
                <Stack {...columnProps} horizontal>
                    <PrimaryButton
                        text="Edit Cart Item"
                        className="btn btn-warning"
                        onClick={() => navigate("/basket/edit/" + item.id,
                            { state: { id: item.id } })}
                    />
                    <PrimaryButton
                        className="btn btn-danger"
                        text="Discard from Cart"
                        onClick={() => DeleteProduct(item.id)}
                    />
                </Stack>

            )
        }

    ]
    console.log((paymentTypes))
    const onPurchase = async () => {
        await dispatch(Actions.basketActions.purchaseAction(basketId, paymentTypes))
        setPaymentType(0)
        window.location.reload(1)
    }
    if (paymentTypes === 0) {
        navigate("/products")
    }
    const handleChange = (e) => {
        const value = e.target.value;
        console.log(value)
        setPaymentType({ ["paymentType"]: parseInt(value) })
    }
    async function DeleteProduct(id) {
        if (window.confirm("Delete the item?")) {
            dispatch(Actions.basketActions.removeAction(id))
            await GetLists();
            window.location.reload(1)
        }
    }
    async function GetLists() {
        await dispatch(Actions.basketActions.getByIdAction(currentUser))
    };
    useEffect(() => {
        GetLists();
    }, []);
    return (
        <div className="container-fluid">
            <div className="fs-2 text-center">Cart Items</div>

            <DetailsList
                items={basketItems}
                columns={columns}
                SelectionMode={SelectionMode.none}
            />
            <div className="row">
                <div className="col-5">
                    <form >
                        <div >
                            <input
                                type="radio"
                                name="paymentType"
                                value={1}
                                checked
                                onChange={handleChange}
                            /> Credit Cards
                        </div>
                        <div>
                            <input
                                type="radio"
                                name="paymentType"
                                value={2}
                                onChange={handleChange}
                            /> Debit Cards
                        </div>
                        <div>
                            <input
                                type="radio"
                                name="paymentType"
                                value={3}
                                onChange={handleChange}
                            /> Paypal
                        </div>
                        <div>
                            <input
                                type="radio"
                                name="paymentType"
                                value={4}
                                onChange={handleChange}
                            /> Cash
                        </div>

                        <div >
                            <button className="btn btn-primary ms-5" onClick={onPurchase} >Purchase</button>
                        </div>
                    </form>
                </div>
            </div>

        </div>
    )
}

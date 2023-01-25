import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { DetailsList, SelectionMode, Stack, PrimaryButton, CommandBar } from "@fluentui/react";
import Actions from "../../store/redux/actions";
import { useNavigate } from 'react-router-dom';
const columnProps = {
    tokens: { childrenGap: 20 },
    style: { root: { width: 100 } }
}

const ProductList = () => {
    const productList = useSelector((e) => e.product.getAll);
    const currentUser = useSelector((e) => e.auth.currentUser)
    const dispatch = useDispatch();
    const navigate = useNavigate();
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
            key: "name",
            name: "Name",
            fieldName: "name",
            minWidth: 100,
            maxWidth: 150,
            isRowHeader: true
        },
        {
            key: "categoryId",
            name: "Category",
            fieldName: "categoryId",
            minWidth: 100,
            maxWidth: 200,
            isRowHeader: true
        },
        {
            key: "stock",
            name: "Stock",
            fieldName: "stock",
            minWidth: 50,
            maxWidth: 100,
            isRowHeader: true
        },
        {
            key: "unitPrice",
            name: "Unit Price",
            fieldName: "unitPrice",
            minWidth: 100,
            maxWidth: 200,
            isRowHeader: true,

        },
        {
            key: "process",
            name: "Action",
            fieldName: "Action",
            minWidth: 300,
            maxWidth: 500,
            isRowHeader: true,
            onRender: (item) => (
                <Stack {...columnProps} horizontal>
                    <PrimaryButton
                    className="btn btn-info"
                        text="Add to Cart"
                        onClick={() => AddToCart(currentUser, { productId: item.id, quantity: item.stock })}
                    />
                    <PrimaryButton
                        text="Edit Product"
                        className="btn btn-warning"
                        onClick={() => navigate("/product/edit/" + item.id,
                            { state: { id: item.id } })} />
                    <PrimaryButton
                    className="btn btn-danger"
                        text="Delete Product"
                        onClick={() => DeleteProduct(item.id)}
                    />
                </Stack>

            )
        }

    ]
    async function GetLists() {
        await dispatch(Actions.productActions.getAllAction())
    };
    useEffect(() => {
        GetLists();
    }, []);

    async function DeleteProduct(id) {
        if (window.confirm("Delete the item?")) {
            await dispatch(Actions.productActions.removeAction(id))
            await GetLists();
            window.location.reload(1)
        }
    }
    function AddToCart(userId, data) {
        dispatch(Actions.basketActions.createAction(userId, data))
        alert("Successfully Added to Cart")
    }

    return (
        <div className='container-fluid'>
              <div className="fs-2 text-center">Product List</div>
              <div>
                <button className="btn btn-primary ms-5" onClick={()=> navigate("/product/create")} >Add Product</button>
              </div>
            <DetailsList
                items={productList}
                columns={columns}
                SelectionMode={SelectionMode.none}
            />
        </div>
    );
};
export default ProductList;
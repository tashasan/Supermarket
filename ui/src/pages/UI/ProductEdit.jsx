import React, { useEffect, useState } from 'react'
import { Stack, PrimaryButton, TextField, Dropdown } from "@fluentui/react"
import { initialState } from '../../store/redux/reducers/initialState';
import { useDispatch, useSelector } from 'react-redux';
import Actions from '../../store/redux/actions';
import { useLocation } from 'react-router-dom';

export default function ProductEdit() {
    const dispatch = useDispatch();
    const data = useSelector((e) => e.product.getById)
    const location = useLocation();
    const [pageData, setPageData] = useState(initialState.product.product);
    const options = [{ key: "1", text: "Staple Food", value: 1 }, { key: "2", text: "Chocolates", value: 2 }, { key: "3", text: "Drinks", value: 3 }]
    const onChangeText = (e) => {
        e.preventDefault();
        const { name, value } = e.target;
        setPageData({ ...pageData, [name]: value });
    };
    const handleRoleChange = (event, option, index) => {
        setPageData({ ...pageData, ["categoryId"]: option.value });
    }
    const onUpdate = () => {
        dispatch(Actions.productActions.updateAction(pageData, location.state.id))
        setPageData(initialState.product.product)
    }
    const getProduct = () => {
        dispatch(Actions.productActions.getByIdAction(location.state.id))
        setPageData(data)
    }
    useEffect(() => {
        getProduct();
    }, []);
    return (
        <div className="container-fluid ms-5">
            <div className="fs-2 text-center">Edit Product</div>
            <Stack className='text-center'
                tokens={{ childrenGap: 10 }}
                styles={
                    {
                        root: {
                            width: 700,
                            marginLeft: 10,
                            marginTop: 10
                        }
                    }
                }>
                <TextField
                    label="Product Name"
                    name="productName"
                    value={pageData.productName}
                    onChange={onChangeText}
                    required
                />
                <Dropdown
                    placeholder="Select a Category"
                    label="Category"
                    name="categoryId"
                    options={options}
                    onChange={handleRoleChange}
                    required
                />
                <TextField
                    type='number'
                    label="How many products you have?"
                    name="productStock"
                    value={pageData.productStock}
                    onChange={onChangeText}
                    required
                />
                <TextField
                    type='number'
                    label="What price for each unit?"
                    name="productUnitPrice"
                    value={pageData.productUnitPrice}
                    onChange={onChangeText}
                    required
                />
                <PrimaryButton
                    text="Save"
                    onClick={() => onUpdate()}
                    style={{ width: "10%", height: "50px" }}
                />

            </Stack></div>
    )
}

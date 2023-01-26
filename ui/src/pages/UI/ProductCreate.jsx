import React, { useState } from 'react'
import { initialState } from '../../store/redux/reducers/initialState';
import { Stack, PrimaryButton, TextField, Dropdown } from "@fluentui/react"
import { useDispatch } from 'react-redux';
import Actions from '../../store/redux/actions';

export default function ProductCreate() {
    const dispatch = useDispatch();
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
    const onCreate = () => {
        dispatch(Actions.productActions.createAction(pageData))
        setPageData(initialState.product.product)
    }
    return (
        <div className="container-fluid">
            <div className="fs-2 text-center">Create Product</div>
            <Stack className='text-center'
                tokens={{ childrenGap: 10 }}
                styles={
                    {
                        root: {
                            width: 300,
                            marginLeft: 480,
                            marginTop: 20
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
                    text="Create"
                    onClick={() => onCreate()}
                    style={{ width: "20%", height: "50px",marginLeft:110 }}
                />

            </Stack>
            </div>
    )
}

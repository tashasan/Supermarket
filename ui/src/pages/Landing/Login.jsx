import { useState } from "react";
import { useDispatch } from "react-redux";
import {  useLocation, useNavigate } from "react-router-dom";
import Actions from "../../store/redux/actions";
import { Stack, PrimaryButton, TextField } from "@fluentui/react"

function Login() {
    const [loginData, setLoginData] = useState({});
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const location = useLocation();
    const from = location.state?.from?.pathname || "/products";

    const onChangeText = (e) => {
        const { name, value } = e.target;
        setLoginData({ ...loginData, [name]: value });
    };
    const onLogin = async (e) => {
        e.preventDefault();
        await dispatch(Actions.authActions.loginAction(loginData.email, loginData.password));
        navigate(from, { replace: true })
    };

    const content = (
        <div className="container-fluid">
            <div className="row">
                <div className="col-5"></div>
                <div className="col-7 mt-5">
                    <form
                        onSubmit={onLogin}
                        className="form-group col-lg-8 col-sm-6 offset-sm-3 offset-lg-0 ps-0"
                    >
                        <Stack className='text-center'
                            tokens={{ childrenGap: 10 }}
                            styles={
                                {
                                    root: {
                                        width: 250,
                                        marginLeft: 0,
                                        marginTop: 100
                                    }
                                }
                            }>
                            <TextField
                                label="Email"
                                name="email"
                                type="text"
                                value={loginData.email}
                                onChange={onChangeText}
                                required
                            />
                            <TextField
                                label="Password"
                                type="password"
                                name="password"
                                value={loginData.password}
                                onChange={onChangeText}
                                required
                            />
                            <PrimaryButton
                                text="Login"
                                type="submit"
                                style={{ width: "20%", height: "50px",marginLeft:80 }}
                            />

                        </Stack>
                    </form>
                </div>

            </div>
        </div>
    );
    return content;
}

export default Login;
{/* <Form onSubmit={onLogin}>
    <Form.Group size="sm" controlId="email">
        <Form.Label>Kullanıcı Adı</Form.Label>
        <Form.Control
            autoFocus
            name="email"
            type="text"
            value={loginData.email}
            onChange={onChangeText}
        />
    </Form.Group>
    <Form.Group size="sm" controlId="password">
        <Form.Label>Şifre</Form.Label>
        <Form.Control
            type="password"
            name="password"
            value={loginData.password}
            onChange={onChangeText}
        />
    </Form.Group>
    <Button className="button" block="true" size="lg" type="submit" >
        Giriş
    </Button>
</Form> */}
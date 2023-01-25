import React from "react";
import { Routes, Route, Outlet } from "react-router-dom";
import { useEffect } from "react";
import HandleAlert from "./hooks/useAlert";
import Landing from "./pages/Landing";
import UI from "./pages/UI";
import Sidebar from "./components/Sidebar";


function LandingPages() {
    useEffect(() => {
        window.scrollTo(0, 0)
    });
    return (
        <div>
            {HandleAlert()}
            <Outlet />
        </div>
    )

}
function UIPages() {
    useEffect(() => {
        window.scrollTo(0, 0)
    });
    return (
        <div className="container-fluid p-0">
            <div className="row">
                <div className="col-2" > <Sidebar /></div>
                <div className="col-10"><Outlet /></div>
            </div>
        </div>)
}
export const App = () => {

    return (
        <Routes>
            <Route element={<LandingPages />}>
                <Route path="/" element={<Landing.Login />} />
            </Route>
            <Route element={<UIPages />}>
                <Route path="/products" element={<UI.ProductList />} />
                <Route path="/product/edit/:id" element={<UI.ProductEdit />} />
                <Route path="/product/create" element={<UI.ProductCreate />} />
                <Route path="/basket" element={<UI.Basket />} />
            </Route>
        </Routes>
    );
};

export default App;

import React, { Suspense } from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { BrowserRouter } from "react-router-dom";
import { Provider } from "react-redux";
import { store } from "./store/redux/store";

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
	<Suspense fallback={<div>Loading</div>}>
		<BrowserRouter>
			<Provider store={store}>
				<App />
			</Provider>
		</BrowserRouter>
	</Suspense>
);
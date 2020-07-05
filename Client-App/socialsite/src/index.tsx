import React from 'react';
import { initSentry } from './lib/errorLib';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import ErrorBoundary from './Components/ErrorBoundaries/ErrorBoundary';

initSentry();
ReactDOM.render(
  //  <React.StrictMode>
  //  <App />
  // </React.StrictMode>,
   <ErrorBoundary render = {()=> <span>Error!! Logging out</span>}  ><App /></ErrorBoundary>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();

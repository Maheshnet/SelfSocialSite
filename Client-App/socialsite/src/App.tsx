import React from "react";
import logo from "./logo.svg";
import "./App.css";
//import * as Sentry from "@sentry/browser";
//import { logError } from "./lib/errorLib";
// import ErrorBoundary from "./Components/ErrorBoundaries/ErrorBoundary";

function App() {
  return (
    <div className="App">
           <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
        {/* <ErrorBoundary><div>
          <button onClick={HndErrBreak1}>Break the world1</button>
        </div></ErrorBoundary> */}
        <div>
          <button onClick={HdErrBreak1}>Break the world</button>
        </div>
      </header>
      <footer>
        {" "}
        <div>
          <small>
            You are running this application in <b>{process.env.NODE_ENV}</b>{" "}
            mode.
          </small>
          <form></form>
        </div>
      </footer>
    </div>
  );
}

function HdErrBreak1() {
  try {
    throw new Error("Test Error 123");
  } catch (error) {
    if (process.env.NODE_ENV !== "development") {
      return;
    }
    throw new Error("Extended Test Error 23.2");
    //logError(error);
   // Sentry.captureException(error);
  }
}

// function HndErrBreak1() {
//   try {
//     throw new Error("Test Error12");
  
//   } catch (error) {
//     if (process.env.NODE_ENV !== "development") {
//       return;
//     }
    //throw new Error("Extended Test Error");
    //logError(error);
    // Sentry.captureException(error);

  
// }
// }



export default App;

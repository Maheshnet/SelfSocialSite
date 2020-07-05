import React, { Component } from "react";
import { Header, Icon, List } from 'semantic-ui-react'


import "./App.css";
import axios from 'axios';
//import * as Sentry from "@sentry/browser";
//import { logError } from "./lib/errorLib";
// import ErrorBoundary from "./Components/ErrorBoundaries/ErrorBoundary";

class App extends Component {
  state = { values: [] }
  componentDidMount() {
    axios.get('https://localhost:44304/api/values')
      .then((response) => {
        //console.log(response)
        this.setState({
          values: response.data
        })
      })
    // this.setState ({
    //   values: [{id:1, name: 'Value 101'}, {id:2, name: 'Value 102'}]
    // }) 
  }
  render() {
    return (
      <div>
        <Header as='h2'>
          <Icon name="users" />
          <Header.Content>SActivities</Header.Content>
        </Header>
        <List>
        {this.state.values.map((value: any) =>
          (<List.Item key={value.id}>{value.name}</List.Item>))}
        </List>
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
}
// function HdErrBreak1() {
//   try {
//     throw new Error("Test Error 123");
//   } catch (error) {
//     if (process.env.NODE_ENV !== "development") {
//       return;
//     }
//     throw new Error("Extended Test Error 23.2");
//     //logError(error);
//    // Sentry.captureException(error);
//   }
// }

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

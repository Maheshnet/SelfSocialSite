
import { Component } from 'react';
import PropTypes from 'prop-types'
import * as Sentry from '@sentry/browser';
//import App from '../../App';
import TestErrorPage from '../ErrorPages/TestErrorPage';


const initialState = { error: null, info: null, hasError: false }
class ErrorBoundary extends Component {
  static propTypes = {
    children: PropTypes.oneOfType([
      PropTypes.node,
      PropTypes.arrayOf(PropTypes.node)
    ]).isRequired,
    render: PropTypes.func.isRequired
  }
  state = initialState;
  constructor(props: Readonly<{}>) {
    super(props);
    this.setState(initialState);
  }

  // static getDerivedStateFromError() {
  //   return { hasError: true };
  // }

  componentDidCatch(error: any, errorInfo: { [key: string]: any; }) {
    Sentry.withScope((scope) => {
      errorInfo && scope.setExtras(errorInfo);
      const eventId = Sentry.captureException(error);
      //this.setState({ eventId });
      this.setState({ error: eventId, info: errorInfo, hasError: true });
    });
  }

  render() {
    // const error = this.state.error
    if (this.state.hasError) {
      
      //render fallback UI
      return (TestErrorPage);
    }
    //when there's not an error, render children untouched
    return this.props.children;

  }

}


export default ErrorBoundary
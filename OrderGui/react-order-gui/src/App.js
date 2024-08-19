import React, { Component } from "react";
import Orders from './components/orders';
import axios from 'axios'

const API_URL = "http://localhost:3001/orders"

class App extends Component {
  state = {
    orders: []
  };


  componentDidMount() {
    axios.get(API_URL)
      .then(res => {
        const orders = res.data;
        this.setState({ orders })
      })
  }

  render() {
    return (
      <div>
        App component
        <Orders orders={this.state.orders} />
      </div>
    )
  }
}

export default App;
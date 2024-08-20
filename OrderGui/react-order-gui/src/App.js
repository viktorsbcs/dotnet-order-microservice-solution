import React, { Component } from "react";
import Orders from './components/orders';
import axios from 'axios'

const API_URL = "http://localhost:3001/orders"

class App extends Component {
  state = {
    orders: []
  };


  componentDidMount() {
    // axios.get(API_URL)
    //   .then(res => {
    //     const orders = res.data;
    //     this.setState({ orders })
    //   })
  }

  render() {
    return (
      <div class="container text-center">
        <div class="row align-items-start mt-5">
          <div class="col-2">
          </div>
          <div class="col-6">
            <Orders orders={this.state.orders} />
          </div>
          <div class="col-2">
          </div>
        </div>

        
      </div>
    )
  }
}

export default App;
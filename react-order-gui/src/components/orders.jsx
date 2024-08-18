import React, { Component } from "react";

class Orders extends Component {

    render() {
        const { orders } = this.props;
        return (
            <div>
                <ul>
                    {orders.map((order) => (
                        <li key={order.id}>{order.id} - {order.value}</li>
                    ))}
                </ul>
            </div>
        )
    }
}

export default Orders;
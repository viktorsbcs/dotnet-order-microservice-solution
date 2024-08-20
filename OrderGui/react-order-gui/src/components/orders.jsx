import React, { Component } from "react";

class Orders extends Component {

    render() {
        //const { orders } = this.props;
        const orders = [
            { id: 1, value: "aaa"},
            { id: 2, value: "bbb"},
            { id: 3, value: "ccc"},
            { id: 4, value: "ddd"},
        ]
        const rows = []
        orders.map(order => {
            const row = {id:order.id, value:order.value}
            rows.push(row)
        })

        const columns = [
            { field: 'id', headerName: 'OrderId', width: 170 },
            { field: 'value', headerName: 'Value', width: 200}
        ]

        return (
            <div class="table-responsive-sm">
                <table class="table table-bordered ">
                    <thead>
                        <tr>
                        <th scope="col">Order Id</th>
                        <th scope="col">Value</th>
                        </tr>
                    </thead>
                    <tbody>
                        
                        {orders.map(order => ( 
                            <tr>
                                <th scope="row">{order.id}</th>
                                <td>{order.value}</td>
                            </tr>
                        ))}
                        
                    </tbody>
                    </table>
            </div>
        )
    }
}

export default Orders;
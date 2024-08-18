const express = require('express');
const app = express();
const cors = require('cors')
app.use(express.json());

const PORT = process.env.PORT || 3001;

app.listen(PORT, () => {
    console.log("Server Listening on PORT:", PORT);
});

app.get("/orders", cors(), (request, response) => {

    const orders = [
        { id: 1, value: "aaa"},
        { id: 2, value: "bbb"},
        { id: 3, value: "ccc"},
        { id: 4, value: "ddd"},
    ]

    

    response.send(orders);
});
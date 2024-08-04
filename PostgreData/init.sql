\connect OrdersDb;

CREATE SCHEMA IF NOT EXISTS dbo;

CREATE TABLE IF NOT EXISTS dbo.UserOrders (
    Id UUID NOT NULL PRIMARY KEY,
    OrderDate TIMESTAMP NOT NULL
);

\echo "OrdersDb initialization complete"

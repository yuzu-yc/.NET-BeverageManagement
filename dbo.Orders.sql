CREATE TABLE [dbo].[Orders] (
    [OrderID]     INT             IDENTITY (1, 1) NOT NULL,
    [OrderDate]   DATETIME        DEFAULT (getdate()) NULL,
    [TotalPrice]  DECIMAL (10, 2) DEFAULT ((0.00)) NULL,
    [OrderStatus] NVARCHAR (50)   DEFAULT ('???') NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC)
);


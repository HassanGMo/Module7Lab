-- Task 1: Retrieve columns. -- 
SELECT CompanyName, Phone FROM Shippers;

-- Task 2: Sort rows. --
SELECT CompanyName, City, Country FROM Customers
ORDER BY City LIMIT 5;

-- Task 3: Filter rows. --
SELECT OrderID, OrderDate, ShipCity FROM Orders
WHERE CustomerID = 'ANATR';

-- Task 4: Join two tables. --
SELECT c.CompanyName, o.OrderDate FROM Customers AS c
JOIN Orders AS o ON c.CustomerID = o.CustomerID
WHERE c.CompanyName = 'Around the Horn' LIMIT 5;

-- Task 5: Add a row. --
DELETE FROM Customers WHERE CustomerID = 'STUD1';

INSERT INTO Customers (CustomerID, ContactName, CompanyName, Country)
VALUES ('STUD1', 'Hassan Mohamed', 'My Company', 'USA');

SELECT * FROM Customers WHERE CustomerID = 'STUD1';

-- Task 6: Change a row. --
UPDATE Customers SET Phone = '555-0100'
WHERE CustomerID = 'STUD1';

SELECT CustomerID, ContactName, Phone FROM Customers
WHERE CustomerID = 'STUD1';

-- Task 7: Remove a row. --
DELETE FROM Customers WHERE CustomerID = 'STUD1';

SELECT * FROM Customers WHERE CustomerID = 'STUD1';
/*
QUESTION

Customers ( -> c
  CustomerId,
  CustomerName,
  DOB,
  City,
  CreatedDate
)
PolicyTypes ( -> pt
  PolicyTypeId,
  PolicyTypeName,
  CoverageAmount,
  BasePremium
)
Policies ( -> p
  PolicyId,
  CustomerId,
  PolicyTypeId,
  StartDate,
  EndDate,
  PremiumAmount,
  Status
)
Payments ( -> py
  PaymentId,
  PolicyId,
  PaymentDate,
  Amount
)
Claims ( -> cl
  ClaimId,
  PolicyId,
  ClaimDate,
  ClaimAmount,
  ClaimStatus
)


---------------------------------------------
1.While creation
Enforce that:

Policy end date is greater than start date

Claim amount cannot exceed policy coverage

Premium amount must be positive
---------------------------------------------
USE STORED PROCEDURE FOR THE QUERIES BELOW:
---------------------------------------------
2.Insert a new policy and first premium payment for a customer;

rollback the transaction if premium or dates are invalid using TRY…CATCH.
---------------------------------------------
3.Return policy details showing:
Customer name, policy type, premium, total paid amount, number of claims.
---------------------------------------------
4.Return customers who have policies but never made any payment.
---------------------------------------------
5.Return policies whose premium is greater than the average premium of the same policy type.
---------------------------------------------
6.Return:

a)who purchased policies in 2023 UNION 2024

b)Customers common to both years

c)Customers who purchased only in 2023
---------------------------------------------
7.Return:

a)Policy-type-wise total premium collected

b)City-wise total claim amount

c)Top 3 customers by total premium paid
---------------------------------------------
==>FUNCTION
8.Create a function that returns loyalty discount % based on total premium paid by a customer.
---------------------------------------------
==>TRIGGERS
9. Create a trigger that:

a)Automatically marks a policy as EXPIRED when end date is crossed

b)Prevents approval of claims for expired policies
*/
-----------------------------------------------
CREATE DATABASE Customer_Policy;

USE Customer_Policy;

CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    DOB DATE,
    City VARCHAR(50),
    CreatedDate DATE
)

CREATE TABLE PolicyTypes (
    PolicyTypeId INT PRIMARY KEY,
    PolicyTypeName VARCHAR(100),
    CoverageAmount DECIMAL(12,2),
    BasePremium DECIMAL(10,2)
)

CREATE TABLE Policies (
    PolicyId INT PRIMARY KEY,
    CustomerId INT,
    PolicyTypeId INT,
    StartDate DATE,
    EndDate DATE,
    PremiumAmount DECIMAL(10,2) CHECK (PremiumAmount > 0),
    Status VARCHAR(20),
    
    CONSTRAINT FK_Policies_Customer
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),

    CONSTRAINT FK_Policies_PolicyTypes
    FOREIGN KEY (PolicyTypeId) REFERENCES PolicyTypes(PolicyTypeId),

    CHECK (EndDate > StartDate)
)

CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY,
    PolicyId INT,
    PaymentDate DATE,
    Amount DECIMAL(10,2),

    CONSTRAINT FK_Payments_Policies
    FOREIGN KEY (PolicyId) REFERENCES Policies(PolicyId)
)

CREATE TABLE Claims (
    ClaimId INT PRIMARY KEY,
    PolicyId INT,
    ClaimDate DATE,
    ClaimAmount DECIMAL(12,2),
    ClaimStatus VARCHAR(20),
    CONSTRAINT FK_Claims_Policies
    FOREIGN KEY (PolicyId) REFERENCES Policies(PolicyId)
)
------------------------------------------
INSERT INTO Customers VALUES
(1,'Pranav','2003-11-07','Himachal Pradesh','2022-01-01'),
(2,'Dilshad','2003-06-16','Jharkhand','2023-03-15'),
(3,'Adarsh','2004-12-10','Madhya Pradesh','2024-02-10'),
(4,'Srikesh','2003-01-05','Bangalore','2025-05-12')


INSERT INTO PolicyTypes VALUES
(1,'HealthInsurance',500000,12000),
(2,'LifeInsurance',1000000,15000)
-------------------------------------------
-- 2
CREATE PROCEDURE sp_InsertPolicyWithPayment
@PolicyId INT,
@CustomerId INT,
@PolicyTypeId INT,
@StartDate DATE,
@EndDate DATE,
@PremiumAmount DECIMAL(10,2),
@PaymentId INT,
@PaymentDate DATE,
@Amount DECIMAL(10,2)
AS
BEGIN
BEGIN TRY
BEGIN TRANSACTION

IF @EndDate <= @StartDate OR @PremiumAmount <= 0
THROW 50001, 'Invalid Policy Data', 1

INSERT INTO Policies VALUES
(@PolicyId,@CustomerId,@PolicyTypeId,@StartDate,@EndDate,@PremiumAmount,'Active')

INSERT INTO Payments VALUES
(@PaymentId,@PolicyId,@PaymentDate,@Amount)

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END

EXEC sp_InsertPolicyWithPayment 1,1,1,'2023-02-01','2024-02-05',13000,1,'2023-02-05',13000
EXEC sp_InsertPolicyWithPayment 2,2,1,'2023-04-05','2024-02-05',14000,2,'2023-05-05',14000
EXEC sp_InsertPolicyWithPayment 3,3,2,'2024-03-02','2025-02-05',20000,3,'2024-02-05',20000
EXEC sp_InsertPolicyWithPayment 4,4,2,'2024-06-01','2025-02-05',22000,4,'2024-02-05',22000
------------------------------------------
-- 3
CREATE PROCEDURE sp_PolicyDetails
AS
BEGIN

SELECT 
c.CustomerName,
pt.PolicyTypeName,
p.PremiumAmount,
SUM(py.Amount) AS TotalPaidAmount,
COUNT(cl.ClaimId) AS NumberOfClaims

FROM Policies p

JOIN Customers c ON p.CustomerId = c.CustomerId
JOIN PolicyTypes pt ON p.PolicyTypeId = pt.PolicyTypeId

LEFT JOIN Payments py ON p.PolicyId = py.PolicyId
LEFT JOIN Claims cl ON p.PolicyId = cl.PolicyId

GROUP BY c.CustomerName, pt.PolicyTypeName, p.PremiumAmount
END
--------------------------------------------
-- 4
CREATE PROCEDURE sp_CustomersWithoutPayments
AS
BEGIN

SELECT DISTINCT c.CustomerId,c.CustomerName
FROM Customers c

JOIN Policies p ON c.CustomerId = p.CustomerId
LEFT JOIN Payments py ON p.PolicyId = py.PolicyId

WHERE py.PaymentId IS NULL
END
--------------------------------------------
-- 5
CREATE PROCEDURE sp_PoliciesAboveAveragePremium
AS
BEGIN

SELECT p.PolicyId, p.PolicyTypeId, p.PremiumAmount
FROM Policies p

JOIN (
    SELECT PolicyTypeId, AVG(PremiumAmount) AS AvgPremium
    FROM Policies
    GROUP BY PolicyTypeId
) a ON p.PolicyTypeId = a.PolicyTypeId

WHERE p.PremiumAmount > a.AvgPremium

END
--------------------------------------------
-- 6
CREATE PROCEDURE sp_YearWiseCustomers
AS
BEGIN

-- a)
SELECT CustomerId FROM Policies WHERE YEAR(StartDate)=2023
UNION
SELECT CustomerId FROM Policies WHERE YEAR(StartDate)=2024

-- b)
SELECT CustomerId FROM Policies WHERE YEAR(StartDate)=2023
INTERSECT
SELECT CustomerId FROM Policies WHERE YEAR(StartDate)=2024

-- c)
SELECT CustomerId FROM Policies WHERE YEAR(StartDate)=2023
EXCEPT
SELECT CustomerId FROM Policies WHERE YEAR(StartDate)=2024

END
--------------------------------------------
-- 7
CREATE PROCEDURE sp_TotalAmounts
AS
BEGIN

-- a)
SELECT pt.PolicyTypeName,SUM(p.PremiumAmount) AS TotalPremium
FROM Policies p

JOIN PolicyTypes pt ON p.PolicyTypeId = pt.PolicyTypeId

GROUP BY pt.PolicyTypeName

-- b)
SELECT c.City, SUM(cl.ClaimAmount) AS TotalClaimAmount
FROM Claims cl

JOIN Policies p ON cl.PolicyId = p.PolicyId
JOIN Customers c ON p.CustomerId = c.CustomerId

GROUP BY c.City

-- c)
SELECT TOP 3 c.CustomerName, SUM(py.Amount) AS TotalPaid
FROM Payments py

JOIN Policies p ON py.PolicyId = p.PolicyId
JOIN Customers c ON p.CustomerId = c.CustomerId

GROUP BY c.CustomerName
ORDER BY TotalPaid DESC

END
-------------------------------------------
-- 8
CREATE FUNCTION fn_LoyaltyDiscountPercentage (@CustomerId INT)
RETURNS DECIMAL(5,2)
AS
BEGIN
DECLARE @TotalPaid DECIMAL(12,2)

SELECT @TotalPaid = ISNULL(SUM(py.Amount),0)
FROM Policies p
JOIN Payments py ON p.PolicyId = py.PolicyId
WHERE p.CustomerId = @CustomerId

RETURN
CASE
WHEN @TotalPaid >= 50000 THEN 15
WHEN @TotalPaid >= 30000 THEN 10
WHEN @TotalPaid >= 10000 THEN 5
ELSE 0
END
END
--------------------------------------------
-- EXECUTION

-- 3 
EXEC sp_PolicyDetails

-- 4
EXEC sp_CustomersWithoutPayments

-- 5
EXEC sp_PoliciesAboveAveragePremium

-- 6
EXEC sp_YearWiseCustomers

-- 7
EXEC sp_TotalAmounts

-- 8
SELECT CustomerId,dbo.fn_LoyaltyDiscountPercentage(CustomerId) AS LoyaltyDiscountPercentage
FROM Customers
--------------------------------------------
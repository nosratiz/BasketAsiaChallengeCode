Feature: AddCustomer
In order to retain customers
As a store owner
I want to add new customers to the customer list

    @addCustomer
    Scenario: Add a new customer to the customer list

        Given see the customer list

        When I add a customer information like I enter the following customer information:
          | FirstName | LastName | Email             | PhoneNumber  | BankAccountNumber | DateOfBirth |
          | John      | Doe      | johnDoe@gmail.com | +18185778330 | 1234567890        | 01-03-1993  |

        Then the customer list should contain 1 customer
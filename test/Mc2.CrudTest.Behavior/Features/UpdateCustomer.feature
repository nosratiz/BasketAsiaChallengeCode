Feature: UpdateCustomer
	  As a user
  I want to update a customer
  So that I can keep my customer list up to date

 @updateCustomer
  Scenario: Update a customer
	Given I have a customer with the following attributes:
	| Id                                    | FirstName | LastName | Email             | PhoneNumber   | BankAccountNumber | DateOfBirth |
	|  C469FB46-01B8-4B8F-8E7D-CEF3AFD14A59 | John      | Doe      | johnDoe@gmail.com | +989107602786 | 1234567890        | 01-03-1993  |
    
    When I update the customer with the following attributes:
     | Id                                   | FirstName | LastName | Email             | PhoneNumber   | BankAccountNumber | DateOfBirth |
     | C469FB46-01B8-4B8F-8E7D-CEF3AFD14A59 | nima      | nosrati  | johnDoe@gmail.com | +989107602786 | 1234567890        | 01-03-1993  |
     
    Then the customer should be updated with the following attributes:
      | Id                                   | FirstName | LastName | Email             | PhoneNumber   | BankAccountNumber | DateOfBirth |
      | C469FB46-01B8-4B8F-8E7D-CEF3AFD14A59 | nima      | nosrati  | johnDoe@gmail.com | +989107602786 | 1234567890        | 01-03-1993  |

            
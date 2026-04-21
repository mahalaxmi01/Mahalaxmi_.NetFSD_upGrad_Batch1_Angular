"use strict";
class BankAccount {
    name;
    accountNumber;
    accountType;
    balance;
    constructor(name, accNo, type, balance) {
        this.name = name;
        this.accountNumber = accNo;
        this.accountType = type;
        this.balance = balance;
    }
    deposit(amount) {
        this.balance += amount;
        console.log(`Deposited: ${amount}`);
    }
    withdraw(amount) {
        if (amount <= this.balance) {
            this.balance -= amount;
            console.log(`Withdrawn: ${amount}`);
        }
        else {
            console.log("Insufficient Balance");
        }
    }
    display() {
        console.log("Name:", this.name);
        console.log("Balance:", this.balance);
    }
}
// Usage
let acc = new BankAccount("Sai", 12345, "Savings", 10000);
acc.deposit(2000);
acc.withdraw(5000);
acc.display();

class BankAccount {
    name: string;
    accountNumber: number;
    accountType: string;
    balance: number;

    constructor(name: string, accNo: number, type: string, balance: number) {
        this.name = name;
        this.accountNumber = accNo;
        this.accountType = type;
        this.balance = balance;
    }

    deposit(amount: number): void {
        this.balance += amount;
        console.log(`Deposited: ${amount}`);
    }

    withdraw(amount: number): void {
        if (amount <= this.balance) {
            this.balance -= amount;
            console.log(`Withdrawn: ${amount}`);
        } else {
            console.log("Insufficient Balance");
        }
    }

    display(): void {
        console.log("Name:", this.name);
        console.log("Balance:", this.balance);
    }
}

let acc = new BankAccount("Sai", 12345, "Savings", 10000);
acc.deposit(2000);
acc.withdraw(5000);
acc.display();
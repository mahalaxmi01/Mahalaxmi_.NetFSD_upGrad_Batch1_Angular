class Wallet {
    #balance = 0;
    addMoney(amount) {
        if (amount > 0) {
            this.#balance += amount;
            console.log(`Added ₹${amount}`);
        } else {
            console.log("Invalid amount");
        }
    }

    spendMoney(amount) {
        if (amount <= this.#balance && amount > 0) {
            this.#balance -= amount;
            console.log(`Spent ₹${amount}`);
        } else {
            console.log("Insufficient balance or invalid amount");
        }
    }

    getBalance() {
        return this.#balance;
    }
}

const myWallet = new Wallet();

myWallet.addMoney(1000);
myWallet.spendMoney(300);

console.log("Current Balance:", myWallet.getBalance());

console.log(myWallet.balance);
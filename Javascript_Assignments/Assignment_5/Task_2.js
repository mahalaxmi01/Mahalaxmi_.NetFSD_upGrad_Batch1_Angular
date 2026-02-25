class BankAccount{
    constructor(accountHolder,balance){
        this.accountHolder=accountHolder;
        this.balance=balance;

    }
    deposit(amount){
        if(amount>0) this.balance +=amount;
    }
    withdraw(amount){
        if(amount>this.balance) {
            console.log(`insuffient amount`)
        }
        else{
            this.balance -=amount;
        }
    }
    getBalance(){
        return this.balance;
    }
}
const account =new BankAccount('mahalaxmi',0);
account.deposit(1000);
console.log(account.getBalance());
account.withdraw(10000);

interface Payment {
    amount: number;
    pay(): void;
}

interface Refundable {
    refund(): void;
}

class CreditCardPayment implements Payment, Refundable {
    amount: number;

    constructor(amount: number) {
        this.amount = amount;
    }

    pay(): void {
        console.log(`Paid ${this.amount} using Credit Card`);
    }

    refund(): void {
        console.log("Refund initiated to Credit Card");
    }
}

class UPIPayment implements Payment {
    amount: number;

    constructor(amount: number) {
        this.amount = amount;
    }

    pay(): void {
        console.log(`Paid ${this.amount} using UPI`);
    }
}


let credit1 = new CreditCardPayment(1000);
let upi1 = new UPIPayment(500);


credit1.pay();
credit1.refund();

upi1.pay();
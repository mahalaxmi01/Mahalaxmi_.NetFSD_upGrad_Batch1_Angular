class Product {

    constructor({ name, price, category = "General" }) {
        this.name = name;
        this.price = price;
        this.category = category;
    }

    display = () => {
        console.log(`Product: ${this.name} | Price: ₹${this.price} | Category: ${this.category}`);
    }

    updateProduct = (updates) => {
        Object.assign(this, { ...updates });
    }
}


const p1 = new Product({
    name: "Laptop",
    price: 55000
});

const p2 = new Product({
    name: "Mobile",
    price: 20000,
    category: "Electronics"
});

p1.display();
p2.display();

p1.updateProduct({ price: 53000, category: "Electronics" });

p1.display();
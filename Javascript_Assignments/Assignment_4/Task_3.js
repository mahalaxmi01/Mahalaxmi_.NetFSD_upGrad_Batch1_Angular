let cart = [
  { id: 1, product: "Laptop", price: 60000, qty: 1 },
  { id: 2, product: "Headphones", price: 2000, qty: 2 },
  { id: 3, product: "Mouse", price: 800, qty: 1 }
];

console.log("Original Cart:", cart);

let totalValue = cart.reduce(
  (sum, item) => sum + item.price * item.qty,
  0
);

console.log("\n1. Total Cart Value:", totalValue);

let increaseId = 2;

cart = cart.map(item =>
  item.id === increaseId
    ? { ...item, qty: item.qty + 1 }
    : item
);

console.log("\n2. Quantity Increased:", cart);

let removeId = 3;

cart = cart.filter(item => item.id !== removeId);

console.log("\n3. After Removing Product:", cart);

let discountedCart = cart.map(item =>
  item.price > 10000
    ? { ...item, price: item.price * 0.9 }
    : item
);

console.log("\n4. Discount Applied:", discountedCart);

let sortedCart = [...cart].sort(
  (a, b) => (a.price * a.qty) - (b.price * b.qty)
);

console.log("\n5. Sorted Cart:", sortedCart);


let expensiveItem =
  cart.some(item => item.price > 50000);

console.log("\n6. Any item above ₹50,000?", expensiveItem);

let inStock =
  cart.every(item => item.qty > 0);

console.log("\n7. All items in stock?", inStock);

let invoice = cart
  .map(item =>
    `${item.product} x${item.qty} = ₹${item.price * item.qty}`
  )
  .join("\n");

console.log("\nBonus 1 - Invoice:\n" + invoice);


let mostExpensive = cart.reduce(
  (max, item) =>
    item.price > max.price ? item : max
);

console.log("\nBonus 2 - Most Expensive Product:");
console.log(mostExpensive);

let total = cart.reduce(
  (sum, item) => sum + item.price * item.qty,
  0
);

let gst = total * 0.18;
let finalAmount = total + gst;

console.log("\nBonus 3 - GST:", gst);
console.log("Final Amount (with GST):", finalAmount);
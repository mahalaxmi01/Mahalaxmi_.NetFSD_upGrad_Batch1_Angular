let books = [
  { id: 1, title: "JavaScript Basics", price: 450, stock: 10 },
  { id: 2, title: "React Guide", price: 650, stock: 5 },
  { id: 3, title: "Node.js Mastery", price: 550, stock: 8 },
  { id: 4, title: "CSS Complete", price: 300, stock: 12 }
];

console.log("Original Books:", books);


let titles = books.map(book => book.title);
console.log("\n1. Book Titles:");
console.log(titles);


let totalValue = books.reduce(
  (sum, book) => sum + (book.price * book.stock), 0
);

console.log("\n2. Total Inventory Value:", totalValue);


let costlyBooks = books.filter(book => book.price > 500);

console.log("\n3. Books Above ₹500:");
console.log(costlyBooks);


let increasedPrices = books.map(book => ({
  ...book,
  price: Math.round(book.price * 1.05)
}));

console.log("\n4. Prices Increased by 5%:");
console.log(increasedPrices);


let sortedBooks = [...books].sort(
  (a, b) => a.price - b.price
);

console.log("\n5. Sorted Books:");
console.log(sortedBooks);


let removeId = 2;

let removedBook = books.find(book => book.id === removeId);

books = books.filter(book => book.id !== removeId);

console.log("\n6. Removed Book:", removedBook);
console.log("Updated Books:", books);


let outOfStock = books.some(book => book.stock === 0);

console.log("\n7. Any book out of stock?", outOfStock);


let groupedBooks = books.reduce((acc, book) => {

  if (book.price < 400) acc.Low.push(book);
  else if (book.price <= 600) acc.Medium.push(book);
  else acc.High.push(book);

  return acc;

}, { Low: [], Medium: [], High: [] });

console.log("\nBonus 1 - Grouped Books:");
console.log(groupedBooks);

let discountedBooks = books.map(book =>
  book.price > 600
    ? { ...book, price: Math.round(book.price * 0.9) }
    : book
);

console.log("\nBonus 2 - Discount Applied:");
console.log(discountedBooks);


let invoice = books
  .map(book => `${book.title} - ₹${book.price}`)
  .join("\n");

console.log("\nBonus 3 - Invoice:");
console.log(invoice);
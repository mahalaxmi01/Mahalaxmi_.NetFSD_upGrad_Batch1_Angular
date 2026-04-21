class Book {
    isbn: number;
    bookName: string;
    bookTitle: string;
    bookAuthor: string;
    quantityOfBooks: number;
    bookPrice: number;

    constructor(isbn: number, name: string, title: string, author: string, quantity: number, price: number) {
        this.isbn = isbn;
        this.bookName = name;
        this.bookTitle = title;
        this.bookAuthor = author;
        this.quantityOfBooks = quantity;
        this.bookPrice = price;
    }

    calculateBill(): number {
        return this.quantityOfBooks * this.bookPrice;
    }

    displayDetails(): void {
        console.log("ISBN:", this.isbn);
        console.log("Book Name:", this.bookName);
        console.log("Title:", this.bookTitle);
        console.log("Author:", this.bookAuthor);
        console.log("Quantity:", this.quantityOfBooks);
        console.log("Price per Book:", this.bookPrice);
        console.log("Total Bill:", this.calculateBill());
    }
}


let book1 = new Book(101, "Java Basics", "Learn Java", "James", 3, 500);
book1.displayDetails();
class User {
    #password;
    constructor(password) {
        this.password = password;
    }

    set password(value) {
        if (value.length >= 6) {
            this.#password = value;
        } else {
            console.log("Password must contain at least 6 characters");
        }
    }

    get password() {
        return this.#password;
    }
}

const user1 = new User("abc123");

console.log(user1.password);   

user1.password = "123";    
user1.password = "newpass";   

console.log(user1.password);
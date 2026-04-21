class Vehicle {
    brand: string;
    speed: number;

    constructor(brand: string, speed: number) {
        this.brand = brand;
        this.speed = speed;
    }

    move(): void {
        console.log("Vehicle is moving");
    }
}

class Car extends Vehicle {
    fuelType: string;

    constructor(brand: string, speed: number, fuelType: string) {
        super(brand, speed);
        this.fuelType = fuelType;
    }

    move(): void {
        console.log(`Car is moving at ${this.speed} km/h`);
    }
}

class Bike extends Vehicle {
    hasGear: boolean;

    constructor(brand: string, speed: number, hasGear: boolean) {
        super(brand, speed);
        this.hasGear = hasGear;
    }

    move(): void {
        console.log(`Bike is moving at ${this.speed} km/h`);
    }
}

let car1 = new Car("Toyota", 80, "Petrol");
let bike1 = new Bike("Yamaha", 60, true);

car1.move();
bike1.move();

console.log("Car Brand:", car1.brand);
console.log("Bike Brand:", bike1.brand);

console.log("Car Fuel Type:", car1.fuelType);
console.log("Bike Has Gear:", bike1.hasGear);
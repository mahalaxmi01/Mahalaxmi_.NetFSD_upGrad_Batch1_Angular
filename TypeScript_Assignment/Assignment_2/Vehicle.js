"use strict";
class Vehicle {
    brand;
    speed;
    constructor(brand, speed) {
        this.brand = brand;
        this.speed = speed;
    }
    move() {
        console.log("Vehicle is moving");
    }
}
class Car extends Vehicle {
    fuelType;
    constructor(brand, speed, fuelType) {
        super(brand, speed);
        this.fuelType = fuelType;
    }
    move() {
        console.log(`Car is moving at ${this.speed} km/h`);
    }
}
class Bike extends Vehicle {
    hasGear;
    constructor(brand, speed, hasGear) {
        super(brand, speed);
        this.hasGear = hasGear;
    }
    move() {
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

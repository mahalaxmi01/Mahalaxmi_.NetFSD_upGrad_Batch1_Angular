"use strict";
class Shapes {
    // Implementation
    area(a, b, type) {
        if (b !== undefined && type === "triangle") {
            return 0.5 * a * b; // Triangle
        }
        else if (b !== undefined) {
            return a * b; // Rectangle
        }
        else {
            return Math.PI * a * a; // Circle
        }
    }
    // Square (separate method for clarity)
    squareArea(side) {
        return side * side;
    }
}
// Usage
let shape = new Shapes();
console.log("Rectangle:", shape.area(10, 5));
console.log("Triangle:", shape.area(10, 5, "triangle"));
console.log("Circle:", shape.area(7));
console.log("Square:", shape.squareArea(4));

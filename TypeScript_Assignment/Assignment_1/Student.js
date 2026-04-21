"use strict";
class Student {
    rollNo;
    studName;
    marksEng;
    marksMaths;
    marksScience;
    constructor(roll, name, eng, maths, science) {
        this.rollNo = roll;
        this.studName = name;
        this.marksEng = eng;
        this.marksMaths = maths;
        this.marksScience = science;
    }
    calculateTotal() {
        return this.marksEng + this.marksMaths + this.marksScience;
    }
    calculatePercentage() {
        return this.calculateTotal() / 3;
    }
    display() {
        console.log("Roll No:", this.rollNo);
        console.log("Name:", this.studName);
        console.log("Total Marks:", this.calculateTotal());
        console.log("Percentage:", this.calculatePercentage());
    }
}
let student1 = new Student(1, "Navya", 85, 90, 88);
student1.display();

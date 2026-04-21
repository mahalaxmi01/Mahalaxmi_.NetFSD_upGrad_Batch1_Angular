class Student {
    rollNo: number;
    studName: string;
    marksEng: number;
    marksMaths: number;
    marksScience: number;

    constructor(roll: number, name: string, eng: number, maths: number, science: number) {
        this.rollNo = roll;
        this.studName = name;
        this.marksEng = eng;
        this.marksMaths = maths;
        this.marksScience = science;
    }

    calculateTotal(): number {
        return this.marksEng + this.marksMaths + this.marksScience;
    }

    calculatePercentage(): number {
        return this.calculateTotal() / 3;
    }

    display(): void {
        console.log("Roll No:", this.rollNo);
        console.log("Name:", this.studName);
        console.log("Total Marks:", this.calculateTotal());
        console.log("Percentage:", this.calculatePercentage());
    }
}

let student1 = new Student(1, "Navya", 85, 90, 88);
student1.display();
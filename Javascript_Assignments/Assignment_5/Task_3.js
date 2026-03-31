class student{
    constructor(name){
        this.name=name;
        this.marks=[];
    }
    addMarks(num){
        this.marks.push(num);
    }
    getAvg(){
        if(this.marks.length==0) return 0;
        let sum=0;
        for(let mark of this.marks){
            sum +=mark;
        }
        return sum/this.marks.length
    }
    getGrade() {
        const avg = this.getAvg();

        if (avg >= 90) return "A";
        else if (avg >= 75) return "B";
        else if (avg >= 50) return "C";
        else return "Fail";
    }
}

const student1 = new student("John");

student1.addMarks(85);
student1.addMarks(92);
student1.addMarks(78);

console.log("Name:", student1.name);
console.log("Average:", student1.getAvg());
console.log("Grade:", student1.getGrade());
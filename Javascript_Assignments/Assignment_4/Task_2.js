let students = [
  { name: "Akhil", marks: 85 },
  { name: "Priya", marks: 72 },
  { name: "Ravi", marks: 90 },
  { name: "Meena", marks: 45 },
  { name: "Karan", marks: 30 }
];

console.log("Original Students:", students);

let passedStudents =
  students.filter(student => student.marks >= 40);

console.log("\n1. Passed Students:");
console.log(passedStudents);

let distinction =
  students.filter(student => student.marks >= 85);

console.log("\n2. Distinction Students:");
console.log(distinction);

let average =
  students.reduce((sum, student) =>
    sum + student.marks, 0) / students.length;

console.log("\n3. Class Average:", average.toFixed(2));

let topper =
  students.reduce((max, student) =>
    student.marks > max.marks ? student : max);

console.log("\n4. Topper:");
console.log(topper);


let failedCount =
  students.filter(student => student.marks < 40).length;

console.log("\n5. Failed Students Count:", failedCount);

let gradedStudents = students.map(student => {

  let grade;

  if (student.marks >= 85) grade = "A";
  else if (student.marks >= 60) grade = "B";
  else if (student.marks >= 40) grade = "C";
  else grade = "Fail";

  return { ...student, grade };
});

console.log("\n6. Students with Grades:");
console.log(gradedStudents);


let rankedStudents = [...students]
  .sort((a, b) => b.marks - a.marks)
  .map((student, index) => ({
    ...student,
    rank: index + 1
  }));

console.log("\nBonus 1 - Ranked Students:");
console.log(rankedStudents);


let withoutLowest =
  [...students]
    .sort((a, b) => a.marks - b.marks)
    .slice(1);

console.log("\nBonus 2 - After Removing Lowest:");
console.log(withoutLowest);


let leaderboard =
  [...students]
    .sort((a, b) => b.marks - a.marks);

console.log("\nBonus 3 - Leaderboard:");
console.log(leaderboard);
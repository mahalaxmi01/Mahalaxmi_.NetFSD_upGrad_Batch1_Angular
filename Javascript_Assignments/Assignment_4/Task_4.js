let employees = [
 { id:1, name:"Ravi", dept:"IT", salary:70000 },
 { id:2, name:"Anita", dept:"HR", salary:50000 },
 { id:3, name:"Karan", dept:"IT", salary:80000 },
 { id:4, name:"Meena", dept:"Finance", salary:60000 }
];

console.log("Original Employees:", employees);

let totalSalary = employees.reduce(
 (sum, emp) => sum + emp.salary, 0
);

console.log("\n1. Total Salary Expense:", totalSalary);

let highestPaid = employees.reduce(
 (max, emp) => emp.salary > max.salary ? emp : max
);

let lowestPaid = employees.reduce(
 (min, emp) => emp.salary < min.salary ? emp : min
);

console.log("\n2. Highest Paid:", highestPaid);
console.log("Lowest Paid:", lowestPaid);


let updatedEmployees = employees.map(emp =>
 emp.dept === "IT"
   ? { ...emp, salary: Math.round(emp.salary * 1.15) }
   : emp
);

console.log("\n3. IT Salary Increased:");
console.log(updatedEmployees);

let grouped = employees.reduce((acc, emp) => {

 if(!acc[emp.dept]) {
   acc[emp.dept] = [];
 }

 acc[emp.dept].push(emp);

 return acc;

}, {});

console.log("\n4. Grouped by Department:");
console.log(grouped);


let deptAverage = Object.keys(grouped).map(dept => {

 let total = grouped[dept].reduce(
   (sum, emp) => sum + emp.salary, 0
 );

 return {
   department: dept,
   averageSalary: total / grouped[dept].length
 };
});

console.log("\n5. Department Average Salary:");
console.log(deptAverage);

let sortedEmployees =
 [...employees].sort((a,b) => b.salary - a.salary);

console.log("\n6. Sorted Employees:");
console.log(sortedEmployees);


let afterTax = employees.map(emp => ({
 ...emp,
 netSalary: Math.round(emp.salary * 0.9)
}));

console.log("\nBonus 1 - After Tax Deduction:");
console.log(afterTax);

let avgSalary =
 employees.reduce((sum,e)=>sum+e.salary,0) / employees.length;

let aboveAverage =
 employees.filter(emp => emp.salary > avgSalary);

console.log("\nBonus 2 - Above Average Salary:");
console.log(aboveAverage);

let tableHTML = `
<table border="1">
    <tr>
        <th>ID</th>
        <th>Name</th>
        <th>Department</th>
        <th>Salary</th>
    </tr>

    ${employees.map(emp => `
    <tr>
        <td>${emp.id}</td>
        <td>${emp.name}</td>
        <td>${emp.dept}</td>
        <td>${emp.salary}</td>
    </tr>
    `).join("")}

</table>
`;

console.log("\nBonus 3 - HTML Table:");
document.getElementById("output").innerHTML = tableHTML;
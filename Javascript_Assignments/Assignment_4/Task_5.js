let numbers = [10,20,30,10,40,20,50,60,60];


let unique = [...new Set(numbers)];


let secondLargest = unique.sort((a,b)=>b-a)[1];


let frequency = numbers.reduce((acc,num)=>{
    acc[num]=(acc[num]||0)+1;
    return acc;
},{});

let firstNonRepeat = numbers.find(num=>frequency[num]===1);

let rotated = numbers.slice(2).concat(numbers.slice(0,2));

let flattened = [1,2,[3,4,[5]]].flat(Infinity);

let arr=[1,2,3,5,6];
let missing=[];
for(let i=1;i<=Math.max(...arr);i++){
    if(!arr.includes(i)) missing.push(i);
}

console.log(unique);
console.log(secondLargest);
console.log(frequency);
console.log(firstNonRepeat);
console.log(rotated);
console.log(flattened);
console.log(missing);
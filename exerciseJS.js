function func(num1, num2, numOfDecimalPlaces){
  let x = num1 * num2;

  x = parseFloat(x.toFixed(numOfDecimalPlaces+1));
  x = parseFloat(x.toFixed(numOfDecimalPlaces));

  return x;
}
//console.log(func(660, 0.08875, 2));

function isPalindrome(str) {
  const cleanedStr = str.toLowerCase().replace(/[^a-z0-9]/g, '');

  const reversedStr = cleanedStr.split('').reverse().join('');

  return cleanedStr === reversedStr;
}

//console.log(isPalindrome(", ,!howoh "));
//console.log(isPalindrome(",,ana "));

function fizzBuzz(){
  for(let i = 1; i <= 100; i++){
    if(i % 15 == 0){
      console.log("FizzBuzz");
    }
    else if(i % 3 == 0){
        console.log("Fizz");
    }
    else if(i % 5 == 0){
        console.log("Buzz");
    }
    else{console.log(i);}
  }
}
//fizzBuzz();

function fibonacci(n) {
  if (n <= 0) {
    return 0;
  } else if (n === 1 || n === 2) { return 1;}
    else {
    return fibonacci(n - 1) + fibonacci(n - 2);
  }
}
//console.log(fibonacci(2));

function duplicates(arr) {
  const set = new Set(arr);
  return Array.from(set);
}
//const arr = [10,10,10,20,20,20,30];
//console.log(duplicates(arr));

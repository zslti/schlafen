# ⚡What is Schlafen?

Schlafen is an esoteric programming language interpreter built in C#. Download it for Windows <a href="https://github.com/zslti/schlafen/files/14279458/schlafen.zip"><kbd>here</kbd></a>.

The fundamental concept of this project was creating a language utilizing German words as its keywords.

Schlafen consists of a basic text editor as well as an interpreter for the language.

# 🚀Code examples

## ➗ Print all divisors of a number

```dart
// open the file and read the value
eingangspfad "number.in";
ganzzahl num;
eingang num;

ganzzahl i = 2;
ganzzahl mod;

schreiben "divisors of ";
schreiben num;
neuezeile;

// while i <= num / 2
solange i < num / 2 + 1:
    mod = num % i,
    // if the number is divisible by i then print i
    wenn mod ist 0:
        schreiben i,
        schreiben " ",
    i = i + 1,
;
schlafen;
```

## 🔃 Check if a number is palindrome

```dart
ganzzahl num = 12321;
ganzzahl rev = 0;
ganzzahl digit;
ganzzahl temp = num;

// reverse the number
solange temp > 0:
    digit = temp % 10,
    rev = rev * 10 + digit,
    temp = temp / 10,
;

// if the reversed number is equal to the number it is palindrome
wenn rev ist num:
    schreiben "palindrome",
;

// otherwise it is not palindrome
wenn rev ist nicht num:
    schreiben "not palindrome",
schlafen;
```

## 📈 Print the first n elements of the fibonacci sequence

```dart
ganzzahl n;
ganzzahl num = 0;
ganzzahl num2 = 1;
ganzzahl next = 0;

eingangspfad "fibonacci.in";
eingang n;
ganzzahl i = 1;
solange i < n + 1:
    wenn i ist 1:
        schreiben num,
        schreiben " ",
        i = i + 1,
    wenn i ist 2:
        schreiben num2,
        schreiben " ",
        i = i + 1,
    next = num + num2,
    num = num2,
    num2 = next,

    schreiben next,
    schreiben " ",
    i = i + 1,
schlafen;

```

# 🔰Syntax and features

## 📢 Basic input and output

- **schreiben** _value_
  - Prints the value of the given expression to the console.

- **neuezeile**
  - Prints a newline character to the console.
 
- **aufklaren**
  - Clears the console.
 
- **eingangspfad** _filepath_
  - Opens the file at the given path. After it is opened, you can read values from the file using ```eingang```. 

- **eingang** _variable_
  - Reads a value from the file opened with ```eingangspfad``` and stores it in the given variable.

- Example:
```dart
  eingangspfad "input.txt";   // set the input path
  ganzzahl a;                 // declaration of an integer
  eingang a;                  // read the value
  schreiben a*a;              // prints the value of a*a
```

## 💯 Types and variables

- **ganzzahl** - integer
  
- **flieskommazahl** - floating point number

- **schnur** - string

- **zweiteilig** - boolean
  - The value of a ```zweiteilig``` variable is either ```richtig``` or ```falsch``` (true or false).
 
- Declaring a variable:
  ```dart
    // type name;
    flieskommazahl myVariable;
  ```

- You can also initialize a variable when declaring it:
  ```dart
    // type name = value;
    zweiteilig myVariable = richtig;
  ```

## ↔️ If statement

- Executes the code if the condition is true.

- Usage: 
```dart
  wenn condition:
    code,
```

- Example: 
```dart
  // print the value of a if it is not 0
  ganzzahl a = 5;
  wenn a ist nicht 0:
    schreiben a,
```

## ➿ While loop

- Executes the code until the condition becomes false.

- Usage: 
```dart
  solange condition:
    code,
```

- Example: 
```dart
  // prints all integers from 1 to n
  ganzzahl i = 1;
  ganzzahl n = 10;
  solange i < n + 1:
    schreiben i,
    neuezeile,
    i = i + 1,
```

## ➕ Operators

- _value1_ **ist** _value2_
  - Returns ```richtig``` if the two values are equal, ```falsch``` otherwise.
 
- _value1_ **ist nicht** _value2_
  - Returns ```richtig``` if the two values are not equal, ```falsch``` otherwise.

- The ```=```, ```+```, ```-```, ```*```, ```/```, ```%```, ```>```, ```<``` operators work as expected.

## ⛔ Finishing execution

- **schlafen** 
  - Finishes execution of the program.

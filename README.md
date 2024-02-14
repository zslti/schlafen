# ⚡What is Schlafen?

Schlafen is an esoteric programming language interpreter. Download it for Windows <a href="https://github.com/zslti/schlafen/files/14279458/schlafen.zip"><kbd>here</kbd></a>.

The fundamental concept of this project was creating a language utilizing German words as its keywords.

Schlafen contains a basic text editor as well as the interpreter for the language.

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

# 🚀Code examples
tbd

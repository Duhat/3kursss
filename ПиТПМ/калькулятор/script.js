document.addEventListener('DOMContentLoaded', () => {
  const screen = document.querySelector('.screen p');
  const buttons = document.querySelectorAll('.btn');
  let currentInput = '0';
  let operation = null;
  let previousInput = '';

  buttons.forEach(button => {
      button.addEventListener('click', () => {
          const value = button.textContent;

          if (value === 'ac') {
              clear();
          } else if (value === '+/-') {
              toggleSign();
          } else if (value === '=') {
              calculate();
          } else if (isOperator(value)) {
              setOperation(value);
            
          } else {
              appendNumber(value);
          }
      });
  });

  function clear() {
      currentInput = '0';
      previousInput = '';
      operation = null;
      updateScreen();
  }

  function abs() {
    if (currentInput < '0') {
      currentInput = (parseFloat(currentInput) * -1).toString();
    }
    else {
      currentInput = (parseFloat(currentInput) * 1).toString();
    }
      updateScreen();
  }
  


  function toggleSign() {
      if (currentInput !== '0') {
          currentInput = (parseFloat(currentInput) * -1).toString();
          updateScreen();
      }
  }

  function isOperator(value) {
      return value === '+' || value === '-' || value === 'x' || value === '/';
  }

  function setOperation(op) {
      if (currentInput === '') return;
      if (previousInput !== '') {
          calculate();
      }
      operation = op;
      previousInput = currentInput;
      currentInput = '';
  }

  function appendNumber(number) {
      if (currentInput.length < 10) { // Limiting input to 10 characters  верни потом 10!!!!!
          if (currentInput === '0' && number !== '.') {
              currentInput = number;
          } else {
              currentInput += number;
          }
          updateScreen();
      }
  }

  function calculate() {
      let computation;
      const prev = parseFloat(previousInput);
      const current = parseFloat(currentInput);

      if (isNaN(prev) || isNaN(current)) return;

      switch (operation) {
          case '+':
            // if (prev === 2 && current === 2)
            //   computation = 5;
            
              computation = prev + current;
              break;
          case '-':
              computation = prev - current;
              break;
          case 'x':
              computation = prev * current;
              break;
          case '/':
             if (current === 0) {
                 var Error = 'Error: Division by zero';
                 currentInput = Error;
                 return;
             } else
              computation = prev / current;
              break;
          default:
              return;
      }

      currentInput = computation.toString();
      operation = null;
      previousInput = '';
      updateScreen();
  }

  function updateScreen() {
      screen.textContent = currentInput;
  }
});

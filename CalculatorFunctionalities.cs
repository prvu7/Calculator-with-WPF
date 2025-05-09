using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF
{
    public class CalculatorFunctionalities : INotifyPropertyChanged
    {
        private string _currentDigit = "0";
        private double _firstNumber = 0;
        private string _operator = "";
        private bool _isNewEntry = true;
        private string _resultText = "";
        private string _copiedText = "";
        private string _pasteText = "";

        public string CurrentDigit
        {
            get { return _currentDigit; }
            set
            {
                _currentDigit = value;
                OnPropertyChanged(nameof(CurrentDigit));
            }
            
        }

        public string ResultText
        {
            get { return _resultText; }
            set
            {
                _resultText = value;
                OnPropertyChanged(nameof(ResultText));
            }
        }

        public void AppendNumber(string number)
        {
            if (CurrentDigit == "0" || _isNewEntry)
            {
                CurrentDigit = number;
                _isNewEntry = false;
            }
            else
            {
                CurrentDigit += number; 
            }
        }

        private void CalculateIntermediateResult(double secondNumber)
        {
            double result = 0;

            switch (_operator)
            {
                case "+":
                    result = _firstNumber + secondNumber;
                    break;
                case "-":
                    result = _firstNumber - secondNumber;
                    break;
                case "\u00D7": 
                    result = _firstNumber * secondNumber;
                    break;
                case "\u00F7": 
                    result = _firstNumber / secondNumber;
                    break;
            }

            _firstNumber = result;  
            CurrentDigit = result.ToString();  
            ResultText = _firstNumber + " " + _operator;  
        }


        public void SetOperator(string op)
        {
            double currentNumber = double.Parse(CurrentDigit);  

            if (_operator != "")  
            {
                CalculateIntermediateResult(currentNumber);  
            }
            else
            {
                _firstNumber = currentNumber;  
            }

            _operator = op; 
            _isNewEntry = true;  
            ResultText = _firstNumber + " " + _operator; 
        }


        public void CalculateResult()
        {
            double secondNumber = double.Parse(CurrentDigit);
            double result = 0;

            switch (_operator)
            {
                case "+": 
                    result = _firstNumber + secondNumber; 
                    break;
                case "-": 
                    result = _firstNumber - secondNumber; 
                    break;
                case "\u00D7": 
                    result = _firstNumber * secondNumber; 
                    break;
                case "\u00F7":
                    result = _firstNumber / secondNumber; 
                    break;
            }

            CurrentDigit = result.ToString();
            ResultText = _firstNumber + " " + _operator + " " + secondNumber + " =";
            _firstNumber = result;
            _isNewEntry = true;
            _operator = "";
        }

        public void Clear()
        {
            CurrentDigit = "0";
            _firstNumber = 0;
            _operator = "";
            _isNewEntry = false;
            ResultText = "";
        }
        public void Square()
        {
            if (double.TryParse(CurrentDigit, out double number))
            {
                CurrentDigit = (number * number).ToString();
            }
            _isNewEntry = true;
        }

        public void Radical()
        {
            if (double.TryParse(CurrentDigit, out double number))
            {
                if (number < 0)
                {
                    CurrentDigit = "Error";  
                }
                else
                {
                    double result = Math.Sqrt(number);  
                    CurrentDigit = result.ToString();
                }
            }
            else
            {
                CurrentDigit = "Error";  
            }
            _isNewEntry = true;
        }

        public void Reciprocal()
        {
            if (double.TryParse(CurrentDigit, out double number) && number != 0)
            {
                CurrentDigit = (1 / number).ToString();
            }
            else
            {
                CurrentDigit = "Error"; 
            }
            _isNewEntry = true;
        }

        public void AddDecimalPoint()
        {
            if (_isNewEntry)
            {
                CurrentDigit = "0.";  
                _isNewEntry = false;
            }
            else if (!CurrentDigit.Contains("."))
            {
                CurrentDigit += ".";  
            }
        }

        public void DeleteLastCharacter() 
        {
            if (!string.IsNullOrEmpty(CurrentDigit) && CurrentDigit.Length > 1)
            {
                CurrentDigit = CurrentDigit.Substring(0, CurrentDigit.Length - 1);
            }
            else
            {
                CurrentDigit = "0";
            }
        }

        public void DeleteLastNumber() 
        { 
            CurrentDigit = "0";
            _isNewEntry = true;
        }

        public void Negate() 
        {
            if (double.TryParse(CurrentDigit, out double number))
            {
                if (number != 0)  
                {
                    number = -number;
                    CurrentDigit = number.ToString();
                }
            }
        }

        public void Percentage()
        {
            if (_firstNumber != 0 && CurrentDigit != "0")
            {
                double secondNumber = double.Parse(CurrentDigit);
                double procent = secondNumber / 100;
                CurrentDigit = procent.ToString();
            }
        }

        public void CopyFunction()
        {
            _copiedText = CurrentDigit;
        }

        public void PasteFunction()
        {
            CurrentDigit = _copiedText;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

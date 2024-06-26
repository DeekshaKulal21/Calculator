/********************************************************************************************
 * Project Name - Calculator
 * Description  - Subtraction operation
 *  
 **************
 * Version Log
 **************
 * Version       Date           Modified By          Remarks          
 *********************************************************************************************
 *0 .0.0        26-Jul-2024     Deeksha Kulal        Created.
 **********************************************************************************************/
namespace Calculator
{
    /// <summary>
    /// SubtractOperation
    /// </summary>
    internal class SubtractOperation : ICalculatorOperation
    {
        public double Calculate(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
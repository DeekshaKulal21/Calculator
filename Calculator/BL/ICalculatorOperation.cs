/********************************************************************************************
 * Project Name - Calculator
 * Description  - Calculator operation Interface
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
    /// ICalculatorOperation
    /// </summary>
    public interface ICalculatorOperation
    {
        double Calculate(double num1, double num2);
    }
}

/********************************************************************************************
 * Project Name - Calculator
 * Description  - Division operation
 *  
 **************
 * Version Log
 **************
 * Version       Date           Modified By          Remarks          
 *********************************************************************************************
 *0 .0.0        26-Jul-2024     Deeksha Kulal        Created.
 **********************************************************************************************/
 using System;
namespace Calculator
{
    /// <summary>
    /// DivideOperation
    /// </summary>
    internal class DivideOperation : ICalculatorOperation
    {
        private static readonly Logger.Logging log = new Logger.Logging(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public double Calculate(double num1, double num2)
        {
            log.Debug("Begin: Calculate for Divide operation");
            double result = num1 / num2;
            ValidateResult(result);
            log.Debug("End: Calculate for Divide operation");
            return result;
        }

        /// <summary>
        /// Validate Divide by Zero Error
        /// </summary>
        /// <param name="result"></param>
        public void ValidateResult(double result)
        {
            log.Debug("Begin: ValidateResult for Divide operation");
            if (double.IsInfinity(result) || double.IsNaN(result))
            {
                log.Error("Division by zero resulted in an invalid value.");
                throw new DivideByZeroException("Division by zero resulted in an invalid value.");
            }
            log.Debug("Begin: ValidateResult for Divide operation");
        }
    }
}
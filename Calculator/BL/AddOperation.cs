/********************************************************************************************
 * Project Name - Calculator
 * Description  - Addition operation
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
    /// Add Operation
    /// </summary>
    internal class AddOperation : ICalculatorOperation
    {
        private static readonly Logger.Logging log = new Logger.Logging(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Calculate
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public double Calculate(double num1, double num2)
        {
            log.Debug("Begin: Calculate for Add operation");
            double result = num1 + num2;
            log.Debug("End: Calculate for Add operation");
            return result;
        }
    }
}
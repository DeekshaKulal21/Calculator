/********************************************************************************************
 * Project Name - Calculator
 * Description  - Factory class for the Calculator
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
    /// Factory class for creating operations
    /// </summary>
    public class OperationFactory
    {
        public ICalculatorOperation GetOperation(CalculatorOperations operation, CalculatorMode mode)
        {
            switch (mode)
            {
                case CalculatorMode.Standard:
                    return GetStandardOperation(operation);
                case CalculatorMode.Scientific:
                    return GetScientificOperation(operation);
                default:
                    throw new NotSupportedException("Calculator mode not supported");
            }
        } 

        /// <summary>
        /// Get Standard Operation
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        private ICalculatorOperation GetStandardOperation(CalculatorOperations operation)
        {
            switch (operation)
            {
                case CalculatorOperations.Add:
                    return new AddOperation();
                case CalculatorOperations.Multiply:
                    return new MultiplyOperation();
                case CalculatorOperations.Subtract:
                    return new SubtractOperation();
                case CalculatorOperations.Divide:
                    return new DivideOperation();
                default:
                    throw new NotSupportedException("Operation not supported in simple mode");
            }
        }

        /// <summary>
        /// GetScientificOperation
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        private ICalculatorOperation GetScientificOperation(CalculatorOperations operation)
        {
            switch (operation)
            {
                case CalculatorOperations.Add:
                    return new AddOperation();
                case CalculatorOperations.Multiply:
                    return new MultiplyOperation();
                case CalculatorOperations.Subtract:
                    return new SubtractOperation();
                case CalculatorOperations.Divide:
                    return new DivideOperation();
                case CalculatorOperations.Sin:
                    return new SinOperation();
                case CalculatorOperations.Cos:
                    return new CosOperation();
                case CalculatorOperations.Tan:
                    return new TanOperation();
                // Add more scientific operations as needed
                default:
                    throw new NotSupportedException("Operation not supported in scientific mode");
            }
        }
    }
}

/********************************************************************************************
 * Project Name - Calculator
 * Description  - Enums for Calculator
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
    /// CalculatorOperations
    /// </summary>
    public enum CalculatorOperations
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// Add
        /// </summary>
        Add,
        /// <summary>
        /// Subtract
        /// </summary>
        Subtract,
        /// <summary>
        /// Multiply
        /// </summary>
        Multiply,
        /// <summary>
        /// Divide
        /// </summary>
        Divide,
        /// <summary>
        /// Sin
        /// </summary>
        Sin,
        /// <summary>
        /// Cos
        /// </summary>
        Cos,
        /// <summary>
        /// Tan
        /// </summary>
        Tan
    }

    /// <summary>
    ///  Enum to define calculator modes
    /// </summary>
    public enum CalculatorMode
    {
        /// <summary>
        /// Standard calculator Mode
        /// </summary>
        Standard,
        /// <summary>
        /// Scientific calculator Mode
        /// </summary>
        Scientific
    }
}

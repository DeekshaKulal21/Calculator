/********************************************************************************************
 * Project Name - Calculator
 * Description  - Observable Interface for calculator UI
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
    /// IObserver
    /// </summary>
    public interface IObserver
    {
        void Update(double value);
    }
}

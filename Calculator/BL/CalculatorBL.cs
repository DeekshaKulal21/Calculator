/********************************************************************************************
 * Project Name - Calculator
 * Description  - Buisiness logic for Calculator operations
 *  
 **************
 * Version Log
 **************
 * Version       Date           Modified By          Remarks          
 *********************************************************************************************
 *0 .0.0        26-Jul-2024     Deeksha Kulal        Created.
 **********************************************************************************************/
using System.Collections.Generic;

namespace Calculator
{
    /// <summary>
    /// CalculatorBL
    /// </summary>
    public class CalculatorBL : IObservable
    {
        private static readonly Logger.Logging log = new Logger.Logging(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private OperationFactory factory = new OperationFactory();
        private CalculatorMode mode;
        private readonly List<IObserver> observers = new List<IObserver>();
        private double result;

        /// <summary>
        /// CalculatorBL
        /// </summary>
        /// <param name="mode"></param>
        public CalculatorBL(CalculatorMode mode)
        {
            log.Info("Begin : CalculatorBL constructor Invoke");
            this.mode = mode;
            log.Info("End : CalculatorBL constructor Invoke");
        }

        /// <summary>
        /// PerformCalculation
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="operand1"></param>
        /// <param name="operand2"></param>
        /// <returns></returns>
        public double PerformCalculation(CalculatorOperations operation, double operand1, double operand2)
        {
            log.Info("Begin : PerformCalculation Method with operation = " 
                + operation + " ,first number = " + operand1 + " ,second number = " + operand2);
            ICalculatorOperation operationInterface = factory.GetOperation((CalculatorOperations)operation, mode);
            Result = operationInterface.Calculate(operand1, operand2);
            log.Info("End : PerformCalculation Method Return value = " + result);
            return Result;
        }

        /// <summary>
        /// Result Property
        /// </summary>
        public double Result
        {
            get
            {
                return result;
            } 
            set
            {
                result = value;
                NotifyObservers();
            }
        }

        /// <summary>
        /// AddObserver
        /// </summary>
        /// <param name="observer"></param>
        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// RemoveObserver
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// NotifyObservers
        /// </summary>
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(result);
            }
        }
    }
}

/********************************************************************************************
 * Project Name - Calculator
 * Description  - Text Writer for calculator Debug window
 *  
 **************
 * Version Log
 **************
 * Version       Date           Modified By          Remarks          
 *********************************************************************************************
 *0 .0.0        26-Jul-2024     Deeksha Kulal        Created.
 **********************************************************************************************/
 using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// TextBoxStreamWriter
    /// </summary>
    public class TextBoxStreamWriter : TextWriter
    {
        private TextBox textOutput;

        /// <summary>
        /// TextBoxStreamWriter
        /// </summary>
        /// <param name="output"></param>
        public TextBoxStreamWriter(TextBox output)
        {
            textOutput = output;
        }

        /// <summary>
        /// Encoding
        /// </summary>
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="value"></param>
        public override void Write(char value)
        {
            textOutput.AppendText(value.ToString());
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="value"></param>
        public override void Write(string value)
        {
            textOutput.AppendText(value);
        }
    }
}

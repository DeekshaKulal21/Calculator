/********************************************************************************************
 * Project Name - Calculator
 * Description  - Calculator UI 
 *  
 **************
 * Version Log
 **************
 * Version       Date           Modified By          Remarks          
 *********************************************************************************************
 *0 .0.0        26-Jul-2024     Deeksha Kulal        Created.
 **********************************************************************************************/
using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace Calculator
{
    public partial class FrmCalculator : Form ,IObserver
    {
        private static readonly Logger.Logging log = new Logger.Logging(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private CalculatorBL calculatorBL = null;
        private double dblNum1, dblNum2;
        private CalculatorOperations currentoperation;
        private TextWriter writeText;
        private CalculatorMode calculatorMode = CalculatorMode.Standard;
        private ResourceManager resourceManager;

        public FrmCalculator()
        {
            try
            {
                InitializeComponent();
                writeText = new TextBoxStreamWriter(txtLog);
                Console.SetOut(writeText);
                log.Info("Begin: Constructor FrmCalculator");
                calculatorBL = new CalculatorBL(calculatorMode);
                calculatorBL.AddObserver(this);
                InitializeLocalization();
                log.Info(GetTranslatedMessage("End: Constructor FrmCalculator"));
            }
            catch (Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
        }

        private void FrmCalculator_Load(object sender, EventArgs e)
        {
            try
            {
                log.Info("Begin: FrmCalculator_Load");
                txtLog.Visible = false;
                ResetCalculator();
                DisplayFooterMessage("Enter a number");
                log.Info("End: FrmCalculator_Load");
            }
            catch(Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
        }

        private void ResetCalculator()
        {
            log.Info("Begin: ResetCalculator Method");
            dblNum1 = 0;
            dblNum2 = 0;
            calculatorBL.Result = 0;    
            txtNum1.Text = string.Empty;
            txtNum2.Text = string.Empty;
            txtEqual.Text = string.Empty;
            txtOperator.Text = string.Empty;
            txtResult.Text = string.Empty;
            txtFooterMessage.Text = string.Empty;
            log.Info("End: ResetCalculator Method");
        }

        private void btnNumeric_Click(object sender, EventArgs e)
        {
            log.Info("Begin: Number Clicked ");
            try
            {
                txtFooterMessage.Text = string.Empty;
                txtEqual.Text = string.Empty;
                Button btn = (Button)sender;
                txtResult.Text += btn.Text;
                log.Info("Entered Number is = " + txtResult.Text);
            }
            catch(Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
            log.Info("End: Number Clicked ");
        }

        private void SetOperation(CalculatorOperations operation)
        {
            log.Info("Begin: SetOperation Method for operation " + operation);
            currentoperation = operation;
            if (double.TryParse(txtResult.Text, out dblNum1))
            {
                txtNum1.Text = txtResult.Text;
                txtNum2.Text = string.Empty;
                txtResult.Text = string.Empty;

                switch (operation)
                {
                    case CalculatorOperations.Add:
                        txtOperator.Text = "+";
                        break;
                    case CalculatorOperations.Subtract:
                        txtOperator.Text = "-";
                        break;
                    case CalculatorOperations.Multiply:
                        txtOperator.Text = "X";
                        break;
                    case CalculatorOperations.Divide:
                        txtOperator.Text = "/";
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation");
                }
            }
            else
            {
                DisplayFooterMessage("Enter a number");
            }
            log.Info("End: SetOperation Method for operation " + operation);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("Begin: Add button Clicked");
                SetOperation(CalculatorOperations.Add);
                log.Info("End: Add button Clicked");
            }
            catch(Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("Begin: Subtract button Clicked");
                SetOperation(CalculatorOperations.Subtract);
                log.Info("End: Multiply button Clicked");
            }
            catch(Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
        }

        private void btnMultiplicate_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("Begin: Multiply button Clicked");
                SetOperation(CalculatorOperations.Multiply);
                log.Info("End: Multiply button Clicked");
            }
            catch(Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
        }

        private void DisplayFooterMessage(string message)
        {
            log.Debug(GetTranslatedMessage("Begin : DisplayErrorMessage"));
            message = GetTranslatedMessage(message);
            txtFooterMessage.Text = message;
            log.Error(message);
            log.Debug(GetTranslatedMessage("End : DisplayErrorMessage"));
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            log.Info(GetTranslatedMessage("Begin: Divide button Clicked"));
            SetOperation(CalculatorOperations.Divide);
            log.Info(GetTranslatedMessage("End: Divide button Clicked"));
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            log.Info(GetTranslatedMessage("Begin: Enter button Clicked"));
            try
            {
                if (double.TryParse(txtResult.Text, out dblNum2))
                {
                    txtEqual.Text = "=";
                    txtNum2.Text = txtResult.Text;
                    calculatorBL.PerformCalculation(currentoperation, dblNum1, dblNum2).ToString();
                    log.Info(GetTranslatedMessage("calculatorState.Result for first number = "
                        + calculatorBL.Result));
                }
                else
                {
                    DisplayFooterMessage("Enter a number"); 
                }
            }
            catch(Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
            log.Info("End: Enter button Clicked");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            log.Info(GetTranslatedMessage("Begin: Clear button Clicked"));
            try
            {
                ResetCalculator();
            }
            catch(Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
            log.Info(GetTranslatedMessage("End: Clear button Clicked"));
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            try
            {
                log.Debug(GetTranslatedMessage("Begin: txtResult_TextChanged Event"));
                ValidateDecimalInput(txtResult);
                log.Debug(GetTranslatedMessage("End: txtResult_TextChanged Event"));
            }
            catch(Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
        }

        private void ValidateDecimalInput(TextBox textBox)
        {
            log.Debug(GetTranslatedMessage("Begin: ValidateDecimalInput"));
            string text = textBox.Text;
            if (double.TryParse(text, out double result))
            {
                if (text.Contains("."))
                {
                    int decimalPlaces = text.Split('.')[1].Length;
                    if (decimalPlaces > 5)
                    {
                        // If more than 5 decimal places, truncate
                        log.Info(GetTranslatedMessage("Entered number decimal point is more than 5 digits hence truncating."));
                        textBox.Text = result.ToString("F5", CultureInfo.InvariantCulture);
                        textBox.SelectionStart = textBox.Text.Length; // Move cursor to the end
                        log.Info(GetTranslatedMessage("Result after truncating: " + textBox.Text));
                    }
                }
            }
            log.Debug(GetTranslatedMessage("End: ValidateDecimalInput"));
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(GetTranslatedMessage("Pending Implementation"));
                log.Error(GetTranslatedMessage("Pending Implementation"));
                throw new NotImplementedException("Pending Implementation");
            }
            catch(Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
        }

        private void FrmCalculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.Info(GetTranslatedMessage("Begin: FrmCalculator_FormClosing"));
            calculatorBL.RemoveObserver(this);
            log.Info("End: FrmCalculator_FormClosing");
        }

        private void btnShowlog_Click(object sender, EventArgs e)
        {
            log.Info(GetTranslatedMessage("Begin: btnShowlog_Click"));
            try
            {
                txtLog.Visible = !txtLog.Visible;
                AdjustFormSize();
            }
            catch(Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
            log.Info(GetTranslatedMessage("End: btnShowlog_Click"));
        }

        private void AdjustFormSize()
        {
            log.Info(GetTranslatedMessage("Begin: Adjust form size"));
            // Adjust form size based on log TextBox visibility
            if (txtLog.Visible)
            {
                btnShowlog.Text = GetTranslatedMessage("Hide Debug Log");
                this.Size = new System.Drawing.Size(981, 681); // Adjust size accordingly
            }
            else
            {
                btnShowlog.Text = GetTranslatedMessage("Display Debug Log"); 
                this.Size = new System.Drawing.Size(590, 681); // Adjust size accordingly
            }
            log.Info(GetTranslatedMessage("End: Adjust form size"));
        }

        private void tblOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tblOptions.SelectedTab == tblOptions.TabPages["Standard"])//your specific tabname
                {
                    calculatorMode = CalculatorMode.Standard;
                }
                else if (tblOptions.SelectedTab == tblOptions.TabPages["Standard"])//your specific tabname
                {
                    calculatorMode = CalculatorMode.Scientific;
                }
            }
            catch (Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
        }

        private void InitializeLocalization()
        {

            log.Info("Begin: InitializeLocalization");

            cmbLanguage.Items.Add(new CultureInfo("en-US"));
            cmbLanguage.Items.Add(new CultureInfo("ja-JP"));

            // Set default language to English (United States)
            cmbLanguage.SelectedItem = new CultureInfo("en-US");

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cmbLanguage.SelectedItem.ToString());
            resourceManager = new ResourceManager("Calculator.Messages", typeof(FrmCalculator).Assembly);
            UpdateUIMessagesOnLangSelection();
            log.Info(GetTranslatedMessage("Begin: InitializeLocalization"));
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                log.Debug("Begin: combo box selected index changed");
                txtFooterMessage.Text = string.Empty;
                if (cmbLanguage.SelectedItem is CultureInfo selectedCulture)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedCulture.Name);
                    resourceManager = new ResourceManager("Calculator.Messages", typeof(FrmCalculator).Assembly);
                    UpdateUIMessagesOnLangSelection();
                }
            }
            catch (Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
            log.Debug(GetTranslatedMessage("End: combo box selected index changed"));
        }

        public string GetTranslatedMessage(string message)
        {
            string translatedMessage = resourceManager.GetString(message, CultureInfo.CurrentUICulture) != null
                            ? resourceManager.GetString(message, CultureInfo.CurrentUICulture) : message;
            return translatedMessage;
        }

        private void UpdateUIMessagesOnLangSelection()
        {
            log.Debug(GetTranslatedMessage("Begin: UpdateUIMessagesOnLangSelection"));
            tabPage1.Text = GetTranslatedMessage("Standard");
            tabPage2.Text = GetTranslatedMessage("Scientific");
            btnClear.Text = GetTranslatedMessage("Clear");
            lblPending.Text = GetTranslatedMessage("Pending Implementation"); 
            if (txtLog.Visible)
            {
                btnShowlog.Text = GetTranslatedMessage("Hide Debug Log");
            }
            else
            {
                btnShowlog.Text = GetTranslatedMessage("Display Debug Log");
            }
            log.Debug(GetTranslatedMessage("End: UpdateUIMessagesOnLangSelection"));
        }

        public void Update(double result)
        {
            try
            {
                log.Debug(GetTranslatedMessage("Begin: Update method called"));
                txtResult.Text = result.ToString();
                log.Debug("Updated result value: " + result);
                log.Debug(GetTranslatedMessage("End: Update method called"));
            }
            catch(Exception ex)
            {
                DisplayFooterMessage(ex.Message);
            }
        }
    }
}

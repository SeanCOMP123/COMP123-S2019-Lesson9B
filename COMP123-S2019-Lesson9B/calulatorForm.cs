using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_Lesson9B
{

    public partial class CalulatorForm : Form
    {
        public string outputString { get; set; }
        public bool decimalExists { get; set; }
        public float outputValue { get; set; }
        public CalulatorForm()
        {
            InitializeComponent();
            
        }
        
        /// <summary>
        /// This is the shared event handler for all the calculator buttons-click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalulatorButton_Click(object sender, EventArgs e)
        {
            var TheButton = sender as Button;
            var tag = TheButton.Tag.ToString();
            int buttonValue;
            bool resultCondition = int.TryParse(tag,out buttonValue);
            //if the user pressed a numbe button
            if (resultCondition)
            {
                int maxSize = 3;
                if (decimalExists)
                {
                    maxSize = 5;
                }
                if ((outputString != "0")&& (ResultLabel.Text.Count() < maxSize))
                {
                    outputString += tag;
                    ResultLabel.Text = outputString;
                }
            }
            //if the user pressed a button that is not a number
            if (!resultCondition)
            {
                switch (tag)
                {
                    case "clear":
                        clearNumbericKeyboard();
                        break;
                    case "back":
                        removeLastCharacterFromResultLabel();
                        break;
                    case "done":
                        finalizedOutput();
                        break;
                    case "decimal":
                        addDecimalToResutlLabel();
                        break;


                }
            }
        }
        /// <summary>
        /// This method add a decimal to ResultLabel
        /// </summary>
        private void addDecimalToResutlLabel()
        {
            if (!decimalExists)
            {
                if (ResultLabel.Text == "0")
                {
                    outputString += "0";

                }
                outputString += ".";
                decimalExists = true;
            }
        }
        /// <summary>
        /// This method finalized the calculation for a label
        /// </summary>
        private void finalizedOutput()
        {
            if (outputString == string.Empty)
            {
                outputString = "0";
            }

            outputValue = float.Parse(outputString);
            HeightLabel.Text = outputValue.ToString();
            clearNumbericKeyboard();
            outputValue = 0.0f;
            CalculatorButtontableLayoutPanel.Visible = false;
        }

        /// <summary>
        /// This method removes the last character from the ResultLabel
        /// </summary>
        private void removeLastCharacterFromResultLabel()
        {
            if (outputString.Length > 0)
            {
                var lastChar = outputString.Substring(outputString.Length - 1);
                if (lastChar == ".")
                {
                    decimalExists = false;

                }
                outputString = outputString.Remove(outputString.Length - 1);

                if (outputString.Length == 0)
                {
                    outputString = "0";
                }
                ResultLabel.Text = outputString;
            }
        }

        /// <summary>
        /// This method clears the numeric keyboard
        /// </summary>
        private void clearNumbericKeyboard()
        {
            ResultLabel.Text = "0";
            outputString = string.Empty;
            decimalExists = false;
          
        }
        /// <summary>
        /// This is the event handler for the heightLabel Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeightLabel_Click(object sender, EventArgs e)
        {
            CalculatorButtontableLayoutPanel.Visible = true;
        }

        private void CalulatorForm_Load(object sender, EventArgs e)
        {
            clearNumbericKeyboard();
        }
    }
}

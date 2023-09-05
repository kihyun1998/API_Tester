using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Tester
{
    public static class CustomMessageBox
    {
        public static System.Windows.Forms.DialogResult ShowMessage(string message, string caption, System.Windows.Forms.MessageBoxButtons button, System.Windows.Forms.MessageBoxIcon icon)
        {
            System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.DialogResult.None;
            switch (button)
            {
                case System.Windows.Forms.MessageBoxButtons.OK:
                    using (OKMessageBox customMBox = new OKMessageBox())
                    {
                        customMBox.Text = caption;
                        customMBox.Message = message;
                        switch (icon)
                        {
                            case System.Windows.Forms.MessageBoxIcon.Information:
                                customMBox.MessageIcon = API_Tester.Properties.Resources.info_blue;
                                break;
                            case System.Windows.Forms.MessageBoxIcon.Question:
                                customMBox.MessageIcon = API_Tester.Properties.Resources.question_sky;
                                break;
                            case System.Windows.Forms.MessageBoxIcon.Warning:
                                customMBox.MessageIcon = API_Tester.Properties.Resources.error;
                                break;
                        }
                        dialogResult = customMBox.ShowDialog();
                    }
                    break;
                case System.Windows.Forms.MessageBoxButtons.YesNo:
                    using (YesOrNoMessageBox customYoNBox = new YesOrNoMessageBox())
                    {
                        customYoNBox.Text = caption;
                        customYoNBox.Message = message;
                        switch (icon)
                        {
                            case System.Windows.Forms.MessageBoxIcon.Information:
                                customYoNBox.MessageIcon = API_Tester.Properties.Resources.info_blue;
                                break;
                            case System.Windows.Forms.MessageBoxIcon.Question:
                                customYoNBox.MessageIcon = API_Tester.Properties.Resources.question_sky;
                                break;
                            case System.Windows.Forms.MessageBoxIcon.Warning:
                                customYoNBox.MessageIcon = API_Tester.Properties.Resources.error;
                                break;
                        }
                        dialogResult = customYoNBox.ShowDialog();
                    }
                    break;
            }
            return dialogResult;
        }
    }
}

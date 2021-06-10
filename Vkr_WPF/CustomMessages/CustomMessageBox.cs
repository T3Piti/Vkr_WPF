using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Vkr_WPF.CustomMessages
{
    public class CustomMessageBox
    {
        public void ShowMessage(string message, string header, string type)
        {
            switch (type)
            {
                case "information":
                    Message(message, header, MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case "error":
                    Message(message, header, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        private void Message(string message, string header, MessageBoxButton buttons, MessageBoxImage img)
        {
            MessageBox.Show(message, header, buttons, img);
        }
    }
}

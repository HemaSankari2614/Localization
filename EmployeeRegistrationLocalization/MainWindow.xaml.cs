using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Localization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

            private void LanguageComboBox_SelectionChanged(
                object sender, SelectionChangedEventArgs e)
            {
                if (NameLabel == null)
                    return;

                bool isTamil = LanguageComboBox.SelectedIndex == 1;

                if (isTamil)
                {
                    NameLabel.Text = "பணியாளர் பெயர்";
                    EmailLabel.Text = "மின்னஞ்சல் முகவரி";
                    DepartmentLabel.Text = "துறை";
                    GenderLabel.Text = "பாலினம்";
                    DobLabel.Text = "பிறந்த தேதி";

                    RegisterButton.Content = "பதிவு செய்";
                    ResetButton.Content = "மீட்டமை";
                }
                else
                {
                    NameLabel.Text = "Employee Name";
                    EmailLabel.Text = "Email Address";
                    DepartmentLabel.Text = "Department";
                    GenderLabel.Text = "Gender";
                    DobLabel.Text = "Date of Birth";

                    RegisterButton.Content = "Register";
                    ResetButton.Content = "Reset";
                }
            }

            private void RegisterButton_Click(
                object sender, RoutedEventArgs e)
            {
                bool isTamil = LanguageComboBox.SelectedIndex == 1;

                string name = NameTextBox.Text.Trim();
                string email = EmailTextBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(email) ||
                    DepartmentComboBox.SelectedItem == null ||
                    GenderComboBox.SelectedItem == null ||
                    DobPicker.SelectedDate == null)
                {
                    MessageBox.Show(
                        isTamil
                            ? "அனைத்து விவரங்களையும் நிரப்பவும்."
                            : "Please fill in all fields.",
                        isTamil ? "எச்சரிக்கை" : "Warning",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    return;
                }

                string department =
                    ((ComboBoxItem)DepartmentComboBox.SelectedItem).Content.ToString();

                string gender =
                    ((ComboBoxItem)GenderComboBox.SelectedItem).Content.ToString();

                string dob = DobPicker.SelectedDate.Value.ToString("dd-MM-yyyy");

                string message =
                    (isTamil ? "பணியாளர் பதிவு வெற்றிகரமாக முடிந்தது!\n\n"
                             : "Employee registered successfully!\n\n") +
                    (isTamil ? "பெயர்: " : "Name: ") + name + "\n" +
                    (isTamil ? "மின்னஞ்சல்: " : "Email: ") + email + "\n" +
                    (isTamil ? "துறை: " : "Department: ") + department + "\n" +
                    (isTamil ? "பாலினம்: " : "Gender: ") + gender + "\n" +
                    (isTamil ? "பிறந்த தேதி: " : "Date of Birth: ") + dob;

                MessageBox.Show(
                    message,
                    isTamil ? "பதிவு வெற்றி" : "Registration Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            private void ResetButton_Click(
                object sender, RoutedEventArgs e)
            {
                NameTextBox.Clear();
                EmailTextBox.Clear();
                DepartmentComboBox.SelectedIndex = -1;
                GenderComboBox.SelectedIndex = -1;
                DobPicker.SelectedDate = null;
            }
    }
}


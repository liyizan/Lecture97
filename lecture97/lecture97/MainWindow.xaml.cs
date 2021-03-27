using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lecture97
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ArrayList arraylist;
        
        public MainWindow()
        {
            InitializeComponent();
            AccessData.InitializeDatabase();
            arraylist = new ArrayList();
            
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            AccessData.Adddata(txt_charactername.Text, txt_element.Text, txt_phone.Text);     
            MessageBox.Show("add" +"\n Charecter name "+txt_charactername.Text +"\n element "+ txt_element.Text +"\n your number phone "+ txt_phone.Text );
        }

        private void btn_sHowall_Click(object sender, RoutedEventArgs e)
        {

            string charecterprofile = "";
            foreach(string dAta in AccessData.GetData())
            {
                charecterprofile = charecterprofile +
                    " charecter name " + dAta + "\n";
            }
            MessageBox.Show(charecterprofile);
        }

        
    }
}

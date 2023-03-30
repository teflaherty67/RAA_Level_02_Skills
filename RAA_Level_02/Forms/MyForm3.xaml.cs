using System;
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

namespace RAA_Level_02_Skills.Forms
{
    /// <summary>
    /// Interaction logic for MyForm3.xaml
    /// </summary>
    public partial class MyForm3 : Window
    {
        public MyForm3()
        {
            InitializeComponent();

            lbxTest.Items.Add("abc");

            lbxTest.Items.Add("bcd");

            lbxTest.Items.Add("cde");

            lbxTest.Items.Add("def");

            lbxTest.Items.Add("efg");
        }

        public List<string> GetSelectedItems()
        {
            List<string> returnList = new List<string>();

            foreach (string item in lbxTest.SelectedItems) 
            {
                returnList.Add(item);
            }

            return returnList;
        }
    }
}

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Win32;
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


namespace RAA_Level_02_Skills
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class MyForm2 : Window
    {
        public Document myDoc;
        public MyForm2(string testText, Document doc, List<string> listBoxItems)
        {
            InitializeComponent();

            myDoc = doc;

            lblLabel.Content = testText + doc.PathName;

            foreach(string item in listBoxItems)
            {
                lbxText.Items.Add(item);                
            }

            cmbViews.Items.Add("This is my first combobox item");
            cmbViews.Items.Add("This is my second combobox item");

            cmbViews.SelectedIndex = 0;
        }

        public void DocumentTest()
        {
            FilteredElementCollector collector = new FilteredElementCollector(myDoc);
            collector.OfCategory(BuiltInCategory.OST_Views);
            collector.WhereElementIsNotElementType();

            foreach(View curView in collector)
            {
                lbxText.Items.Add(curView.Name);
                cmbViews.Items.Add(curView.Name);
            }            
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DocumentTest();
        }
    }
}

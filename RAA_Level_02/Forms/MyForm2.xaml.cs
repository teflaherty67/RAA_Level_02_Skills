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
        public MyForm2(string testText, Document doc)
        {
            InitializeComponent()

            myDoc = doc;

            lblLabel.Content = testText + doc.PathName;
        }

        public void DocumentTest()
        {
            FilteredElementCollector collector = new FilteredElementCollector(myDoc);
            collector.OfCategory(BuiltInCategory.OST_Views);

            TaskDialog.Show("Test", "There are " + collector.Count.ToString() + " views in the model.");
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DocumentTest();
        }
    }
}

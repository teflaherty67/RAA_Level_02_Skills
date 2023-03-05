#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

#endregion

namespace RAA_Level_02_Skills
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // step 1: put any code needed for the form here

            // step 2: open form
            MyForm curForm = new MyForm()
            {
                Width = 500,
                Height = 450,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                Topmost = true,
            };

            curForm.ShowDialog();

            // Step 4: get form data and do something

            if(curForm.DialogResult == false)
            {
                return Result.Cancelled;
            }

            // do something

            List<string[]> dataList = new List<string[]>();

            string tbxResult = curForm.tbxFile.Text;

            string[] dataArray = System.IO.File.ReadAllLines(tbxResult);

            foreach( string data in dataArray )
            {
                string[] cellData = data.Split(',');
                dataList.Add(cellData);
            }            

            bool chbCheck1Result = curForm.GetCheckbox1();

            string rbGroup1Result = curForm.GetGroup1();

            TaskDialog.Show("Test", "text box result is " + tbxResult);

            if(chbCheck1Result == true)
            {
                TaskDialog.Show("Test", "Checkbox 1 was selected");
            }

            TaskDialog.Show("Test", rbGroup1Result);

            // go through csv data & do something

            foreach (string[] curArray in dataList)
            {
                string text = curArray[0];
                string number = curArray[1];

                double actualNumber = 0;

                bool convertNumber = double.TryParse(number, out actualNumber);
            }

            return Result.Succeeded;
        }

        public static String GetMethod()
        {
            var method = MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            return method;
        }
    }
}

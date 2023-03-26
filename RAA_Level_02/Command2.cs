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
    public class Command2 : IExternalCommand
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

            List<string> args = new List<string> { "abc", "bcd", "cde", "def" };

            MyForm2 curForm = new MyForm2("", doc, null)
            {
                Width = 500,
                Height = 450,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                Topmost = true,
            };

            curForm.ShowDialog();

            List<Reference> refList = new List<Reference>();
            bool flag = true;

            while (flag == true)
            {
                try
                {
                    Reference curRef = uidoc.Selection.PickObject(ObjectType.Element, "Pick an item");
                    refList.Add(curRef);
                }
                catch (Exception)
                {

                    flag = false;
                }               
            }

            string cmbString = "There are " + refList.Count.ToString() + " selected elements";
            List<string> lbxString = curForm.GetSelectedListBoxItems();

            MyForm2 curForm2 = new MyForm2(cmbString, doc, lbxString)
            {
                Width = 500,
                Height = 450,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                Topmost = true,
            };

            curForm2.ShowDialog();

            string cmbString2 = curForm2.GetSelectedComboBoxItem();
            List<string> lbxString2 = curForm2.GetSelectedListBoxItems();

            return Result.Succeeded;
        }

        public static String GetMethod()
        {
            var method = MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            return method;
        }

    }
}

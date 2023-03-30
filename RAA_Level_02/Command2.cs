#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RAA_Level_02_Skills.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;

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

            Units curUnits = doc.GetUnits();
            FormatOptions curFormatOptions = curUnits.GetFormatOptions(SpecTypeId.Length);
            ForgeTypeId typeId = curFormatOptions.GetUnitTypeId();

            if (typeId == UnitTypeId.Meters)
                TaskDialog.Show("Units", "The current model is metric.");
            else if (typeId == UnitTypeId.Millimeters)
                TaskDialog.Show("Units", "The current model is metric.");
            else if (typeId == UnitTypeId.Feet)
                TaskDialog.Show("Units", "The current model is imperial.");
            else if (typeId == UnitTypeId.Inches)
                TaskDialog.Show("Units", "The current model is imperial.");
            else if (typeId == UnitTypeId.FeetFractionalInches)
                TaskDialog.Show("Units", "The current model is imperial.");
            else
            {
                TaskDialog.Show("Units", "The current model is something else.");
            }


            // step 1: put any code needed for the form here

            // step 2: open form

            //List<string> args = new List<string> { "abc", "bcd", "cde", "def" };

            //MyForm2 curForm = new MyForm2("", doc, null)
            //{
            //    Width = 500,
            //    Height = 450,
            //    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
            //    Topmost = true,
            //};

            //curForm.ShowDialog();

            //List<Reference> refList = new List<Reference>();
            ////bool flag = true;

            //try
            //{
            //    refList = uidoc.Selection.PickObjects(ObjectType.Element, "Pick some items.").ToList<Reference>();
            //}
            //catch (Exception)
            //{

            //}

            //List<Viewport> viewportList = new List<Viewport>();

            //foreach(Reference curRef in refList)
            //{
            //    Element curElem = doc.GetElement(curRef);

            //    if(curElem is Viewport)
            //    {
            //        Viewport curVP = curElem as Viewport;
            //        viewportList.Add(curVP);
            //    }                
            //}

            //while (flag == true)
            //{
            //    try
            //    {
            //        Reference curRef = uidoc.Selection.PickObject(ObjectType.Element, "Pick an item. Click 'Esc' when finished.");
            //        refList.Add(curRef);
            //    }
            //    catch (Exception)
            //    {

            //        flag = false;
            //    }
            //}

            //string cmbString = "There are " + refList.Count.ToString() + " selected elements";
            //List<string> lbxString = curForm.GetSelectedListBoxItems();

            Forms.MyForm3 curForm = new Forms.MyForm3()
            {
                Width = 500,
                Height = 450,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                Topmost = true,
            };

            curForm.ShowDialog();

            TaskDialog.Show("Test", "There were " + curForm.GetSelectedItems().Count.ToString() + " items selected");

            //string cmbString2 = curForm2.GetSelectedComboBoxItem();
            //List<string> lbxString2 = curForm2.GetSelectedListBoxItems();
                  
            return Result.Succeeded;
        }       

        public static String GetMethod()
        {
            var method = MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            return method;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace sample28
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;

            app.Workbooks.Add();

            dynamic workSheet = app.ActiveSheet;
            workSheet.Cells[1, "A"] = "Header A";
            workSheet.Cells[1, "B"] = "Header A";

            var row = 1;
            var range = Enumerable.Range(1, 50);
            foreach (var item in range)
            {
                row++;
                workSheet.Cells[row, "A"] = item;
                workSheet.Cells[row, "B"] = item;
            }

            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
        }
    }
}

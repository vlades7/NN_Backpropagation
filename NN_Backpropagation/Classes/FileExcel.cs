using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace NN_Backpropagation.Classes
{
    public static class FileExcel
    {
        static Excel.Application ObjExcel = null;
        static Excel.Workbook ObjWorkBook = null;
        static Excel.Worksheet ObjWorkSheet = null;
        static int FlagExcelApp = 0; // 0 - создаем свое приложение, 1 - присоединяемся к открытому

        public static void Open()
        {
            try
            {
                // Присоединение к открытому приложению Excel (если оно открыто)
                ObjExcel = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
                FlagExcelApp = 1;
            }
            catch
            {
                // Если нет, то создаём новое приложение
                ObjExcel = new Excel.Application(); // Запуск приложение
            }
            // Открываем книгу  
            ObjWorkBook = ObjExcel.Workbooks.Open(Const.FilePath, 0, true, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            // Выбираем таблицу(лист)
            ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
        }

        public static void Close()
        {
            // Если же мы присоединялись, то закрываем рабочую книгу, по поводу параметров
            if (ObjWorkBook != null)
            {
                ObjWorkBook.Close(false, false, false);
            }
            if (FlagExcelApp == 0)
            {
                if (ObjExcel != null)
                {
                    ObjExcel.Quit();
                }
                ObjExcel = null;
                ObjWorkBook = null;
                ObjWorkSheet = null;
                Process[] processes = Process.GetProcessesByName("EXCEL");
                foreach (Process proc in processes)
                {
                    proc.Kill();
                }
            }
        }

        public static List<string> ReadRow(int index)
        {
            Excel.Range usedRows = ObjWorkSheet.UsedRange.Rows[index];
            Array myRow = (Array)usedRows.Cells.Value2;
            usedRows = null;
            return myRow.OfType<object>().Select(o => o.ToString()).ToList();
        }

        public static List<string> ReadColumn(int index)
        {
            Excel.Range usedColumns = ObjWorkSheet.UsedRange.Columns[index];
            Array myColumn = (Array)usedColumns.Cells.Value2;
            usedColumns = null;
            return myColumn.OfType<object>().Select(o => o.ToString()).ToList();
        }

        public static List<List<string>> ReadFile()
        {
            List<List<string>> data = new List<List<string>>();
            for (int i = 0; i < ObjWorkSheet.UsedRange.Rows.Count; i++)
            {
                data.Add(ReadRow(i + 1));
            }
            return data;
        }
    }
}

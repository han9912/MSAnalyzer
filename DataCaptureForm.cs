using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace LogDataCapture
{
    public partial class DataCaptureForm : Form
    {
        string logRootDir = "";
        Thread thdCapture;
        DataTable mdt = null;
        string templatePath = Path.Combine(Application.StartupPath, "template.xlsx");
        readonly string reportPath = Path.Combine(Application.StartupPath, "Report");
        public DataCaptureForm()
        {
            InitializeComponent();
        }
        private void DataCaptureForm_Load(object sender, EventArgs e)
        {
            Version ver = new Version(Application.ProductVersion);
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0);
            dt = dt.AddDays(ver.Build).AddSeconds(ver.Revision * 2);
            this.Text += $" V{ver.Major}.{dt:y.Mdd.Hmm}";

        }
        private void Btn_SelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog() { Description = "请选择Log根目录文件夹", };
            if (dialog.ShowDialog() == DialogResult.OK)tb_FolderDir.Text = dialog.SelectedPath;
            Console.WriteLine(dialog.SelectedPath);
        }
        private void Tb_FolderDir_TextChanged(object sender, EventArgs e)
        {
            logRootDir = tb_FolderDir.Text;
            mdt = null;
        }

        private void Btn_ClearLog_Click(object sender, EventArgs e)
        {
            lsb_Msg.Items.Clear();
        }
        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Tb_TemplatePath_TextChanged(object sender, EventArgs e)
        {
            tb_TemplatePath.Text = templatePath;
            templatePath = tb_TemplatePath.Text;
        }
        private void Btn_SelectTemplate_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog() { Description = "请选择输出模板文件", };
            if (dialog.ShowDialog() == DialogResult.OK) tb_TemplatePath.Text = dialog.SelectedPath;
            Console.WriteLine(dialog.SelectedPath);
        }
        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (logRootDir == "")
            {
                MessageBox.Show(this, "请先选择Log根目录");
                return;
            }
            pn_Control.Enabled = false;
            thdCapture = new Thread(new ThreadStart(ThreadCaptureMethod)) { IsBackground = true };
            thdCapture.Start();
        }

        private void Btn_OpenReportPath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", reportPath);
        }

        private void ShowMsg(string msg)
        {
            try
            {
                string[] lsMsg = msg.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in lsMsg)
                {
                    if (this.InvokeRequired) lsb_Msg.BeginInvoke(new Action(() =>
                    {
                        lsb_Msg.Items.Add(s);
                        lsb_Msg.SelectedIndex = lsb_Msg.Items.Count - 1;
                        lsb_Msg.ClearSelected();
                    }));
                    else
                    {
                        lsb_Msg.Items.Add(s);
                        lsb_Msg.SelectedIndex = lsb_Msg.Items.Count - 1;
                        lsb_Msg.ClearSelected();
                    }
                }

            }
            catch (Exception ex)
            {
                if (this.InvokeRequired) this.BeginInvoke(new Action(() => { MessageBox.Show(this, ex.Message, "ShowMsg"); }));
                else MessageBox.Show(this, ex.Message, "ShowMsg");
            }
        }

        /// <summary>
        /// Generate a workbook of several worksheets, and their names are based on experiments from first report of first SN folder
        /// </summary>
        /// <param name="path">report folder path</param>
        /// <param name="colNum">experiment column number</param>
        /// <param name="startRow">first experiment row</param>
        /// <returns>A Workbook with several worksheets</returns>
        private XLWorkbook GetWorkbook(string path, int colNum = 1, int startRow = 2)
        {
            XLWorkbook wb = new XLWorkbook();
            DirectoryInfo[] dirInfo = new DirectoryInfo(path).GetDirectories();
            foreach (var dir in dirInfo)
            {
                FileInfo[] files = dir.GetFiles("*.xls?");
                foreach (var dir1 in files)
                {
                    XLWorkbook xlwb = new XLWorkbook(dir1.FullName);
                    IXLWorksheet xlws = xlwb.Worksheet(1);

                    for (int i = startRow; i <= xlws.LastRowUsed().RowNumber(); i++)
                    {
                        IXLWorksheet ws = GetTemplateWorksheet();
                        ws.Name = xlws.Cell(i, colNum).Value.ToString().Replace("/","").Trim();
                        wb.AddWorksheet(ws);
                    }
                    return wb;
                }
            }
            return null;
        }

        /// <summary>
        /// Get template worksheet for output, default: template.xlsx under the app's startup path
        /// </summary>
        /// <param name="template">template worksheet file name</param>
        /// <returns>template IXLWorksheet</returns>
        private IXLWorksheet GetTemplateWorksheet()
        {
            XLWorkbook wb;
            wb = new XLWorkbook(templatePath);
            return wb.Worksheet(1);
        }

        /// <summary>
        /// Print a DataTable to a template Worksheet
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        private IXLWorksheet PrintToWorksheet(IXLWorksheet worksheet, DataTable dt)          
        {
            int sbjNum = 10;
            int expNum = 3;
            int aprNum = 3;
            int startRow = 19;
            int startCol = 5;
            int expSum = expNum * aprNum;
            int gap = 6;
            /*
             * sbjNum: subject number 被测零件数量
             * expNum: experiment number 单个实验员测试次数
             * aprNum: appraiser number 评价人数
             * startRow: template中第1次实验数据的行数
             * startCol: template中1号零件实验数据的行数
             * gap: 相邻两位测试员数据的间隔
             */
          
            int colNum = startCol;
            int k;
            for (int i = 0; i < sbjNum; i++) 
            {
                k = i; 
                if (k >= dt.Columns.Count) k -= dt.Columns.Count; 

                int rowNum = startRow;
                for (int j = 0; j < expSum; j++)
                {
                    if (j % expNum == 0) rowNum = startRow + gap * j / expNum; // 跳至下一位测试员的第一次实验
                    if (j >= dt.Rows.Count)
                    {
                        worksheet.Cell(rowNum++, colNum).Value = dt.Rows[j % expNum][k].ToString();
                    }
                    else if (dt.Rows[j].IsNull(k))
                    {
                        worksheet.Cell(rowNum++, colNum).Value = dt.Rows[j % expNum][k].ToString();
                    }
                    else
                    {
                        worksheet.Cell(rowNum++, colNum).Value = dt.Rows[j][k].ToString();
                    }
                    worksheet.Cell(rowNum, colNum).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(rowNum, colNum).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                }
                colNum++;                   
            }
            return worksheet;
        }


        /// <summary>
        /// Get single value from excel charts under a folder.
        /// Values from charts in a subfolder form a column in returned datatable.
        /// </summary>
        /// <param name="folderPath">Project folder path containing folders with names of serial number</param>
        /// <param name="valueRow">The desired value's row number</param>
        /// <param name="valueCol">The desired value's column number</param>
        /// <returns>DataTable, each column contains values from a same serial number</returns>
        private DataTable GetDataTableFromFolder(string folderPath, int valueRow, int valueCol)
        {
            DataTable dt = new DataTable();
            DirectoryInfo[] dirInfos = new DirectoryInfo(folderPath).GetDirectories();
            int dirInfoCount = -1;
            foreach (var dirInfo in dirInfos)  //遍历序列号命名的文件夹
            {
                dt.Columns.Add(dirInfo.Name);
                dirInfoCount++;
                /*FileInfo[] files = dir.GetFiles("*.xls?");*/
                FileInfo[] fileInfos = new DirectoryInfo(dirInfo.FullName).GetFiles("*.xls?");
                int reportCount = -1;
                foreach (var fileInfo in fileInfos) //遍历序列号文件夹下的测试结果
                {
                    string fileName = fileInfo.Name;
                    /*if (!fileName.EndsWith(@".xls?")) continue;*/

                    XLWorkbook wb = new XLWorkbook(fileInfo.FullName);
                    IXLWorksheet ws = wb.Worksheet(1);
                    if (!(ws.Cell(1, 10).Value.ToString() == "value")) continue;
                    string item = ws.Cell(valueRow, valueCol).Value.ToString();
                    if (string.IsNullOrEmpty(item)) continue;

                    reportCount++;
                    if (dirInfoCount == 0)
                    {
                        DataRow row = dt.NewRow();
                        row[dirInfoCount] = item;
                        dt.Rows.Add(row);
                    }
                    else
                    {
                        if (dt.Rows.Count >= reportCount + 1) dt.Rows[reportCount][dirInfoCount] = item;
                        else
                        {
                            DataRow row = dt.NewRow();
                            row[dirInfoCount] = item;
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
            return dt;
        }

        private void ThreadCaptureMethod()
        {
            btn_OpenReportPath_Click.Enabled = false;
            string rootName = new FileInfo(logRootDir).Name;
            XLWorkbook workBook = GetWorkbook(logRootDir);
            ShowMsg($"[{DateTime.Now:HH:mm:ss.fff}]>>>\r\n\t 获取模板完毕");
            IXLWorksheet worksheet;

            for (int k = 0; k < workBook.Worksheets.Count; k++) //遍历worksheet,次数相当于测试项目数
            {
                worksheet = workBook.Worksheet(k + 1);
                mdt = new DataTable();
                try
                {                 
                    mdt = GetDataTableFromFolder(logRootDir, k + 2, 10);                  
                }
                catch (Exception ex)
                {
                    if (this.InvokeRequired) this.BeginInvoke(new Action(() => { MessageBox.Show(this, ex.Message, "ThreadCaptureMethod1"); }));
                    else MessageBox.Show(this, ex.Message, "ThreadCaptureMethod1");
                }
                finally
                {
                    if (this.InvokeRequired) pn_Control.BeginInvoke(new Action(() => { pn_Control.Enabled = true; }));
                    else pn_Control.Enabled = true;
                }
                worksheet = PrintToWorksheet(worksheet, mdt);

            }

            string newFile = Path.Combine(reportPath, $"{rootName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            workBook.SaveAs(newFile);
            ShowMsg($"[{DateTime.Now:HH:mm:ss.fff}]>>>\r\n\t 结果储存于{newFile}");
            btn_OpenReportPath_Click.Enabled = true;
        }


    }
}

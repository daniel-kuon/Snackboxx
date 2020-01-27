using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Snackboxx.Core;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace SnackBoxxWeb.Controls
{
    public partial class TimeRegistration : System.Web.UI.UserControl
    {
        private User _user;
        private DBConnection _dbconn;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void SetParams(User user,DBConnection dbconn)
        {
            _user = user;
            _dbconn = dbconn;

            string erg = ddlYears.SelectedValue;
            string erg1 = ddlMonth.SelectedValue;
            string erg2 = ddlDays.SelectedValue;

            DropDownList year = (DropDownList)ViewState["ddlYears"];
            


            if (Page.IsPostBack)
            {
                this.FillData(ddlYears.SelectedValue, ddlMonth.SelectedValue, ddlDays.SelectedValue);
            }
        }

        private TextBox GetTextBox(string id, bool enable, string text,bool underline,bool bold)
        {
            TextBox tb = new TextBox();
            tb.CssClass = "textbox";
            
            if (underline && bold) { tb.CssClass = "textboxbu"; }
            if(bold){tb.CssClass="textboxb";}

            tb.Enabled = enable;
            tb.AutoPostBack = false;
            tb.Text = text;
            tb.EnableViewState = true;
            tb.Width = Unit.Percentage(99.2);
            if (!enable) { tb.BackColor = Color.FromArgb(255,100,100,100); tb.ForeColor = Color.White; }
            tb.TextChanged += new EventHandler(tb_TextChanged);
            tb.ID = id;
            return tb;
        }

        private Button GetDelButton(string id,bool enable,string idOne,string idTwo)
        {
            Button btn = new Button();
            btn.ID = id+"|"+idOne+"|"+idTwo;
            btn.CssClass = "btnstyle";
            btn.ForeColor = Color.Red;
            btn.BackColor = Color.White;
            btn.Width = Unit.Percentage(100);
            btn.Enabled = enable;
            btn.EnableViewState = true;
            btn.Text = "Delete";
            btn.Click += new EventHandler(btn_Click);
            return btn;
        }

        void btn_Click(object sender, EventArgs e)
        {
            try
            {
                Label2.Text = string.Empty;
                string id = ((Button)sender).ID;
                string[] ids = id.Split(new string[] { "|" }, StringSplitOptions.None);
                for (int i = 1; i < ids.GetLength(0); ++i)
                {
                    if (!string.IsNullOrEmpty(ids[i]))
                    {
                        string del = "Delete from T_Time where TimeID='" + ids[i] + "'";
                        _dbconn.Execute(del, null);
                    }
                }
                this.btnsearch_Click(sender, e);
            }
            catch (Exception exp)
            {
                Label2.Text = exp.Message;
            }
        }
        
        private Label GetLabel(string id, string text, bool underline, bool bold, bool center)
        {
            Label lab = new Label();
            lab.CssClass = "textbox";
            if (underline) { lab.CssClass += " textboxu"; }
            if (bold) { lab.CssClass += " textboxb"; }
            if (center) { lab.CssClass += " textboxc"; }

            lab.BackColor = Color.FromArgb(255, 100, 100, 100);
            if (!string.IsNullOrEmpty(text)) { lab.Text = text; }
            else { lab.Text = "00:00:00"; }
            lab.EnableViewState = true;
            lab.Width = Unit.Percentage(99.8);
            lab.ID = id;

            return lab;
        }

        private TextBox GetTextBox(string id,bool enable)
        {
            return this.GetTextBox(id, enable, null,false,false);
        }

        private TableCell GetTableCell(string id,int colspan)
        {
            TableCell cell = new TableCell();
            cell.ID = id;
            if (colspan > 0) { cell.ColumnSpan = colspan; }
            return cell;
        }

        private TableRow GetTableRow(string id)
        {
            TableRow row = new TableRow();
            row.ID = id;
            return row;
        }

        private TableRow GetRowTemplate(bool enablecom, bool enablego, bool delbtn, 
            DateTime ndate, int i, string commdate, string godate, int k, string ergdate,
            string idOne,string idTwo)
        {
            TableRow row = this.GetTableRow(i.ToString() + ".0." + k);
            
            TableCell c1 = this.GetTableCell(row.ID + ".1", 0);
            c1.Controls.Add(this.GetLabel(c1.ID + "_index", (k + 1).ToString() + " Pos", false, false,false));
            
            TableCell c2 = this.GetTableCell(row.ID + ".2", 0);
            if (enablecom) { c2.Controls.Add(this.GetTextBox(c2.ID + "_co_" + ndate.ToShortDateString(), true, commdate, false, false)); }
            else { c2.Controls.Add(this.GetLabel(c2.ID + "_co_" + ndate.ToShortDateString(), commdate, false, false,false)); }
            
            TableCell c3 = this.GetTableCell(row.ID + ".3", 0);
            if (enablego) { c3.Controls.Add(this.GetTextBox(c3.ID + "_go_" + ndate.ToShortDateString(), true, godate, false, false)); }
            else { c3.Controls.Add(this.GetLabel(c3.ID + "_go_" + ndate.ToShortDateString(), godate, false, false,false)); }
            
            TableCell c4 = this.GetTableCell(row.ID + ".4", 0);
            if (delbtn) { c4.Controls.Add(this.GetDelButton(c4.ID + "_del", true,idOne,idTwo)); }
            else { c4.Controls.Add(this.GetLabel(c4.ID + "_lab", "Delete", false, false,true)); }
            
            TableCell c5 = this.GetTableCell(row.ID + ".5", 0);
            c5.Controls.Add(this.GetLabel(c5.ID + "_erg", ergdate, true, false,true));
            
            row.Cells.Add(c1);
            row.Cells.Add(c2);
            row.Cells.Add(c3);
            row.Cells.Add(c4);
            row.Cells.Add(c5);
            return row;
        }

        private List<ParameterObj> GetSearchParam(string year, string month, string day)
        {
            List<ParameterObj> paramlist = new List<ParameterObj>();
            DateTime sstdate = new DateTime();
            DateTime sendate = new DateTime();
            sstdate = new DateTime(DateTime.Now.Year, 1, 1);
            sendate = new DateTime(DateTime.Now.Year, 12, 31);
            if (!year.Equals("0"))
            {
                sstdate = new DateTime(Convert.ToInt32(year), sstdate.Month, sstdate.Day);
                sendate = new DateTime(Convert.ToInt32(year), sendate.Month, sendate.Day);
            }
            if (!month.Equals("0"))
            {
                sstdate = new DateTime(sstdate.Year, Convert.ToInt32(month), sstdate.Day);
                sendate = new DateTime(sendate.Year, Convert.ToInt32(month), DateTime.DaysInMonth(sendate.Year, Convert.ToInt32(month)),23,59,59);                
            }
            if (!day.Equals("0"))
            {
                sstdate = new DateTime(sstdate.Year, sstdate.Month, Convert.ToInt32(day));
                sendate= new DateTime(sendate.Year,sendate.Month, Convert.ToInt32(day)+1);  
            }
            /*
            if (year.Equals("0") && month.Equals("0") && day.Equals("0"))
            {
                sstdate = new DateTime(DateTime.Now.Year, 1, 1);
                sendate = new DateTime(DateTime.Now.Year, 12, 31);                
            }*/

            ParameterObj p1 = new ParameterObj();
            p1.name = "@StartDate";
            p1.type = SqlDbType.DateTime;
            p1.value = sstdate.ToString();

            ParameterObj p2 = new ParameterObj();
            p2.name = "@EndDate";
            p2.type = SqlDbType.DateTime;
            p2.value = sendate.ToString();
            
            paramlist.Add(p1);
            paramlist.Add(p2);
            
            return paramlist;
        }

        private void FillData(string year, string month, string day)
        {
            #region Variables
            //Label2.Text = "Year: " + year + " |Month: " + month + " |Day: " + day;
            if (year.Equals("0") && month.Equals("0") && day.Equals("0") && !cbOnlyDayResults.Checked)
            {
                labeditfunktion.Text = "You can edit your time now!";
            }
            else { labeditfunktion.Text = "Not edit your time..."; }


            List<ParameterObj> paramlist = this.GetSearchParam(year, month, day);
            string query = "Select * from VW_TimeKonto where UserID='" + _user.userid + "'";
            query += " and Time between @StartDate and @EndDate";
            query += " order by Time";
            Dictionary<string, DateTime> commdate = new Dictionary<string, DateTime>();
            Dictionary<string, DateTime> godate = new Dictionary<string, DateTime>();
            List<Dictionary<string, string>> table = _dbconn.GetResultList(query, paramlist);
            DateTime nowdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime startdate = Convert.ToDateTime(paramlist[0].value);
            DateTime enddate = Convert.ToDateTime(paramlist[1].value);

            if (((TimeSpan)enddate.Subtract(nowdate)).Days > -1) { enddate = nowdate; }

            int diff = enddate.Subtract(startdate).Days;
            if (diff == 1) { enddate = startdate; }
            if (startdate.Day == 1 && diff != 1) diff++;

            TimeSpan weekresult = new TimeSpan();
            TimeSpan monthresult = new TimeSpan();

            #endregion

            #region Operativ
            for (int i = 0; i < diff; ++i)//DateTime
            {
                //Row
                List<TableRow> tablerows = new List<TableRow>();
                TableRow row = this.GetTableRow(i.ToString());
                tablerows.Add(row);
                for (int z = 0; z < table.Count; ++z)
                {
                    Dictionary<string, string> element = table[z];
                    DateTime checkdate = Convert.ToDateTime(element["Time"]);
                    if (checkdate.Day.Equals(enddate.Day) && checkdate.Month.Equals(enddate.Month) && checkdate.Year.Equals(enddate.Year))
                    {
                        bool iscomming = Convert.ToBoolean(element["iscomming"]);
                        if (iscomming) { commdate.Add(element["TimeID"],checkdate); }
                        else { godate.Add(element["TimeID"],checkdate); }
                    }
                }
                TimeSpan dayresult = new TimeSpan();
                TimeSpan subpause = new TimeSpan(0, 1, 0, 0, 0);
                bool allset = true;
                int k = 0;
                foreach (string id in commdate.Keys)
                {
                    DateTime cdate = commdate[id];
                    bool goexists = false;
                    if (godate.Count > k) { goexists = true; }
                    if (goexists)
                    {
                        int count = 0;
                        foreach (string goid in godate.Keys)
                        {
                            if (count == k)
                            {
                                TimeSpan difftime = godate[goid].Subtract(cdate);
                                if (!cbOnlyDayResults.Checked)
                                {
                                    TableRow urow = this.GetRowTemplate(false, false, true, enddate, i, 
                                                    cdate.ToLongTimeString(), godate[goid].ToLongTimeString(), 
                                                    k, difftime.ToString(),id,goid);
                                    tablerows.Add(urow);
                                    allset = true;
                                }
                                dayresult = dayresult.Add(difftime);
                            }
                            count++;
                        }
                        
                    }
                    else
                    {
                        if (!cbOnlyDayResults.Checked)
                        {
                            TableRow krow = this.GetRowTemplate(false,true,true,enddate, i, cdate.ToLongTimeString(), null, k, null,id,null);
                            tablerows.Add(krow);
                            allset = false;
                        }
                    }
                    k++;
                }
                if (!cbOnlyDayResults.Checked)
                {
                    if (allset)
                    {
                        TableRow blrow = this.GetRowTemplate(true, true,false, enddate, i, null, null, k++, null,null,null);
                        tablerows.Add(blrow);
                    }
                }


                //DayResult:
                #region DayResult
                
                string cell2text = null;
                if (enddate.DayOfWeek==DayOfWeek.Sunday || enddate.DayOfWeek==DayOfWeek.Saturday)
                {
                    cell2text = "DayResult (2x)...";
                    dayresult = dayresult.Add(dayresult);
                }
                else
                {
                    cell2text = "Day Result with 1h pause...";
                    dayresult = dayresult.Subtract(subpause);
                }
                
                for (int t = 0; t < tablerows.Count; ++t)
                {
                    TableRow irow = tablerows[t];

                    if (t == 0)
                    {
                        TableCell cell = this.GetTableCell(i.ToString() + "_1", 1);
                        TableCell cell2 = this.GetTableCell(i.ToString() + "_2", 3);
                        TableCell cell3 = this.GetTableCell(i.ToString() + "_3", 1);
                        cell.Controls.Add(this.GetLabel(i.ToString() + "_1_lab", enddate.ToShortDateString() + " (" + enddate.DayOfWeek.ToString() + ")",false,true,false));
                        cell2.Controls.Add(this.GetLabel(i.ToString() + "_2_lab",  cell2text,false,true,false));
                        cell3.Controls.Add(this.GetLabel(i.ToString() + "_3_lab",  dayresult.ToString(),true,true,true));
                        irow.Cells.Add(cell);
                        irow.Cells.Add(cell2);
                        irow.Cells.Add(cell3);
                    }
                    tabledate.Rows.Add(irow);
                }

                #endregion
                //end DayResult

                if (diff > 1)
                {
                    //Weekresult
                    #region WeekResult
                    if (cbwithWeekResults.Checked)
                    {
                        weekresult = weekresult.Add(dayresult);
                        if (enddate.DayOfWeek == DayOfWeek.Monday)
                        {
                            TableRow weekrow = this.GetTableRow(i.ToString() + ".W");
                            TableCell weekcell1 = this.GetTableCell(i.ToString() + ".W1.1", 4);
                            TableCell weekcell2 = this.GetTableCell(i.ToString() + ".W2.1", 1);
                            weekcell1.Controls.Add(this.GetLabel(i.ToString() + ".W1.2.lab", "Week Result...",false,true,false));

                            int hour = (weekresult.Days * 24) + weekresult.Hours;
                            string erg = this.FillOneNull(hour.ToString()) + ":" + this.FillOneNull(weekresult.Minutes.ToString()) + ":" + this.FillOneNull(weekresult.Seconds.ToString());

                            weekcell2.Controls.Add(this.GetLabel(i.ToString() + ".W2.2.lab", erg,true,true,true));
                            weekrow.Cells.Add(weekcell1);
                            weekrow.Cells.Add(weekcell2);
                            tabledate.Rows.Add(weekrow);
                            weekresult = new TimeSpan();
                        }
                    }
                    #endregion
                }
                commdate.Clear();
                godate.Clear();
                enddate = enddate.AddDays(-1);
            }
            #endregion
        }

        private string FillOneNull(string time)
        {
            if (time.Length == 1)
                time = "0" + time;
            return time;
        }

        void tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox tb = ((TextBox)sender);
                bool iscomming=true;
                if (tb.ID.Substring(tb.ID.IndexOf("_")+1, 2).Equals("go"))
                    iscomming = false;
                string date = tb.ID.Substring(tb.ID.LastIndexOf("_")+1);
                string ntime = tb.Text;                
                DateTime settime = Convert.ToDateTime(date + " " + ntime);
                if (!settime.ToLongTimeString().Equals("00:00:00"))
                {
                    //Label2.Text = iscomming+ " | "+settime.ToString()+" | "+tb.ID;
                    List<ParameterObj> paramlist = new List<ParameterObj>();
                    ParameterObj timeObj = new ParameterObj();
                    timeObj.name = "@Time";
                    timeObj.type = SqlDbType.DateTime;
                    timeObj.value = settime;
                    paramlist.Add(timeObj);
                    string insertquery = "Insert into T_Time(KontoID,Time,iscomming)values('" + _user.TimeKontoID + "',@Time,'" + iscomming + "')";
                    _dbconn.Execute(insertquery, paramlist);
                }
            }
            catch (Exception exp)
            {
                Label2.Text = exp.Message;
            }
            
        }
        
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Label2.Text = string.Empty;
            tabledate.Rows.Clear();
            this.FillData(ddlYears.SelectedValue, ddlMonth.SelectedValue, ddlDays.SelectedValue);
        }            

    }
}
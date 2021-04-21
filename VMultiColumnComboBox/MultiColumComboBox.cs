using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VMultiColumnComboBox
{
    #region Enum
    public enum GridLines
    {
        None,
        Vertical,
        Horizontal,
        Both
    }
    #endregion

    public partial class MultiColumComboBox : UserControl
    {
        #region Declaraion(s)
        PopupEditor popup;
        DataGridView dgMultiColumn;
        private DataGridViewRow _SelectedRow;
        private BindingSource _BindingSource;
        private UserControl dgMultiColumnContainer;
        #endregion
        
        #region Constructor
        public MultiColumComboBox()
        {
            InitializeComponent();
            _BindingSource = new BindingSource();
            InitializeMultiColumnGridView();
            InitializePopup();
            ResizeCombo();
        }
        #endregion        

        #region Properties
        private DataTable _DataSource;
        public DataTable DataSource 
        {
            get { return _DataSource; }
            set 
            { 
                _DataSource = value;
                BindData();                
            }
        }
       
        private string[] _SourceDataString;
        public string[] SourceDataString
        {
            get
            {
                return _SourceDataString;
            }
            set
            {
                _SourceDataString = value;
            }
        }

        private string[] _SourceDataHeader;
        public string[] SourceDataHeader
        {
            get
            {
                return _SourceDataHeader;
            }
            set
            {
                _SourceDataHeader = value;
            }
        }

        private string[] _ColumnWidth;
        public string[] ColumnWidth
        {
            get { return _ColumnWidth; }
            set { _ColumnWidth = value; }
        }

        private int _DisplayColumnNo = 1;
        public int DisplayColumnNo
        {
            get { return _DisplayColumnNo; }
            set { _DisplayColumnNo = value; }
        }

        private int _ValueColumnNo = 0;
        public int ValueColumnNo
        {
            get { return _ValueColumnNo; }
            set { _ValueColumnNo = value; }
        }

        private bool _ShowHeader = false;
        public bool ShowHeader
        {
            get { return _ShowHeader; }
            set { _ShowHeader = value; }
        }

        private GridLines _GridLines = GridLines.None;
        public GridLines GridLines
        {
            get { return _GridLines; }
            set { _GridLines = value; }
        }

        private int _DropDownHeight = 200;
        public int DropDownHeight
        {
            get { return _DropDownHeight; }
            set { _DropDownHeight = value; }
        }

        private int _DropDownWidth = 200;       

        private ComboBoxItem _SelectedItem = null;
        public ComboBoxItem SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; }
        }
        #endregion

        #region Private Methods
        private void InitializePopup()
        {
            popup = new PopupEditor(dgMultiColumnContainer);
            popup.AutoClose = false;          
        }
        private bool dgvSelected() 
        {
            if (dgMultiColumn.SelectedRows != null && dgMultiColumn.SelectedRows.Count > 0)
                return true;
            else
                return false;
        }
        private void BindData()
        {
            if (DataSource != null)
            {
                dgMultiColumn.DataSource = null;
                

                ConstructDataColumns();
                CalculateDropDownWidth();
                dgMultiColumn.ColumnHeadersVisible = ShowHeader;
                switch (GridLines)
                {
                    case GridLines.None:
                        dgMultiColumn.CellBorderStyle = DataGridViewCellBorderStyle.None;
                        break;
                    case GridLines.Vertical:
                        dgMultiColumn.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
                        break;
                    case GridLines.Horizontal:
                        dgMultiColumn.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                        break;
                    case GridLines.Both:
                        dgMultiColumn.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                        break;
                }
            }
            _BindingSource.Sort = null;
             _BindingSource.DataSource = _DataSource;
            dgMultiColumn.DataSource = _BindingSource;
            if (dgMultiColumn.Rows.Count > 0)
                dgMultiColumn.Rows[0].Selected = true;

        }

        private void ConstructDataColumns()
        {
            if (_SourceDataString != null)
            {
                dgMultiColumn.AutoGenerateColumns = false;
                dgMultiColumn.Columns.Clear();
                DataGridViewTextBoxColumn column;
                for (int index = 0; index < _SourceDataString.Length; index++)
                {
                    column = new DataGridViewTextBoxColumn();
                    column.Name = "Col_" + _SourceDataString[index];
                    column.DataPropertyName = _SourceDataString[index];
                    if (_SourceDataHeader != null && _SourceDataHeader.Length > index)
                        column.HeaderText = _SourceDataHeader[index];
                    else
                        column.HeaderText = _SourceDataString[index];
                    if (_ColumnWidth != null && _ColumnWidth.Length > index)
                    {
                        int colWidth;
                        int.TryParse(_ColumnWidth[index], out colWidth);
                        if (colWidth == 0)
                        {
                            column.Width = colWidth;
                            column.Visible = false;                                                   
                        }
                        else
                        {
                            column.Width = colWidth;
                            column.Visible = true;
                            
                        }
                    }
                    else
                    {
                        if ( index == 0)
                        {
                            column.Width = 10;
                        }
                        else
                        {
                            column.Width = 100; //Default

                        }
                        column.Visible = true;
                    }
                    dgMultiColumn.Columns.Add(column);
                }
            }
            else
            {
                dgMultiColumn.AutoGenerateColumns = true;
                dgMultiColumn.Columns.Clear();
            }
        }

        private void CalculateDropDownWidth()
        {
            _DropDownWidth = 0;
            if (dgMultiColumn.Columns.Count > 0) // _ColumnWidth != null
            {
                // try this out 
                //dgMultiColumn.Columns
                int a = dgMultiColumn.Columns[1].Width;
                for (int index = 0; index < dgMultiColumn.Columns.Count ; index++) // _ColumnWidth.Length
                {
                    _DropDownWidth += Convert.ToInt32(dgMultiColumn.Columns[index].Width); // _ColumnWidth[index]
                }
                //_DropDownWidth = 500;
            }
        }

        private void ShowPopup()
        {
            popup.Height = DropDownHeight;
            popup.Width = _DropDownWidth + 20;                
            dgMultiColumn.Size = popup.Size;
            dgMultiColumnContainer.Size = popup.Size;
            popup.Show(this);
        }

        private void FilterData()
        {
            try
            {
                SetFilter(txtbox.Text);
                if (dgMultiColumn.Rows.Count > 0)
                    dgMultiColumn.Rows[0].Selected = true;
                ShowHideColumn();

            }
            catch
            {
            }            
        }

        private void ShowHideColumn()
        {
            if (_ColumnWidth != null)
            {
                for (int index = 0; index < _ColumnWidth.Length; index++)
                {
                    int colWidth;
                    int.TryParse(_ColumnWidth[index], out colWidth);
                    if (dgMultiColumn.Columns.Count > index)
                    {
                        if (colWidth == 0)
                        {
                            dgMultiColumn.Columns[index].Width = colWidth;
                            dgMultiColumn.Columns[index].Visible = false;
                        }
                        else
                        {
                            dgMultiColumn.Columns[index].Width = colWidth;
                            dgMultiColumn.Columns[index].Visible = true;
                        }
                    }
                }
            }
        }

        private void SetFilter(string filterText)
        {
            string strFilterColumn ="";
            try
            {
                if (filterText.Trim().Length > 0 && dgMultiColumn.Columns.Count > 0)
                {
                    for (byte i = 0 ; i < dgMultiColumn.Columns.Count ;i++ )
                    { // _DisplayColumnNo instead of i
                        strFilterColumn = strFilterColumn + dgMultiColumn.Columns[i].DataPropertyName +
                            string.Format(" LIKE '%{0}%'", filterText);
                        if ( i != dgMultiColumn.Columns.Count -1)
                        {
                            strFilterColumn += " OR ";
                        }
                    }
                        
                     
                    _BindingSource.Filter = strFilterColumn   ;
                   //MessageBox(_BindingSource.Filter);
                }
                else
                {
                    _BindingSource.Filter = null;
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Public Methods        
        public void Clear()
        {
            _SelectedItem = null;
            txtbox.Text = "";
        }

        private void ResizeCombo()
        {
            this.Height = this.txtbox.Height;
            this.txtbox.Location = new Point(0, 0);
            this.buttonDropDown.Height = this.txtbox.Height + 1;
            this.buttonDropDown.Width = this.buttonDropDown.Height + 1;
            this.txtbox.Width = this.Width - this.buttonDropDown.Width;
            this.Refresh();
        }
        #endregion

        #region Events

        private void MultiColumComboBox_Resize(object sender, EventArgs e)
        {
            ResizeCombo();
        }

        private void buttonDropDown_Click(object sender, EventArgs e)
        {
            if (popup.Visible)
            {
                popup.Close();
            }
            else
            {
                FilterData();
                ShowPopup();
            }
        }

        private void txtbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (popup.Visible)
                    dgMultiColumn_ItemSeleted(_SelectedRow);
                txtbox.SelectionStart = txtbox.Text.Length;
                txtbox.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                dgMultiColumn_ItemSeleted(null);
                popup.Close();
                txtbox.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                //Filter Data
                popup.Focus();
                dgMultiColumnContainer.Focus();
                dgMultiColumn.Focus();
                FilterData();
                if (popup.Visible == false)
                {
                    ShowPopup();
                }
                else
                {
                    if (dgMultiColumn.Rows.Count > 1)
                    {
                        dgMultiColumn.Rows[0].Selected = false;
                        dgMultiColumn.Rows[1].Selected = true;
                        //Set Current Cell
                        for (int index = 0; index < dgMultiColumn.Rows[1].Cells.Count; index++)
                        {
                            if (dgMultiColumn.Rows[1].Cells[index].Visible)
                            {
                                dgMultiColumn.CurrentCell = dgMultiColumn.Rows[1].Cells[index];
                                break;
                            }
                        }
                        
                    }
                }

            }
            else if (e.KeyCode == Keys.Up)
            {
                popup.Close();
                txtbox.Focus();
            }
            else if (txtbox.Text == "")
            {
                popup.Close();
            }
            else
            {
                //Filter data
                FilterData();
                if (popup.Visible == false)
                {
                    ShowPopup();
                }
                txtbox.Focus();
            }
        }

        private void txtbox_Leave(object sender, EventArgs e)
        {
            popup.Close();
            if (txtbox.Text.Trim().Length == 0)
            {
                Clear();
            }
        }

        private void txtbox_FontChanged(object sender, EventArgs e)
        {
            ResizeCombo();
        } 
        #endregion

        #region DataGridView Methods
        private void InitializeMultiColumnGridView()
        {
            this.dgMultiColumn = new DataGridView();
            this.dgMultiColumn.AllowUserToAddRows = false;
            this.dgMultiColumn.AllowUserToDeleteRows = false;
            this.dgMultiColumn.AllowUserToResizeColumns = false;
            this.dgMultiColumn.AllowUserToResizeRows = false;
            this.dgMultiColumn.AutoGenerateColumns = false;
            this.dgMultiColumn.BackgroundColor = System.Drawing.Color.White;
            this.dgMultiColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMultiColumn.Location = new System.Drawing.Point(0, 0);
            this.dgMultiColumn.MultiSelect = false;
            this.dgMultiColumn.Name = "dgMultiColumn";
            this.dgMultiColumn.ReadOnly = true;
            this.dgMultiColumn.RowHeadersVisible = false;
            this.dgMultiColumn.RowHeadersWidth = 25;
            this.dgMultiColumn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMultiColumn.Size = new System.Drawing.Size(_DropDownWidth, _DropDownHeight);
            this.dgMultiColumn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMultiColumn.TabIndex = 0;
            this.dgMultiColumn.DefaultCellStyle.Font = txtbox.Font;           
            this.dgMultiColumn.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMultiColumn_RowEnter);
            this.dgMultiColumn.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMultiColumn_CellDoubleClick);
            this.dgMultiColumn.KeyDown += new KeyEventHandler(dgMultiColumn_KeyDown);
            
            dgMultiColumnContainer = new UserControl();
            dgMultiColumnContainer.Name = "GridContainer";
            dgMultiColumnContainer.Size = this.dgMultiColumn.Size;
            dgMultiColumnContainer.Controls.Add(dgMultiColumn); 
        }  

        private void dgMultiColumn_ItemSeleted(DataGridViewRow item)
        {
            ComboBoxItem selItem = new ComboBoxItem();
            if (item != null && item.Cells.Count > _DisplayColumnNo && item.Cells.Count > _ValueColumnNo && item.Cells[_DisplayColumnNo].Value != null)
            {
                selItem.Text = item.Cells[_DisplayColumnNo].Value.ToString();
                selItem.Value = item.Cells[_ValueColumnNo].Value.ToString();
                for (int index = 0; index < item.Cells.Count; index++)
                {
                    selItem.ItemData.Add(item.Cells[index].Value.ToString());
                }
            }
            else
            {
                selItem = null;
            }
            _SelectedItem = selItem;
            if (_SelectedItem == null)
            {
                txtbox.Text = "";
            }
            else
            {
                txtbox.Text = _SelectedItem.Text;
            }
            popup.Close();
        }

        #endregion

        #region DataGridView Events
        private void dgMultiColumn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgMultiColumn.SelectedRows.Count > 0)
                dgMultiColumn_ItemSeleted(dgMultiColumn.SelectedRows[0]);
        }

        private void dgMultiColumn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgMultiColumn.SelectedRows.Count > 0)
                {
                    _SelectedRow = dgMultiColumn.SelectedRows[0];
                    dgMultiColumn_ItemSeleted(_SelectedRow);
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                _SelectedRow = null;
                dgMultiColumn_ItemSeleted(_SelectedRow);
                e.Handled = true;
            }
        }

        private void dgMultiColumn_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _SelectedRow = dgMultiColumn.Rows[e.RowIndex];
        }

        #endregion

        private void txtbox_TextChanged(object sender, EventArgs e)
        {/*
            popup.Focus();
            dgMultiColumnContainer.Focus();
            dgMultiColumn.Focus();
            
            FilterData();
            if (popup.Visible == false)
            {
                ShowPopup();
            }
            txtbox.Focus();
           */ 
        }
    }

    [ToolboxItem(false)]
    public class PopupEditor : ToolStripDropDown
    {
        #region Declaration(s)
        private ToolStripControlHost _host;
        #endregion

        #region Constructor
        public PopupEditor(Control content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }
            Content = content;
            AutoSize = false;
            DoubleBuffered = true;
            ResizeRedraw = true;
            _host = new ToolStripControlHost(content);
            Padding = Margin = _host.Padding = _host.Margin = Padding.Empty;
            content.Margin = Padding.Empty;
            MinimumSize = content.MinimumSize;
            content.MinimumSize = content.Size;
            MaximumSize = content.MaximumSize;
            Size = content.Size;
            _host.Size = content.Size;
            TabStop = content.TabStop = true;
            content.Location = Point.Empty;
            Items.Add(_host);
            content.Disposed += (sender, e) =>
            {
                content = null;
                Dispose(true);
            };
            content.RegionChanged += (sender, e) => UpdateRegion();
            UpdateRegion();
        }
        #endregion

        #region Properties
        public Control Content { get; private set; }
        #endregion

        #region Private Methods
        /// <summary>
        /// Updates the pop-up region.
        /// </summary>
        private void UpdateRegion()
        {
            if (Region != null)
            {
                Region.Dispose();
                Region = null;
            }
            if (Content.Region != null)
            {
                Region = Content.Region.Clone();
            }
        }

        private void Show(Control control, Rectangle area)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            Rectangle screen = Screen.FromControl(control).WorkingArea;
            if (location.X + Size.Width > (screen.Left + screen.Width))
            {
                location.X = (screen.Left + screen.Width) - Size.Width;
            }
            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                location.Y -= Size.Height + area.Height;
            }
            location = control.PointToClient(location);
            Show(control, location, ToolStripDropDownDirection.BelowRight);
        }

        private void Show(Rectangle area)
        {
            Point location = new Point(area.Left, area.Top + area.Height);
            Rectangle screen = Screen.FromControl(this).WorkingArea;
            if (location.X + Size.Width > (screen.Left + screen.Width))
            {
                location.X = (screen.Left + screen.Width) - Size.Width;
            }
            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                location.Y -= Size.Height + area.Height;
            }
            Show(location, ToolStripDropDownDirection.BelowRight);
        }
        #endregion

        #region Public Methods
        public void Show(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            Show(control, control.ClientRectangle);
        }
        #endregion
    }

    public class ComboBoxItem
    {
        private string _Text;

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        private string _Value;

        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        private List<string> _ItemData;

        public List<string> ItemData
        {
            get { return _ItemData; }
            set { _ItemData = value; }
        }

        public ComboBoxItem()
        {
            _Text = "";
            _Value = "";
            _ItemData = new List<string>();
        }
    }   
    
}

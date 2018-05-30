using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Business.Entities.ViewModels
{
    // ThuanNN5 : datatalbe không chuyển được thành json do dữ liệu quá lớn 
    public class DataTableViewModel
	{
        public string Name { get; set; }
        public List<DataColumnViewModel> Columns { get; set; }
        public List<DataRowViewModel> Rows { get; set; }

        public DataTableViewModel()
        {
            Columns = new List<DataColumnViewModel>();
            Rows = new List<DataRowViewModel>();
        }

        public DataTableViewModel(IDataReader datas)
        {
            var schema = datas.GetSchemaTable();
            Columns = new List<DataColumnViewModel>();
            Rows = new List<DataRowViewModel>();
            foreach (DataRow row in schema.Rows)
            {
                DataColumnViewModel col = new DataColumnViewModel();
                col.Name = row["ColumnName"] != null ? row["ColumnName"].ToString() : "";
                col.Type = row["DataType"] != null ? row["DataType"].ToString() : "";
                Columns.Add(col);
            }
            int i = 0;
            while (datas.Read())
            {
                var row = new DataRowViewModel();
                row.Index = i;
                row.Cells = new List<DataRowCellViewModel>();
                foreach (var col in Columns)
                {
                    DataRowCellViewModel cell = new DataRowCellViewModel();
                    cell.Name = col.Name;
                    cell.Value = datas[col.Name].ToString();
                    row.Cells.Add(cell);
                }
                Rows.Add(row);
                i++;
            }
        }
    }

    public class DataColumnViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    public class DataRowViewModel
    {
        public int Index { get; set; }
        public List<DataRowCellViewModel> Cells { get; set; }
        public DataRowViewModel()
        {
            Cells = new List<DataRowCellViewModel>();
        }
    }
    public class DataRowCellViewModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}

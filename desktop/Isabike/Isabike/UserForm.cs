using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isabike
{

    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        DataGridViewButtonColumn makeadminButtonColumn = new DataGridViewButtonColumn
        {
            Name = "makeadmin_column",
            Text = "Makeadmin"
        };

        private void UserForm_Load(object sender, EventArgs e)
        {
            GetRESTData("http://127.0.0.1:8000/api/getfelhasznalok");
            adminButtonCreate();
            populatePrivilege();
        }

        private void GetRESTData(string uri)
        {
            userDataGridView.DataSource = DbConnect.getUserData(uri);
        }

        private void adminButtonCreate()
        {
            if (userDataGridView.Columns["makeadmin_column"] == null )
            {
                userDataGridView.Columns.Insert(0, makeadminButtonColumn);

            }
        }

        private void userDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == userDataGridView.Columns["makeadmin_column"].Index)
            {
                var jsonString = new
                {
                    token = Login.getToken(),
                    felhasznalo_id = Convert.ToInt32(userDataGridView.Rows[e.RowIndex].Cells[1].Value),
                    felhasznalo_nev = userDataGridView.Rows[e.RowIndex].Cells[2].Value,
                    vezetek_nev = userDataGridView.Rows[e.RowIndex].Cells[3].Value,
                    kereszt_nev = userDataGridView.Rows[e.RowIndex].Cells[4].Value,
                    vasarlo_telefonszama = userDataGridView.Rows[e.RowIndex].Cells[5].Value,
                    email = userDataGridView.Rows[e.RowIndex].Cells[6].Value,
                    szalitasi_cime = userDataGridView.Rows[e.RowIndex].Cells[8].Value,
                    jogosultsag = Convert.ToInt32(privilageComboBox.SelectedValue)
                };
                string json = JsonConvert.SerializeObject(jsonString);
                DbOperations dbOperations = new DbOperations();
                dbOperations.updateUser(json, "http://127.0.0.1:8000/api/updatefelhasznalo");
                RefreshUsers();
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshUsers();
        }

        public void populatePrivilege()
        {
            List<Privilege> privileges = new List<Privilege> {
                new Privilege(1,"Felhasználó"),
                new Privilege(2,"Eladó"),
                new Privilege(3,"Admin")
            };
            privilageComboBox.DataSource = privileges;
            privilageComboBox.DisplayMember = "Name";
            privilageComboBox.ValueMember = "Id";

        }

        private void RefreshUsers()
        {
            userDataGridView.Rows.Clear();
            userDataGridView.Columns.Clear();
            GetRESTData("http://127.0.0.1:8000/api/getfelhasznalok");
            adminButtonCreate();
            populatePrivilege();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.MaximizeBox = false;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
    }
}

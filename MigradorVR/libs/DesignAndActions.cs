using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Linq.Expressions;

namespace MigradorRP
{
    public static class DesignAndActions
    {
        private static Label lblActivated;
        public static void lblMouseEnter(object sender, EventArgs e)
        {
            Label lblTarget = (Label)sender;
            if(lblTarget != lblActivated)
            {
                lblTarget.BackColor = Color.FromArgb(54, 54, 54);
            }
        }

        public static void lblMouseOut(object sender, EventArgs e)
        {
            Label lblTarget = (Label)sender;
            if(lblTarget != lblActivated)
            {
                lblTarget.BackColor = Color.Transparent;
            }
        }

        public static void ActiveTab(Label sender, Timer tmr, DataGridView dt, bool noValidade = true )
        {
            dynamic frm = Application.OpenForms["frmMain"];
            Label lblTarget = sender;

            if(lblActivated == lblTarget && noValidade)
            {
                return;
            }

            DesactiveTabs();
            lblActivated        = sender;
            tmr.Enabled         = true;
            dt.Location         = new Point(0, 90);
            dt.Size             = new Size(frm.Width, frm.Controls["pnlDadosImp"].Height - dt.Location.Y );
            lblTarget.BackColor = Color.FromArgb(255, 192, 128);
            lblTarget.ForeColor = Color.Black;

            dt.Show();

        }

        public static void timer1_Tick(object sender, EventArgs e)
        {
            Timer tmr = (Timer)sender;
            Panel pnlBorda = Application.OpenForms["frmMain"].Controls["pnlDadosImp"].Controls["pnlBorda"] as Panel;
            int toPosition = lblActivated.Left - pnlBorda.Left;
            bool type = toPosition > 0 ? true : false ;

            if (toPosition != 0)
            {
                if (type)
                {
                    pnlBorda.Left += 15;
                }
                else
                {
                    pnlBorda.Left -= 15;
                }
            }
            else
            {
                tmr.Stop();
            }
        }

        public static void DesactiveTabs()
        {

            Label l1 = (Label)Application.OpenForms["frmMain"].Controls["pnlDadosImp"].Controls["lblTabProd"];
            Label l2 = (Label)Application.OpenForms["frmMain"].Controls["pnlDadosImp"].Controls["lblTabClient"];
            Label l3 = (Label)Application.OpenForms["frmMain"].Controls["pnlDadosImp"].Controls["lblTabForn"];
            
            DataGridView dt1 = (DataGridView)Application.OpenForms["frmMain"].Controls["pnlDadosImp"].Controls["dtGridProdutos"];
            DataGridView dt2 = (DataGridView)Application.OpenForms["frmMain"].Controls["pnlDadosImp"].Controls["dtGridClientes"];
            DataGridView dt3 = (DataGridView)Application.OpenForms["frmMain"].Controls["pnlDadosImp"].Controls["dtGridFornecedores"];

            l1.BackColor = Color.Transparent;
            l1.ForeColor = Color.White;

            l2.BackColor = Color.Transparent;
            l2.ForeColor= Color.White;

            l3.BackColor = Color.Transparent;
            l3.ForeColor= Color.White;

            dt1.Hide();
            dt2.Hide();
            dt3.Hide();

        }
    }
}

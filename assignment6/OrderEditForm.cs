using System;
using System.Windows.Forms;
using assignment5;

namespace assignment6
{
    public partial class OrderEditForm : Form
    {
        public Order Order { get; set; }
        private BindingSource orderDetailsBindingSource = new BindingSource();

        public OrderEditForm()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            // 将 Order 的属性进行数据绑定
            txtOrderID.DataBindings.Add("Text", Order, "Id", false, DataSourceUpdateMode.OnPropertyChanged);
            txtCustomer.DataBindings.Add("Text", Order, "Customer", false, DataSourceUpdateMode.OnPropertyChanged);

            // 订单明细绑定
            orderDetailsBindingSource.DataSource =Order;
            orderDetailsDataGridView.DataSource = orderDetailsBindingSource;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // 必要时进行数据校验
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

using System;
using System.Windows.Forms;
using assignment5; // 引用 Order 项目

namespace assignment6
{
    public partial class MainForm : Form
    {
        private OrderService orderService;
        private BindingSource orderBindingSource = new BindingSource();
        private BindingSource orderDetailBindingSource = new BindingSource();

        private void InitializeDataBindings()
        {
            // 数据绑定
            orderBindingSource.DataSource = orderService.OrderList;
            // 通过 DataMember 将主从绑定
            orderDetailBindingSource.DataSource = orderBindingSource;
            orderDetailBindingSource.DataMember = "Details";

            // ordersDataGridView 与 orderDetailsDataGridView 均需要在设计器中添加到窗体
            ordersDataGridView.DataSource = orderBindingSource;
            orderDetailsDataGridView.DataSource = orderDetailBindingSource;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OrderEditForm editForm = new OrderEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                Order newOrder = editForm.Order;
                orderService.AddOrder(newOrder);
                RefreshData();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current is Order selectedOrder)
            {
                OrderEditForm editForm = new OrderEditForm(selectedOrder);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    orderService.ModifyOrder(editForm.Order);
                    RefreshData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current is Order selectedOrder)
            {
                orderService.RemoveOrder(selectedOrder);
                RefreshData();
            }
        }

        

        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private BindingSource bindingSource1;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_ModifyOrder = new System.Windows.Forms.Button();
            this.button_DeleteOrder = new System.Windows.Forms.Button();
            this.button2_AddOrder = new System.Windows.Forms.Button();
            this.button_QueryOrder = new System.Windows.Forms.Button();
            this.ordersDataGridView = new System.Windows.Forms.DataGridView();
            this.orderDetailsDataGridView = new System.Windows.Forms.DataGridView();
            this.TxtQuery = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDetailsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_ModifyOrder);
            this.groupBox1.Controls.Add(this.button_DeleteOrder);
            this.groupBox1.Controls.Add(this.button2_AddOrder);
            this.groupBox1.Controls.Add(this.button_QueryOrder);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1161, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能";
            // 
            // button_ModifyOrder
            // 
            this.button_ModifyOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ModifyOrder.Location = new System.Drawing.Point(702, 39);
            this.button_ModifyOrder.Name = "button_ModifyOrder";
            this.button_ModifyOrder.Size = new System.Drawing.Size(131, 46);
            this.button_ModifyOrder.TabIndex = 3;
            this.button_ModifyOrder.Text = "修改订单";
            this.button_ModifyOrder.UseVisualStyleBackColor = true;
            // 
            // button_DeleteOrder
            // 
            this.button_DeleteOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_DeleteOrder.Location = new System.Drawing.Point(446, 39);
            this.button_DeleteOrder.Name = "button_DeleteOrder";
            this.button_DeleteOrder.Size = new System.Drawing.Size(129, 46);
            this.button_DeleteOrder.TabIndex = 2;
            this.button_DeleteOrder.Text = "删除订单";
            this.button_DeleteOrder.UseVisualStyleBackColor = true;
            // 
            // button2_AddOrder
            // 
            this.button2_AddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2_AddOrder.Location = new System.Drawing.Point(230, 37);
            this.button2_AddOrder.Name = "button2_AddOrder";
            this.button2_AddOrder.Size = new System.Drawing.Size(123, 48);
            this.button2_AddOrder.TabIndex = 1;
            this.button2_AddOrder.Text = "添加订单";
            this.button2_AddOrder.UseVisualStyleBackColor = true;
            // 
            // button_QueryOrder
            // 
            this.button_QueryOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_QueryOrder.Location = new System.Drawing.Point(79, 37);
            this.button_QueryOrder.Name = "button_QueryOrder";
            this.button_QueryOrder.Size = new System.Drawing.Size(134, 45);
            this.button_QueryOrder.TabIndex = 0;
            this.button_QueryOrder.Text = "查询订单";
            this.button_QueryOrder.UseVisualStyleBackColor = true;
            this.button_QueryOrder.Click += new System.EventHandler(this.button_QueryOrder_Click);
            // 
            // ordersDataGridView
            // 
            this.ordersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.ordersDataGridView.Location = new System.Drawing.Point(4, 104);
            this.ordersDataGridView.Name = "ordersDataGridView";
            this.ordersDataGridView.RowHeadersWidth = 62;
            this.ordersDataGridView.RowTemplate.Height = 30;
            this.ordersDataGridView.Size = new System.Drawing.Size(240, 580);
            this.ordersDataGridView.TabIndex = 1;
            // 
            // orderDetailsDataGridView
            // 
            this.orderDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDetailsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderDetailsDataGridView.Location = new System.Drawing.Point(244, 104);
            this.orderDetailsDataGridView.Name = "orderDetailsDataGridView";
            this.orderDetailsDataGridView.RowHeadersWidth = 62;
            this.orderDetailsDataGridView.RowTemplate.Height = 30;
            this.orderDetailsDataGridView.Size = new System.Drawing.Size(921, 580);
            this.orderDetailsDataGridView.TabIndex = 2;
            // 
            // TxtQuery
            // 
            this.TxtQuery.Location = new System.Drawing.Point(52, 194);
            this.TxtQuery.Name = "TxtQuery";
            this.TxtQuery.Size = new System.Drawing.Size(120, 28);
            this.TxtQuery.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "输入名称：";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1169, 688);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtQuery);
            this.Controls.Add(this.orderDetailsDataGridView);
            this.Controls.Add(this.ordersDataGridView);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDetailsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private GroupBox groupBox1;
        private Button button_ModifyOrder;
        private Button button_DeleteOrder;
        private Button button2_AddOrder;
        private Button button_QueryOrder;
        private DataGridView ordersDataGridView;
        private DataGridView orderDetailsDataGridView;

        private void button_QueryOrder_Click(object sender, EventArgs e)
        {

        }

        private TextBox TxtQuery;
        private Label label1;
        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 通过客户名称查询
            string customer = TxtQuery.Text.Trim();
            var orders = orderService.QueryByCustomer(customer);
            orderBindingSource.DataSource = orders;
        }

        private void RefreshData()
        {
            // 刷新绑定数据
            orderBindingSource.DataSource = orderService.OrderList;
            orderDetailBindingSource.DataSource = orderBindingSource;
        }
    }
}

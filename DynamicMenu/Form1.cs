using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicMenu
{
    public partial class Form1 : Form
    {
        private List<Menu> MenuItems;
        private MenuStrip menuStrip;
        public Form1()
        {
            InitializeComponent();
            menuStrip = new MenuStrip();
            this.Controls.Add(menuStrip);

            InitMenu();
        }

        void InitMenu()
        {
            MenuItems = new List<Menu>();
            MenuItems.Add(new Menu() { ID = "1", Code = "File", MenuType = 1, Name = "File", OrderBy = 1, ParentID = "", Tag = "", Enabled = true, Visiable = true, DllName= "DynamicMenu.exe", FormName="frmItem", NameSpace ="DynamicMenu" });
            MenuItems.Add(new Menu() { ID = "2", Code = "Item", MenuType = 2, Name = "Item", OrderBy = 2, ParentID = "1", Tag = "", Enabled = false, Visiable = true, DllName = "DynamicMenu.exe", FormName = "frmItem", NameSpace = "DynamicMenu" });
            MenuItems.Add(new Menu() { ID = "3", Code = "Custom", MenuType = 2, Name = "Custom", OrderBy = 3, ParentID = "1", Tag = "", Enabled = true, Visiable = true, DllName = "DynamicMenu.exe", FormName = "frmCustom", NameSpace = "DynamicMenu" });
            MenuItems.Add(new Menu() { ID = "4", Code = "Exit", MenuType = 2, Name = "Exit", OrderBy = 4, ParentID = "1", Tag = "", Enabled = true, Visiable = true, DllName = "DynamicMenu.exe", FormName = "frmItem", NameSpace = "DynamicMenu" });


            var mns = MenuItems.Where(f => f.ParentID == "").ToList();
            CreateMenuItem(mns);
        }

        private void CreateMenuItem(List<Menu> menus)
        {
            foreach (var menu in menus)
            {
                if (menu.MenuType == 1)
                {
                    ToolStripMenuItem mn = new ToolStripMenuItem(menu.Name);
                    mn.Click += Mn_Click;
                    mn.Enabled = menu.Enabled;
                    this.menuStrip.Items.Add(mn);
                    var mns = MenuItems.Where(f => f.ParentID == menu.ID && f.Visiable == true).OrderBy(f => f.OrderBy).ToList();
                    CreateMenuItem(mn, mns);
                }
            }
        }

        private void CreateMenuItem(ToolStripMenuItem MenuItem, List<Menu> menus)
        {
            foreach (var menu in menus)
            {                
                ToolStripMenuItem mn = new ToolStripMenuItem(menu.Name);
                mn.Click += Mn_Click;
                mn.Enabled = menu.Enabled;
                mn.Visible = menu.Visiable;
                mn.Tag = menu;
                MenuItem.DropDownItems.Add(mn);                
            }
        }


        private void CreateMenu(ToolStripMenuItem menuItem, List<Menu> menus)
        {
            foreach(var menu in menus)
            {
                if(menu.MenuType == 1)
                {
                    ToolStripMenuItem mn = new ToolStripMenuItem(menu.Name);
                    mn.Click += Mn_Click;
                    mn.Enabled = menu.Enabled;
                    menuItem.DropDownItems.Add(mn);
                }
            }
        }

        private void ExecuteMenu(Menu menu)
        {
            try
            {

                Assembly assembly = Assembly.LoadFrom(Application.StartupPath + "\\" + menu.DllName);
                if(assembly == null)
                {
                    MessageBox.Show("Assembly is null : " + menu.DllName);
                    return;
                }
                Type type = assembly.GetType(menu.NameSpace + "." + menu.FormName);
                if(type == null)
                {
                    MessageBox.Show("Type is null : " + menu.DllName);
                    return;
                }
                Form form = (Form)Activator.CreateInstance(type);
              //  form.MdiParent = this;
                form.Text = menu.Name;
                form.Tag = menu;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex.Message);
            }
        }

        private void Mn_Click(object sender, EventArgs e)
        {
            if( sender is ToolStripMenuItem)
            {
                var mn = sender as ToolStripMenuItem;
                if(mn.Tag != null)
                {
                    if(mn.Tag is Menu)
                    {
                        var menu = mn.Tag as Menu;
                        switch (menu.Code)
                        {
                            case "Exit":
                                Close();
                                break;
                            default:
                                ExecuteMenu(menu);
                                break;
                        }
                    }
                }
            }
         }
    }
}

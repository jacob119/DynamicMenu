# DynamicMenu
I want to share the project for controlling of dynamic menu using c#.



 MenuItems.Add(new Menu() { ID = "1", Code = "File", MenuType = 1, Name = "File", OrderBy = 1, ParentID = "", Tag = "", Enabled = true, Visiable = true, DllName= "DynamicMenu.exe", FormName="frmItem", NameSpace ="DynamicMenu" });
            MenuItems.Add(new Menu() { ID = "2", Code = "Item", MenuType = 2, Name = "Item", OrderBy = 2, ParentID = "1", Tag = "", Enabled = false, Visiable = true, DllName = "DynamicMenu.exe", FormName = "frmItem", NameSpace = "DynamicMenu" });
            MenuItems.Add(new Menu() { ID = "3", Code = "Custom", MenuType = 2, Name = "Custom", OrderBy = 3, ParentID = "1", Tag = "", Enabled = true, Visiable = true, DllName = "DynamicMenu.exe", FormName = "frmCustom", NameSpace = "DynamicMenu" });
            MenuItems.Add(new Menu() { ID = "4", Code = "Exit", MenuType = 2, Name = "Exit", OrderBy = 4, ParentID = "1", Tag = "", Enabled = true, Visiable = true, DllName = "DynamicMenu.exe", FormName = "frmItem", NameSpace = "DynamicMenu" });


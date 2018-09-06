using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMenu
{
    public class Menu
    {
        private string iD;
        private string code;
        private int menuType;
        private string name;
        private int orderBy;
        private string parentID;
        private string tag;
        private bool enabled;
        private string nameSpace;
        private string formName;
        private string dllName;
        private bool visiable;

        public string ID { get => iD; set => iD = value; }
        public string Code { get => code; set => code = value; }
        public int MenuType { get => menuType; set => menuType = value; }
        public string Name { get => name; set => name = value; }
        public int OrderBy { get => orderBy; set => orderBy = value; }
        public string ParentID { get => parentID; set => parentID = value; }
        public string Tag { get => tag; set => tag = value; }
        public bool Enabled { get => enabled; set => enabled = value; }
        public string NameSpace { get => nameSpace; set => nameSpace = value; }
        public string FormName { get => formName; set => formName = value; }
        public string DllName { get => dllName; set => dllName = value; }
        public bool Visiable { get => visiable; set => visiable = value; }
    }
}

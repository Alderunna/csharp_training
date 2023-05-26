using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {

        public static string GROUPWINTITLE = "Group editor";
        public static string GROUPWINTITLEDELETE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }
       
        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
                       
            CloseGroupsDialogue(dialogue);
            return list;
        }


        /*public int GetGroupCount()
        {

            Window dialogue = OpenGroupsDialogue();
            string count = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            
            CloseGroupsDialogue(dialogue);
            int.Parse(count);
            return int.Parse(count);
        }*/

        /*public void Remove()
        {
            Window dialogue = OpenGroupsDialogue();
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#0", "");            
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");            
            aux.WinWait(GROUPWINTITLEDELETE);
            aux.ControlClick(GROUPWINTITLEDELETE, "", "WindowsForms10.BUTTON.app.0.2c908d51");            
            aux.ControlClick(GROUPWINTITLEDELETE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            Thread.Sleep(5000);
            CloseGroupsDialogue(dialogue);
        }*/


       


        /*public GroupHelper CheckExistGroups()
        {
            GroupData group = new GroupData();
            Window dialogue = OpenGroupsDialogue();
            string gg = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Exists", "#0|#1", "");

            if (int.Parse(gg) == 0)
            {
                Add(group);
            }
            
            return this;
        }*/


        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialogue(dialogue);
        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }
    }
}
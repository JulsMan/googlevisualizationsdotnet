using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;

namespace GoogleChartsNGraphsControls
{
    public enum TrippleStateBool { True, False, NotSet}
    public class CustomDropDownListDesigner: System.Web.UI.Design.ControlDesigner
    {
        public CustomDropDownListDesigner()
        {
           

        }
        private DesignerActionListCollection _actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (_actionLists == null)
                {
                    _actionLists = new DesignerActionListCollection();
                    _actionLists.AddRange(base.ActionLists);

                    // Add a custom DesignerActionList
                    _actionLists.Add(new ActionList(this));
                }
                return _actionLists;
            }
        }

        public class ActionList : DesignerActionList
        {
            private CustomDropDownListDesigner _parent;
            private DesignerActionItemCollection _items;

            // Constructor
            public ActionList(CustomDropDownListDesigner parent)
                : base(parent.Component)
            {
                _parent = parent;

            }

            // Create the ActionItem collection and add one command
            public override DesignerActionItemCollection GetSortedActionItems()
            {
                if (_items == null)
                {
                    _items = new DesignerActionItemCollection();
                    _items.Add(new DesignerActionMethodItem(this, "ToggleLargeText", "Toggle Text Size", true));
                }
                return _items;
            }

            // ActionList command to change the text size
            private void ToggleLargeText()
            {
                // Get a reference to the parent designer's associated control
                Control ctl = (Control)_parent.Component;

                // Get a reference to the control's LargeText property
                PropertyDescriptor propDesc = TypeDescriptor.GetProperties(ctl)["Text"];

                // Get the current value of the property
                bool v = (bool)propDesc.GetValue(ctl);

                // Toggle the property value
                propDesc.SetValue(ctl, !v);
            }
        }
    }
}

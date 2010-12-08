using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GoogleChartsNGraphsControls
{
    /******************************************************************************** 
        Properties Inherited from Control

        For a complete listing of the properties that a control inherits from the Control class, see System.Web.UI.Control. The following list describes some of the commonly accessed properties.

        Controls — The collection of a control's child controls.
        ID — A user-supplied identifier for a control.
        Page — The page that contains the control.
        Parent — The control whose Controls collection a control belongs to. (Control A is a parent of control B if B is an element of A.Controls).
        ViewState — A data structure that is sent to the client and back and is generally used for persisting form data across round trips. ViewState is of type StateBag, which is a dictionary that stores dataas name/value pairs.
        EnableViewState — Indicates whether a control maintains its view state across round trips. If a parent control does not maintain its view state, the view state for its child controls is automatically not maintained.
        UniqueID — The hierarchically-qualified unique identifier assigned to a control by the ASP.NET page framework.
        ClientID — A unique identifier assigned to a control by the ASP.NET page framework and rendered as the HTML ID attribute on the client. The ClientID is different from the UniqueID because the UniqueID can contain the colon character (:), which is not valid in the HTML ID attribute (and is not allowed in variable names in client-side script).
        Visible — Determines whether a control is visible on a page.
        Properties Inherited from WebControl

        If a control derives from WebControl, it inherits additional properties that are related to visual display. For a complete list of properties inherited from WebControl, see System.Web.UI.WebControl. The following list describes some of the commonly accessed properties of WebControl.

        Font — The font for the control.
        ForeColor — The foreground color of the control.
        BackColor — The background color of the control.
        Height — The height of the control.
        Width — The width of the control.
        Attributes — A collection of name/value pairs rendered to the client as attributes. The Attributes property contains the union of declaratively set attributes that do not correspond to properties (or events) of the control and those that are set programmatically.

    ********************************************************************************/


    interface GenericGVIControl
    {
        DataTable ChartDataTable { get; set; }
        string Title { get; set; }
    }
}

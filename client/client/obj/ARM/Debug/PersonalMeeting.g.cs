﻿#pragma checksum "C:\Users\יאיר\Desktop\ח נ י פרויקט\client\client\PersonalMeeting.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "54AC7E0904B9E3277EB6316D98A2EE95"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace client
{
    partial class PersonalMeeting : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // PersonalMeeting.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loading += this.Page_Loading;
                }
                break;
            case 2: // PersonalMeeting.xaml line 17
                {
                    global::Windows.UI.Xaml.Controls.Button element2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Click += this.RegistrationForPersonalMeeting;
                }
                break;
            case 3: // PersonalMeeting.xaml line 42
                {
                    this.PCheckBox = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 4: // PersonalMeeting.xaml line 50
                {
                    this.PCheckBox1 = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 5: // PersonalMeeting.xaml line 58
                {
                    this.PCheckBox2 = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 6: // PersonalMeeting.xaml line 66
                {
                    this.PCheckBox3 = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                }
                break;
            case 7: // PersonalMeeting.xaml line 21
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Click += this.HomeBack;
                }
                break;
            case 8: // PersonalMeeting.xaml line 28
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.back;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

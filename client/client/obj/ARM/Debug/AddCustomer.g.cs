﻿#pragma checksum "C:\Users\יאיר\Desktop\ח נ י פרויקט\client\client\AddCustomer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "45ACD30CC40D7F91BA2A7A1178CD6EAB"
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
    partial class AddCustomer : 
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
            case 1: // AddCustomer.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loading += this.Page_Loading;
                }
                break;
            case 2: // AddCustomer.xaml line 39
                {
                    this.firstName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // AddCustomer.xaml line 40
                {
                    this.lastName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // AddCustomer.xaml line 41
                {
                    this.telephon = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // AddCustomer.xaml line 42
                {
                    this.mail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // AddCustomer.xaml line 43
                {
                    this.adress = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // AddCustomer.xaml line 44
                {
                    this.city = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 8: // AddCustomer.xaml line 52
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.Add;
                }
                break;
            case 11: // AddCustomer.xaml line 20
                {
                    global::Windows.UI.Xaml.Controls.Button element11 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element11).Click += this.HomeBack;
                }
                break;
            case 12: // AddCustomer.xaml line 27
                {
                    global::Windows.UI.Xaml.Controls.Button element12 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element12).Click += this.back;
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


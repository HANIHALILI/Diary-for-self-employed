﻿#pragma checksum "C:\Users\Hani\Desktop\פרויקטים\פרויקט ניהול יומן עבודה לעצמאי\client\client\AddCustomer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8B97A027ACEDFAFA7B01A3DD4D05F08F05373E3F5953D86B0CC1D121CD250598"
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
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
            case 2: // AddCustomer.xaml line 40
                {
                    this.firstName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // AddCustomer.xaml line 41
                {
                    this.telephon = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // AddCustomer.xaml line 42
                {
                    this.mail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // AddCustomer.xaml line 43
                {
                    this.adress = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // AddCustomer.xaml line 44
                {
                    this.city = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 7: // AddCustomer.xaml line 51
                {
                    this.notes = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // AddCustomer.xaml line 53
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.Add;
                }
                break;
            case 9: // AddCustomer.xaml line 54
                {
                    this.txtMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // AddCustomer.xaml line 20
                {
                    global::Windows.UI.Xaml.Controls.Button element12 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element12).Click += this.HomeBack;
                }
                break;
            case 13: // AddCustomer.xaml line 27
                {
                    global::Windows.UI.Xaml.Controls.Button element13 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element13).Click += this.back;
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}


﻿#pragma checksum "C:\Users\Hani\Desktop\פרויקטים\פרויקט ניהול יומן עבודה לעצמאי\client\client\AddCourse.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9D2510BBF5BFDF770FF5246B1C9CC32D74236C94E117C6203F877822F1EBF903"
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
    partial class AddCourse : 
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
            case 1: // AddCourse.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loading += this.Page_Loading;
                }
                break;
            case 2: // AddCourse.xaml line 63
                {
                    this.btnCM = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCM).Click += this.CourseMmeting;
                }
                break;
            case 3: // AddCourse.xaml line 38
                {
                    this.courseCombo = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 4: // AddCourse.xaml line 46
                {
                    this.ststusCombo = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 5: // AddCourse.xaml line 52
                {
                    this.price = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // AddCourse.xaml line 53
                {
                    this.numberOfLessons = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // AddCourse.xaml line 54
                {
                    this.discrabtion = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // AddCourse.xaml line 55
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.AddCourse1;
                }
                break;
            case 9: // AddCourse.xaml line 56
                {
                    this.txtMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // AddCourse.xaml line 57
                {
                    this.txtMessage1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // AddCourse.xaml line 19
                {
                    global::Windows.UI.Xaml.Controls.Button element13 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element13).Click += this.back;
                }
                break;
            case 14: // AddCourse.xaml line 26
                {
                    global::Windows.UI.Xaml.Controls.Button element14 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element14).Click += this.HomeBack;
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

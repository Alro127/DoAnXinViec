﻿#pragma checksum "..\..\..\UCCapNhatThongTinCty.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00FC07106D33050EAC496E6C9ECE0AE5DFED17EE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DoAnXinViec;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace DoAnXinViec {
    
    
    /// <summary>
    /// UCCapNhatThongTinCty
    /// </summary>
    public partial class UCCapNhatThongTinCty : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\UCCapNhatThongTinCty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid thongtincty;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UCCapNhatThongTinCty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush imgAnh;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UCCapNhatThongTinCty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTaiAnhLen;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\UCCapNhatThongTinCty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLuu;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\UCCapNhatThongTinCty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwMatKhau;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\UCCapNhatThongTinCty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDoiMatKhau;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\UCCapNhatThongTinCty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThemAnh;
        
        #line default
        #line hidden
        
        
        #line 207 "..\..\..\UCCapNhatThongTinCty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stAnh;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DoAnXinViec;component/uccapnhatthongtincty.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UCCapNhatThongTinCty.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.thongtincty = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.imgAnh = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 3:
            this.btnTaiAnhLen = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\UCCapNhatThongTinCty.xaml"
            this.btnTaiAnhLen.Click += new System.Windows.RoutedEventHandler(this.btnTaiAnhLen_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnLuu = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.pwMatKhau = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.btnDoiMatKhau = ((System.Windows.Controls.Button)(target));
            
            #line 163 "..\..\..\UCCapNhatThongTinCty.xaml"
            this.btnDoiMatKhau.Click += new System.Windows.RoutedEventHandler(this.btnDoiMatKhau_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnThemAnh = ((System.Windows.Controls.Button)(target));
            
            #line 199 "..\..\..\UCCapNhatThongTinCty.xaml"
            this.btnThemAnh.Click += new System.Windows.RoutedEventHandler(this.btnThemAnh_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.stAnh = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


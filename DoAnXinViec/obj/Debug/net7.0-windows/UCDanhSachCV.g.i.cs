﻿#pragma checksum "..\..\..\UCDanhSachCV.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73A5B0CA932631EBB7A46414946C2CCF351683A9"
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
    /// UCDanhSachCV
    /// </summary>
    public partial class UCDanhSachCV : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 14 "..\..\..\UCDanhSachCV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvDanhSachCV;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\UCDanhSachCV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLuu;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\UCDanhSachCV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTimKiem;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\UCDanhSachCV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSapXep;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\UCDanhSachCV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbBoLoc;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\UCDanhSachCV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThemCV;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\UCDanhSachCV.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReLoad;
        
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
            System.Uri resourceLocater = new System.Uri("/DoAnXinViec;component/ucdanhsachcv.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UCDanhSachCV.xaml"
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
            this.lvDanhSachCV = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.btnLuu = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.tbTimKiem = ((System.Windows.Controls.TextBox)(target));
            
            #line 76 "..\..\..\UCDanhSachCV.xaml"
            this.tbTimKiem.KeyUp += new System.Windows.Input.KeyEventHandler(this.tbTimKiem_KeyUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cbSapXep = ((System.Windows.Controls.ComboBox)(target));
            
            #line 80 "..\..\..\UCDanhSachCV.xaml"
            this.cbSapXep.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbSapXep_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cbBoLoc = ((System.Windows.Controls.ComboBox)(target));
            
            #line 91 "..\..\..\UCDanhSachCV.xaml"
            this.cbBoLoc.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbBoLoc_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnThemCV = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\UCDanhSachCV.xaml"
            this.btnThemCV.Click += new System.Windows.RoutedEventHandler(this.btnThemCV_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnReLoad = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\UCDanhSachCV.xaml"
            this.btnReLoad.Click += new System.Windows.RoutedEventHandler(this.btnReLoad_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 56 "..\..\..\UCDanhSachCV.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnXem_Click);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 66 "..\..\..\UCDanhSachCV.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnChinhSua_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


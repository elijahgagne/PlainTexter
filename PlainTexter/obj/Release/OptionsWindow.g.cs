﻿#pragma checksum "..\..\OptionsWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2758DB368077000B05AF0E1D36F9FD88"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace PlainTexter {
    
    
    /// <summary>
    /// OptionsWindow
    /// </summary>
    public partial class OptionsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveSettingshButton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RunAtStartupCheckbox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox PlaySoundCheckbox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem ViewerTab;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ViewerRefreshButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DataFormatTextBlock;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser ViewerWebBrowser;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ViewerTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox ViewerRichTextBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\OptionsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ViewerDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PlainTexter;component/optionswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OptionsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 6 "..\..\OptionsWindow.xaml"
            ((System.Windows.Controls.TabControl)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TabControl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SaveSettingshButton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\OptionsWindow.xaml"
            this.SaveSettingshButton.Click += new System.Windows.RoutedEventHandler(this.SaveSettingshButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RunAtStartupCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.PlaySoundCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.ViewerTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 6:
            this.ViewerRefreshButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\OptionsWindow.xaml"
            this.ViewerRefreshButton.Click += new System.Windows.RoutedEventHandler(this.ViewerRefreshButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DataFormatTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.ViewerWebBrowser = ((System.Windows.Controls.WebBrowser)(target));
            return;
            case 9:
            this.ViewerTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.ViewerRichTextBox = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 11:
            this.ViewerDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


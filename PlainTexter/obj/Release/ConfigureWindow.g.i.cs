﻿#pragma checksum "..\..\ConfigureWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "315066A9FCB51F207FBA6F8C8FAC5BC2"
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
    /// ConfigureWindow
    /// </summary>
    public partial class ConfigureWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ConfigureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveSettingshButton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ConfigureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RunAtStartupCheckbox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ConfigureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox PlaySoundCheckbox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ConfigureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DebugRefreshButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ConfigureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetKeysButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ConfigureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DebugTextBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/PlainTexter;component/configurewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ConfigureWindow.xaml"
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
            this.SaveSettingshButton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\ConfigureWindow.xaml"
            this.SaveSettingshButton.Click += new System.Windows.RoutedEventHandler(this.SaveSettingshButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RunAtStartupCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.PlaySoundCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.DebugRefreshButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\ConfigureWindow.xaml"
            this.DebugRefreshButton.Click += new System.Windows.RoutedEventHandler(this.DebugRefreshButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ResetKeysButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\ConfigureWindow.xaml"
            this.ResetKeysButton.Click += new System.Windows.RoutedEventHandler(this.ResetKeysButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DebugTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


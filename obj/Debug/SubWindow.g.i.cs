﻿#pragma checksum "..\..\SubWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A523C66A6966CFEC66B02EF96DA4BFFD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PlantMonitor;
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


namespace PlantMonitor {
    
    
    /// <summary>
    /// SubWindow
    /// </summary>
    public partial class SubWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NameChange;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NameEdit;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateCreated;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DateCreatedButton;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock BucketSizeDisplay;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BucketSizeEdit;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid LogBook;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid InputBox;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock EditPromptBlock;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EditPromptBox;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EditPromptComboBox;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button YesButton;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\SubWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NoButton;
        
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
            System.Uri resourceLocater = new System.Uri("/PlantMonitor;component/subwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SubWindow.xaml"
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
            this.NameChange = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.NameEdit = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\SubWindow.xaml"
            this.NameEdit.Click += new System.Windows.RoutedEventHandler(this.EditName);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DateCreated = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.DateCreatedButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\SubWindow.xaml"
            this.DateCreatedButton.Click += new System.Windows.RoutedEventHandler(this.SetDateTime);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BucketSizeDisplay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.BucketSizeEdit = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\SubWindow.xaml"
            this.BucketSizeEdit.Click += new System.Windows.RoutedEventHandler(this.EditSize);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LogBook = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            
            #line 55 "..\..\SubWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DataGridAddRow);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 56 "..\..\SubWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DatGridRemoveRow);
            
            #line default
            #line hidden
            return;
            case 10:
            this.InputBox = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.EditPromptBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.EditPromptBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.EditPromptComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 14:
            this.YesButton = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\SubWindow.xaml"
            this.YesButton.Click += new System.Windows.RoutedEventHandler(this.YesButton_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.NoButton = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\SubWindow.xaml"
            this.NoButton.Click += new System.Windows.RoutedEventHandler(this.NoButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\AddRecipeWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "11A7D0390B1BD6AD09DE5FFD151B1EB35E7F35DBAFB7DBBD4EF9FBEBC4807368"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SanaleRecipeApp;
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


namespace SanaleRecipeApp {
    
    
    /// <summary>
    /// AddRecipeWindow
    /// </summary>
    public partial class AddRecipeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\AddRecipeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RecipeNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AddRecipeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumIngredientsTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\AddRecipeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel IngredientsPanel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AddRecipeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumStepsTextBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AddRecipeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StepsPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/SanaleRecipeApp;component/addrecipewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddRecipeWindow.xaml"
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
            this.RecipeNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.NumIngredientsTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\AddRecipeWindow.xaml"
            this.NumIngredientsTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NumIngredientsTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.IngredientsPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.NumStepsTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\AddRecipeWindow.xaml"
            this.NumStepsTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NumStepsTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.StepsPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            
            #line 37 "..\..\AddRecipeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveRecipeButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


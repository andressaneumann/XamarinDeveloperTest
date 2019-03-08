using System;
using System.Collections.Generic;
using DevelopmentTest.ViewModel;
using Xamarin.Forms;

namespace DevelopmentTest.View
{
    public partial class ToDoPropertyView : ContentPage
    {
        public ToDoPropertyView(ToDoViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }
    }
}

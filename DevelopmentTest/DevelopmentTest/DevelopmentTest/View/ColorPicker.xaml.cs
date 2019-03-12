using System;
using System.Collections.Generic;
using DevelopmentTest.ViewModel;
using Xamarin.Forms;

namespace DevelopmentTest.View
{
    public partial class ColorPicker : Grid
    {
        string selectedColor;

        public string PickerSelectedColor
        {
            get
            {
                return selectedColor;
            }

            set
            {
                selectedColor = value;
            }
        }

        public Color Color
        {
            get { return this.bvColorPicker.Color; }
            set { this.bvColorPicker.Color = value; }
        }

        public ColorPicker()
        {
            InitializeComponent();



            foreach (string colorName in colorDict.Keys)
            {
                pickerColorPicker.Items.Add(colorName);
            }

            TapGestureRecognizer tapImgColorPicker = new TapGestureRecognizer();
            tapImgColorPicker.Tapped += TapImgColorPicker_Tapped;
            imgColorPicker.GestureRecognizers.Add(tapImgColorPicker);

            imgColorPicker.Source = ImageSource.FromResource("DevelopmentTest.ColorPicker.png");
        }

            private void TapImgColorPicker_Tapped(object sender, EventArgs e)
            {
                pickerColorPicker.Focus();
            }

        Dictionary<string, string> colorDict = new Dictionary<string, string>
        {
            { "Amber", "#FFC107" },
            { "Black", "#212121" },         { "Blue", "#2196F3" },
            { "Lime", "#CDDC39" },          { "Orange", "#FF9800" },
            { "Pink", "#E91E63" },          { "Purple", "#94499D" },
            { "Red", "#D32F2F" },           { "Teal", "#009587" },
            { "White", "#FFFFFF" },         { "Yellow", "#FFEB3B" },
        };


        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string colorName = pickerColorPicker.Items[pickerColorPicker.SelectedIndex];
            this.Color = Color.FromHex(colorDict[colorName]);
            this.PickerSelectedColor = colorDict[colorName];

            if(((ToDoViewModel)this.BindingContext).SelectedToDo != null)
            {
                ((ToDoViewModel)this.BindingContext).SelectedToDo.ToDoListColor = colorDict[colorName];
            }


        }
    }
}

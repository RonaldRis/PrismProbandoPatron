﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YUGIOH_Master.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardCellView : Frame
    {
        public CardCellView()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //Open a Modal!
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RatingControls;

namespace StopLoss
{
    public partial class FormCoolDown : Form
    {
        //StarRatingControl m_starRatingControl;
        StarRatingControl[] te;

        public FormCoolDown()
        {
            InitializeComponent();
            int numberquestion = 11;
            te = new StarRatingControl[numberquestion];
            for (int i = 0; i < 10; i++)
            {
                te[i] = new StarRatingControl();
                te[i].Top = 20 + (i * 35);
                te[i].Left = 40;
                te[i].Margin = new Padding(20);
                Controls.Add(te[i]);
            }

            //m_starRatingControl = new StarRatingControl();
            //m_starRatingControl.Top = 45;
            //m_starRatingControl.Left = 85;

            //Controls.Add(m_starRatingControl);
            //te[0] = new StarRatingControl();
            //te[1] = new StarRatingControl();
        }
    }
}

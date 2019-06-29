using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA
{
   public partial class Mainapp : Form
   {
      public Mainapp()
      {
         InitializeComponent();
      }

      private void btnExit_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void btnNew_MouseHover(object sender, EventArgs e)
      {
         btnNew.ForeColor = Color.Green;
      }

      private void btnNew_MouseLeave(object sender, EventArgs e)
      {
         btnNew.ForeColor = Color.White;
      }

      private void button1_MouseHover(object sender, EventArgs e)
      {
         btnOpen.ForeColor = Color.Green;
      }

      private void btnOpen_MouseLeave(object sender, EventArgs e)
      {
         btnOpen.ForeColor = Color.White;
      }

      private void btnSave_MouseHover(object sender, EventArgs e)
      {
         btnSave.ForeColor = Color.Green;
      }

      private void btnSave_MouseLeave(object sender, EventArgs e)
      {
         btnSave.ForeColor = Color.White;
      }

      private void btnCircle_MouseHover(object sender, EventArgs e)
      {
         btnCircle.ForeColor = Color.White;
      }

      private void btnCircle_MouseLeave(object sender, EventArgs e)
      {
         btnCircle.ForeColor = Color.Gray;
      }

      private void btnSquare_MouseHover(object sender, EventArgs e)
      {
         btnSquare.ForeColor = Color.White;
      }

      private void btnSquare_MouseLeave(object sender, EventArgs e)
      {
         btnSquare.ForeColor = Color.Gray;
      }

      private void btnRectangle_MouseHover(object sender, EventArgs e)
      {
         btnRectangle.ForeColor = Color.White;
      }

      private void btnRectangle_MouseLeave(object sender, EventArgs e)
      {
         btnRectangle.ForeColor = Color.Gray;
      }

      private void btnTriangle_MouseHover(object sender, EventArgs e)
      {
         btnTriangle.ForeColor = Color.White;
      }

      private void btnTriangle_MouseLeave(object sender, EventArgs e)
      {
         btnTriangle.ForeColor = Color.Gray;
      }

      private void btnPentagon_MouseHover(object sender, EventArgs e)
      {
         btnPentagon.ForeColor = Color.White;
      }

      private void btnPentagon_MouseLeave(object sender, EventArgs e)
      {
         btnPentagon.ForeColor = Color.Gray;
      }

      private void btnRhombus_MouseHover(object sender, EventArgs e)
      {
         btnRhombus.ForeColor = Color.White;
      }

      private void btnRhombus_MouseLeave(object sender, EventArgs e)
      {
         btnRhombus.ForeColor = Color.Gray;
      }
   }
}

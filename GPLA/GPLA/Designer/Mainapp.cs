using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccessClassLibrary;

namespace GPLA
{
   public partial class Mainapp : Form
   {
      private bool mousedown;
      private Point lastlocation;

      int texturestyle = 0;
      int selectshape = 0;

      /// <summary>
      /// for system color dialog box
      /// </summary>
      /// 
      Color paintcolor = Color.Black;

      Graphics g;
      Pen p;
      Brush bb;
      int x, y = 0;
      int x1, y1, x2, y2 = 0;

      public Mainapp()
      {
         InitializeComponent();
         g = DrawAreaPanel.CreateGraphics();
         p = new Pen(showColorbox.BackColor);

         int x_canvas = DrawAreaPanel.Width / 2;
         int y_canvas = DrawAreaPanel.Height / 2;
         lbl_StartPosX.Text = x_canvas.ToString();
         lbl_StartPosY.Text = y_canvas.ToString();
         lbl_canvasx.Text = x_canvas.ToString();
         lbl_canvasy.Text = y_canvas.ToString();

         bb = new HatchBrush(HatchStyle.Vertical, Color.Red, Color.FromArgb(255, 128, 255, 255));
         g.FillEllipse(bb, 0, 0, 100, 60);
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

      private void btnPen_Click(object sender, EventArgs e)
      {
         selectshape = 1;
      }

      private void btnCircle_Click(object sender, EventArgs e)
      {
         selectshape = 2;
      }

      private void btnSquare_Click(object sender, EventArgs e)
      {
         selectshape = 3;
      }

      private void btnRectangle_Click(object sender, EventArgs e)
      {
         selectshape = 4;
      }

      private void btnTriangle_Click(object sender, EventArgs e)
      {
         selectshape = 5;
      }

      private void btnRhombus_Click(object sender, EventArgs e)
      {
         selectshape = 6;
      }

      private void btnPentagon_Click(object sender, EventArgs e)
      {
         selectshape = 7;
      }

      private void btnNew_Click(object sender, EventArgs e)
      {
         DrawAreaPanel.Refresh();
         this.DrawAreaPanel.BackgroundImage = null;
      }

      private void btnOpen_Click(object sender, EventArgs e)
      {
         OpenFileDialog o = new OpenFileDialog();
         o.Filter = "PNG Files|*.png|JPEG Files|*.jpeg|Bitmap|*.bmp";
         if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
         {
            DrawAreaPanel.BackgroundImage = (Image)Image.FromFile(o.FileName).Clone();
            DrawAreaPanel.BackgroundImageLayout = ImageLayout.Zoom;
         }
         MessageBox.Show("open");
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         SaveFileDialog sfdlg = new SaveFileDialog();
         sfdlg.Title = "Save Dialog";
         sfdlg.Filter = "Bitmap Images (*.bmp)|*.bmp|All files(*.*)|*.*";
         if (sfdlg.ShowDialog(this) == DialogResult.OK)
         {
            using (Bitmap bmp = new Bitmap(DrawAreaPanel.Width, DrawAreaPanel.Height))
            {
               DrawAreaPanel.Image = new Bitmap(DrawAreaPanel.Width, DrawAreaPanel.Height);
               DrawAreaPanel.Image.Save(sfdlg.FileName);
               bmp.Save(sfdlg.FileName);
               MessageBox.Show("Saved Successfully.....");
            }
         }
      }

      private void Mainapp_MouseDown(object sender, MouseEventArgs e)
      {
         mousedown = true;
         lastlocation = e.Location;
      }

      private void Mainapp_MouseMove(object sender, MouseEventArgs e)
      {
         if (mousedown)
         {
            this.Location = new Point(
                (this.Location.X - lastlocation.X) + e.X, (this.Location.Y - lastlocation.Y) + e.Y);

            this.Update();
         }
      }

      private void Mainapp_MouseUp(object sender, MouseEventArgs e)
      {
         mousedown = false;   
      }

      bool start;

      private void DrawAreaPanel_MouseDown(object sender, MouseEventArgs e)
      {
         start = true;
         x1 = e.X;
         y1 = e.Y;
      }

      private void DrawAreaPanel_MouseLeave(object sender, EventArgs e)
      {
         start = false;
         x = 0;
         y = 0;
      }

      private void DrawAreaPanel_MouseMove(object sender, MouseEventArgs e)
      {
         lbl_cursorx.Text = e.X.ToString();
         lbl_cursory.Text = e.Y.ToString();
         if (start)
         {
            if (selectshape == 1)
            {
               if (x > 0 && y > 00)
               {
                  g.DrawLine(p, x, y, e.X, e.Y);
               }

               x = e.X;
               y = e.Y;
            }
            else if (selectshape == 2)
            {
               if (x > 0 && y > 00)
               {
                  g.FillEllipse(new SolidBrush(paintcolor), e.X, e.Y, 40, 50);
               }

               x = e.X;
               y = e.Y;
            }
            else if (selectshape == 4)
            {
               if (x > 0 && y > 00)
               {
                  g.FillRectangle(new SolidBrush(paintcolor), x1, y1, e.X - x1, e.Y - y1);
               }

               x = e.X;
               y = e.Y;
            }
         }
      }

      private void DrawAreaPanel_MouseUp(object sender, MouseEventArgs e)
      {
         start = false;
         x = 0;
         y = 0;

         x2 = e.X;
         y2 = e.Y;
      }

      private void Texture1_Click(object sender, EventArgs e)
      {
         texturestyle = 1;
         bb = new HatchBrush(HatchStyle.Cross, Color.Chocolate, Color.Cornsilk);
         showTexturebox.BackgroundImage = Texture1.BackgroundImage;
      }

      private void Texture2_Click(object sender, EventArgs e)
      {
         bb = new HatchBrush(HatchStyle.DiagonalCross, Color.Red, Color.Orange);
         texturestyle = 2;
         showTexturebox.BackgroundImage = Texture2.BackgroundImage;
      }

      private void Texture3_Click(object sender, EventArgs e)
      {
         bb = new HatchBrush(HatchStyle.ForwardDiagonal, Color.SkyBlue, Color.Yellow);
         texturestyle = 3;
         showTexturebox.BackgroundImage = Texture3.BackgroundImage;
      }

      private void Texture4_Click(object sender, EventArgs e)
      {
         texturestyle = 4;
         bb = new HatchBrush(HatchStyle.Horizontal, Color.Plum, Color.Lime);
         showTexturebox.BackgroundImage = Texture4.BackgroundImage;
      }

      private void Texture5_Click(object sender, EventArgs e)
      {
         texturestyle = 5;
         bb = new HatchBrush(HatchStyle.Vertical, Color.Black, Color.Yellow);
         showTexturebox.BackgroundImage = Texture5.BackgroundImage;
      }

      public int _size1, _size2, _size3, _size4, _size5, _size6, _size7, _size8, _size9, _size10, _size11, _size12;

      private void DrawAreaPanel_MouseClick(object sender, MouseEventArgs e)
      {
         lbl_StartPosX.Text = (e.X).ToString();
         lbl_StartPosY.Text = (e.Y).ToString();
      }

      private void showColorbox_Click(object sender, EventArgs e)
      {
         texturestyle = 0;
         ColorDialog c = new ColorDialog();
         c.ShowDialog();
         paintcolor = c.Color;

         showColorbox.BackColor = paintcolor;
         p.Color = c.Color;
      }

      private void btnConsoleClear_Click(object sender, EventArgs e)
      {
         rtxtConsole.Text = "";
      }

      private void btnConsoleSave_Click(object sender, EventArgs e)
      {
         SaveFileDialog sv = new SaveFileDialog();
         sv.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
         if (sv.ShowDialog() == DialogResult.OK)
         {
            rtxtConsole.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
            this.Text = sv.FileName;
         }
      }

      /// <summary>
      /// declare variable for triangle
      /// </summary>
      public int xi1, yi1, xi2, yi2, xii1, yii1, xii2, yii2, xiii1, yiii1, xiii2, yiii2;
      /// <summary>
      /// declaring variable for repeat number
      /// </summary>

      public int _repeatNo;

      private void btnConsoleRun_Click(object sender, EventArgs e)
      {
         Regex regex1 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) line (.*[\d])([,])(.*[\d])");
         Regex regex2 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) rectangle (.*[\d])([,])(.*[\d])");
         Regex regex3 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) circle (.*[\d])");
         Regex regex4 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) triangle (.*[\d])([,])(.*[\d])([,])(.*[\d])");
         Regex regex5 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) pentagon point2 (.*[\d])([,])(.*[\d]) point3 (.*[\d])([,])(.*[\d]) point4 (.*[\d])([,])(.*[\d]) point5 (.*[\d])([,])(.*[\d])");

         Regex regexClear = new Regex(@"clear board");
         Regex regexMT = new Regex(@"moveto (.*[\d])([,])(.*[\d])");

         Regex regexR = new Regex(@"rectangle (.*[\d])([,])(.*[\d])");
         Regex regexC = new Regex(@"circle (.*[\d])");
         Regex regexT = new Regex(@"triangle (.*[\d])([,])(.*[\d])([,])(.*[\d])");

         Regex regexRepeat = new Regex(@"repeat (.*[\d])");

         Regex regexIfelse = new Regex(@"if drawto x= (.*[\d]) >= 0 or y= (.*[\d]) >= 0 ");
         
         //if drawto x= 9 >= 0 or y= 19 >= 0
         //----------------------------------------------------------------------------------------------------------------------
         //----------------------------------------------------------------------------------------------------------------------
         Match match1 = regex1.Match(rtxtConsole.Text.ToLower());
         Match match2 = regex2.Match(rtxtConsole.Text.ToLower());
         Match match3 = regex3.Match(rtxtConsole.Text.ToLower());
         Match match4 = regex4.Match(rtxtConsole.Text.ToLower());
         Match match5 = regex5.Match(rtxtConsole.Text.ToLower());

         Match matchClear = regexClear.Match(rtxtConsole.Text.ToLower());
         Match matchMT = regexMT.Match(rtxtConsole.Text.ToLower());

         Match matchR = regexR.Match(rtxtConsole.Text.ToLower());
         Match matchC = regexC.Match(rtxtConsole.Text.ToLower());
         Match matchT = regexT.Match(rtxtConsole.Text.ToLower());

         Match matchRepeat = regexRepeat.Match(rtxtConsole.Text.ToLower());

         Match matchIfelse = regexIfelse.Match(rtxtConsole.Text.ToLower());

         //============================== DRAWING LINE =========================================
         if (match1.Success)
         {
            try
            {
               g = DrawAreaPanel.CreateGraphics();
               _size1 = int.Parse(match1.Groups[1].Value);
               _size2 = int.Parse(match1.Groups[3].Value);
               _size3 = int.Parse(match1.Groups[4].Value);
               _size4 = int.Parse(match1.Groups[6].Value);

               ClassShapeFactory shapeFactory = new ClassShapeFactory();
               ClassShape c = shapeFactory.GetShape("line");
               c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3, _size4);
               c.draw(g);
            }
            catch (Exception ex)
            {
               rtxtErrors.AppendText(ex.Message + Environment.NewLine);
               //MessageBox.Show(ex.Message);
            }
         }
         //=============================== RECTANGLE with DrawTo ====================================================
         else if (match2.Success)
         {
            try
            {
               g = DrawAreaPanel.CreateGraphics();
               _size1 = int.Parse(match2.Groups[1].Value);
               _size2 = int.Parse(match2.Groups[3].Value);
               _size3 = int.Parse(match2.Groups[4].Value);
               _size4 = int.Parse(match2.Groups[6].Value);

               ClassShapeFactory shapeFactory = new ClassShapeFactory();
               ClassShape c = shapeFactory.GetShape("rectangle");

               c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3, _size4);
               c.draw(g);
            }
            catch (Exception ex)
            {
               rtxtErrors.AppendText(ex.Message + Environment.NewLine);
               //MessageBox.Show(ex.Message);
            }
         }

         //=================================== RECTANGLE ==============================================================
         else if (matchR.Success)
         {
            try
            {
               g = DrawAreaPanel.CreateGraphics();
               _size1 = int.Parse(lbl_StartPosX.Text);
               _size2 = int.Parse(lbl_StartPosY.Text);
               _size3 = int.Parse(matchR.Groups[1].Value);
               _size4 = int.Parse(matchR.Groups[3].Value);

               ClassShapeFactory shapeFactory = new ClassShapeFactory();
               ClassShape c = shapeFactory.GetShape("rectangle");
               c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3, _size4);
               c.draw(g);
            }
            catch (Exception ex)
            {
               rtxtErrors.AppendText(ex.Message + Environment.NewLine);
            }
         }

         //================================== CIRCLE with Drawto ======================================
         else if (match3.Success)
         {
            try
            {
               g = DrawAreaPanel.CreateGraphics();
               _size1 = int.Parse(match3.Groups[1].Value);
               _size2 = int.Parse(match3.Groups[3].Value);
               _size3 = int.Parse(match3.Groups[4].Value);

               ClassShapeFactory shapeFactory = new ClassShapeFactory();
               ClassShape c = shapeFactory.GetShape("circle");
               c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3 * 2, _size3 * 2);
               c.draw(g);
            }
            catch (Exception ex)
            {
               rtxtErrors.AppendText(ex.Message + Environment.NewLine);
            }
         }

         //=========================================== Circle =======================================================
         else if (matchC.Success)
         {
            try
            {
               g = DrawAreaPanel.CreateGraphics();
               _size1 = int.Parse(lbl_StartPosX.Text);
               _size2 = int.Parse(lbl_StartPosY.Text);
               _size3 = int.Parse(matchC.Groups[1].Value);

               ClassShapeFactory shapeFactory = new ClassShapeFactory();
               ClassShape c = shapeFactory.GetShape("circle");
               c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3 * 2, _size3 * 2);
               //c.draw(set);
               c.draw(g);
            }
            catch (Exception ex)
            {
               rtxtErrors.AppendText(ex.Message + Environment.NewLine);
               // MessageBox.Show(ex.Message);
            }
         }

         //==================================== TRIANGLE with DrawTo ===================================================
         else if (match4.Success)
         {
            try
            {
               g = DrawAreaPanel.CreateGraphics();
               _size1 = int.Parse(match4.Groups[1].Value);
               _size2 = int.Parse(match4.Groups[3].Value);

               _size3 = int.Parse(match4.Groups[4].Value);
               _size4 = int.Parse(match4.Groups[6].Value);
               _size5 = int.Parse(match4.Groups[8].Value);

               xi1 = _size1;
               yi1 = _size2;
               xi2 = Math.Abs(_size3);
               yi2 = _size2;

               xii1 = _size1;
               yii1 = _size2;
               xii2 = _size1;
               yii2 = Math.Abs(_size4);

               xiii1 = Math.Abs(_size3);
               yiii1 = _size2;
               xiii2 = _size1;
               yiii2 = Math.Abs(_size4);

               ClassShapeFactory shapeFactory = new ClassShapeFactory();
               ClassShape c = shapeFactory.GetShape("triangle");
               c.set(texturestyle, bb, paintcolor, xi1, yi1, xi2, yi2, xii1, yii1, xii2, yii2, xiii1, yiii1, xiii2, yiii2);
               c.draw(g);
            }
            catch (Exception ex)
            {
               rtxtErrors.AppendText(ex.Message + Environment.NewLine);
            }
         }

         //==================================================== Triangle =====================================================
         else if (matchT.Success)
         {
            try
            {
               g = DrawAreaPanel.CreateGraphics();
               _size1 = int.Parse(lbl_StartPosX.Text);
               _size2 = int.Parse(lbl_StartPosY.Text);

               _size3 = int.Parse(matchT.Groups[1].Value);
               _size4 = int.Parse(matchT.Groups[3].Value);
               _size5 = int.Parse(matchT.Groups[5].Value);

               xi1 = _size1;
               yi1 = _size2;
               xi2 = Math.Abs(_size3);
               yi2 = _size2;

               xii1 = _size1;
               yii1 = _size2;
               xii2 = _size1;
               yii2 = Math.Abs(_size4);

               xiii1 = Math.Abs(_size3);
               yiii1 = _size2;
               xiii2 = _size1;
               yiii2 = Math.Abs(_size4);

               ClassShapeFactory shapeFactory = new ClassShapeFactory();
               ClassShape c = shapeFactory.GetShape("triangle"); //new rectangles();
               c.set(texturestyle, bb, paintcolor, xi1, yi1, xi2, yi2, xii1, yii1, xii2, yii2, xiii1, yiii1, xiii2, yiii2);
               c.draw(g);
            }
            catch (Exception ex)
            {
               rtxtErrors.AppendText(ex.Message + Environment.NewLine);
            }
         }

         //================================================= PENTAGON ==============================================================

         if (match5.Success)
         {
            try
            {
               //1,3,4,6,7,9,10,12,13,15,16,18
               g = DrawAreaPanel.CreateGraphics();
               _size1 = int.Parse(match5.Groups[1].Value);
               _size2 = int.Parse(match5.Groups[3].Value);
               _size3 = int.Parse(match5.Groups[4].Value);
               _size4 = int.Parse(match5.Groups[6].Value);
               _size5 = int.Parse(match5.Groups[7].Value);
               _size6 = int.Parse(match5.Groups[9].Value);
               _size7 = int.Parse(match5.Groups[10].Value);
               _size8 = int.Parse(match5.Groups[12].Value);
               _size9 = int.Parse(match5.Groups[13].Value);
               _size10 = int.Parse(match5.Groups[15].Value);

               ClassShapeFactory shapeFactory = new ClassShapeFactory();
               ClassShape c = shapeFactory.GetShape("pentagon");
               c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3, _size4, _size5, _size6, _size7, _size8, _size9, _size10);
               c.draw(g);
            }
            catch (Exception ex)
            {
               rtxtErrors.AppendText(ex.Message + Environment.NewLine);
               //MessageBox.Show(ex.Message);
            }
         }

         //================================================ CLEAR BOARD ====================================================================

         else if (matchClear.Success)
         {
            DrawAreaPanel.Refresh();
            this.DrawAreaPanel.BackgroundImage = null;
         }

         //================================================= MOVETO ==========================================================
         else if (matchMT.Success)
         {
            try
            {
               _size1 = int.Parse(matchMT.Groups[1].Value);
               _size2 = int.Parse(matchMT.Groups[3].Value);

               lbl_StartPosX.Text = _size1.ToString();
               lbl_StartPosY.Text = _size2.ToString();
            }
            catch (Exception ex)
            {
               rtxtErrors.AppendText(ex.Message + Environment.NewLine);
               //MessageBox.Show(ex.Message);
            }
         }

         //======================================================== REPEAT ====================================================
         else if (matchRepeat.Success)
         {
            try
            {
               _repeatNo = int.Parse(matchRepeat.Groups[1].Value);

               //=================================================== Repeat Shapes ====================================

               //Regex regexRepCircle = new Regex(@"circle radius (.*[\d]) by radius (.*[\d]) end");
               
               Regex regexRepCircle = new Regex(@"circle radius (.*[\d]) by (.*[\d]) end");
               //repeat 4 circle radius 30 by 20 end
               
               Regex regexRepRectangle = new Regex(@"rectangle width (.*[\d]) height (.*[\d]) by width (.*[\d]) height (.*[\d]) end");
               //repeat 4 rectangle width 90 height 120 by width 20 height 20

               Match matchRepCircle = regexRepCircle.Match(rtxtConsole.Text.ToLower());
               Match matchRepRectangle = regexRepRectangle.Match(rtxtConsole.Text.ToLower());

               //================================================== Repeat Circle ================================================
               if (matchRepCircle.Success)
               {
                  int _repeatAdd = 0;
                  int _repeatAddConstant;
                  _size1 = int.Parse(lbl_StartPosX.Text);
                  _size2 = int.Parse(lbl_StartPosY.Text);
                  _size3 = int.Parse(matchRepCircle.Groups[1].Value);
                  _repeatAdd = int.Parse(matchRepCircle.Groups[2].Value);
                  _repeatAddConstant = int.Parse(matchRepCircle.Groups[2].Value);

                  ClassShapeFactory shapeFactory = new ClassShapeFactory();
                  ClassShape c = shapeFactory.GetShape("circle");

                  for (int i = 0; i < _repeatNo; i++)
                  {
                     c.set(texturestyle, bb, paintcolor, _size1, _size2, (_size3 + _repeatAdd), (_size3 + _repeatAdd));
                     c.draw(g);
                     _size1 = _size1 - (_repeatAddConstant / 2);
                     _size2 = _size2 - (_repeatAddConstant / 2);
                     _repeatAdd = _repeatAdd + _repeatAddConstant;

                     //_repeatAdd = _repeatAdd + _repeatAdd;
                  }
               }

               //=================================================== Repeat Rectangle ==============================================
               else if (matchRepRectangle.Success)
               {
                  try
                  {
                     int _repeatAddWidth = 0;
                     int _repeatAddConstantWidth;
                     int _repeatAddHeight = 0;
                     int _repeatAddConstantHeight;
                     
                     //g = DrawAreaPanel.CreateGraphics();
                     _size1 = int.Parse(lbl_StartPosX.Text);
                     _size2 = int.Parse(lbl_StartPosY.Text);
                     _size3 = int.Parse(matchRepRectangle.Groups[1].Value);
                     _size4 = int.Parse(matchRepRectangle.Groups[2].Value);

                     _repeatAddWidth = int.Parse(matchRepRectangle.Groups[3].Value);
                     _repeatAddConstantWidth = int.Parse(matchRepRectangle.Groups[3].Value);

                     _repeatAddHeight = int.Parse(matchRepRectangle.Groups[4].Value);
                     _repeatAddConstantHeight = int.Parse(matchRepRectangle.Groups[4].Value);

                     ClassShapeFactory shapeFactory = new ClassShapeFactory();
                     ClassShape c = shapeFactory.GetShape("rectangle");

                     for (int i = 0; i < _repeatNo; i++)
                     {
                        c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3 + _repeatAddWidth, _size4 + _repeatAddHeight);
                        c.draw(g);
                        _size1 = _size1 - (_repeatAddConstantWidth / 2);
                        _size2 = _size2 - (_repeatAddConstantHeight / 2);
                        _repeatAddWidth = _repeatAddWidth + _repeatAddConstantWidth;
                        _repeatAddHeight = _repeatAddHeight + _repeatAddConstantHeight;
                     }
                  }
                  catch (Exception ex)
                  {
                     rtxtErrors.AppendText(ex.Message + Environment.NewLine);
                     //MessageBox.Show(ex.Message);
                  }
               }

         //=============================================== IF ELSE ==================================================

               else if (matchIfelse.Success)
               {
                  try
                  {
                     int checkX, checkY;

                     //g = drawareapanel.CreateGraphics();
                     checkX = int.Parse(matchIfelse.Groups[1].Value);
                     checkY = int.Parse(matchIfelse.Groups[2].Value);
                     lbl_StartPosX.Text = checkX.ToString();
                     lbl_StartPosY.Text = checkY.ToString();
                     _size1 = checkX;
                     _size2 = checkY;

                     if (checkX > 0 && checkY > 0)
                     {
                        Regex regexIfelseCircle = new Regex(@"draw circle (.*[\d])");
                        Match matchIfelseCircle = regexIfelseCircle.Match(rtxtConsole.Text.ToLower());

                        Regex regexIfelseRectangle = new Regex(@"draw rectangle (.*[\d])([,])(.*[\d])");
                        Match matchIfelseRectangle = regexIfelseRectangle.Match(rtxtConsole.Text.ToLower());
                        
                        //if drawto x= 9 >= 0 or y= 19 >= 0 draw circle 90
                        //draw circle 90
                        //draw rectangle 90,70
                        if (matchIfelseCircle.Success)
                        {
                           try
                           {
                              _size3 = int.Parse(matchIfelseCircle.Groups[1].Value);

                              ClassShapeFactory shapeFactory = new ClassShapeFactory();
                              ClassShape c = shapeFactory.GetShape("circle");
                              c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3 * 2, _size3 * 2);
                              c.draw(g);
                           }
                           catch (Exception ex)
                           {
                              rtxtErrors.AppendText(ex.Message + Environment.NewLine);
                              // MessageBox.Show(ex.Message);
                           }
                        }
                        else if (matchIfelseRectangle.Success)
                        {
                           try
                           {
                              _size3 = int.Parse(matchIfelseRectangle.Groups[1].Value);
                              _size4 = int.Parse(matchIfelseRectangle.Groups[3].Value);

                              ClassShapeFactory shapeFactory = new ClassShapeFactory();
                              ClassShape c = shapeFactory.GetShape("rectangle");
                              c.set(texturestyle, bb, paintcolor, _size1, _size2, _size3, _size4);
                              c.draw(g);
                           }
                           catch (Exception ex)
                           {
                              rtxtErrors.AppendText(ex.Message + Environment.NewLine);
                           }
                        }
                     }
                     else
                     {
                        if (checkX < 0)
                        {
                           MessageBox.Show("Drawto X= " + checkX + " cannot be less than zero(0)");
                        }
                        else
                        {
                           MessageBox.Show("Drawto Y= " + checkY + " cannot be less than zero(0)");
                        }
                     }
                  }
                  catch (Exception ex)
                  {
                     rtxtErrors.AppendText(ex.Message + Environment.NewLine);
                     //MessageBox.Show(ex.Message);
                  }
               }
            }
            catch (Exception ex)
            {
               rtxtErrors.AppendText(ex.Message + Environment.NewLine);
            }
         }

         //=================================================== HISTORY RECORDING ===============================================
         rtxtHistory.AppendText(rtxtConsole.Text + Environment.NewLine);
         //=================================================== ***************** ==============================================
      }

      private void rtxtConsole_TextChanged(object sender, EventArgs e)
      {
         Regex regex_scan_drawto = new Regex(@"drawto (.*[\d])([,])(.*[\d])");
         Match match_scan_drawto = regex_scan_drawto.Match(rtxtConsole.Text.ToLower());
         if (match_scan_drawto.Success)
         {
            try
            {
               _size1 = int.Parse(match_scan_drawto.Groups[1].Value);
               _size2 = int.Parse(match_scan_drawto.Groups[3].Value);
               lbl_StartPosX.Text = _size1.ToString();
               lbl_StartPosY.Text = _size2.ToString();
            }
            catch (Exception)
            {
               //rtxt_errors.AppendText(ex.Message + Environment.NewLine);
            }
         }  
      }

      private void btnText_Click(object sender, EventArgs e)
      {
         OpenFileDialog op = new OpenFileDialog();
         if (op.ShowDialog() == DialogResult.OK)
         {
            rtxtConsole.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
            this.Text = op.FileName;
         }
      }

      private void btnTextsave_Click(object sender, EventArgs e)
      {
         SaveFileDialog sv = new SaveFileDialog();
         sv.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
         if (sv.ShowDialog() == DialogResult.OK)
         {
            rtxtConsole.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
            this.Text = sv.FileName;
         }
      }
   }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TaskTracker
{
    public class RoundedButton : Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();

            // Calculate the corner radius to make the button appear as a circle
            int radius = Math.Min(this.Width, this.Height) / 2;

            // Define a rectangle with rounded corners (same width and height as the button)
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            // Create a path with a rounded rectangle
            path.AddArc(rect.Left, rect.Top, 2 * radius, 2 * radius, 180, 90);
            path.AddArc(rect.Right - 2 * radius, rect.Top, 2 * radius, 2 * radius, 270, 90);
            path.AddArc(rect.Right - 2 * radius, rect.Bottom - 2 * radius, 2 * radius, 2 * radius, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - 2 * radius, 2 * radius, 2 * radius, 90, 90);
            path.CloseFigure();

            // Fill the button with the specified background color
            e.Graphics.FillPath(new SolidBrush(this.BackColor), path);

            // Draw the button text
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, Color.Transparent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }

    public class OvalButton : Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();

            // Create an ellipse path that fits the button's client rectangle
            path.AddEllipse(this.ClientRectangle);

            // Fill the button with the specified background color
            e.Graphics.FillPath(new SolidBrush(this.BackColor), path);

            // Draw the button text
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, Color.Transparent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}

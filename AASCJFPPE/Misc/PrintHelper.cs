using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

namespace AASCJFPPE.Misc
{
    /// <summary>
    /// Print Helper
    /// </summary>
    public class PrintHelper : IDisposable
    {
        /// <summary>
        /// Graphics for printing
        /// </summary>
        private Graphics _graphics;

        /// <summary>
        /// Fonts
        /// </summary>
        private List<Font> _fonts;

        /// <summary>
        /// Brush
        /// </summary>
        private Brush _brush;

        /// <summary>
        /// Size of the page
        /// </summary>
        private PaperSize _pageSize;

        /// <summary>
        /// Pen
        /// </summary>
        private Pen _pen;

        /// <summary>
        /// Gets or sets the height of the arial10.
        /// </summary>
        /// <value>The height of the arial10.</value>
        public Int32 Arial10Height { get; private set; }

        /// <summary>
        /// Gets or sets the height of the arial8.
        /// </summary>
        /// <value>The height of the arial8.</value>
        public Int32 Arial8Height { get; private set; }

        /// <summary>
        /// Gets or sets the height of the arial10 bold.
        /// </summary>
        /// <value>The height of the arial10 bold.</value>
        public Int32 Arial10BoldHeight { get; private set; }

        /// <summary>
        /// Gets or sets the height of the arial8 bold.
        /// </summary>
        /// <value>The height of the arial8 bold.</value>
        public Int32 Arial8BoldHeight { get; private set; }

        /// <summary>
        /// Gets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public PaperSize PageSize
        {
            get { return this._pageSize; }
        }

        /// <summary>
        /// Marges
        /// </summary>
        public int Margin { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintHelper"/> class.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public PrintHelper(Graphics graphics)
        {
            this._graphics = graphics;

            this._fonts = new List<Font>();
            this._fonts.Add(new Font("Arial", 8));
            this._fonts.Add(new Font("Arial", 8, FontStyle.Bold));
            this._fonts.Add(new Font("Arial", 10));
            this._fonts.Add(new Font("Arial", 10, FontStyle.Bold));

            this._brush = new SolidBrush(Color.Black);

            this._pen = new Pen(this._brush);

            this.Margin = 50;

            // Get page size
            PrinterSettings printerSettings = new PrinterSettings();
            IQueryable<PaperSize> paperSizes = printerSettings.PaperSizes.Cast<PaperSize>().AsQueryable();
            this._pageSize = paperSizes.Where(paperSize => paperSize.Kind == PaperKind.A4).FirstOrDefault();

            // Gets Fonts size
            Arial10Height = GetHeight(PrintHelper.AvailableFont.Arial10);
            Arial8Height = GetHeight(PrintHelper.AvailableFont.Arial8);
            Arial10BoldHeight = GetHeight(PrintHelper.AvailableFont.Arial10Bold);
            Arial8BoldHeight = GetHeight(PrintHelper.AvailableFont.Arial8Bold);

        }

        /// <summary>
        /// Gets the X coordinate from X position.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="xPosition">The x position.</param>
        /// <param name="moreOrLess">The more or less.</param>
        /// <returns></returns>
        private Int32 GetXCoordinateFromXPosition(String text, AvailableFont font, XPosition xPosition, Int32 moreOrLess)
        {
            Int32 x = 0;

            Size textSize = this.GetTextSize(text, font);

            if (xPosition == XPosition.Center)
            {
                x = (_pageSize.Width - textSize.Width) / 2;
            }
            else if (xPosition == XPosition.Right)
            {
                x = _pageSize.Width - textSize.Width;
            }

            x += moreOrLess;

            return x;
        }

        /// <summary>
        /// Gets the size of the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public Size GetTextSize(String text, AvailableFont font)
        {
            return this._graphics.MeasureString(text, this._fonts[(Int32)font]).ToSize();
        }

        /// <summary>
        /// Gets the size of the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public Size GetTextSize(String text, Font font)
        {
            return this._graphics.MeasureString(text, font).ToSize();
        }

        /// <summary>
        /// Prints the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Rectangle.Empty if there not enough space to print the text; Otherwise the Rectangle where the text was print.</returns>
        public Rectangle Print(String text, AvailableFont font, Int32 x, Int32 y)
        {
            if (font == AvailableFont.Arial8)
            {
                y += 3;
            }

            Int32 width = PageSize.Width - (Margin * 2);
            Int32 height = this.GetRealHeight(text, font, width);

            //Size textSize = this.GetTextSize(text, font);
            //if (textSize.Height + y > PageSize.Height)
            if (height + y > PageSize.Height)
            {
                return Rectangle.Empty;
            }

            this._graphics.DrawString(text, this._fonts[(Int32)font], this._brush, new RectangleF(x, y,  width, height)); //new PointF(x, y));

            //return new Rectangle(x, y, textSize.Width, textSize.Height);
            return new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Prints the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="bounds">The bounds.</param>
        /// <returns></returns>
        public Rectangle Print(String text, AvailableFont font, Rectangle bounds)
        {
            if (font == AvailableFont.Arial8)
            {
                bounds.Y += 3;
            }

            this._graphics.DrawString(text, this._fonts[(Int32)font], this._brush, bounds);

            Size textSize = this.GetTextSize(text, font);
            return bounds;
        }

        /// <summary>
        /// Prints the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="xPosition">The x position.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public Rectangle Print(String text, AvailableFont font, XPosition xPosition, Int32 y)
        {
            Int32 x = this.GetXCoordinateFromXPosition(text, font, xPosition, 0);
            return this.Print(text, font, x, y);
        }

        /// <summary>
        /// Prints the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="xPosition">The x position.</param>
        /// <param name="moreOrLess">The more or less.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public Rectangle Print(String text, AvailableFont font, XPosition xPosition, Int32 moreOrLess, Int32 y)
        {
            Int32 x = this.GetXCoordinateFromXPosition(text, font, xPosition, moreOrLess);

            return this.Print(text, font, x, y);
        }


        /// <summary>
        /// Prints the title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public Rectangle PrintTitle(String title, Int32 y)
        {
            return Print(title, PrintHelper.AvailableFont.Arial10Bold, Margin, y);
        }

        /// <summary>
        /// Prints the title right.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public Rectangle PrintTitleRight(String title, Int32 y)
        {
            return Print(title, PrintHelper.AvailableFont.Arial10Bold, PrintHelper.XPosition.Right, -Margin, y);
        }

        /// <summary>
        /// Prints the content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="lastRectangle">The last rectangle.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public Rectangle PrintContent(String content, Rectangle lastRectangle, Int32 y)
        {
            return Print(content, PrintHelper.AvailableFont.Arial8, lastRectangle.X + lastRectangle.Width, y);
        }

        /// <summary>
        /// Prints the content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public Rectangle PrintContent(String content, Int32 y)
        {
            return Print(content, PrintHelper.AvailableFont.Arial8, Margin, y);
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public Int32 GetHeight(AvailableFont font)
        {
            return this.GetTextSize("A", font).Height;
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public Int32 GetHeight(Font font)
        {
            return this.GetTextSize("A", font).Height;
        }

        /// <summary>
        /// Gets the height of the real.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="limitedWidth">Width of the limited.</param>
        /// <returns></returns>
        public Int32 GetRealHeight(String text, AvailableFont font, Int32 limitedWidth)
        {
            Int32 realHeight = 0;

            Int32 fontHeight = this.GetHeight(font);

            Size textSize = this.GetTextSize(text, font);

            Int32 heightAddedFromWidthLimitation = fontHeight;
            if (textSize.Width > limitedWidth && limitedWidth > 0)
            {
                Int32 coef = textSize.Width / limitedWidth;
                heightAddedFromWidthLimitation = coef * fontHeight;
                heightAddedFromWidthLimitation += ((textSize.Width % limitedWidth) == 0) ? 0 : fontHeight;
            }

            realHeight = heightAddedFromWidthLimitation + textSize.Height;

            return realHeight;
        }

        /// <summary>
        /// Gets the height of the real.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="limitedWidth">Width of the limited.</param>
        /// <returns></returns>
        public Int32 GetRealHeight(String text, Font font, Int32 limitedWidth)
        {
            Int32 realHeight = 0;

            Int32 fontHeight = this.GetHeight(font);

            Size textSize = this.GetTextSize(text, font);

            Int32 heightAddedFromWidthLimitation = fontHeight;
            if (textSize.Width > limitedWidth && limitedWidth > 0)
            {
                Int32 coef = textSize.Width / limitedWidth;
                heightAddedFromWidthLimitation = coef * fontHeight;
                heightAddedFromWidthLimitation += ((textSize.Width % limitedWidth) == 0) ? 0 : fontHeight;
            }

            realHeight = heightAddedFromWidthLimitation + textSize.Height;

            return realHeight;
        }

        /// <summary>
        /// Prints the rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        public void PrintRectangle(Rectangle rectangle)
        {
            this._graphics.DrawRectangle(this._pen, rectangle);
        }

        /// <summary>
        /// Prints the rectangle.
        /// </summary>
        /// <param name="rectangles">The rectangles.</param>
        public void PrintRectangle(Rectangle[] rectangles)
        {
            this._graphics.DrawRectangles(this._pen, rectangles);
        }

        /// <summary>
        /// Prints the rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        public void PrintRectangle(RectangleF rectangle)
        {
            this._graphics.DrawRectangle(this._pen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        /// Prints the rectangle.
        /// </summary>
        /// <param name="rectangles">The rectangles.</param>
        public void PrintRectangle(RectangleF[] rectangles)
        {
            this._graphics.DrawRectangles(this._pen, rectangles);
        }

        /// <summary>
        /// Prints the vertical line.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="height">The height.</param>
        public void PrintVerticalLine(Int32 x, Int32 y, Int32 height)
        {
            this._graphics.DrawLine(this._pen, new Point(x, y), new Point(x, y + height));
        }

        /// <summary>
        /// Prints the vertical line.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="height">The height.</param>
        public void PrintVerticalLine(float x, float y, float height)
        {
            this._graphics.DrawLine(this._pen, new PointF(x, y), new PointF(x, y + height));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            for (int i = 0; i < this._fonts.Count; i++)
            {
                this._fonts[i].Dispose();
            }

            this._brush.Dispose();
            this._pen.Dispose();
        }

        /// <summary>
        /// Available fonts
        /// </summary>
        public enum AvailableFont
        {
            /// <summary>
            /// Arial 8
            /// </summary>
            Arial8,
            /// <summary>
            /// Arial 8 bold
            /// </summary>
            Arial8Bold,
            /// <summary>
            /// Arial 10
            /// </summary>
            Arial10,
            /// <summary>
            /// Arial 10 bold
            /// </summary>
            Arial10Bold,
        }

        /// <summary>
        /// X position
        /// </summary>
        public enum XPosition
        {
            /// <summary>
            /// Left
            /// </summary>
            Left,
            /// <summary>
            /// Center
            /// </summary>
            Center,
            /// <summary>
            /// Right
            /// </summary>
            Right
        }
    }
}

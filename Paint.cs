using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Paint : Form
    {
        ToolTip t1 = new ToolTip();
        private clsDrawObject currentObject = null;
        private clsDrawObject selectedObject;
        Graphics gp;
        Color myColor;
        SolidBrush myBrush;
        Pen myPen;

        bool bLine = false;
        bool bRectFr = false;
        bool bRect = false;
        bool bEllipseFr = false;
        bool bEllipse = false;
        bool bPen = false;
        bool bCirFr = false;
        bool bCir = false;

        //Danh sách đương thẳng
        List<clsDrawObject> lstObject = new List<clsDrawObject>();
        bool isPress = false;
        public Paint()
        {
            InitializeComponent();
            gp = this.ptBox.CreateGraphics();
            myColor = Color.Black;
            myPen = new Pen(myColor);
            myBrush = new SolidBrush(myColor);
        }

 

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.bLine = true;
            this.bEllipseFr = false;
            this.bEllipse = false;
            this.bRectFr = false;
            this.bRect = false;
            this.bCirFr = false;
            this.bCir = false;
            this.bPen = false;
        }
        private void btnLine_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Line", btnLine);
            btnLine.FlatAppearance.MouseOverBackColor = Color.Pink;
        }
        private void btnLine_MouseLeave(object sender, EventArgs e)
        {
            btnLine.FlatAppearance.BorderColor = Color.White;
        }
        private void btnRectFr_Click(object sender, EventArgs e)
        {
            this.bRectFr = true;
            this.bLine = false;
            this.bEllipseFr = false;
            this.bEllipse = false;
            this.bRect = false;
            this.bCirFr = false;
            this.bCir = false;
            this.bPen = false;
        }
        private void btnRectFr_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Rectangle Frame", btnRectFr);
            btnRectFr.FlatAppearance.MouseOverBackColor = Color.Pink;
        }

        private void btnRectFr_MouseLeave(object sender, EventArgs e)
        {
            btnRectFr.FlatAppearance.BorderColor = Color.White;
        }
        private void btnRect_Click(object sender, EventArgs e)
        {
            this.bRect = true;
            this.bLine = false;
            this.bEllipseFr = false;
            this.bEllipse = false;
            this.bRectFr = false;
            this.bCirFr = false;
            this.bCir = false;
            this.bPen = false;
        }
        private void btnRect_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Rectangle", btnRect);
            btnRect.FlatAppearance.MouseOverBackColor = Color.Pink;
        }
        private void btnRect_MouseLeave(object sender, EventArgs e)
        {
            btnRect.FlatAppearance.BorderColor = Color.White;
        }
        private void btnEllipseFr_Click(object sender, EventArgs e)
        {
            this.bEllipseFr = true;
            this.bLine = false;
            this.bEllipse = false;
            this.bRectFr = false;
            this.bRect = false;
            this.bCirFr = false;
            this.bCir = false;
            this.bPen = false;
        }
        private void btnEllipseFr_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Ellipse Frame", btnEllipseFr);
            btnEllipseFr.FlatAppearance.MouseOverBackColor = Color.Pink;
        }
        private void btnEllipseFr_MouseLeave(object sender, EventArgs e)
        {
            btnEllipseFr.FlatAppearance.BorderColor = Color.White;
        }
        private void btnEllipse_Click(object sender, EventArgs e)
        {
            this.bEllipse= true;
            this.bLine = false;
            this.bEllipseFr = false;
            this.bRectFr = false;
            this.bRect = false;
            this.bCirFr = false;
            this.bCir = false;
            this.bPen = false;
        }
        private void btnEllipse_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Ellipse", btnEllipse);
            btnEllipse.FlatAppearance.MouseOverBackColor = Color.Pink;
        }
        private void btnEllipse_MouseLeave(object sender, EventArgs e)
        {
            btnEllipse.FlatAppearance.BorderColor = Color.White;
        }
        private Bitmap bitmap;

        private void ptBox_Paint(object sender, PaintEventArgs e)
        {
            // Tạo bitmap tạm thời nếu chưa có
            if (bitmap == null)
            {
                bitmap = new Bitmap(ptBox.Width, ptBox.Height);
            }

            // Vẽ các đối tượng lên bitmap tạm thời
            using (Graphics bufferGraphics = Graphics.FromImage(bitmap))
            {
                bufferGraphics.Clear(Color.White); // Xóa bitmap trước khi vẽ
                foreach (clsDrawObject obj in lstObject)
                {
                    obj.Draw(bufferGraphics, myPen, myBrush, myColor);
                    obj.DrawSelection(bufferGraphics); // Vẽ các điểm bao quanh đối tượng khi nó được chọn

                }
            }

            // Vẽ bitmap lên pictureBox
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        //Ktra xem đối tượng có đang được kéo không
        private bool isDragging = false;
        private Point lastPos;
        private void ptBox_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (clsDrawObject obj in lstObject)
            {
                if (obj.IsPointInObject(e.Location))
                {
                    selectedObject = obj;
                    numericUpDown1.Value = (decimal)obj.Thickness;
                    break;
                }
            }
            if (bPen)
            {
                // Thêm đối tượng mới vào danh sách
                clsDrawObject myObj = new clsFreehand();
                myObj.color = myColor;
                myObj.Points.Add(e.Location);
                lstObject.Add(myObj);
                currentObject = myObj;
                isDragging = true;
                this.Invalidate();
            }
            else
            {
                // Kiểm tra xem người dùng có click chuột phải vào đối tượng đã chọn không
                foreach (clsDrawObject obj in lstObject)
                {
                    obj.IsSelected = false;
                }
                // Kiểm tra xem người dùng có click vào đối tượng nào không
                foreach (clsDrawObject obj in lstObject)
                {
                    if (obj.IsPointInObject(e.Location))
                    {
                        // Nếu đối tượng nằm trong vùng click, đánh dấu đối tượng này là được chọn và đặt các đối tượng khác là không được chọn
                        obj.IsSelected = true;
                        foreach (clsDrawObject otherObj in lstObject)
                        {
                            if (otherObj != obj)
                            {
                                otherObj.IsSelected = false;
                            }
                        }
                        // Lưu lại đối tượng được chọn và vị trí click cũ
                        isDragging = true;
                        currentObject = obj;
                        lastPos = e.Location;
                        this.Invalidate();
                        break;
                    }
                }
                // Nếu không click vào đối tượng nào, thêm đối tượng mới vào danh sách
                if (currentObject == null)
                {

                    if (this.bLine == true)
                    {
                        clsDrawObject myObj;
                        myObj = new clsLine();
                        myObj.p1 = e.Location;
                        myObj.color = myColor;
                        this.lstObject.Add(myObj);
                        currentObject = myObj;
                    }
                    if (this.bRectFr == true)
                    {
                        clsDrawObject myObj;
                        myObj = new clsRectangleFr();
                        myObj.p1 = e.Location;
                        myObj.color = myColor;
                        this.lstObject.Add(myObj);
                        currentObject = myObj;
                    }
                    if (this.bRect == true)
                    {
                        clsDrawObject myObj;
                        myObj = new clsRectangle();
                        myObj.p1 = e.Location;
                        myObj.color = myColor;
                        this.lstObject.Add(myObj);
                        currentObject = myObj;
                    }
                    if (this.bEllipseFr == true)
                    {
                        clsDrawObject myObj;
                        myObj = new clsEllipseFr();
                        myObj.p1 = e.Location;
                        myObj.color = myColor;
                        this.lstObject.Add(myObj);
                        currentObject = myObj;
                    }
                    if (this.bEllipse == true)
                    {
                        clsDrawObject myObj;
                        myObj = new clsEllipse();
                        myObj.p1 = e.Location;
                        myObj.color = myColor;
                        this.lstObject.Add(myObj);
                        currentObject = myObj;
                    }
                    if (this.bCirFr == true)
                    {
                        clsDrawObject myObj;
                        myObj = new clsCirFr();
                        myObj.p1 = e.Location;
                        myObj.color = myColor;
                        this.lstObject.Add(myObj);
                        currentObject = myObj;
                    }
                    if (this.bCir == true)
                    {
                        clsDrawObject myObj;
                        myObj = new clsCir();
                        myObj.p1 = e.Location;
                        myObj.color = myColor;
                        this.lstObject.Add(myObj);
                        currentObject = myObj;
                    }
                }
                if (currentObject != null && !currentObject.IsPointInObject(e.Location))
                {
                    // Nếu đã chọn một đối tượng trước đó, nhưng click vào vùng trống, hủy chọn đối tượng đó và đặt lại trạng thái được chọn cho tất cả các đối tượng khác là false
                    currentObject.IsSelected = false;
                    foreach (clsDrawObject otherObj in lstObject)
                    {
                        if (otherObj != currentObject)
                        {
                            otherObj.IsSelected = false;
                        }
                    }
                    currentObject = null;
                    lastPos = e.Location;
                    this.Invalidate();
                }
            }
        }
        private void ptBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (bPen && isDragging && currentObject != null)
            {
                currentObject.Points.Add(e.Location);
                this.ptBox.Invalidate();
            }
            else if (isDragging && currentObject != null)
            {
                int deltaX = e.Location.X - lastPos.X;
                int deltaY = e.Location.Y - lastPos.Y;
                currentObject.Move(deltaX, deltaY); // Thêm phương thức Move để di chuyển đối tượng
                lastPos = e.Location;
                ptBox.Invalidate();
            }
            else
            {
                if (this.isPress == true)
                {
                    this.lstObject[this.lstObject.Count - 1].p2 = e.Location;
                    this.ptBox.Refresh();
                }
                if (e.Button == MouseButtons.Left && lstObject.Count > 0)
                {
                    if (this.bLine == true)
                    {
                        clsLine bLine = (clsLine)lstObject[lstObject.Count - 1];
                        bLine.p2 = e.Location;
                        this.ptBox.Invalidate();

                    }
                    if (this.bRectFr == true)
                    {
                        clsRectangleFr bRectFr = (clsRectangleFr)lstObject[lstObject.Count - 1];
                        bRectFr.p2 = e.Location;
                        this.ptBox.Invalidate();
                    }
                    if (this.bRect == true)
                    {
                        clsRectangle bRect = (clsRectangle)lstObject[lstObject.Count - 1];
                        bRect.p2 = e.Location;
                        this.ptBox.Invalidate();
                    }
                    if (this.bEllipse == true)
                    {
                        clsEllipse bEllipse = (clsEllipse)lstObject[lstObject.Count - 1];
                        bEllipse.p2 = e.Location;
                        this.ptBox.Invalidate();
                    }
                    if (this.bEllipseFr == true)
                    {
                        clsEllipseFr bEllipseFr = (clsEllipseFr)lstObject[lstObject.Count - 1];
                        bEllipseFr.p2 = e.Location;
                        this.ptBox.Invalidate();
                    }
                    if (this.bCirFr == true)
                    {
                        clsCirFr bCirFr = (clsCirFr)lstObject[lstObject.Count - 1];
                        bCirFr.p2 = e.Location;
                        this.ptBox.Invalidate();
                    }
                    if (this.bCir == true)
                    {
                        clsCir bCir = (clsCir)lstObject[lstObject.Count - 1];
                        bCir.p2 = e.Location;
                        this.ptBox.Invalidate();
                    }
                }
                if (isDragging && currentObject != null)
                {
                    int deltaX = e.Location.X - lastPos.X;
                    int deltaY = e.Location.Y - lastPos.Y;
                    currentObject.p1.X += deltaX;
                    currentObject.p1.Y += deltaY;
                    currentObject.p2.X += deltaX;
                    currentObject.p2.Y += deltaY;
                    lastPos = e.Location;
                    ptBox.Invalidate();
                }
            }
        }
        private void ptBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (bPen)
            {
                bPen = false;
                isDragging = false;
                currentObject = null;
                this.ptBox.Invalidate();
            }
            else
            {
                isDragging = false;
                currentObject = null;
                this.isPress = false;
                if (currentObject != null)
                {
                    currentObject.p2 = e.Location;
                }
                if (e.Button == MouseButtons.Left && lstObject.Count > 0)
                {
                    if (this.bLine == true)
                    {
                        clsLine bLine = (clsLine)lstObject[lstObject.Count - 1];
                        bLine.p2 = e.Location;
                        currentObject = bLine;
                        this.ptBox.Invalidate();
                    }
                    if (this.bRectFr == true)
                    {
                        clsRectangleFr bRectFr = (clsRectangleFr)lstObject[lstObject.Count - 1];
                        bRectFr.p2 = e.Location;
                        currentObject = bRectFr;
                        this.ptBox.Invalidate();
                    }
                    if (this.bRect == true)
                    {
                        clsRectangle bRect = (clsRectangle)lstObject[lstObject.Count - 1];
                        bRect.p2 = e.Location;
                        currentObject = bRect;
                        this.ptBox.Invalidate();
                    }
                    if (this.bEllipse == true)
                    {
                        clsEllipse bEllipse = (clsEllipse)lstObject[lstObject.Count - 1];
                        bEllipse.p2 = e.Location;
                        currentObject = bEllipse;
                        this.ptBox.Invalidate();
                    }
                    if (this.bEllipseFr == true)
                    {
                        clsEllipseFr bEllipseFr = (clsEllipseFr)lstObject[lstObject.Count - 1];
                        bEllipseFr.p2 = e.Location;
                        currentObject = bEllipseFr;
                        this.ptBox.Invalidate();
                    }
                    if (this.bCirFr == true)
                    {
                        clsCirFr bCirFr = (clsCirFr)lstObject[lstObject.Count - 1];
                        bCirFr.p2 = e.Location;
                        currentObject = bCirFr;
                        this.ptBox.Invalidate();
                    }
                    if (this.bCir == true)
                    {
                        clsCir bCir = (clsCir)lstObject[lstObject.Count - 1];
                        bCir.p2 = e.Location;
                        currentObject = bCir;
                        this.ptBox.Invalidate();
                    }
                }
                this.ptBox.Refresh();
                this.bLine = false;
                this.bEllipseFr = false;
                this.bEllipse = false;
                this.bRectFr = false;
                this.bRect = false;
                this.bCirFr = false;
                this.bCir = false;
                this.currentObject = null;
            }
        }
        private void ptBox_MouseClick(object sender, MouseEventArgs e)
        {
            // Kiểm tra xem người dùng có click vào đối tượng nào không
            foreach (clsDrawObject obj in lstObject)
            {
                if (obj.IsPointInObject(e.Location))
                {
                    currentObject = obj;
                    // Lưu đối tượng vào biến tạm thời
                    selectedObject = obj;
                    this.Invalidate();
                    break;
                }
            }

        }
        Control myControl = null;
        Color selectedColor;
        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true; // cho phép chọn bất kỳ màu nào
            cd.Color = selectedColor; // màu được chọn trước đó sẽ được chọn mặc định
            if (cd.ShowDialog() == DialogResult.OK)
            {
                myColor = cd.Color;
                myPen = new Pen(myColor);
                myBrush = new SolidBrush(myColor);
                this.ptBox.Refresh();
                this.ptBox.Invalidate();

            }
            if (myControl != null)
            {
                myControl.BackColor = myColor; // cập nhật màu cho Control nếu có
                this.ptBox.Refresh();
                this.ptBox.Invalidate();
            }
            if (selectedObject != null)
            {
                cd.AllowFullOpen = true;
                cd.Color = selectedObject.color;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    selectedObject.color = cd.Color; // Cập nhật màu cho đối tượng được chọn
                    this.Invalidate();
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (clsDrawObject obj in lstObject)
            {
                obj.Draw(e.Graphics, myPen, myBrush, myColor);
            }
        }
        public abstract class clsDrawObject
        {
            public bool IsSelected { get; set; }
            public List<Point> Points { get; set; }
            public Color color;
            public Point p1;
            public Point p2;
            protected float closestDistance;
            public Point closestPoint;
            public float Thickness { get; set; }

            public clsDrawObject()
            {
                Thickness = 1.0f; // Độ dày mặc định là 1.0
            }
            public virtual void Draw(Graphics myGp, Pen myPen, SolidBrush myBrush, Color myColor)
            {
                // Use object color instead of main color
                myPen.Color = color;
                myPen.Width = Thickness;
            }
            public virtual bool IsPointInObject(Point p)
            {
                double distFromStart = Math.Sqrt(Math.Pow(p.X - p1.X, 2) + Math.Pow(p.Y - p1.Y, 2));
                double distFromEnd = Math.Sqrt(Math.Pow(p.X - p2.X, 2) + Math.Pow(p.Y - p2.Y, 2));
                double lineLength = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
                double buffer = 3; // Tolerance for checking if point is near the line

                return (distFromStart + distFromEnd >= lineLength - buffer && distFromStart + distFromEnd <= lineLength + buffer);
            }
            public virtual void Move(int dx, int dy)
            {
                p1.X += dx;
                p1.Y += dy;
                p2.X += dx;
                p2.Y += dy;
            }
            public void DrawSelection(Graphics g)
            {
                if (IsSelected)
                {
                    // Vẽ các điểm trên đường biên của đối tượng
                    if (this is clsLine)
                    {
                        SolidBrush brush = new SolidBrush(Color.DarkRed);
                        g.FillRectangle(brush, p1.X - 3, p1.Y - 3, 7, 7);
                        g.FillRectangle(brush, p2.X - 3, p2.Y - 3, 7, 7);
                        brush.Dispose();
                    }
                    else if (this is clsRectangle || this is clsRectangleFr || this is clsEllipse || this is clsEllipseFr)
                    {
                        // Với đối tượng hình chữ nhật
                        SolidBrush brush = new SolidBrush(Color.DarkRed);
                        g.FillRectangle(brush, p1.X - 3, p1.Y - 3, 7, 7);
                        g.FillRectangle(brush, p1.X - 3, p2.Y - 3, 7, 7);
                        g.FillRectangle(brush, p2.X - 3, p1.Y - 3, 7, 7);
                        g.FillRectangle(brush, p2.X - 3, p2.Y - 3, 7, 7);
                        g.FillRectangle(brush, (p1.X + p2.X) / 2 - 3, p1.Y - 3, 7, 7); // Điểm giữa bên trên
                        g.FillRectangle(brush, (p1.X + p2.X) / 2 - 3, p2.Y - 3, 7, 7); // Điểm giữa bên dưới
                        g.FillRectangle(brush, p1.X - 3, (p1.Y + p2.Y) / 2 - 3, 7, 7); // Điểm giữa bên trái
                        g.FillRectangle(brush, p2.X - 3, (p1.Y + p2.Y) / 2 - 3, 7, 7); // Điểm giữa bên phải
                        // Vẽ khung hình chữ nhật bằng nét đứt, với khoảng cách là 5 pixel
                        Pen dashedPen = new Pen(Color.DarkGray, 1);
                        dashedPen.DashPattern = new float[] { 5.0F, 5.0F };
                        Rectangle rect = new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
                        g.DrawRectangle(dashedPen, rect);
                        dashedPen.Dispose(); // Hủy bỏ pen để tránh lãng phí tài nguyên hệ thống
                        brush.Dispose();
                    }
                    else if(this is clsCirFr || this is clsCir)
                    {
                        // Vẽ điểm giữa hình tròn
                        int diameter = Math.Max(p2.X - p1.X, p2.Y - p1.Y);
                        int radius = diameter / 2;
                        Point center = new Point(p1.X + radius, p1.Y + radius);
                        SolidBrush brush = new SolidBrush(Color.DarkRed);

                        // Tính toán các điểm bao quanh khung hình
                        int topLeftX = center.X - radius;
                        int topLeftY = center.Y - radius;
                        int topRightX = center.X + radius;
                        int topRightY = center.Y - radius;
                        int bottomLeftX = center.X - radius;
                        int bottomLeftY = center.Y + radius;
                        int bottomRightX = center.X + radius;
                        int bottomRightY = center.Y + radius;

                        // Vẽ các điểm bao quanh khung hình
                        g.FillRectangle(brush, topLeftX - 3, topLeftY - 3, 7, 7);
                        g.FillRectangle(brush, topRightX - 3, topRightY - 3, 7, 7);
                        g.FillRectangle(brush, bottomLeftX - 3, bottomLeftY - 3, 7, 7);
                        g.FillRectangle(brush, bottomRightX - 3, bottomRightY - 3, 7, 7);
                        g.FillRectangle(brush, (topLeftX + topRightX) / 2 - 3, topLeftY - 3, 7, 7); // Điểm giữa bên trên
                        g.FillRectangle(brush, (bottomLeftX + bottomRightX) / 2 - 3, bottomLeftY - 3, 7, 7); // Điểm giữa bên dưới
                        g.FillRectangle(brush, topLeftX - 3, (topLeftY + bottomLeftY) / 2 - 3, 7, 7); // Điểm giữa bên trái
                        g.FillRectangle(brush, topRightX - 3, (topRightY + bottomRightY) / 2 - 3, 7, 7); // Điểm giữa bên phải

                        // Vẽ khung hình vuông bao quanh hình tròn
                        Pen dashedPen = new Pen(Color.DarkGray, 1);
                        dashedPen.DashPattern = new float[] { 5.0F, 5.0F };
                        g.DrawRectangle(dashedPen, topLeftX, topLeftY, diameter, diameter);
                        dashedPen.Dispose();
                        brush.Dispose();
                    }    
                    else if (this is clsFreehand)
                    {
                        // Vẽ khung bao quanh hình vẽ tự do
                        int minX = Points.Min(p => p.X);
                        int minY = Points.Min(p => p.Y);
                        int maxX = Points.Max(p => p.X);
                        int maxY = Points.Max(p => p.Y);

                        int padding = 5; // Khoảng cách từ khung đến hình vẽ tự do
                                  
                        // Vẽ khung bao quanh bằng nét đứt, với khoảng cách là 5 pixel
                        Pen dashedPen = new Pen(Color.DarkGray, 1);
                        dashedPen.DashPattern = new float[] { 5.0F, 5.0F };
                        Rectangle rect = new Rectangle(minX - padding, minY - padding, maxX - minX + 2 * padding, maxY - minY + 2 * padding);
                        g.DrawRectangle(dashedPen, rect);
                        dashedPen.Dispose(); // Hủy bỏ pen để tránh lãng phí tài nguyên hệ thống
                        // Thêm các điểm bao quanh khung hình
                        List<Point> boundingPoints = new List<Point>();
                        boundingPoints.Add(new Point(rect.Left, rect.Top));
                        boundingPoints.Add(new Point(rect.Right, rect.Top));
                        boundingPoints.Add(new Point(rect.Right, rect.Bottom));
                        boundingPoints.Add(new Point(rect.Left, rect.Bottom));

                        // Vẽ các điểm bao quanh khung hình
                        SolidBrush brush = new SolidBrush(Color.DarkRed);
                        foreach (Point point in boundingPoints)
                        {
                            g.FillRectangle(brush, point.X - 3, point.Y - 3, 7, 7);
                        }
                        brush.Dispose();
                    }
                }
            }
            // Phương thức tính khoảng cách từ một điểm đến đối tượng
            public abstract float DistanceFromPoint(Point p);
            
            public Point GetClosestPointOnObject(Point p)
            {
                //Tính điểm trên đối tượng gần nhất với điểm p
                closestDistance = DistanceFromPoint(p);
                return closestPoint;
                
            }
            public const int RESIZE_PADDING = 5; // Tolerance for selecting resize points

            public virtual int getResizePointIndex(Point p)
            {
                Rectangle rect = new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));

                // Check each corner and edge for proximity to point p
                if (p.X < p1.X + RESIZE_PADDING && p.Y < p1.Y + RESIZE_PADDING)
                    return 0; // Top-left
                if (p.X > p2.X - RESIZE_PADDING && p.Y < p1.Y + RESIZE_PADDING)
                    return 1; // Top-right
                if (p.X < p1.X + RESIZE_PADDING && p.Y > p2.Y - RESIZE_PADDING)
                    return 2; // Bottom-left
                if (p.X > p2.X - RESIZE_PADDING && p.Y > p2.Y - RESIZE_PADDING)
                    return 3; // Bottom-right
                if (Math.Abs(p.X - p1.X) < RESIZE_PADDING && p.Y >= p1.Y + RESIZE_PADDING && p.Y <= p2.Y - RESIZE_PADDING)
                    return 4; // Left
                if (Math.Abs(p.X - p2.X) < RESIZE_PADDING && p.Y >= p1.Y + RESIZE_PADDING && p.Y <= p2.Y - RESIZE_PADDING)
                    return 5; // Right
                if (Math.Abs(p.Y - p1.Y) < RESIZE_PADDING && p.X >= p1.X + RESIZE_PADDING && p.X <= p2.X - RESIZE_PADDING)
                    return 6; // Top
                if (Math.Abs(p.Y - p2.Y) < RESIZE_PADDING && p.X >= p1.X + RESIZE_PADDING && p.X <= p2.X - RESIZE_PADDING)
                    return 7; // Bottom

                return -1; // No resize point found
            }
            private const int MIN_SIZE = 10;
            public virtual void resize(int index, Point p)
            {

                int x1 = p1.X;
                int x2 = p2.X;
                int y1 = p1.Y;
                int y2 = p2.Y;

                switch (index)
                {
                    case 0: // Top-left
                        x1 = Math.Min(p.X, p2.X - MIN_SIZE);
                        y2 = Math.Max(p.Y,p1.Y + MIN_SIZE);
                        break;

                    case 1: // Top-right
                        x2 = Math.Max(p.X,
                            p1.X + MIN_SIZE);
                        y1 = Math.Min(p.Y, p2.Y - MIN_SIZE);
                        break;

                    case 2: // Bottom-left
                        x1 = Math.Min(p.X, p2.X - MIN_SIZE);
                        y2 = Math.Max(p.Y, p1.Y + MIN_SIZE);
                        break;

                    case 3: // Bottom-right
                        x2 = Math.Max(p.X, p1.X + MIN_SIZE);
                        y2 = Math.Max(p.Y, p1.Y + MIN_SIZE);
                        break;

                    case 4: // Left
                        x1 = Math.Min(p.X, p2.X - MIN_SIZE);
                        break;

                    case 5: // Right
                        x2 = Math.Max(p.X, p1.X + MIN_SIZE);
                        break;

                    case 6: // Top
                        y1 = Math.Min(p.Y, p2.Y - MIN_SIZE);
                        break;

                    case 7: // Bottom
                        y2 = Math.Max(p.Y, p1.Y + MIN_SIZE);
                        break;

                    default:
                        break;
                }

                p1 = new Point(x1, y1);
                p2 = new Point(x2, y2);
            }
        };
        public class clsFreehand : clsDrawObject
        {

            public clsFreehand()
            {
                Points = new List<Point>();
            }

            public override void Draw(Graphics myGp, Pen myPen, SolidBrush myBrush, Color myColor)
            {
                myPen.Color = color;
                if (Points.Count > 1)
                {
                    myGp.DrawLines(myPen, Points.ToArray());
                }
            }

            public override bool IsPointInObject(Point p)
            {
                // Kiểm tra xem điểm p có nằm trong đường cong của đối tượng tự do hay không
                GraphicsPath path = new GraphicsPath();
                path.AddCurve(Points.ToArray());

                bool isPointInObject = path.IsVisible(p);
                path.Dispose();

                return isPointInObject;
            }

            public override void Move(int dx, int dy)
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    Points[i] = new Point(Points[i].X + dx, Points[i].Y + dy);
                }
            }
            public override float DistanceFromPoint(Point p)
            {
                throw new NotImplementedException();
            }
        }
        public class clsLine : clsDrawObject
        {
            public override void Draw(Graphics myGp, Pen myPen, SolidBrush myBrush, Color myColor)
            {
                base.Draw(myGp, myPen, myBrush, myColor);
                myGp.DrawLine(myPen, this.p1, this.p2);
                // Vẽ đường thẳng
            }
            public override void Move(int dx, int dy)
            {
                base.Move(dx, dy);
            }
            public override float DistanceFromPoint(Point p)
            {
                // Tính khoảng cách từ điểm p đến đường thẳng
                float dx = p2.X - p1.X;
                float dy = p2.Y - p1.Y;
                float t = (dx * (p.X - p1.X) + dy * (p.Y - p1.Y)) / (dx * dx + dy * dy);
                if (t < 0)
                {
                    closestPoint = p1;
                }
                else if (t > 1)
                {
                    closestPoint = p2;
                }
                else
                {
                    closestPoint = new Point((int)(p1.X + t * dx), (int)(p1.Y + t * dy));
                }
                return (float)Math.Sqrt((closestPoint.X - p.X) * (closestPoint.X - p.X) + (closestPoint.Y - p.Y) * (closestPoint.Y - p.Y));
            }

        };
        public class clsRectangleFr : clsDrawObject
        {
            public override void Draw(Graphics myGp, Pen myPen, SolidBrush myBrush, Color myColor)
            {
                base.Draw(myGp, myPen, myBrush, myColor);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);
                if (p2.X < p1.X && p2.Y < p1.Y)
                {
                    //myGp.FillRectangle(myBrush, p2.X, p2.Y, width, height);
                    myGp.DrawRectangle(myPen, p2.X, p2.Y, width, height);
                }
                else if (p2.X < p1.X && p2.Y > p1.Y)
                {
                    //myGp.FillRectangle(myBrush, p2.X, p1.Y, width, height);
                    myGp.DrawRectangle(myPen, p2.X, p1.Y, width, height);
                }
                else if (p2.X > p1.X && p2.Y < p1.Y)
                {
                    //myGp.FillRectangle(myBrush, p1.X, p2.Y, width, height);
                    myGp.DrawRectangle(myPen, p1.X, p2.Y, width, height);
                }
                else
                {
                    //myGp.FillRectangle(myBrush, p1.X, p1.Y, width, height);
                    myGp.DrawRectangle(myPen, p1.X, p1.Y, width, height);
                }
               
            }
            public override bool IsPointInObject(Point p)
            {
                // kiểm tra vị trí của p có nằm trong đối tượng hay không
                Rectangle rect = new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
                return rect.Contains(p);
            }
            public override void Move(int dx, int dy)
            {
                base.Move(dx, dy);
            }
            public override float DistanceFromPoint(Point p)
            {
                float dx1 = Math.Max(p1.X - p.X, 0);
                float dx2 = Math.Max(p.X - p2.X, 0);
                float dx = Math.Max(dx1, dx2);

                float dy1 = Math.Max(p1.Y - p.Y, 0);
                float dy2 = Math.Max(p.Y - p2.Y, 0);
                float dy = Math.Max(dy1, dy2);
                return (float)Math.Sqrt(dx * dx + dy * dy);
            }
            public override void resize(int index, Point p)
            {
                base.resize(index, p);
            }
        };
        public class clsRectangle : clsDrawObject
        {
            public override void resize(int index, Point p)
            {
                base.resize(index, p);
            }
            public override void Draw(Graphics myGp, Pen myPen, SolidBrush myBrush, Color myColor)
            {
                base.Draw(myGp, myPen, myBrush, myColor);
                myBrush = new SolidBrush(color);
                int width = Math.Abs(p2.X - p1.X);
                int height = Math.Abs(p2.Y - p1.Y);
                if (p2.X < p1.X && p2.Y < p1.Y)
                {
                    myGp.FillRectangle(myBrush, p2.X, p2.Y, width, height);
                    myGp.DrawRectangle(myPen, p2.X, p2.Y, width, height);
                }
                else if (p2.X < p1.X && p2.Y > p1.Y)
                {
                    myGp.FillRectangle(myBrush, p2.X, p1.Y, width, height);
                    myGp.DrawRectangle(myPen, p2.X, p1.Y, width, height);
                }
                else if (p2.X > p1.X && p2.Y < p1.Y)
                {
                    myGp.FillRectangle(myBrush, p1.X, p2.Y, width, height);
                    myGp.DrawRectangle(myPen, p1.X, p2.Y, width, height);
                }
                else
                {
                    myGp.FillRectangle(myBrush, p1.X, p1.Y, width, height);
                    myGp.DrawRectangle(myPen, p1.X, p1.Y, width, height);
                }            
            }
            public override bool IsPointInObject(Point p)
            {
                // kiểm tra vị trí của p có nằm trong đối tượng hay không
                Rectangle rect = new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
                return rect.Contains(p);
            }
            public override void Move(int dx, int dy)
            {
                base.Move(dx, dy);
            }
            public override float DistanceFromPoint(Point p)
            {
                float dx1 = Math.Max(p1.X - p.X, 0);
                float dx2 = Math.Max(p.X - p2.X, 0);
                float dx = Math.Max(dx1, dx2);

                float dy1 = Math.Max(p1.Y - p.Y, 0);
                float dy2 = Math.Max(p.Y - p2.Y, 0);
                float dy = Math.Max(dy1, dy2);
                return (float)Math.Sqrt(dx * dx + dy * dy);
            }
        };
        public class clsEllipseFr : clsDrawObject
        {
            public override void resize(int index, Point p)
            {
                base.resize(index, p);
            }
            public override void Draw(Graphics myGp, Pen myPen, SolidBrush myBrush, Color myColor)
            {
                base.Draw(myGp, myPen, myBrush, myColor);
                myGp.DrawEllipse(myPen, this.p1.X, this.p1.Y, this.p2.X - this.p1.X, this.p2.Y - this.p1.Y);
            }
            public override bool IsPointInObject(Point p)
            {
                // kiểm tra vị trí của p có nằm trong đối tượng hay không
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
                bool result = path.IsVisible(p);
                path.Dispose();
                return result;
            }
            public override void Move(int dx, int dy)
            {
                base.Move(dx, dy);
            }
            public override float DistanceFromPoint(Point p)
            {
                float dx = p.X - (p1.X + (p2.X - p1.X) / 2);
                float dy = p.Y - (p1.Y + (p2.Y - p1.Y) / 2);
                float rx = (p2.X - p1.X) / 2;
                float ry = (p2.Y - p1.Y) / 2;
                return (float)Math.Sqrt((dx * dx) / (rx * rx) + (dy * dy) / (ry * ry));
            }
        };
        public class clsEllipse : clsDrawObject
        {
            public override void Draw(Graphics myGp, Pen myPen, SolidBrush myBrush, Color myColor)
            {
                myBrush = new SolidBrush(color);
                myGp.FillEllipse(myBrush, this.p1.X, this.p1.Y, this.p2.X - this.p1.X, this.p2.Y - this.p1.Y);
                base.Draw(myGp, myPen, myBrush, myColor);
            }
            public override bool IsPointInObject(Point p)
            {
                // kiểm tra vị trí của p có nằm trong đối tượng hay không
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
                bool result = path.IsVisible(p);
                path.Dispose();
                return result;
            }
            public override void Move(int dx, int dy)
            {
                base.Move(dx, dy);
            }
            public override float DistanceFromPoint(Point p)
            {
                float dx = p.X - (p1.X + (p2.X - p1.X) / 2);
                float dy = p.Y - (p1.Y + (p2.Y - p1.Y) / 2);
                float rx = (p2.X - p1.X) / 2;
                float ry = (p2.Y - p1.Y) / 2;
                return (float)Math.Sqrt((dx * dx) / (rx * rx) + (dy * dy) / (ry * ry));
            }
            public override void resize(int index, Point p)
            {
                base.resize(index, p);
            }
        };
        public class clsCirFr : clsDrawObject
        {
            public override void Draw(Graphics myGp, Pen myPen, SolidBrush myBrush, Color myColor)
            {
                base.Draw(myGp, myPen, myBrush, myColor);
                int diameter = Math.Max(p2.X - p1.X, p2.Y - p1.Y); // Sử dụng chiều dài cạnh lớn nhất làm đường kính cho hình tròn
                myGp.DrawEllipse(myPen, this.p1.X, this.p1.Y, diameter, diameter);
            }
            public override bool IsPointInObject(Point p)
            {
                // kiểm tra vị trí của p có nằm trong đối tượng hay không
                GraphicsPath path = new GraphicsPath();
                int diameter = Math.Max(p2.X - p1.X, p2.Y - p1.Y);
                path.AddEllipse(p1.X, p1.Y, diameter, diameter);
                bool result = path.IsVisible(p);
                path.Dispose();
                return result;
            }
            public override void Move(int dx, int dy)
            {
                base.Move(dx, dy);
            }
            public override float DistanceFromPoint(Point p)
            {
                int diameter = Math.Max(p2.X - p1.X, p2.Y - p1.Y);
                float dx = p.X - (p1.X + diameter / 2);
                float dy = p.Y - (p1.Y + diameter / 2);
                float radius = diameter / 2;
                return (float)Math.Sqrt(dx * dx + dy * dy) - radius;
            }

        };
        public class clsCir : clsDrawObject
        {
            public override void Draw(Graphics myGp, Pen myPen, SolidBrush myBrush, Color myColor)
            {
                myBrush = new SolidBrush(color);
                base.Draw(myGp, myPen, myBrush, myColor);
                int diameter = Math.Max(p2.X - p1.X, p2.Y - p1.Y);
                myGp.DrawEllipse(myPen, p1.X, p1.Y, diameter, diameter); // Vẽ hình tròn
                myGp.FillEllipse(myBrush, p1.X, p1.Y, diameter, diameter); // Tô màu cho hình tròn
            }

            public override bool IsPointInObject(Point p)
            {
                int diameter = Math.Max(p2.X - p1.X, p2.Y - p1.Y);
                float radius = diameter / 2;
                float dx = p.X - (p1.X + radius);
                float dy = p.Y - (p1.Y + radius);
                float distance = (float)Math.Sqrt(dx * dx + dy * dy);
                return distance <= radius;
            }

            public override void Move(int dx, int dy)
            {
                base.Move(dx, dy);
            }

            public override float DistanceFromPoint(Point p)
            {
                int diameter = Math.Max(p2.X - p1.X, p2.Y - p1.Y);
                float radius = diameter / 2;
                float dx = p.X - (p1.X + radius);
                float dy = p.Y - (p1.Y + radius);
                float distance = (float)Math.Sqrt(dx * dx + dy * dy) - radius;
                return Math.Abs(distance);
            }

        };
        

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstObject.Clear();
            ptBox.Refresh();
        }
        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Clear All", btnClear);
            btnClear.FlatAppearance.MouseOverBackColor = Color.Pink;
        }
        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.FlatAppearance.BorderColor = Color.White;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gp = this.ptBox.CreateGraphics();
            gp.Clear(Color.White);
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(this.ptBox.Width, this.ptBox.Height);
                this.ptBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                ImageFormat format = null;
                string ext = Path.GetExtension(sfd.FileName);
                switch (ext.ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                bmp.Save(sfd.FileName, format);
            }
        }
        private void btnSaveImage_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Save Image", btnSaveImage);
            btnSaveImage.FlatAppearance.MouseOverBackColor = Color.Pink;
        }

        private void btnSaveImage_MouseLeave(object sender, EventArgs e)
        {
            btnSaveImage.FlatAppearance.BorderColor = Color.White;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {

        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có đối tượng nào được chọn không
            foreach (clsDrawObject obj in lstObject)
            {
                if (obj.IsSelected)
                {
                    // Xóa đối tượng khỏi danh sách và vẽ lại ptBox
                    lstObject.Remove(obj);
                    ptBox.Invalidate();
                    break;
                }
            }
        }
        private void btn_Delete_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Delete", btn_Delete);
            btn_Delete.FlatAppearance.MouseOverBackColor = Color.Pink;
        }
        private void btn_Delete_MouseLeave(object sender, EventArgs e)
        {
            btn_Delete.FlatAppearance.BorderColor = Color.White;
        }

        private void btnPolygon_Click(object sender, EventArgs e)
        {
        }

        private void btnColor_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Color", btnColor);
            btnColor.FlatAppearance.MouseOverBackColor = Color.Pink;
        }

        private void btnColor_MouseLeave(object sender, EventArgs e)
        {
            btnColor.FlatAppearance.BorderColor = Color.White;
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            this.bPen = true;
            this.bLine = false;
            this.bEllipseFr = false;
            this.bEllipse = false;
            this.bRectFr = false;
            this.bRect = false;
            this.bCirFr = false;
            this.bCir = false;
        }
        private void btnPen_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Color", btnPen);
            btnPen.FlatAppearance.MouseOverBackColor = Color.Pink;
        }
        private void btnPen_MouseLeave(object sender, EventArgs e)
        {
            btnPen.FlatAppearance.BorderColor = Color.White;
        }

        private void btnCirFr_Click(object sender, EventArgs e)
        {
            this.bCirFr = true;
            this.bLine = false;
            this.bEllipseFr = false;
            this.bEllipse = false;
            this.bRectFr = false;
            this.bRect = false;
            this.bCir = false;
            this.bPen = false;
        }

        private void btnCir_Click(object sender, EventArgs e)
        {
            this.bCir = true;
            this.bLine = false;
            this.bEllipseFr = false;
            this.bEllipse = false;
            this.bRectFr = false;
            this.bRect = false;
            this.bCirFr = false;
            this.bPen = false;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnCirFr_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Circle Frame", btnCirFr);
            btnCirFr.FlatAppearance.MouseOverBackColor = Color.Pink;
        }

        private void btnCirFr_MouseLeave(object sender, EventArgs e)
        {
            btnCirFr.FlatAppearance.BorderColor = Color.White;
        }

        private void btnCir_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Circle", btnCir);
            btnCir.FlatAppearance.MouseOverBackColor = Color.Pink;
        }

        private void btnCir_MouseLeave(object sender, EventArgs e)
        {
            btnCir.FlatAppearance.BorderColor = Color.White;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (selectedObject != null)
            {
                float newThickness = (float)numericUpDown1.Value;
                selectedObject.Thickness = newThickness;
                this.Invalidate();
            }
        }
    }
}

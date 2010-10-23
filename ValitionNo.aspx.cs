using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.IO;

public partial class ValitionNo : System.Web.UI.Page
{
    string tcheckCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        CodeImage(CheckCode());
        StreamWriter sw;
        sw = File.CreateText(Server.MapPath("Source/Login/") + "checkCode.txt");
        sw.WriteLine(tcheckCode);
        sw.Close();
    }
    private string CheckCode()
    {
        int number;
        char code;
        string checkCode = string.Empty;
        tcheckCode = string.Empty;
        Random random = new Random();
        for (int i = 0; i < 4; i++)
        {
            number = random.Next();
            if (number % 2 == 0)
            {
                code = (char)('0' + (char)(number % 10));
            }
            else
            {
                code = (char)('A' + (char)(number % 26));
            }
            checkCode += " " + code.ToString();
            tcheckCode += code.ToString();
        }
        return checkCode;
    }
    private void CodeImage(string checkCode)
    {
        System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 10.0)), 20);
        Graphics g = Graphics.FromImage(image);
        try
        {
            Random random = new Random();

            g.Clear(Color.White);

            //画图片的背景噪音线
            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);

                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
            g.DrawString(checkCode, font, brush, 2, 2);

            //画图片的前景噪音点
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }

            //画图片的边框线
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(Server.MapPath("Source/Login") + "/VaImg.gif", System.Drawing.Imaging.ImageFormat.Gif);
            image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);

        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Util;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.IO.Ports;

namespace IAProject
{
    public partial class Main : Form
    {
        /* For handeling the Serial Port */
        public System.IO.Ports.SerialPort sport;



        #region Variables
        Capture capture; //Webcam Variable
        Timer ImageTimer; //Timer to click pictures
        Image<Bgr, Byte> MyImage;
        Image<Gray, Byte> Mask;
        Image<Bgr, Byte> MyImageRegion;
        Image<Gray, Byte> MyMaskRegion;

        private HaarCascade haar; //To detect the face using Haar Method

        Seq<Point> Hull;
        Seq<MCvConvexityDefect> Defects;
        Seq<Point> filteredHull;

        int fingerNum; //Global Number of fingers.

        MCvConvexityDefect[] DefectArray;
        #endregion

        public Main()
        {
            InitializeComponent();//Intializes the form UI.
            capture = new Capture(0); //create a camera capture

            capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 1280);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 720);


            haar = new HaarCascade("C:\\Emgu\\emgucv-windows-universal-cuda 2.9.0.1922\\opencv\\data\\haarcascades\\haarcascade_frontalface_default.xml");
            ArrayList Images = new ArrayList();


            //Serial setiings
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                txtPort.Items.Add(s);
            }
            labelHide();

        }
        public void serialport_connect(String port, int baudrate, Parity parity, int databits, StopBits stopbits)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            sport = new System.IO.Ports.SerialPort(
            port, baudrate, parity, databits, stopbits);

            try
            {
                sport.Open();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error"); }
        }


        public void ImageTimer_Tick(object sender, EventArgs e)
        {
            //MyImage = I;
            MyImage= capture.QueryFrame();
            if (MyImage != null)
            {
                imageBox1.Image = MyImage;
                //Remove the face out of the image
                Image<Bgr, Byte> MyNoFaceImage = RemoveFace(MyImage);
                imageBox2.Image = MyNoFaceImage;
                //Take the skin out of the without face image
                Mask = SkinDetect(MyNoFaceImage, new Ycc(0, 131, 80), new Ycc(255, 185, 135), 1);//Grayscale Image
                imageBox4.Image = Mask;
                //Extracting the canny edges
                Image<Gray, Byte> CannyImage = new Image<Gray, Byte>(Mask.Size);
                CvInvoke.cvCanny(Mask, CannyImage, 30, 60, 3);
                imageBox5.Image = CannyImage;
                //Getting the mask
                MyMaskRegion = GetMask();
                imageBox6.Image = MyMaskRegion;
                imageBox7.Image = MyImageRegion;
                if (MyImageRegion != null)
                {
                    MyImageRegion.Resize(100, 100, INTER.CV_INTER_CUBIC);
                }
                ExtractFingerNumber(MyMaskRegion);

                imageBox1.SizeMode = PictureBoxSizeMode.Zoom;
                imageBox2.SizeMode = PictureBoxSizeMode.Zoom;
                imageBox3.SizeMode = PictureBoxSizeMode.Zoom;
                imageBox4.SizeMode = PictureBoxSizeMode.Zoom;
                imageBox5.SizeMode = PictureBoxSizeMode.Zoom;
                imageBox6.SizeMode = PictureBoxSizeMode.Zoom;
                imageBox7.SizeMode = PictureBoxSizeMode.Zoom;





            }
        }

        
        private Image<Bgr, Byte> RemoveFace(Image<Bgr, Byte> Input)
        {
            Image<Bgr, Byte> Output = Input.Copy();
            Image<Gray, Byte> GrayImage = Input.Convert<Gray, Byte>();
            var faces = GrayImage.DetectHaarCascade(
                haar, 1.4, 4,
                HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(Input.Width / 8, Input.Height / 8))[0];
            foreach (var face in faces)
            {
                Rectangle R = face.rect;
                Ellipse E = new Ellipse(new PointF(R.Location.X + R.Width / 2, R.Location.Y + R.Width / 2), new SizeF(R.Width, (int)(R.Height * 1.2)), 90);
                Output.Draw(E, new Bgr(Color.Black), -1);
            }
            return Output;
        }


        private Image<Gray, Byte> SkinDetect(Image<Bgr, Byte> Input, IColor min, IColor max, int a)
        {
            Image<Gray, byte> skin = new Image<Gray, byte>(Input.Width, Input.Height);
            if (a == 1)
            {
                Image<Ycc, Byte> YCrCbInput = Input.Convert<Ycc, Byte>();
                skin = YCrCbInput.InRange((Ycc)min, (Ycc)max);
            }
            else
            {
                Image<Hsv, Byte> HsvInput = Input.Convert<Hsv, Byte>();
                skin = HsvInput.InRange((Hsv)min, (Hsv)max);
            }

            Image<Gray, Byte> skin2 = skin.Convert<Gray, Byte>();
            imageBox3.Image = skin2;

            StructuringElementEx Rect12 = new StructuringElementEx(12, 12, 6, 6, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_CROSS);
            StructuringElementEx Rect6 = new StructuringElementEx(6, 6, 3, 3, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_CROSS);

            CvInvoke.cvErode(skin, skin, Rect6, 1);
            CvInvoke.cvDilate(skin, skin, Rect12, 1);
            
            return skin;
        }

        private Image<Gray, Byte> GetMask()
        {

            using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
            {
                Contour<Point> contours = Mask.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage);
                Contour<Point> Big = null;

                Double BigArea = 0;

                while (contours != null)
                {
                    if (contours.Area > BigArea)
                    {
                        BigArea = contours.Area;
                        Big = contours;
                    }
                    contours = contours.HNext;
                }

                if (Big != null)
                {
                    Contour<Point> currentContour = Big.ApproxPoly(Big.Perimeter * 0.0035, storage);
                    MyImage.Draw(currentContour, new Bgr(Color.LimeGreen), 5);
                    var Ract = currentContour.BoundingRectangle;
                    int Diff = Ract.Height - Ract.Width;

                    if (Diff < 0)
                    {
                        Ract.Height += Math.Abs(Diff);
                        Ract.Y -= Math.Abs(Diff) / 2;
                        if (Ract.Y < 0) { Ract.Y = 0; }
                        if (Ract.Y + Ract.Height > MyImage.Height) { Ract.Y = MyImage.Height - Ract.Height; }
                    }
                    else
                    {
                        Ract.Width += Math.Abs(Diff);
                        Ract.X -= Math.Abs(Diff) / 2;
                        if (Ract.X < 0) { Ract.X = 0; }
                        if (Ract.X + Ract.Width > MyImage.Width) { Ract.X = MyImage.Width - Ract.Width; }
                    }

                    Ract.Inflate(new Size(40, 40));
                    MyImageRegion = MyImage.Copy();
                    Image<Gray, Byte> MYROI = Mask.Copy();
                    MyImageRegion.ROI = Ract;
                    MYROI.ROI = Ract;
                    return MYROI;
                }
            }
            return null;
        }

        private void ExtractFingerNumber(Image<Gray, Byte> MyMask)
        {
            using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
            {
                Contour<Point> contours = null;
                try
                {
                    contours = MyMask.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage);
                }
                catch (Exception ex){
                    
                }
                Contour<Point> Big = null;
                Double BigArea = 0;

                Contour<Point> Small = null;
                Double SmallArea = 100000;

                while (contours != null)
                {
                    if (contours.Area > BigArea)
                    {
                        BigArea = contours.Area;
                        Big = contours;
                    }
                    if ((contours.Area < SmallArea)&&(contours.Area>40))
                    {
                        SmallArea = contours.Area;
                        Small = contours;
                    }
                    contours = contours.HNext;
                }


                CircleF This = new CircleF() ;

                if (Big != null)
                {
                    Contour<Point> currentContour = Big.ApproxPoly(Big.Perimeter * 0.0025, storage);
                    MyImageRegion.Draw(currentContour, new Bgr(Color.LimeGreen), 5);

                    MCvMoments moment = new MCvMoments();               // a new MCvMoments object

                    moment = Big.GetMoments();           // Moments of biggestContour

                    CvInvoke.cvMoments(Big, ref moment, 0);

                    double m_00 = CvInvoke.cvGetSpatialMoment(ref moment, 0, 0);
                    double m_10 = CvInvoke.cvGetSpatialMoment(ref moment, 1, 0);
                    double m_01 = CvInvoke.cvGetSpatialMoment(ref moment, 0, 1);

                    int current_X = Convert.ToInt32(m_10 / m_00) / 10;      // X location of centre of contour              
                    int current_Y = Convert.ToInt32(m_01 / m_00) / 10;      // Y location of center of contour

                    Hull = Big.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
                    Defects = Big.GetConvexityDefacts(storage, Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);

                    DefectArray = Defects.ToArray();
                    MCvBox2D box = Big.GetMinAreaRect();

                    MyImageRegion.DrawPolyline(Hull.ToArray(), true, new Bgr(200, 125, 75), 2);
                    //MyImage.DrawPolyline(Defects.ToArray(), true, new Bgr(255, 255, 0), 2);

                    List<CircleF> SmallPoints = new List<CircleF>();
                    List<CircleF> BigPoints=new List<CircleF>();
                    List<LineSegment2D> FingerLines=new List<LineSegment2D>();

                    Double angled=0;
                    fingerNum = 0;                 for (int i = 0; i < DefectArray.Length; i++)
                    {
                        PointF startPoint = new PointF((float)DefectArray[i].StartPoint.X, (float)DefectArray[i].StartPoint.Y);
                        PointF depthPoint = new PointF((float)DefectArray[i].DepthPoint.X, (float)DefectArray[i].DepthPoint.Y);
                        PointF endPoint = new PointF((float)DefectArray[i].EndPoint.X, (float)DefectArray[i].EndPoint.Y);

                        LineSegment2D startDepthLine = new LineSegment2D(DefectArray[i].StartPoint, DefectArray[i].DepthPoint);
                        LineSegment2D depthEndLine = new LineSegment2D(DefectArray[i].DepthPoint, DefectArray[i].EndPoint);

                        
                        CircleF startCircle = new CircleF(startPoint, 5f);
                        CircleF depthCircle = new CircleF(depthPoint, 5f);
                        CircleF endCircle = new CircleF(endPoint, 5f);
                        

                        if ((startCircle.Center.Y < box.center.Y || depthCircle.Center.Y < box.center.Y) && (startCircle.Center.Y < depthCircle.Center.Y) && (Math.Sqrt(Math.Pow(startCircle.Center.X - depthCircle.Center.X, 2) + Math.Pow(startCircle.Center.Y - depthCircle.Center.Y, 2)) > box.size.Height / 7))
                        {
                            fingerNum++;
                            MyImageRegion.Draw(startDepthLine, new Bgr(Color.Black), 2);
                            SmallPoints.Add(depthCircle);
                            BigPoints.Add(startCircle);
                            FingerLines.Add(startDepthLine);
                        }
                    }

                    foreach (CircleF a in SmallPoints)
                    {
                        MyImageRegion.Draw(a, new Bgr(Color.Yellow), 5);
                    }

                    foreach (CircleF a in BigPoints)
                    {
                        MyImageRegion.Draw(a, new Bgr(Color.Red), 5);
                    }

                    MyImageRegion.Draw(This, new Bgr(Color.Pink), 15);
                    label2.Text="";
                    if (fingerNum == 5)
                    {
                        byte[] arr = { 5 };
                        sport.Write(arr, 0, arr.Length);
                        System.Threading.Thread.Sleep(120);
                        label2.Text = "Five " ;
                    }

                    if (fingerNum == 0)
                    {
                        if (box.size.Height / box.size.Width > 1.5)
                        {
                            byte[] arr = { 0 };
                            sport.Write(arr, 0, arr.Length);
                            System.Threading.Thread.Sleep(120);
                            label2.Text = "Zero ";

                        }
                        else
                        {
                            label2.Text = "Zero";
                            byte[] arr = { 0 };
                            System.Threading.Thread.Sleep(120);
                            sport.Write(arr, 0, arr.Length);

                        }
                    }
                    if (fingerNum == 3)
                    {

                        byte[] arr = { 3 };
                        sport.Write(arr, 0, arr.Length);
                        System.Threading.Thread.Sleep(120);
                        label2.Text = "Three";
                    }

                    if (fingerNum == 2)
                    {
                        if((Math.Abs(FingerLines[0].GetExteriorAngleDegree(FingerLines[1]))<100)&&(Math.Abs(FingerLines[0].GetExteriorAngleDegree(FingerLines[1]))>70))
                        {
                            byte[] arr = { 2 };
                            sport.Write(arr, 0, arr.Length);
                            System.Threading.Thread.Sleep(120);
                            label2.Text = "Gun";

                        }
                        if ((Math.Abs(FingerLines[0].GetExteriorAngleDegree(FingerLines[1])) < 50) && (Math.Abs(FingerLines[0].GetExteriorAngleDegree(FingerLines[1])) > 20))
                        {
                            byte[] arr = { 2 };
                            sport.Write(arr, 0, arr.Length);
                            System.Threading.Thread.Sleep(120);
                            label2.Text = "Vectory Sign";

                        }
                    }

                    if (fingerNum ==1 )
                    {
                        byte[] arr = { 1 };
                        sport.Write(arr, 0, arr.Length);
                        System.Threading.Thread.Sleep(200);
                        label2.Text = "One";

                    }

                    if (fingerNum == 4)
                    {
                        byte[] arr = { 4 };
                        sport.Write(arr, 0, arr.Length);
                        System.Threading.Thread.Sleep(200);
                        label2.Text = "Four";
                    }

                    label1.Text = fingerNum.ToString();
                }
            }
        }










        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                
            errorProvider1.Clear();
            if (labelHide())
            {
                labelShow();
            }
            String port = txtPort.Text;
            int baudrate = 9600;
            Parity parity = (Parity)Enum.Parse(typeof(Parity), "None");
            int databits = 8;
            StopBits stopbits = (StopBits)Enum.Parse(typeof(StopBits), "One");

            serialport_connect(port, baudrate, parity, databits, stopbits);


            ImageTimer = new Timer();
            ImageTimer.Interval = 1000 / 24;
            ImageTimer.Tick += new EventHandler(ImageTimer_Tick);
            ImageTimer.Start();
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(label2, ex.Message);
                
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (sport.IsOpen)
            {
                byte[] arr = { 0 };
                sport.Write(arr, 0, arr.Length);
                System.Threading.Thread.Sleep(50);
                sport.Close();
            }
            ImageTimer.Stop();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {

            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            
        }

       private bool labelHide()
        {
            lblCam1.Visible = false;
            lblCam2.Visible = false;
            lblCam3.Visible = false;
            lblCam4.Visible = false;
            lblCam5.Visible = false;
            lblCam6.Visible = false;
            lblCam7.Visible = false;
            return true;
        }
       private void labelShow()
       {
           lblCam1.Visible = true;
           lblCam2.Visible = true;
           lblCam3.Visible = true;
           lblCam4.Visible = true;
           lblCam5.Visible = true;
           lblCam6.Visible = true;
           lblCam7.Visible = true;
       }
    }
}

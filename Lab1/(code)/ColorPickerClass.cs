using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using ColorHelper;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.WebSockets;

namespace ColorPicker
{
    public partial class ColorPickerClass : Form
    {
        bool valuesReadyForChanges = true;

        public ColorPickerClass()
        {
            InitializeComponent();
        }
        //color change function
        private void colorChange()
        {
            byte r = (byte)rgbRValue.Value;
            byte g = (byte)rgbGValue.Value;
            byte b = (byte)rgbBValue.Value;

            selectedColor.BackColor = Color.FromArgb(r, g, b);
        }
        //values change operations
        private void hsvValuesChange(HSV hsv)
        {
            hsvHValue.Value = hsv.H;
            hsvHTrackBar.Value = hsv.H;

            hsvSValue.Value = hsv.S;
            hsvSTrackBar.Value = hsv.S;

            hsvVValue.Value = hsv.V;
            hsvVTrackBar.Value = hsv.V;
        }
        private void hslValuesChange(HSL hsl)
        {
            hslHValue.Value = hsl.H;
            hslHTrackBar.Value = hsl.H;

            hslSValue.Value = hsl.S;
            hslSTrackBar.Value = hsl.S;

            hslLValue.Value = hsl.L;
            hslLTrackBar.Value = hsl.L;
        }
        private void xyzValuesChange(XYZ xyz)
        {
            xyzXValue.Value = (decimal)xyz.X;
            xyzXTrackBar.Value = (int)(xyz.X * 100.0);

            xyzYValue.Value = (decimal)xyz.Y;
            xyzYTrackBar.Value = (int)(xyz.Y * 100.0);

            xyzZValue.Value = (decimal)xyz.Z;
            xyzZTrackBar.Value = (int)(xyz.Z*100.0);
        }
        private void rgbValuesChange(RGB rgb)
        {
            rgbRValue.Value = rgb.R;
            rgbRTrackBar.Value = rgb.R;

            rgbGValue.Value = rgb.G;
            rgbGTrackBar.Value = rgb.G;

            rgbBValue.Value = rgb.B;
            rgbBTrackBar.Value = rgb.B;
        }
        private void cmykValuesChange(CMYK cmyk)
        {
            cmykCValue.Value = cmyk.C;
            cmykCTrackBar.Value = cmyk.C;

            cmykMValue.Value = cmyk.M;
            cmykMTrackBar.Value = cmyk.M;

            cmykYValue.Value = cmyk.Y;
            cmykYTrackBar.Value = cmyk.Y;

            cmykKValue.Value = cmyk.K;
            cmykKTrackBar.Value = cmyk.K;
        }
        private void yiqValuesChange(YIQ yiq)
        {
            yiqYValue.Value = (decimal)yiq.Y;
            yiqYTrackBar.Value = (int)(yiq.Y * 100.0);

            yiqIValue.Value = (decimal)yiq.I;
            yiqITrackBar.Value = (int)(yiq.I * 100.0);

            yiqQValue.Value = (decimal)yiq.Q;
            yiqQTrackBar.Value = (int)(yiq.Q * 100.0);
        }
        //events of changing the values ​​of other color models
        private void xyzValuesChangedEvent()
        {
            double x = (double)xyzXValue.Value;
            double y = (double)xyzYValue.Value;
            double z = (double)xyzZValue.Value;
            XYZ xyz = new XYZ(x, y, z);

            HSL hsl = ColorHelper.ColorConverter.XyzToHsl(xyz);
            HSV hsv = ColorHelper.ColorConverter.XyzToHsv(xyz);
            RGB rgb = ColorHelper.ColorConverter.XyzToRgb(xyz);
            CMYK cmyk = ColorHelper.ColorConverter.XyzToCmyk(xyz);
            YIQ yiq = ColorHelper.ColorConverter.XyzToYiq(xyz);

            rgbValuesChange(rgb);
            hslValuesChange(hsl);
            hsvValuesChange(hsv);
            cmykValuesChange(cmyk);
            yiqValuesChange(yiq);

            colorChange();
            valuesReadyForChanges = true;
        }
        private void rgbValuesChangedEvent()
        {
            byte r = (byte)rgbRValue.Value;
            byte g = (byte)rgbGValue.Value;
            byte b = (byte)rgbBValue.Value;
            RGB rgb = new RGB(r, g, b);

            HSL hsl = ColorHelper.ColorConverter.RgbToHsl(rgb);
            HSV hsv = ColorHelper.ColorConverter.RgbToHsv(rgb);
            XYZ xyz = ColorHelper.ColorConverter.RgbToXyz(rgb);
            CMYK cmyk = ColorHelper.ColorConverter.RgbToCmyk(rgb);
            YIQ yiq = ColorHelper.ColorConverter.RgbToYiq(rgb);

            hslValuesChange(hsl);
            hsvValuesChange(hsv);
            xyzValuesChange(xyz);
            cmykValuesChange(cmyk);
            yiqValuesChange(yiq);

            colorChange();
            valuesReadyForChanges = true;
        }
        private void hslValuesChangedEvent()
        {
            int h = (int)hslHValue.Value;
            byte s = (byte)hslSValue.Value;
            byte l = (byte)hslLValue.Value;
            HSL hsl = new HSL(h, s, l);

            RGB rgb = ColorHelper.ColorConverter.HslToRgb(hsl);
            HSV hsv = ColorHelper.ColorConverter.HslToHsv(hsl);
            XYZ xyz = ColorHelper.ColorConverter.HslToXyz(hsl);
            CMYK cmyk = ColorHelper.ColorConverter.HslToCmyk(hsl);
            YIQ yiq = ColorHelper.ColorConverter.HslToYiq(hsl);

            cmykValuesChange(cmyk);
            hsvValuesChange(hsv);
            rgbValuesChange(rgb);
            xyzValuesChange(xyz);
            yiqValuesChange(yiq);

            colorChange();
            valuesReadyForChanges = true;
        }
        private void hsvValuesChangedEvent()
        {
            int h = (int)hsvHValue.Value;
            byte s = (byte)hsvSValue.Value;
            byte v = (byte)hsvVValue.Value;
            HSV hsv = new HSV(h, s, v);

            RGB rgb = ColorHelper.ColorConverter.HsvToRgb(hsv);
            HSL hsl = ColorHelper.ColorConverter.HsvToHsl(hsv);
            XYZ xyz = ColorHelper.ColorConverter.HsvToXyz(hsv);
            CMYK cmyk = ColorHelper.ColorConverter.HsvToCmyk(hsv);
            YIQ yiq = ColorHelper.ColorConverter.HsvToYiq(hsv);

            cmykValuesChange(cmyk);
            rgbValuesChange(rgb);
            hslValuesChange(hsl);
            xyzValuesChange(xyz);
            yiqValuesChange(yiq);

            colorChange();

            valuesReadyForChanges = true;
        }
        private void cmykValuesChangedEvent()
        {
            byte c = (byte)cmykCValue.Value;
            byte m = (byte)cmykMValue.Value;
            byte y = (byte)cmykYValue.Value;
            byte k = (byte)cmykKValue.Value;
            CMYK cmyk = new CMYK(c, m, y, k);

            HSL hsl = ColorHelper.ColorConverter.CmykToHsl(cmyk);
            HSV hsv = ColorHelper.ColorConverter.CmykToHsv(cmyk);
            RGB rgb = ColorHelper.ColorConverter.CmykToRgb(cmyk);
            XYZ xyz = ColorHelper.ColorConverter.CmykToXyz(cmyk);
            YIQ yiq = ColorHelper.ColorConverter.CmykToYiq(cmyk);

            rgbValuesChange(rgb);
            hslValuesChange(hsl);
            hsvValuesChange(hsv);
            xyzValuesChange(xyz);
            yiqValuesChange(yiq);

            colorChange();
            valuesReadyForChanges = true;
        }
        private void yiqValuesChangedEvent()
        {
            double y = (double)yiqYValue.Value;
            double i = (double)yiqIValue.Value;
            double q = (double)yiqQValue.Value;
            YIQ yiq = new YIQ(y, i, q);

            HSL hsl = ColorHelper.ColorConverter.YiqToHsl(yiq);
            HSV hsv = ColorHelper.ColorConverter.YiqToHsv(yiq);
            RGB rgb = ColorHelper.ColorConverter.YiqToRgb(yiq);
            CMYK cmyk = ColorHelper.ColorConverter.YiqToCmyk(yiq);
            XYZ xyz = ColorHelper.ColorConverter.YiqToXyz(yiq);

            rgbValuesChange(rgb);
            hslValuesChange(hsl);
            hsvValuesChange(hsv);
            cmykValuesChange(cmyk);
            xyzValuesChange(xyz);

            colorChange();
            valuesReadyForChanges = true;
        }
        //COMPLETED
        //color selection through the spectrum
        private void ColorSpectre_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap pixelData = (Bitmap) colorSpectre.Image;
            Color clr = pixelData.GetPixel(e.X, e.Y);

            RGB rgb = new RGB(clr.R, clr.G, clr.B);
            rgbValuesChange(rgb);
            rgbValuesChangedEvent();

            selectedColor.BackColor = clr;
        }
        //close button event
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //rgb slots of values change
        private void rgbRTrackBar_Scroll(object sender, EventArgs e)
        {
            rgbRValue.Value = rgbRTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                rgbValuesChangedEvent();
            }
        }
        private void rgbGTrackBar_Scroll(object sender, EventArgs e)
        {
            rgbGValue.Value = rgbGTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                rgbValuesChangedEvent();
            }
        }
        private void rgbBTrackBar_Scroll(object sender, EventArgs e)
        {
            rgbBValue.Value = rgbBTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                rgbValuesChangedEvent();
            }
        }
        private void rgbRValue_ValueChanged(object sender, EventArgs e)
        {
            rgbRTrackBar.Value = (int)rgbRValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                rgbValuesChangedEvent();
            }
        }
        private void rgbGValue_ValueChanged(object sender, EventArgs e)
        {
            rgbGTrackBar.Value = (int)rgbGValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                rgbValuesChangedEvent();
            }
        }
        private void rgbBValue_ValueChanged(object sender, EventArgs e)
        {
            rgbBTrackBar.Value = (int)rgbBValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                rgbValuesChangedEvent();
            }
        }
        //hsl slots of values change
        private void hslHTrackBar_Scroll(object sender, EventArgs e)
        {
            hslHValue.Value = hslHTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                hslValuesChangedEvent();
            }
        }
        private void hslSTrackBar_Scroll(object sender, EventArgs e)
        {
            hslSValue.Value = hslSTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                hslValuesChangedEvent();
            }
        }
        private void hslLTrackBar_Scroll(object sender, EventArgs e)
        {
            hslLValue.Value = hslLTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                hslValuesChangedEvent();
            }
        }
        private void hslHValue_ValueChanged(object sender, EventArgs e)
        {
            hslHTrackBar.Value = (int)hslHValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                hslValuesChangedEvent();
            }
        }
        private void hslSValue_ValueChanged(object sender, EventArgs e)
        {
            hslSTrackBar.Value = (int)hslSValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                hslValuesChangedEvent();
            }
        }
        private void hslLValue_ValueChanged(object sender, EventArgs e)
        {
            hslLTrackBar.Value = (int)hslLValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                hslValuesChangedEvent();
            }
        }
        //hsv slots of values change
        private void hsvHTrackBar_Scroll(object sender, EventArgs e)
        {
            hsvHValue.Value = hsvHTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                hsvValuesChangedEvent();
            }
        }
        private void hsvSTrackBar_Scroll(object sender, EventArgs e)
        {
            hsvSValue.Value = hsvSTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                hsvValuesChangedEvent();
            }
        }
        private void hsvVTrackBar_Scroll(object sender, EventArgs e)
        {
            hsvVValue.Value = hsvVTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                hsvValuesChangedEvent();
            }
        }
        private void hsvHValue_ValueChanged(object sender, EventArgs e)
        {
            hsvHTrackBar.Value = (int)hsvHValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                hsvValuesChangedEvent();
            }
        }
        private void hsvSValue_ValueChanged(object sender, EventArgs e)
        {
            hsvSTrackBar.Value = (int)hsvSValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                hsvValuesChangedEvent();
            }
        }
        private void hsvVValue_ValueChanged(object sender, EventArgs e)
        {
            hsvVTrackBar.Value = (int)hsvVValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                hsvValuesChangedEvent();
            }
        }
        //xyz slots of values change
        private void xyzXTrackBar_Scroll(object sender, EventArgs e)
        {
            xyzXValue.Value = (decimal)(xyzXTrackBar.Value/100.00);
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                xyzValuesChangedEvent();
            }
        }
        private void xyzYTrackBar_Scroll(object sender, EventArgs e)
        {
            xyzYValue.Value = (decimal)(xyzYTrackBar.Value / 100.00);
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                xyzValuesChangedEvent();
            }
        }
        private void xyzZTrackBar_Scroll(object sender, EventArgs e)
        {
            xyzZValue.Value = (decimal)(xyzZTrackBar.Value / 100.00);
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                xyzValuesChangedEvent();
            }
        }
        private void xyzXValue_ValueChanged(object sender, EventArgs e)
        {
            xyzXTrackBar.Value = (int)(xyzXValue.Value*100);
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                xyzValuesChangedEvent();
            }
        }
        private void xyzYValue_ValueChanged(object sender, EventArgs e)
        {
            xyzYTrackBar.Value = (int)(xyzYValue.Value * 100);
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                xyzValuesChangedEvent();
            }
        }
        private void xyzZValue_ValueChanged(object sender, EventArgs e)
        {
            xyzZTrackBar.Value = (int)(xyzZValue.Value * 100);
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                xyzValuesChangedEvent();
            }
        }
        //cmyk slots of values change
        private void cmykCTrackBar_Scroll(object sender, EventArgs e)
        {
            cmykCValue.Value = cmykCTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                cmykValuesChangedEvent();
            }
        }
        private void cmykMTrackBar_Scroll(object sender, EventArgs e)
        {
            cmykMValue.Value = cmykMTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                cmykValuesChangedEvent();
            }
        }
        private void cmykYTrackBar_Scroll(object sender, EventArgs e)
        {
            cmykYValue.Value = cmykYTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                cmykValuesChangedEvent();
            }
        }
        private void cmykKTrackBar_Scroll(object sender, EventArgs e)
        {
            cmykKValue.Value = cmykKTrackBar.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                cmykValuesChangedEvent();
            }
        }
        private void cmykCValue_ValueChanged(object sender, EventArgs e)
        {
            cmykCTrackBar.Value = (int)cmykCValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                cmykValuesChangedEvent();
            }
        }
        private void cmykMValue_ValueChanged(object sender, EventArgs e)
        {
            cmykMTrackBar.Value = (int)cmykMValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                cmykValuesChangedEvent();
            }
        }
        private void cmykYValue_ValueChanged(object sender, EventArgs e)
        {
            cmykYTrackBar.Value = (int)cmykYValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                cmykValuesChangedEvent();
            }
        }
        private void cmykKValue_ValueChanged(object sender, EventArgs e)
        {
            cmykKTrackBar.Value = (int)cmykKValue.Value;
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                cmykValuesChangedEvent();
            }
        }
        //yiq slots of values changed
        private void yiqYTrackBar_Scroll(object sender, EventArgs e)
        {
            yiqYValue.Value = (decimal)(yiqYTrackBar.Value / 100.00);
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                yiqValuesChangedEvent();
            }
        }
        private void yiqITrackBar_Scroll(object sender, EventArgs e)
        {
            yiqIValue.Value = (decimal)(yiqITrackBar.Value / 100.00);
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                yiqValuesChangedEvent();
            }
        }
        private void yiqQTrackBar_Scroll(object sender, EventArgs e)
        {
            yiqQValue.Value = (decimal)(yiqQTrackBar.Value / 100.00);
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                yiqValuesChangedEvent();
            }
        }
        private void yiqYValue_ValueChanged(object sender, EventArgs e)
        {
            yiqYTrackBar.Value = (int)(yiqYValue.Value * 100);
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                yiqValuesChangedEvent();
            }
        }
        private void yiqIValue_ValueChanged(object sender, EventArgs e)
        {
            yiqITrackBar.Value = (int)(yiqIValue.Value * 100);
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                yiqValuesChangedEvent();
            }
        }
        private void yiqQValue_ValueChanged(object sender, EventArgs e)
        {
            yiqQTrackBar.Value = (int)(yiqQValue.Value * 100);
            if (valuesReadyForChanges)
            {
                valuesReadyForChanges = false;
                yiqValuesChangedEvent();
            }
        }
    }
}



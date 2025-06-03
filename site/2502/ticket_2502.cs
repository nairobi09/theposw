using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;

namespace theposw
{
    internal class ticket_2502
    {
        // Interface Type
        public const int ISerial = 0;
        public const int IParallel = 1;
        public const int IUsb = 2;
        public const int ILan = 3;
        public const int IBluetooth = 5;



        // BIXOLON
        public void print_ticket_2502(String t_ticket_no, String t_date, String t_time, String t_goods_code, String t_goods_name, int t_goods_cnt, int t_goods_amt, String t_coupon_no)
        {
            //
            if (!ConnectPrinter(mTicketPrinterPort, 0))
                return;


            int multiplier = 1;
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int resolution = BXLLApi.GetPrinterDPI();
            int dotsPer1mm = (int)Math.Round((float)resolution / 25.4f);
            if (resolution >= 600)
                multiplier = 3;


            SendPrinterSettingCommand();

            // Prints string using TrueFont
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Font Name
            //  P4 : Font Size
            //  P5 : Rotation : (0 : 0 degree , 1 : 90 degree, 2 : 180 degree, 3 : 270 degree)
            //  P6 : Italic
            //  P7 : Bold
            //  P8 : Underline
            //  P9 : RLE (Run-length encoding)
            //BXLLApi.PrintTrueFontLib(2 * dotsPer1mm, 5 * dotsPer1mm, "Arial", 14, 0, true, true, false, "Sample Label-1", false);
            //BXLLApi.PrintTrueFont(2 * dotsPer1mm, 1 * dotsPer1mm, "Arial", 14, 3, true, true, false, "Sample Label-1", false);

            //	Draw Lines
            //BXLLApi.PrintBlock(1 * dotsPer1mm, 10 * dotsPer1mm, 71 * dotsPer1mm, 11 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.LINE_OVER_WRITING, 0);

            //Print string using Vector Font
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Font selection
            //        U: ASCII (1Byte code)
            //        K: KS5601 (2Byte code)
            //        B: BIG5 (2Byte code)
            //        G: GB2312 (2Byte code)
            //        J: Shift-JIS (2Byte code)
            // P4  : Font width (W)[dot]
            // P5  : Font height (H)[dot]
            // P6  : Right-side character spacing [dot], Plus (+)/Minus (-) option can be used. Ex) 5, +3, -10	
            // P7  : Bold
            // P8  : Reverse printing
            // P9  : Text style  (N : Normal, I : Italic)
            // P10 : Rotation (0 ~ 3)
            // P11 : Text Alignment
            //        L: Left
            //        R: Right
            //        C: Center
            // P12 : Text string write direction (0 : left to right, 1 : right to left)
            // P13 : data to print
            // ※ : Third parameter, 'ASCII' must be set if Bixolon printer is SLP-T400, SLP-T403, SRP-770 and SRP-770II.
            //BXLLApi.PrintVectorFont(22, 65, "U", 34, 34, "0", false, false, false, (int)SLCS_ROTATION.ROTATE_0, SLCS_FONT_ALIGNMENT.LEFTALIGN.ToString(), (int)SLCS_FONT_DIRECTION.LEFTTORIGHT, "Sample Label-2");



            DateTime date;
            string weekdayKorean = "";

            if (DateTime.TryParseExact(t_date, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                weekdayKorean = date.ToString("dddd", new CultureInfo("ko-KR"));
            }
            else
            {
            }


            String str_date = t_date.Substring(0,4) + "-" + t_date.Substring(4,2) + "-" + t_date.Substring(6, 2) + " " + weekdayKorean;
            String str_goods_name = t_goods_name;
            String str_amt = t_goods_amt.ToString("N0");


            BXLLApi.PrintDeviceFont(2 * dotsPer1mm, 245 * dotsPer1mm, (int)SLCS_DEVICE_FONT.KOR_24X24, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_270, true, "입장권 (Ticket)");
            BXLLApi.PrintDeviceFont(6 * dotsPer1mm, 245 * dotsPer1mm, (int)SLCS_DEVICE_FONT.KOR_38X38, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_270, true, str_date);
            BXLLApi.PrintDeviceFont(12 * dotsPer1mm, 245 * dotsPer1mm, (int)SLCS_DEVICE_FONT.KOR_24X24, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_270, false, str_goods_name);
            BXLLApi.PrintDeviceFont(15 * dotsPer1mm, 245 * dotsPer1mm, (int)SLCS_DEVICE_FONT.KOR_24X24, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_270, false, str_amt);

            BXLLApi.Print1DBarcode(3 * dotsPer1mm, 200 * dotsPer1mm, (int)SLCS_BARCODE.CODE128, 2 * multiplier, 5 * multiplier, 100 * multiplier, (int)SLCS_ROTATION.ROTATE_270, (int)SLCS_HRI.HRI_BELOW_SIZE2, t_ticket_no);



            //	Print Command
            BXLLApi.Prints(1, 1);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();

            return;
        }


        private bool ConnectPrinter(String port, int baudrate)
        {
            string strPort = "";
            int nInterface = ISerial;
            int nBaudrate = 115200, nDatabits = 8, nParity = 0, nStopbits = 0;
            int nStatus = (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR;

            if (port == "USB")
            {
                // USB
                nInterface = IUsb;
            }
            else
            {
                // SERIAL (COM)
                nInterface = ISerial;
                strPort = port;
                nBaudrate = baudrate;
                nDatabits = 8;
                nParity = 0;
                nStopbits = 1;
            }


            nStatus = BXLLApi.ConnectPrinterEx(nInterface, strPort, nBaudrate, nDatabits, nParity, nStopbits);

            if (nStatus != (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR)
            {
                BXLLApi.DisconnectPrinter();
                //MessageBox.Show(GetStatusMsg(nStatus));
                return false;
            }
            return true;
        }


        private void SendPrinterSettingCommand()
        {
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int dotsPer1mm = (int)Math.Round((float)BXLLApi.GetPrinterDPI() / 25.4f);
            int nPaper_Width = 20 * dotsPer1mm;
            int nPaper_Height = 245 * dotsPer1mm;
            int nMarginX = 0 * dotsPer1mm;
            int nMarginY = 0 * dotsPer1mm;
            int nSpeed = (int)SLCS_PRINT_SPEED.PRINTER_SETTING_SPEED;
            int nDensity = 14;
            int nOrientation = (int)SLCS_ORIENTATION.TOP2BOTTOM; // : (int)SLCS_ORIENTATION.BOTTOM2TOP;

            //int nSensorType = (int)SLCS_MEDIA_TYPE.GAP;
            int nSensorType = (int)SLCS_MEDIA_TYPE.BLACKMARK;
            //int nSensorType = (int)SLCS_MEDIA_TYPE.CONTINUOUS;

            //	Clear Buffer of Printer
            BXLLApi.ClearBuffer();

            // Rewinder is only available for XT series printers (XT5-40, XT5-43, XT5-46)
            //BXLLApi.PrintDirect("RWDy", true);  // rdoRewind.Checked

            //	Set Label and Printer
            //BXLLApi.SetConfigOfPrinter(BXLLApi.SPEED_50, 17, BXLLApi.TOP, false, 0, true);
            
            
            BXLLApi.SetConfigOfPrinter(nSpeed, nDensity, nOrientation, true, 1, true);  // suto cut

            // Select international character set and code table.To
            BXLLApi.SetCharacterset((int)SLCS_INTERNATIONAL_CHARSET.ICS_USA, (int)SLCS_CODEPAGE.FCP_CP1252);

            /* 
                1 Inch : 25.4mm
                1 mm   :  7.99 Dots (XT5-40, SLP-TX400, SLP-DX420, SLP-DX220, SLP-DL410, SLP-T400, SLP-D420, SLP-D220, SRP-770/770II/770III)
                1 mm   :  7.99 Dots (SPP-L310, SPP-L410, SPP-L3000, SPP-L4000) 
                1 mm   :  7.99 Dots (XD3-40d, XD3-40t, XD5-40d, XD5-40t, XD5-40LCT)
                1 mm   : 11.81 Dots (XT5-43, SLP-TX403, SLP-DX423, SLP-DX223, SLP-DL413, SLP-T403, SLP-D423, SLP-D223)
                1 mm   : 11.81 Dots (XD5-43d, XD5-43t, XD5-43LCT)
                1 mm   : 23.62 Dots (XT5-46)
            */

            BXLLApi.SetPaper(nMarginX, nMarginY, nPaper_Width, nPaper_Height, nSensorType, 0, 2 * dotsPer1mm);
            
            //BXLLApi.PrintDirect("STd", true); // Direct thermal
            BXLLApi.PrintDirect("STt", true); // Thermal transfer
        }


    }
}

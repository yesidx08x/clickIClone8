using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

namespace clickIClone
{

    public enum memEnum{
        exportfbx=0,exportabc=1,exfile=2,start=3,end=4,project=5,after=6}

    public sealed class argClass
    {
        public memEnum mem{get;set;}
        public string arg{get;set;}

    }
    public class MouseHelper
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        //移动鼠标 
        public const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
    }
    public class keyControl
    {
        #region bVk参数 常量定义

        public const byte vbKeyLButton = 0x1;    // 鼠标左键
        public const byte vbKeyRButton = 0x2;    // 鼠标右键
        public const byte vbKeyCancel = 0x3;     // CANCEL 键
        public const byte vbKeyMButton = 0x4;    // 鼠标中键
        public const byte vbKeyBack = 0x8;       // BACKSPACE 键
        public const byte vbKeyTab = 0x9;        // TAB 键
        public const byte vbKeyClear = 0xC;      // CLEAR 键
        public const byte vbKeyReturn = 0xD;     // ENTER 键
        public const byte vbKeyShift = 0x10;     // SHIFT 键
        public const byte vbKeyControl = 0x11;   // CTRL 键
        public const byte vbKeyAlt = 18;         // Alt 键  (键码18)
        public const byte vbKeyMenu = 0x12;      // MENU 键
        public const byte vbKeyPause = 0x13;     // PAUSE 键
        public const byte vbKeyCapital = 0x14;   // CAPS LOCK 键
        public const byte vbKeyEscape = 0x1B;    // ESC 键
        public const byte vbKeySpace = 0x20;     // SPACEBAR 键
        public const byte vbKeyPageUp = 0x21;    // PAGE UP 键
        public const byte vbKeyEnd = 0x23;       // End 键
        public const byte vbKeyHome = 0x24;      // HOME 键
        public const byte vbKeyLeft = 0x25;      // LEFT ARROW 键
        public const byte vbKeyUp = 0x26;        // UP ARROW 键
        public const byte vbKeyRight = 0x27;     // RIGHT ARROW 键
        public const byte vbKeyDown = 0x28;      // DOWN ARROW 键
        public const byte vbKeySelect = 0x29;    // Select 键
        public const byte vbKeyPrint = 0x2A;     // PRINT SCREEN 键
        public const byte vbKeyExecute = 0x2B;   // EXECUTE 键
        public const byte vbKeySnapshot = 0x2C;  // SNAPSHOT 键
        public const byte vbKeyDelete = 0x2E;    // Delete 键
        public const byte vbKeyHelp = 0x2F;      // HELP 键
        public const byte vbKeyNumlock = 0x90;   // NUM LOCK 键

        //常用键 字母键A到Z
        public const byte vbKeyA = 65;
        public const byte vbKeyB = 66;
        public const byte vbKeyC = 67;
        public const byte vbKeyD = 68;
        public const byte vbKeyE = 69;
        public const byte vbKeyF = 70;
        public const byte vbKeyG = 71;
        public const byte vbKeyH = 72;
        public const byte vbKeyI = 73;
        public const byte vbKeyJ = 74;
        public const byte vbKeyK = 75;
        public const byte vbKeyL = 76;
        public const byte vbKeyM = 77;
        public const byte vbKeyN = 78;
        public const byte vbKeyO = 79;
        public const byte vbKeyP = 80;
        public const byte vbKeyQ = 81;
        public const byte vbKeyR = 82;
        public const byte vbKeyS = 83;
        public const byte vbKeyT = 84;
        public const byte vbKeyU = 85;
        public const byte vbKeyV = 86;
        public const byte vbKeyW = 87;
        public const byte vbKeyX = 88;
        public const byte vbKeyY = 89;
        public const byte vbKeyZ = 90;

        //数字键盘0到9
        public const byte vbKey0 = 48;    // 0 键
        public const byte vbKey1 = 49;    // 1 键
        public const byte vbKey2 = 50;    // 2 键
        public const byte vbKey3 = 51;    // 3 键
        public const byte vbKey4 = 52;    // 4 键
        public const byte vbKey5 = 53;    // 5 键
        public const byte vbKey6 = 54;    // 6 键
        public const byte vbKey7 = 55;    // 7 键
        public const byte vbKey8 = 56;    // 8 键
        public const byte vbKey9 = 57;    // 9 键


        public const byte vbKeyNumpad0 = 0x60;    //0 键
        public const byte vbKeyNumpad1 = 0x61;    //1 键
        public const byte vbKeyNumpad2 = 0x62;    //2 键
        public const byte vbKeyNumpad3 = 0x63;    //3 键
        public const byte vbKeyNumpad4 = 0x64;    //4 键
        public const byte vbKeyNumpad5 = 0x65;    //5 键
        public const byte vbKeyNumpad6 = 0x66;    //6 键
        public const byte vbKeyNumpad7 = 0x67;    //7 键
        public const byte vbKeyNumpad8 = 0x68;    //8 键
        public const byte vbKeyNumpad9 = 0x69;    //9 键
        public const byte vbKeyMultiply = 0x6A;   // MULTIPLICATIONSIGN(*)键
        public const byte vbKeyAdd = 0x6B;        // PLUS SIGN(+) 键
        public const byte vbKeySeparator = 0x6C;  // ENTER 键
        public const byte vbKeySubtract = 0x6D;   // MINUS SIGN(-) 键
        public const byte vbKeyDecimal = 0x6E;    // DECIMAL POINT(.) 键
        public const byte vbKeyDivide = 0x6F;     // DIVISION SIGN(/) 键


        //F1到F12按键
        public const byte vbKeyF1 = 0x70;   //F1 键
        public const byte vbKeyF2 = 0x71;   //F2 键
        public const byte vbKeyF3 = 0x72;   //F3 键
        public const byte vbKeyF4 = 0x73;   //F4 键
        public const byte vbKeyF5 = 0x74;   //F5 键
        public const byte vbKeyF6 = 0x75;   //F6 键
        public const byte vbKeyF7 = 0x76;   //F7 键
        public const byte vbKeyF8 = 0x77;   //F8 键
        public const byte vbKeyF9 = 0x78;   //F9 键
        public const byte vbKeyF10 = 0x79;  //F10 键
        public const byte vbKeyF11 = 0x7A;  //F11 键
        public const byte vbKeyF12 = 0x7B;  //F12 键

        #endregion

        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]　//给控件发送指令
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, string lParam);
        [DllImport("User32.dll ")]//获取主窗口下的控件句柄
        private static extern IntPtr FindWindowEx(IntPtr parent, IntPtr childe, string strclass, string FrmText);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        //窗口发送给按钮控件的消息，让按钮执行点击操作，可以模拟按钮点击
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        private const int BM_CLICK = 0xF5;

        private bool startEndFrame(IntPtr hWnd1,RECT rect,string[] startEnd)
        {
            int width = rect.Right - rect.Left;                        //窗口的宽度
            int height = rect.Bottom - rect.Top;                   //窗口的高度
            //远程或在虚拟机里看不到光标移动
            //移到Range处
            MouseHelper.SetCursorPos(rect.Left + 40, rect.Bottom - 280);
            MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            //MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_MOVE | MouseHelper.MOUSEEVENTF_ABSOLUTE, rect.Left + 100, rect.Bottom - height/2, 0, 0);
            //MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTDOWN | MouseHelper.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            //点击export按钮
            MouseHelper.SetCursorPos(rect.Left + 100, rect.Bottom - 25);
            MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            return true;
        }
        private bool clickCountBTN(IntPtr hWnd1, RECT rect)
        {
            int width = rect.Right - rect.Left;                        //窗口的宽度
            int height = rect.Bottom - rect.Top;                   //窗口的高度
            //远程或在虚拟机里看不到光标移动
            //移到Range处
            //MouseHelper.SetCursorPos(rect.Left + 100, rect.Bottom - 350);
            //MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            //MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            //MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_MOVE | MouseHelper.MOUSEEVENTF_ABSOLUTE, rect.Left + 100, rect.Bottom - height/2, 0, 0);
            //MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTDOWN | MouseHelper.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            //点击export按钮
            MouseHelper.SetCursorPos(rect.Right - 50, rect.Bottom - 28);
            MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Console.WriteLine(">>INFO: 点击位置#{0}，{1}", rect.Right - 50, rect.Bottom - 28);
            return true;
        }
        /// <summary>
        /// 需要覆盖时，点击是
        /// </summary>
        /// <returns></returns>
        private bool applySaveAs()
        {
            IntPtr hWnd1 = FindWindow(null, "确认另存为");//主窗体句柄
            if (hWnd1 == IntPtr.Zero)
            {
                Console.WriteLine(">>WARNING:没有找到确认另存为窗口 ");
                return false;
            }
            Console.WriteLine(">>确认另存为窗口 {0}", hWnd1.ToString("x4"));
            IntPtr directHwnd = FindWindowEx(hWnd1, IntPtr.Zero, "DirectUIHWND", ""); //内面板
            if (directHwnd == IntPtr.Zero)
            {
                Console.WriteLine(">>ERROR:没有找到确认另存为窗口的内面板 ");
                return false;
            }
            Console.WriteLine(">>确认另存为窗口内面板 {0}", directHwnd.ToString("x4"));
            IntPtr sinkHwnd = FindWindowEx(directHwnd, IntPtr.Zero, "CtrlNotifySink", ""); //Sink
            IntPtr saveHwnd = FindWindowEx(sinkHwnd, IntPtr.Zero, "Button", "是(&Y)");
            int n = 0;
            do
            {
                sinkHwnd = FindWindowEx(directHwnd, sinkHwnd, "CtrlNotifySink", ""); //Sink
                Console.WriteLine(">>确认另存为窗口内Sink {0}", sinkHwnd.ToString("x4"));
                saveHwnd = FindWindowEx(sinkHwnd, IntPtr.Zero, "Button", "是(&Y)");
                Console.WriteLine(">>{0},{1} ", saveHwnd.ToString("x4"), n);
                if (n > 9)
                {
                    Console.WriteLine(">>ERROR:没有找到确认按钮 ");
                    return false;
                }
                n++;
            }
            while (saveHwnd.Equals(IntPtr.Zero));
            SendMessage(saveHwnd, BM_CLICK, 0, 0);
            return true;
        }

        /// <summary>
        /// 点击保存
        /// </summary>
        /// <param name="hWnd1"></param>
        /// <returns></returns>
        private bool clickSave(IntPtr hWnd1)
        {
            IntPtr saveHwnd = FindWindowEx(hWnd1, IntPtr.Zero, "Button", "保存(&S)"); //内面板
            if (saveHwnd == IntPtr.Zero)
            {
                Console.WriteLine(">>ERROR:没有找到另存为窗口的保存按钮 ");
                return false;
            }
            Console.WriteLine(">>保存按钮 {0}", saveHwnd.ToString("x4"));
            Thread thd = new Thread(runClick);
            thd.Start();
            
            SendMessage(saveHwnd, BM_CLICK, 0, 0);
            if (thd.IsAlive)
                thd.Abort();
            return true;
        }
        /// <summary>
        /// 往另存为文本框里填路径
        /// </summary>
        /// <param name="hWnd1"></param>
        /// <param name="exfile"></param>
        /// <returns></returns>
        private bool addpath(IntPtr hWnd1,string exfile)
        {
            IntPtr WndHwnd = FindWindowEx(hWnd1, IntPtr.Zero, "DUIViewWndClassName", null); //内窗体
            if (WndHwnd == IntPtr.Zero)
            {
                Console.WriteLine(">>ERROR:没有找到另存为窗口的内窗体 ");
                return false;
            }

            IntPtr directHwnd = FindWindowEx(WndHwnd, IntPtr.Zero, "DirectUIHWND", ""); //内面板
            if (directHwnd == IntPtr.Zero)
            {
                Console.WriteLine(">>ERROR:没有找到另存为窗口的内面板 ");
                return false;
            }
            IntPtr sinkHwnd = FindWindowEx(directHwnd, IntPtr.Zero, "FloatNotifySink", ""); //Sink
            if (sinkHwnd == IntPtr.Zero)
            {
                Console.WriteLine(">>ERROR:没有找到另存为窗口文本框的Sink ");
                return false;
            }
            IntPtr cbbHwnd = FindWindowEx(sinkHwnd, IntPtr.Zero, "ComboBox", null); //Combobox
            if (cbbHwnd == IntPtr.Zero)
            {
                Console.WriteLine(">>ERROR:没有找到另存为窗口文本框的下拉框 ");
                return false;
            }

            IntPtr editHwnd = FindWindowEx(cbbHwnd, IntPtr.Zero, "Edit", null);//按钮控件标题
            if (editHwnd != IntPtr.Zero)
            {
                SendMessage(editHwnd, BM_CLICK, 0, 0);
                const int WM_SETTEXT = 0x000C;//设置文本事件
                SendMessage(editHwnd, WM_SETTEXT, 0, exfile);
            }
            else
            {

                Console.WriteLine(">>ERROR:没有找到另存为窗口的文件名文本框 ");
                return false;
            } 
            return true;
        }
        void runClick()
        {
            int n = 0;
            while (true)
            {
                Thread.Sleep(400);
                bool hasOver = applySaveAs();
                if (hasOver)
                    break;
                if (n > 9)
                    break;
                n++;
            }
        }
        public bool saveContrl(string exfile)
        {
            //"#32770(对话框)"
            IntPtr hWnd1 = FindWindow(null, "另存为");//主窗体句柄
            if (hWnd1 != IntPtr.Zero)
            {
                Console.WriteLine(">>iclone 另存为窗口 {0}", hWnd1.ToString("x4"));
                bool hasAdd = addpath(hWnd1, exfile);
                if (hasAdd)
                {
                    Thread.Sleep(500);
                    bool hasSave = clickSave(hWnd1);

                    if (hasSave)
                    {
                        Console.WriteLine(">>iclone 另存为实现输出 {0}", hasSave);
                        
                    }
                }
                else
                    return false;
                
            }
            else
            {
                Console.WriteLine(">>ERROR:没有找到iclone 另存为窗口 ");
                return false;
            } 
            return true;
        }
        public bool icloneContrl(string project)
        {
            // iclone 8 Qt5152QWindowIcon ; iclone 7 Qt5QWindowIcon
            IntPtr hWnd1 = FindWindow("Qt5152QWindowIcon", string.Format("iClone 8 - {0}", project));//主窗体句柄iClone 8 - test.iProject
            /*
            if (hWnd1 == IntPtr.Zero)
            {
                hWnd1 = FindWindow("Qt5152QWindowIcon", string.Format("iClone 8 - {0}", "DefProject.iProject"));//主窗体句柄iClone 8 - DefProject.iProject
            }*/
            if (hWnd1 != IntPtr.Zero)
            {
                Console.WriteLine(">>iclone 8 窗口 {0}", hWnd1.ToString("x4"));
                //ShowWindow(hWnd1, 1);
                RECT rect = new RECT();
                GetWindowRect(hWnd1, ref rect);
                int width = rect.Right - rect.Left;                        //窗口的宽度
                int height = rect.Bottom - rect.Top;                   //窗口的高度
                int x = rect.Left;
                int y = rect.Top;
                Console.WriteLine(">>iclone 8 窗口 {0} [{1},{2},{3},{4}]", hWnd1.ToString("x4"), rect.Left, rect.Right, rect.Top, rect.Bottom);
                //MouseHelper.SetCursorPos(rect.Left+10 , rect.Top + 10);
                //MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                //MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_MOVE | MouseHelper.MOUSEEVENTF_ABSOLUTE, rect.Left + 120, rect.Top - 60, 0, 0);
                MouseHelper.mouse_event(MouseHelper.MOUSEEVENTF_LEFTDOWN | MouseHelper.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                //模拟按下ctrl键 keybd_event(vbKeyControl, 0, 0, 0);
                //模拟按下shift键 keybd_event(vbKeyShift, 0, 0, 0);
                //松开按键ctrl keybd_event(vbKeyControl, 0, 2, 0);
                //松开按键shift keybd_event(vbKeyShift, 0, 2, 0);
                keybd_event(vbKeyAlt, 0, 0, 0);
                keybd_event(vbKeyF, 0, 0, 0);
                keybd_event(vbKeyF, 0, 2, 0);
                keybd_event(vbKeyE, 0, 0, 0);
                keybd_event(vbKeyE, 0, 2, 0);
                keybd_event(vbKeyF, 0, 0, 0);
                keybd_event(vbKeyF, 0, 2, 0);
                keybd_event(vbKeyAlt, 0, 2, 0);
            }

            else
            {
                Console.WriteLine(">>ERROR:没有找到iclone窗口 " + string.Format("iClone 8 -{0}", project));
                return false;
            } 
            return true;
        }
        public bool procContrl()
        {
            // iclone 8 Qt5152QWindowIcon ; iclone 7 Qt5QWindowIcon
            IntPtr hWnd1 = FindWindow("Qt5152QWindow", "iClone 8");//主窗体句柄iClone 8 - test.iProject
            if (hWnd1 != IntPtr.Zero)
            {
                return true;
            }
            return false;
        }
        public bool countContrl()
        {
            IntPtr hWnd1 = FindWindow("Qt5152QWindowToolSaveBits", "Batch Export FBX");//主窗体句柄
            if (hWnd1 != IntPtr.Zero)
            {
                //Console.WriteLine(">>Export FBX窗口 {0}", hWnd1.ToString("x4"));
                ShowWindow(hWnd1, 1);

                RECT rect = new RECT();
                GetWindowRect(hWnd1, ref rect);
                int width = rect.Right - rect.Left;                        //窗口的宽度
                int height = rect.Bottom - rect.Top;                   //窗口的高度
                int x = rect.Left;
                int y = rect.Top;
                Console.WriteLine(">>Batch Export FBX窗口 {0} [{1},{2},{3},{4}]", hWnd1.ToString("x4"), rect.Left, rect.Right, rect.Top, rect.Bottom);
                bool clickCount = clickCountBTN(hWnd1, rect);

                return clickCount;
                /*
                IntPtr childHwnd = FindWindowEx(hWnd1, IntPtr.Zero, null, "Export");//按钮控件标题
                if (childHwnd != IntPtr.Zero)
                {
                    SendMessage(childHwnd, BM_CLICK, 0, 0);
                }
                else
                {

                    Console.WriteLine(">>ERROR:没有找到Export FBX窗口Export按钮 ");
                    return false;
                } 
                 */
            }
            else
            {
                Console.WriteLine(">>ERROR:没有找到Batch Export FBX窗口 ");
                return false;
            }
            return true;
        }
        public bool fbxContrl(string[] startEnd)
        {
            IntPtr hWnd1 = FindWindow("Qt5152QWindowIcon", "Export FBX");//主窗体句柄
            if (hWnd1 != IntPtr.Zero)
            {
                //Console.WriteLine(">>Export FBX窗口 {0}", hWnd1.ToString("x4"));
                ShowWindow(hWnd1, 1);

                RECT rect = new RECT();
                GetWindowRect(hWnd1, ref rect);
                int width = rect.Right - rect.Left;                        //窗口的宽度
                int height = rect.Bottom - rect.Top;                   //窗口的高度
                int x = rect.Left;
                int y = rect.Top;
                Console.WriteLine(">>Export FBX窗口 {0} [{1},{2},{3},{4}]", hWnd1.ToString("x4"), rect.Left, rect.Right, rect.Top, rect.Bottom);
                bool editRange = startEndFrame(hWnd1,rect,startEnd);

                return editRange;
                /*
                IntPtr childHwnd = FindWindowEx(hWnd1, IntPtr.Zero, null, "Export");//按钮控件标题
                if (childHwnd != IntPtr.Zero)
                {
                    SendMessage(childHwnd, BM_CLICK, 0, 0);
                }
                else
                {

                    Console.WriteLine(">>ERROR:没有找到Export FBX窗口Export按钮 ");
                    return false;
                } 
                 */
            }
            else
            {
                Console.WriteLine(">>ERROR:没有找到Export FBX窗口 ");
                return false;
            }
            //return true;
        }

    }
    public  class icloneFBXClass
    {
        public string __fbxfile;
        private bool checkPath(string exfile)
        {
            //无效字符
            char[] invaild = Path.GetInvalidFileNameChars();
            foreach (char chr in exfile.ToCharArray())
            {
                if (invaild.Contains(chr))
                {
                    if (exfile.Substring(1, 1) == ":" && chr.ToString() == ":" )
                        continue;
                    if (chr.ToString() == "/" | chr.ToString() == "\\")
                        continue;
                    Console.WriteLine(">>ERROR: 包含非法字符'{0}'，请给出正确的输出文件名 #{1}",chr.ToString(), exfile);
                    return false;
                }
            }

            FileInfo xfileInfo = new FileInfo(exfile);
            if (xfileInfo.Extension != ".fbx")
            {
                Console.WriteLine(">>ERROR: 请给出正确的输出文件后缀名 #{0}", exfile);
                return false;
            }
            if (File.Exists(exfile))
            {
                Console.WriteLine(">>WARNING: 输出文件已经存在，将覆盖 #{0}", exfile);
                return true;
            }
            return true;
        }
        /// <summary>
        /// 等FBX文件完成，再执行ue导入，同时点击按钮操作下一个
        /// 三分钟没完自动退出
        /// </summary>
        private void newThreadWait()
        {
            keyControl kc = new keyControl();
            int n=179;
            while(n>0)
            {
                Thread.Sleep(1000);
                if (File.Exists(__fbxfile) && kc.procContrl())
                {
                    Thread.Sleep(3000);
                    Console.WriteLine(">>INFO: 输出文件已经完成#{0}", __fbxfile);
                    Thread.Sleep(3000);
                    break;
                }
                n=n-1;
            }
        }
        public void exportFBX(argClass acF,argClass acC,argClass acS,argClass acE,argClass acP,argClass acA)
        {
            string exfile = acF.arg;
            __fbxfile=exfile;
            string start = acS.arg;
            string end = acE.arg;
            string project = acP.arg;
            string after = acA.arg;
            if (checkPath(exfile))
            {
                Console.WriteLine(">>DEBUG: 开始输出文件 #{0}", exfile);
                keyControl kc = new keyControl();
                kc.icloneContrl(project);
                Thread.Sleep(1500);
                kc.fbxContrl(new string[] { start, end });
                Thread.Sleep(500);
                kc.saveContrl(acF.arg);
                //check file is exist. and run ue4edit mcd
                newThreadWait();
                //executeCommand(after.Replace("(", "").Replace(")", ""), 999);
                kc.countContrl();
            }
            return;
            //System.Environment.Exit(-1);
           
        }
        public void exportABC(argClass acF, argClass acC, argClass acS, argClass acE, argClass acP, argClass acA)
        {
            string exfile = acF.arg;
            if (!File.Exists(exfile))
                Console.WriteLine(">>ERROR: 请给出正确的输出文件 #{0}", acF.arg);
        }

        public static void executeCommand(string cmd, int millsecTimeOut)
        {
            System.Diagnostics.ProcessStartInfo processStartInfo =
            //new System.Diagnostics.ProcessStartInfo("CMD.exe", "/C " + cmd);
            new System.Diagnostics.ProcessStartInfo(cmd);
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            System.Diagnostics.Process process =
            System.Diagnostics.Process.Start(processStartInfo);
            //int exitCode = process.ExitCode;
            //process.Close();
            //return exitCode;
        }
    }
}

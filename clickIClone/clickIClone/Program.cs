using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clickIClone
{
    class Program
    {
        //public static string[] memA = new string[] { "exportfbx", "exportabc", "exfile" ,"start", "end","project"};
        /// <summary>
        /// E:\work_ref\vs2013\clickIClone\clickIClone\clickIClone\bin\Release\clickIClone.exe -exportfbx -exfile e:\dd.fbx -start 1 -end 390 -project test.iProject
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<argClass> argClassL = getAllArgs(args);

            icloneFBXClass iFBXClass = new icloneFBXClass();
            argClass acF = new argClass();
            argClass acC = new argClass();
            argClass acS = new argClass();
            argClass acE = new argClass();
            argClass acP = new argClass();
            argClass acA = new argClass();
            foreach(argClass  ac in argClassL)
            {
                if(ac.mem == memEnum.exfile)
                {
                    acF = ac;
                    
                }
                if (ac.mem == memEnum.start)
                {
                    acS = ac;
                }
                if (ac.mem == memEnum.end)
                {
                    acE = ac;
                }
                if(ac.mem == memEnum.project)
                {
                    acP = ac;
                }
                if (ac.mem == memEnum.after)
                {
                    acA = ac;
                }
            }
            foreach (argClass ac in argClassL)
            {
                if(ac.mem == memEnum.exportfbx)
                {
                    acC = ac;
                    iFBXClass.exportFBX(acF,acC,acS,acE,acP,acA);
                    break;
                }
                if (ac.mem == memEnum.exportabc)
                {
                    acC = ac;
                    iFBXClass.exportABC(acF,acC,acS,acE,acP,acA);
                    break;
                }
            }
            return;
            
        }

        static List<argClass> getAllArgs(string[] args)
        {
            int n = 0;
            string[] memA = Enum.GetNames(typeof(memEnum));
            List<argClass> argClassL = new List<argClass>();
            foreach (string arg in args)
            {
                // 命令参数
                if (arg.Substring(0, 1) == "-")
                {
                    string mem = arg.Substring(1, arg.Length - 1);
                    string value = string.Empty;
                    if (memA.Contains(mem.ToLower()))
                    {
                        if (n + 1 < args.Count() && args[n + 1].Substring(0, 1) != "-")
                        {
                            value = args[n + 1];

                        }

                        argClassL.Add(memArgs(mem, value));
                    }
                }
                n++;
            }
            return argClassL;
        }

        static argClass memArgs(string mem, string value)
        {
            argClass ac = new argClass();
            memEnum type = (memEnum)System.Enum.Parse(typeof(memEnum), mem);
            ac.mem = type;
            ac.arg = value;
            return ac;
        }
    }
}

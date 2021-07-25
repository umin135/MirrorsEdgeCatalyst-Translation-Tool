using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Binary_conver0
{
    class Program
    {
        /*
        public static List<string[]> fn_getPcFiles(String pc_fd, List<string> filterList)
        {
            List<string[]> list = new List<string[]>();
            var ext = filterList;
            foreach (string file in Directory.GetFiles(pc_fd, "*.*").Where(s => ext.Any(e => s.ToLower().EndsWith(e))).OrderByDescending(f => new FileInfo(f).LastWriteTime))
            {
                FileInfo f = new FileInfo(file);
                list.Add(new string[]{fn_getOnlyFileNm(file)
        , f.Length.ToString()
        , f.LastWriteTime.ToString()
        , file});
            }
            return list;
        }
        */
        static void Main(string[] args)
        {
            //경로 체크 및 확인
            System.IO.DirectoryInfo inpdi = new System.IO.DirectoryInfo(System.IO.Directory.GetCurrentDirectory() + @"\chunk");
            if (!inpdi.Exists) { inpdi.Create(); }
            System.IO.DirectoryInfo outdi = new System.IO.DirectoryInfo(System.IO.Directory.GetCurrentDirectory() + @"\excel");
            if (!outdi.Exists) { outdi.Create(); }
            //System.IO.Directory.GetCurrentDirectory() = 프로그램이 실행되는 경로

            //input 폴더와 output폴더를 만들고 그 폴더에서 읽고 내보내는 방식으로 기획
            
            Console.WriteLine("===============================");
            Console.WriteLine("Frostbite stringchunk Converter beta 0.1");
            Console.WriteLine("===============================");
            Console.WriteLine("Commands:");
            Console.WriteLine("chk2ex : output/*.chunk. to input/*.excel.");
            Console.WriteLine("ex2chk : input/*.excel to output/*.chunk.");
            Console.WriteLine("exit : Exit Program.");
            Console.WriteLine("===============================");

            while (true)
            {
                Console.Write("Command>");
                string command = Console.ReadLine();

                if (command == "chk2ex")
                {
                    Console.WriteLine("[chk2ex] running...");

                    byte[] bytes = File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + @"\chunk\input.chunk");    //바이트 읽기

                    Chunk2xlsx(bytes);

                    //File.WriteAllBytes(System.IO.Directory.GetCurrentDirectory() + @"\excel\output.xlsx", bytes);          //바이트 쓰기

                    Console.WriteLine("[chk2ex] Done!");
                }
                else if (command == "ex2chk")
                {
                    Console.WriteLine("[ex2chk] running...");

                    byte[] bytes = File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory() + @"\excel\input.xlsx");    //바이트 읽기

                    File.WriteAllBytes(System.IO.Directory.GetCurrentDirectory() + @"\chunk\output.chunk", bytes);          //바이트 쓰기

                    Console.WriteLine("[ex2chk] Done!");
                }
                else if (command == "exit") { break; } else { 
                    Console.WriteLine("< " + command + " >는 유효하지않는 명령입니다.");
                }
            }

        }

        public static void Chunk2xlsx(byte[] data)
        {
            CompressionThing deCompressor = new CompressionThing();
            //00 01 00 00 00 71 00 00이 필요함
            data = deCompressor.decompressLZ4(data);
            //청크 디컴프레스

            //File.WriteAllBytes(Path.Combine(CurrentPath,"en.bin.GOODY"), data);
            /*
            if (exportpath == "")
                exportpath = Tools.EnumarateFileName(CurrentPath, lang);*/
            string exportpath = System.IO.Directory.GetCurrentDirectory() + @"\chunk\input.chunk";
            deCompressor.ExportTextsToExcelFile(exportpath, data);
        }

    }
}
//ini 파일 모두 검색 후, txt로 변경
/*
foreach (FileInfo fileInfo in inpdi.GetFiles("*.excel")) //GetFiles() 적용시 모든 파일을 가져옴
{
    try
    {
        string sNewFileName = string.Format(@"\output\" + System.IO.Path.ChangeExtension(fileInfo.Name, ".chunk"));
        string sOldFileName = string.Format(@"\input\" + System.IO.Path.ChangeExtension(fileInfo.Name, ".excel"));
        System.IO.File.Move(sOldFileName, sNewFileName); //파일 확장자 변경
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception:" + ex.Message.ToString());
    }
}
/ 가져올 확장자를 지정합니다.
List<string> filterList = new List<string> { ".txt", ".csv", ".xls", ".xlsx" };
List<string[]> fileInfoList = fn_getPcFiles("c:\\test", filterList);
*///
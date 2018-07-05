using BLLevel.BLL;
using Microsoft.VisualBasic.FileIO;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParsingLibrary
{
    public class Parser 
    {
        private string _path;
        private string _manager;

        public Parser(string path)
        {
            _path = path;
        }

        public void Parse(DTService dTService)
        {
            
            TextFieldParser csvParser = null;

            try
            {
                csvParser = new TextFieldParser(_path);
                string c = System.IO.Path.GetFileName(_path);
                string[] c1 = c.Split('_');
                _manager = c1[0];

                csvParser.TextFieldType = FieldType.Delimited;
                csvParser.SetDelimiters(",");

                while (!csvParser.EndOfData)
                {
                    string[] s = csvParser.ReadLine().Split(',');
                    dTService.WriteRecord(new BLLevel.BLL.DTO.RecordDTO
                        (new Random().Next(), _manager, s[1], s[2], Convert.ToDateTime(s[0]), Convert.ToInt32(s[3])));
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Жмите any key");
               // Console.ReadKey();
                Environment.Exit(0);
            }
            finally
            {
                if (csvParser != null)
                {
                    ((IDisposable)csvParser).Dispose();
                    
                }
            }
            Object lockObject = new object();

            lock (lockObject)
            {
                File.Delete(_path);
            }

        }
    }
}

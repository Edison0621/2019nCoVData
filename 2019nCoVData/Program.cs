using ConsoleTables;
using ConTabs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;

namespace _2019nCoVData
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://view.inews.qq.com/") };
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("g2/getOnsInfo?name=disease_h5").GetAwaiter().GetResult();
            var result = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            nCoVData data = JsonConvert.DeserializeObject<nCoVData>(result);

            nCoVDataDetail nCoVDataDetail = JsonConvert.DeserializeObject<nCoVDataDetail>(data.Data);
            Console.WriteLine("更新时间：" + nCoVDataDetail.LastUpdateTime);
            Console.WriteLine("===========================================数据总览========================================");
            Console.WriteLine("确诊人数:" + nCoVDataDetail.ChinaTotal.Confirm);
            Console.WriteLine("疑似人数:" + nCoVDataDetail.ChinaTotal.Suspect);
            Console.WriteLine("死亡人数:" + nCoVDataDetail.ChinaTotal.Dead);
            Console.WriteLine("治愈人数:" + nCoVDataDetail.ChinaTotal.Heal);
            Console.WriteLine();
            Console.WriteLine("===========================================新增数据总览========================================");
            Console.WriteLine("确诊人数:" + nCoVDataDetail.ChinaAdd.Confirm);
            Console.WriteLine("疑似人数:" + nCoVDataDetail.ChinaAdd.Suspect);
            Console.WriteLine("死亡人数:" + nCoVDataDetail.ChinaAdd.Dead);
            Console.WriteLine("治愈人数:" + nCoVDataDetail.ChinaAdd.Heal);

            Console.WriteLine();
            Console.WriteLine("===========================================每日数据总览(按日期升序)========================================");

            ConsoleTable.From(nCoVDataDetail.ChinaDayList).Configure(o => o.NumberAlignment = ConsoleTables.Alignment.Right).Write(Format.Alternative);
            ConsoleTable.From(nCoVDataDetail.ChinaDayAddList).Configure(o => o.NumberAlignment = ConsoleTables.Alignment.Right).Write(Format.Alternative);

            SaveToFile(data);

            Console.ReadLine();
        }

        private static void SaveToFile(nCoVData data)
        {
            if (!File.Exists("data.json"))
            {
                using (FileStream fs = new FileStream("data.json", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(data.Data);
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            else
            {
                using (FileStream fs = new FileStream("data.json", FileMode.Open, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(data.Data);
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
        }
    }
}

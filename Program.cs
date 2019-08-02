using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Alturos.Yolo;
using System.Diagnostics;

namespace ConsoleImage
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string target = @"D:\Visual Project\Alturos.Yolo-master\Images\Car1.png";
            if (File.Exists(target))
            {
                var configurationDetector = new ConfigurationDetector();
                var config = configurationDetector.Detect();
                using (var yoloWrapper = new YoloWrapper(config))
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    var items = yoloWrapper.Detect(target);
                    Console.Write("Number of Object Detected: "+ items.Count().ToString()+"\tin: "+ sw.Elapsed.TotalSeconds+"s\n");
                    int y = 0;
                    foreach (Alturos.Yolo.Model.YoloItem s in items)
                    {
                       
                        Console.WriteLine(s.Type.ToString() + " Confidence:" + s.Confidence.ToString() + " X:" + s.X.ToString() + " Y:" + s.Y.ToString() + " Width:" + s.Width.ToString()+"\n");
                        if (s.Type.ToString().Equals("car"))
                            {
                            ++y;
                        }
                    }
                    Console.Write(y);
                    sw.Stop();
                }
               }
            else
            {
                Console.Write("NO");
            }
            Console.ReadKey();
        }
    }
}

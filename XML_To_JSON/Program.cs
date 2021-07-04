using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace XML_To_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Загружаем наш xml файл с директории проекта и сохраняем его в string
                string xml = GetXMLStringFromProjectDirectory();

                //Заполняем xml объект для дальнейшего проебразования
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                //Преобразование с xml к json и сохранение json файла в директории проекта
                XMLToJsonAndSave(doc);
            }

            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        static string GetXMLStringFromProjectDirectory()
        {
                string xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"test.xml");
                string[] xmlFiles = File.ReadAllLines(xmlPath);
                string xml = String.Join("\n", xmlFiles);
                return xml;
        }

        static void XMLToJsonAndSave(XmlDocument doc)
        {
            string json = JsonConvert.SerializeXmlNode(doc);
            string jsonPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"test.json");
            File.WriteAllText(jsonPath, json);

        }
    }
}

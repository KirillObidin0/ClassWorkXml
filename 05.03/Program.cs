using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _05._03
{
    class Program
    {
        static void Main(string[] args)
        {
            exmpl02();
        }
        static void exmpl01()
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);

            doc.AppendChild(declaration); //<?xml version="1.0" encoding="utf-8" ?>

            //<root></root>
            XmlElement root = doc.CreateElement("root");
            //<note></note>
            XmlElement note = doc.CreateElement("note");
            //<message></message>
            XmlElement message = doc.CreateElement("message");

            note.AppendChild(message);
            root.AppendChild(note); //<root> <note> <message></message> </note> </root>

            doc.AppendChild(root);  //<? xml version = "1.0" encoding = "utf-8" ?>
                                    //<root> <note> <message></message> </note> </root>
            
            message.InnerText = "Hello!";

            XmlAttribute date = doc.CreateAttribute("date");
            root.Attributes.Append(date);

            date.InnerText = "05.03.2019";

            doc.Save("note.xml");
        }
        static void exmpl02()
        {
            XmlDocument doc = new XmlDocument();

            //1 var is to parse a string
            string result = GetStatusMessage();
            doc.LoadXml(result);

            //2 var is to load web link
            doc.Load("http://www.examplelink.com");

            //3
            doc.Load("note.xml");
        }
        static string GetStatusMessage()
        {
            return "<result><message>Сообщение обрабатывается</message></result>";
        }
    }
}

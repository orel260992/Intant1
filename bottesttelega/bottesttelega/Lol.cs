using System;
using System.Xml;
using System.IO;

namespace bottesttelega
{
    public class user
    {
        public string Name;
        public string City;
        public int Age;
    }
    public class Lol
    {
        public void lalka()
        {            
            StreamWriter sw = new StreamWriter(@"files/Test.txt");            
            XmlDocument Price = new XmlDocument();
            Price.Load(@"files/offers.xml");
            XmlElement element = Price.DocumentElement;
            foreach (XmlNode xnode in element)
            {
                if (xnode.Attributes.Count > 0)
                {
                    
                        XmlNode attr = xnode.Attributes.GetNamedItem("ПакетПредложений");
                    if (attr != null)
                    {
                        /*Console.WriteLine(attr.Value);
                        sw.WriteLine($"Имя: {attr.Value}");*/
                    }
                }
                     foreach (XmlNode childnode in xnode.ChildNodes)
                                {
                                        if (childnode.Name == "Предложения")
                                        {

                        /*Console.WriteLine($"Город: {childnode.InnerText}");
                        sw.WriteLine($"Имя: {childnode.InnerText}");*/
                        foreach (XmlNode hildnode in childnode.ChildNodes)
                        {
                            if (hildnode.Name == "Предложение")
                            {

                                /*Console.WriteLine($"Город: {hildnode.InnerText}");
                                sw.WriteLine($"Имя: {hildnode.InnerText}");*/
                                foreach (XmlNode ildnode in hildnode.ChildNodes)
                                {
                                    if (ildnode.Name == "Наименование")
                                    {

                                        Console.WriteLine($"{ildnode.InnerText}");
                                        sw.WriteLine($"{ildnode.InnerText}");                                      
                                        
                                    }
                                    foreach (XmlNode ldnode in ildnode.ChildNodes)
                                    {
                                        foreach (XmlNode dnode in ldnode.ChildNodes)
                                        {
                                            if (dnode.Name == "Представление")
                                            {

                                                Console.WriteLine($"Цена: {dnode.InnerText}");
                                                sw.WriteLine($"Цена: {dnode.InnerText}");
                                            }
                                        }
                                    }
                                    if (ildnode.Name == "Количество")
                                    {

                                        Console.WriteLine($"Остаток(шт): {ildnode.InnerText}");
                                        sw.WriteLine($"Остаток(шт): {ildnode.InnerText}");
                                        sw.WriteLine($"*********************************");
                                        Console.WriteLine($"---------------");
                                        
                                    }
                                    
                                }
                            }
                        }
                    }
                    
                }

            }
                sw.Close();
          
        }
    }
}

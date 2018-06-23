/*using System;
using System.Linq;//LINQ查询的命名空间

namespace _1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			//int[] b = new int[5];
			//int j = 0;
			//for (int i = 0; i < 10; i++)
			//{
			//	if (a[i] % 2 == 0)
			//	{
			//		b[j++] = a[i];
			//	}
			//}
			//
			//for (int i = 0; i < 5; i++)
			//{
			//	Console.WriteLine(b[i]);
			//}

			//LINQ查询语句：
			//from t :创建一个临时变量(t的类型可以省略)
			//in a :在a中查询
			//where t :条件
			//select t:选择满足条件的t
			//返回所有满足条件的元素的容器
			var b = from t in a
					where t % 2 == 0
					select t;
			foreach (int t in b)
			{
				Console.WriteLine(t);
			}

			var p = new[]{
				new { Name = "aa", Age = 20},
				new { Name = "bb", Age = 25},
				new { Name = "cc", Age = 23},
				new { Name = "dd", Age = 22}
			};
			var px = from t in p
					 where t.Age > 22
					 select t;
			foreach (var t in px)
			{
				Console.WriteLine(t.Name + " " + t.Age);
			}
		}
	}
}
*/
/*using System;
using System.Linq;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			int[] a = { 5, 7, 3, 1, 4, 8, 2, 23, 8, 6, 4, 9, 5, 8 };
			var b = from t in a
					where t > 5
					orderby t descending//ascending/descending
					select t;
			foreach (int t in b)
			{
				Console.Write(t + " ");
			}
			Console.WriteLine();
		}
	}
}*/
/*using System;
using System.Linq;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			var a = new[] {
				new { Name = "aa", Age = 20, ID = 201801, Address = "aaa", Class = 1 },
				new { Name = "bb", Age = 21, ID = 201802, Address = "bbb", Class = 2 },
				new { Name = "cc", Age = 25, ID = 201803, Address = "ccc", Class = 1 },
				new { Name = "dd", Age = 24, ID = 201804, Address = "ddd", Class = 3 },
				new { Name = "ee", Age = 22, ID = 201805, Address = "eee", Class = 2 }
			};
			//var b = from t in a
			//		orderby t.Age
			//		select new { t.Name, t.Age };
			//foreach (var t in b)
			//{
			//	Console.WriteLine(t);
			//}
			var b = from t in a
					group t by t.Class;//通过Class属性对t进行分组，返回各个分组
			foreach (var t in b)//遍历得到的是每一个分组
			{
				Console.WriteLine(t.Key);//Key属性表示分组的编号
				foreach (var tt in t)//遍历得到的是分组中的每一个成员
				{
					Console.WriteLine(tt);
				}
				Console.WriteLine("--------------");
			}
		}
	}
}*/
/*using System;
using System.Linq;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			int[] a = { 1, 2, 3 };
			int[] b = { 4, 5, 6 };

			var q = from x in a
					from y in b
					let sum = x + y //let让sum等于x+y
					//where sum == 6
					select new { x, y, sum };
			foreach (var t in q)
			{
				Console.WriteLine(t);
			}
		}
	}
}*/
/*using System;
using System.Linq;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			int[] a = { 1, 2, 3, 4, 5, 6, 7 };

			var b = from t in a
					select t;//编写查询语句没有真正查询
			a[0] = 100;
			
			foreach (var t in b)//遍历b时才真正查询
			{
				Console.WriteLine(t);
			}

			Console.WriteLine("-- "+b.Count());
		}
	}
}*/
/*using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//File.Open("/Users/wzc/Desktop/code/0515第一教室/0613_1/0613_1/Book.xml", FileMode.Open);
			//FileStream 文件流，对文件进行操作的缓冲区
			FileStream fs = File.Open("../../Book.xml", FileMode.Open);
			//fs.Read();参数比较多，比较麻烦，不建议用
			//通过文件流创建一个专门做读操作的流
			StreamReader sr = new StreamReader(fs);
			string str = sr.ReadToEnd();
			//Console.WriteLine(str);
			fs.Close();//关闭文件流

			//解析xml字符串
			//XElement是xml文件中的元素(标签)
			XElement ele = XElement.Parse(str);//XElement.Parse得到的是根标签
											   //Console.WriteLine(ele.Name);
			var result1 = from t in ele.Elements("book")
						  orderby int.Parse(t.Element("price").Value) ascending
						  select t;
			//result中保存的是root的所有子标签(4个book标签)
			foreach (var t in result1)//t就是每一个book标签
			{
				Console.WriteLine(t.Name);
				foreach (var x in t.Elements())//继续遍历book的子标签
				{
					Console.WriteLine(x.Name + " " + x.Value);
				}
				Console.WriteLine("----------");
			}

			var result2 = from q in ele.Elements()
						  select new { Name = q.Element("bookname").Value, Author = q.Element("author").Value, Price = q.Element("price").Value };
			foreach (var t in result2)
			{
				Console.WriteLine(t);
			}
		}
	}
}*/
/*using System;
using System.Xml;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//#用%23代替
			XmlDocument doc = new XmlDocument();
			doc.Load("../../Book.xml");//通过Load加载xml文件，把内容全部加载到doc对象中
			XmlElement root = doc.DocumentElement;//DocumentElement属性获得根节点(根标签)
												  //Console.WriteLine(root.Name);//Name：标签的名字
			XmlNodeList children = root.ChildNodes;//ChildNodes属性获得所有子节点

			//XmlElement是XmlNode的子类
			foreach (XmlNode t in children)//遍历得到每一个book标签
			{
				XmlElement temp = (XmlElement)t;
				Console.WriteLine(temp.Name);
				foreach (XmlNode x in temp.ChildNodes)//遍历得到book的子标签
				{
					XmlElement xtemp = (XmlElement)x;
					Console.WriteLine(xtemp.Name + " " + xtemp.InnerText);//InnerText标签内容
				}
				Console.WriteLine("------------------");
			}
		}
	}
}*/
/*using System;
using System.Xml;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//# --> %23
			XmlDocument doc = new XmlDocument();
			doc.Load("../../Book.xml");

			XmlElement root = doc.DocumentElement;//root根节点
			XmlNodeList children = root.ChildNodes;//root下的4个子节点容器
			foreach (XmlNode node in children)
			{
				XmlElement ele = (XmlElement)node;//ele是每一个book标签
				//获取所有名字叫bookname的子标签，返回到一个容器中
				XmlNode bookname = ele.GetElementsByTagName("bookname")[0];
				XmlNode author = ele.GetElementsByTagName("author")[0];
				XmlNode price = ele.GetElementsByTagName("price")[0];

				Console.WriteLine("{0} {1} {2}", bookname.InnerText, author.InnerText, price.InnerText);
			}
		}
	}
}*/
/*using System;
using System.Xml;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load("../../Book.xml");
			XmlElement root = doc.DocumentElement;

			XmlElement newEle = doc.CreateElement("book");
			XmlElement booknameEle = doc.CreateElement("bookname");
			XmlElement authorEle = doc.CreateElement("author");
			XmlElement priceEle = doc.CreateElement("price");

			booknameEle.InnerText = "xxx";
			authorEle.InnerText = "xxxauthor";
			priceEle.InnerText = "100";

			newEle.AppendChild(booknameEle);
			newEle.AppendChild(authorEle);
			newEle.AppendChild(priceEle);

			//root.AppendChild(newEle);//在root中添加一个新的子节点

			root.RemoveChild(root.GetElementsByTagName("book")[2]);//删除节点，括号中是具体的节点
			doc.Save("../../Book.xml");//重新保存xml内容
		}
	}
}*/
/*using System;
using System.Xml;
using System.Collections.Generic;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			List<Book> l = new List<Book>();
			XmlDocument doc = new XmlDocument();
			doc.Load("../../Book.xml");
			XmlElement root = doc.DocumentElement;
			foreach (XmlNode t in root.ChildNodes)
			{
				XmlElement book = (XmlElement)t;
				XmlNode name = book.GetElementsByTagName("bookname")[0];
				XmlNode author = book.GetElementsByTagName("author")[0];
				XmlNode price = book.GetElementsByTagName("price")[0];

				Book tempBook = new Book(name.InnerText, author.InnerText, int.Parse(price.InnerText));
				l.Add(tempBook);
			}
			foreach (Book t in l)
			{
				Console.WriteLine(t);
			}
		}
	}
	class Book
	{
		public string BookName { get; set; }
		public string Author { get; set; }
		public int Price { get; set; }
		public Book(string _name, string _author, int _price)
		{
			BookName = _name;
			Author = _author;
			Price = _price;
		}
		public override string ToString()
		{
			return string.Format("[Book: BookName={0}, Author={1}, Price={2}]", BookName, Author, Price);
		}
	}
}*/
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			Book b1 = new Book("aa", "aaaa", 100);
			Book b2 = new Book("bb", "aaaa", 100);
			Book b3 = new Book("cc", "aaaa", 100);
			Book b4 = new Book("dd", "aaaa", 100);
			Book b5 = new Book("ee", "aaaa", 100);
			Book b6 = new Book("ff", "aaaa", 100);
			Book b7 = new Book("gg", "aaaa", 100);

			List<Book> l = new List<Book> { b1, b2, b3, b4, b5, b6, b7 };
			string xmlstr = dataToXml(l);
			Console.WriteLine(xmlstr);

			XElement root = XElement.Parse(xmlstr);
			var result = from t in root.Elements()
						 select new Book(t.Element("bookname").Value, t.Element("author").Value, int.Parse(t.Element("price").Value));
			foreach (Book t in result)
			{
				Console.WriteLine(t);
			}
		}
		public static string dataToXml(List<Book> l)
		{
			string str = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
			str += "<root>\n";
			foreach (Book t in l)
			{
				str += "\t<book>\n";
				str += "\t\t<bookname>" + t.BookName + "</bookname>\n";
				str += "\t\t<author>" + t.Author + "</author>\n";
				str += "\t\t<price>" + t.Price + "</price>\n";
				str += "\t</book>\n";
			}
			str += "</root>";
			return str;
		}
	}

	class Book
	{
		public string BookName { get; set; }
		public string Author { get; set; }
		public int Price { get; set; }
		public Book(string _name, string _author, int _price)
		{
			BookName = _name;
			Author = _author;
			Price = _price;
		}
		public override string ToString()
		{
			return string.Format("[Book: BookName={0}, Author={1}, Price={2}]", BookName, Author, Price);
		}
	}
}
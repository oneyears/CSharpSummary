using System;
using System.Linq;//Linq查询的命名空间
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
//LINQ查询
/*
namespace CSharpDay19_06_13
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			//LinQ查询语句： 
			//from t创建一个临时变量
			//from t :创建一个临时变量(t的类型可以省略)
			//in a : 在a中查询
			//where t： 条件
			//select t 选择满足条件 返回满足条件的元素的容器
			//

			var b = from t in a
			        where t % 2 == 0
			        select t;

			foreach (var t in b) {
				Console.WriteLine (t);
			}

			var p = new[] {
				new{Name = "ls",Age = 22},
				new{Name = "ls2",Age = 23},
				new{Name = "ls3",Age = 22},
				new{Name = "ls4",Age = 25},
				new{Name = "ls5",Age = 24},
				new{Name = "ls6",Age = 23},
			};

			var array = from t in p
					where t.Age > 22
				//orderby  descending
			            select t;
			foreach (var i in array)
				Console.WriteLine (i);
		}
	}
}
*/
/*
namespace demo1{
	class MainClass{
		public static void Main(){
			int[] a = { 4, 5, 6, 2, 2, 1, 0, 9, 6, 3 };
			var b = from t in a
				where t >=3
				orderby t //默认是升序ascending 降序用 descending如： orderby descending t
			        select t;
			foreach (var t in b)
				Console.WriteLine (t);
			Console.WriteLine("----------------");
			var array = new[] {
				new {Name = "ls1",Age = 22,Class = 1,Adress = "beijing",Id = 1},
				new {Name = "ls2",Age = 23,Class = 2,Adress = "shanghai",Id = 3},
				new {Name = "ls3",Age = 24,Class = 1,Adress = "yic",Id = 2},
				new {Name = "ls4",Age = 21,Class = 2,Adress = "najing",Id = 4},
				new {Name = "ls5",Age = 26,Class = 1,Adress = "guangzhou",Id = 5},
				new {Name = "ls6",Age = 24,Class = 3,Adress = "shengzhen",Id = 8},
				new {Name = "ls7",Age = 25,Class = 1,Adress = "tianjing",Id = 9},
			};

			var arraySort = from t in array
							orderby t.Age
			                select t;
			foreach (var t in arraySort)
				Console.WriteLine (t);
//			匿名数组能通过对象的年龄进行排序，但是IDE没有显示提示代码，需要强行把写出代码	
			Console.WriteLine("----------------");
			var b2 = from t2 in array
			         group t2 by t2.Class;//group t2 by t2.xx 按相同的属性（值）分组
			foreach (var t in b2) {
				Console.WriteLine (t.Key);
				//Console.WriteLine (t);	//	打印数组的参数数据类型
				//每组可以继续遍历打印
				foreach (var tt in t) {
					Console.WriteLine (tt);
				}
				Console.WriteLine("----------------");

			}


		}
	}
}
*/
/*
namespace demo2{
	class MainClass{
		public static void Main(){

			int[] a = { 1, 2, 3, 4 };
			int[] b = { 4, 5, 6 };
			var q = from x in a
			        from y in b
			        let sum = x * y //let 让sum 加起来  是一个元素以另外一个数组的全部元素 进行操作（两个from相当于两个for循环）
					//where sum == 6    
				select new {x,y,sum};
			foreach (var t in q)
				Console.WriteLine (t);

		}
	}
}
*/
/*
namespace demo3{
	class MainClass{
		public static void Main(){
			int[] a = { 1, 2, 3, 4 ,5,6,7,8};
			var b = from t in a
				orderby t
			        select t; //编写查询语句没有真正查询
			a [0] = 100;
			foreach (var t in b)//遍历b时才真正查询
				Console.WriteLine (t);
			Console.WriteLine ("容器个数"+b.Count());
		}
	}
}
*/
/*
namespace demo4{
	class MainClass{
		public static void Main(){
			//File.Open ("/Users/neworigin/Desktop/MyC\\#Test/CSharpDay19_06_13/CSharpDay19_06_13/Book.xml", File.Open);//绝对路径
			FileStream fs = File.Open ("../../Person.xml",FileMode.Open);//相对路径
			//fs.Read(); 参数比较多，比较麻烦，不建议用
			//FileStream 文件流，对文件进行操作的缓存区
			//通过文件流创建一个专门做读操作的流

			StreamReader sr = new StreamReader(fs);

			string str = sr.ReadToEnd ();//从头读到尾

			Console.WriteLine (str);

			fs.Close ();//关闭文件流 将文件内容以字符串的方式储存给 str，就可以关闭文件流了

			//解析xml字符串  XElement元素，也可解释成标签

			//XElement ele = new XElement (str);
			//第二种方式
			XElement ele2 = XElement.Parse (str);//得到的是根标签 如果这里错误，则可能是XML文件出错了
			//Console.WriteLine (ele.Name);
			Console.WriteLine (ele2.Name);

			var result = from t in ele2.Elements ("Person")
			             select t;

			foreach (var t in result) {
			
				Console.WriteLine (t.Name);
				foreach (var x in t.Elements()) {
					Console.WriteLine (x.Name+" "+x.Value);
				}
				Console.WriteLine ("----------------------");
			}

			var res = from t in result.Elements ("Name")
			          select t;

			foreach (var t in res)
				Console.WriteLine (t);
			//创建匿名对象，返回reult2容器
			//Elements () 不加参数是返回所有的名字子标签    加了名字就是指定的子标签
			var result2 = from t in ele2.Elements ()
				orderby int.Parse(t.Element("Age").Value) descending
				select new {Name = t.Element ("Name").Value,Age = t.Element ("Age").Value,Id = t.Element("Id").Value};
			foreach (var t in result2)
				Console.WriteLine (t);
		}
	}
}
*/
//引入 using System.xml 空间名
/*
namespace demo5XML解析{
	class MainClass{
		public static void Main(){

			XmlDocument doc = new XmlDocument ();
			//需要把 # -> %23   
			//doc.Load("../../Book.xml"); //通过Load加载xml文件，把内容全部加载到doc对象
			doc.Load ("/Users/neworigin/Desktop/MyC%23Test/C%23Day19/CSharpDay19_06_13/CSharpDay19_06_13/Book.xml");
			XmlElement root = doc.DocumentElement;//DocumentElement属性获得根节点(根标签)
			//Console.WriteLine(root.Name);//Name：标签的名字
			XmlNodeList children = root.ChildNodes;//ChildNodes属性获得所有子节点 （根结点下的所有子节点）

			//XmlElement是XmlNode的子类
			foreach (XmlNode t in children)//遍历得到每一个book标签
			{
				//注意Xml 是
				XmlElement temp = (XmlElement)t;//XmlNode是XmlElement的父类
				Console.WriteLine(temp.Name);
				foreach (XmlNode x in temp.ChildNodes)//遍历得到book的子标签
				{
					XmlElement xtemp = (XmlElement)x;
					Console.WriteLine(xtemp.Name + " " + xtemp.InnerText);//InnerText标签内容
					//XmlNode bookname = xtemp.GetElementsByTagName ("bookname") [0];
					//XmlNode price = xtemp.GetElementsByTagName ("price") [0];
					//Console.WriteLine (bookname.Name + " " + price.Name);
				}
				Console.WriteLine("------------------");
			}
		}
	}
}
*/
/*
namespace demo6Test{
	class MainClass{
		public static void Main(){

			XmlDocument doc = new XmlDocument ();

			doc.Load ("/Users/neworigin/Desktop/MyC%23Test/C%23Day19/CSharpDay19_06_13/CSharpDay19_06_13/Book.xml");

			XmlElement root = doc.DocumentElement;

			XmlNodeList children = root.ChildNodes;

			foreach (XmlNode node in children) {
				//node.g
				//XmlElement是 XmlNode的子节点   XmlElement ：XmlLinkedNode ：XmlNode  XmlNodeList是 XmlNode的（里面有迭代器的）容器
				XmlElement ele = (XmlElement)node;
				//获取所有名字叫bookName的子标签，返回到一个容器中
				XmlNode bookname = ele.GetElementsByTagName ("bookName") [0];
				XmlNode author = ele.GetElementsByTagName ("author") [0];
				XmlNode price = ele.GetElementsByTagName ("price") [0];
				//Console.WriteLine (bookname.Name + " " + author.Name + " " + price.Name);//打印对象本身的名字
				Console.WriteLine ("{0} {1} {2}", bookname.InnerText, author.InnerText, price.InnerText);
			}
		}
	}
}
*/
/*
namespace demo7{
	class MainClass{
		public static void Main(){
			XmlDocument doc = new XmlDocument ();
			doc.Load ("/Users/neworigin/Desktop/MyC%23Test/C%23Day19/CSharpDay19_06_13/CSharpDay19_06_13/Book.xml");

			XmlElement root = doc.DocumentElement;

			XmlElement newEle = doc.CreateElement ("book");

			XmlElement booknameEle = doc.CreateElement ("bookName");

			XmlElement priceEle = doc.CreateElement ("price");

			XmlElement authorEle = doc.CreateElement ("author");

			booknameEle.InnerText = "xxx1";
			authorEle.InnerText = "xxxauthor";
			priceEle.InnerText = "120";

			newEle.AppendChild (booknameEle);
			newEle.AppendChild (authorEle);
			newEle.AppendChild (priceEle);

			root.AppendChild (newEle);//在root中添加一个新的子节点
			//root.RemoveChild (root.LastChild); //删除最后一个
			//删除第5个book
			//root.RemoveChild (root.GetElementsByTagName("book")[4]);

			doc.Save ("/Users/neworigin/Desktop/MyC#Test/C#Day19/CSharpDay19_06_13/CSharpDay19_06_13/Book.xml");//重新保存xml内容 //小细节不能用%23代替 #了

		}
	}

}
*/
/*
namespace demo8{
	class MainClass{
		public static void Main(){
			XmlDocument doc = new XmlDocument ();
			doc.Load("/Users/neworigin/Desktop/MyC%23Test/C%23Day19/CSharpDay19_06_13/CSharpDay19_06_13/Book.xml");
			XmlElement root = doc.DocumentElement;

			foreach (XmlNode t in root.ChildNodes) {
				XmlElement book = (XmlElement)t;
				XmlNode Name = book.GetElementsByTagName ("Name") [0];
				XmlNode Author = book.GetElementsByTagName ("Author") [0];
				XmlNode Price = book.GetElementsByTagName ("Price") [0];
			}
			Book b1 = new Book (Name, Author, Price);
		}
	}

	class Book{
		public string Name{ get; set; }
		public string Author{get;set;}
		public int Price{get;set;}
		public Book(string Name,string Author,int Price){
			this.Name = Name;
			this.Author = Author;
			this.Price = Price;
		}
	}
}
*/
/*
namespace demo8_2
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
/*
namespace demo9
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

*/

/*
namespace demo10TestLinq解析xml{
	class MainClass{
		public static void Main(){

			FileStream fs = File.Open("/Users/neworigin/Desktop/MyC#Test/C#Day19/CSharpDay19_06_13/CSharpDay19_06_13/Person.xml",FileMode.Open);
			StreamReader sr = new StreamReader (fs);
			string str = sr.ReadToEnd ();
			fs.Close ();

			XElement ele = XElement.Parse (str);
			var rootChilid = from t in ele.Elements ()
			             select t;

			//获得所以成员
			var nodelist = from t in rootChilid.Elements ()
			               select t;
			foreach (var rt in rootChilid) {

				foreach (var t in rt.Elements()) {
					Console.WriteLine (t);
				}
				Console.WriteLine ("------------");
			}
		}
	}
}
*/
/*
namespace demo11TestXML解析{
	class MainClass{
		public static void Main() {
			XmlDocument doc = new XmlDocument ();
			doc.Load ("/Users/neworigin/Desktop/MyC%23Test/C%23Day19/CSharpDay19_06_13/CSharpDay19_06_13/Person.xml");
			XmlElement root = doc.DocumentElement;
			XmlNodeList rootChild = root.ChildNodes;


			foreach (XmlNode t in rootChild) {

				XmlElement person = (XmlElement) t;
				XmlNode name = person.GetElementsByTagName("Name")[0];
				XmlNode sex = person.GetElementsByTagName ("Sex") [0];
				XmlNode id = person.GetElementsByTagName ("Id") [0];
				XmlNode age = person.GetElementsByTagName ("Age") [0];
				XmlNode address = person.GetElementsByTagName ("Address") [0];
				Console.WriteLine ("{0},{1},{2},{3},{4}", name.InnerText, sex.InnerText, id.InnerText, age.InnerText,address.InnerText);
			}

		}
	}
}
*/

namespace demo12filestreamToTxt{

	class MainClass{

		public static void Main(){

			FileStream ff = File.Open ("test1.txt", FileMode.Open);



		}

	}

}


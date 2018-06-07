/*using System;

namespace _1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//sizeof 计算类型的所占字节数
			Console.WriteLine(sizeof(int));
			Console.WriteLine(sizeof(byte));
			Console.WriteLine(sizeof(float));
			Console.WriteLine(sizeof(double));
			Console.WriteLine(sizeof(long));

			Console.WriteLine("int的字节数是：{0}",sizeof(int));//int的字节数是：4

			int c = 100;
			int a = 5;
			int b = 10;
			Console.WriteLine("{1},{2},{0}", c, a,b);
			//大括号中的数值表示后边变量的位置，0是第一个变量，往后依次加1

			Console.WriteLine("hello \"world\"");
			Console.WriteLine("hello 'world'");
			Console.WriteLine("hello {world}");
			Console.WriteLine("hello {{world}},{0}",a);


			Console.WriteLine("hello \nworld");
			//\是转义字符，表示不按默认的意义打出
		}
	}
}
*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			int a = 5;
			int b = 10;

			Console.WriteLine("a = {0},b = {1}", a, b);

			Console.WriteLine("a = " + a + ",b = " + b);

			Console.WriteLine("a = " + a);
			//+是字符串拼接符号可以连接两个字符串
			Console.WriteLine("5" + "10");
			Console.WriteLine(5 + 10);

			Console.Write("hello");
			Console.Write("world");
			Console.WriteLine("hello world");
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//char a = 'a';
			//char b = 'b';

			string c = "你好hello,world!";//用双引号引起来的内容就是字符串
										//字符串：在内容中开辟一块连续空间，将多个字符放在一起
			c = "Hello World";//赋值过程：将原来的空间释放掉，重新开辟新的空间


			Console.WriteLine("hello world");
			Console.WriteLine(c);

			string d = c + 123;
			Console.WriteLine(d);
			int a = 5;
			int b = 10;
			string e = "a="+a+",b="+b;
			Console.WriteLine(e);
			string f = string.Format("a={0},b={1}", a, b);
			//string.Format按照某种格式创建字符串
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			int a = 5;
			double b = a + 1.1d;
			//进行操作的两个数如果类型不一样，要先转换成相同类型再进行计算
			//int c = b + 5;
			//隐式类型转换的规则：1.只能由低精度转换成高精度
			char c = 'a';
			int d = c + 1;//2.char转成int是使用字符的asc码
			Console.WriteLine(d);
			int e = 'a' - 'A';//3.所有的char做运算时先转换成int在进行计算
			Console.WriteLine(e);
			//4.所有的浮点型运算都要先转换成double再进行运算
			float f = 5.5f - 4.4f;
			//5.赋值运算，等号右边的会直接转换成等号左边的类型，如果转换不了就要显示类型转换
		}

	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//强制类型转换，从高精度转换成低精度，会丢失精度，直接丢掉小数点后的数值
			double a = 5.9d;
			int b = (int)a;
			//1.括号中写上强转的类型
			Console.WriteLine(b);

			//2.使用Convert类中的方法进行转换
			int c = Convert.ToInt32(a);//会四舍五入
			//int d = Convert.ToInt32(Math.Floor(a));Console.WriteLine(d);
			Console.WriteLine(c);
			float d = Convert.ToSingle(a);//转float
			Console.WriteLine(d);

			//3.专门转换字符串和数字的转换方式(只能转换纯数字的字符串,f,d也不可以)
			string e = "123";
			double f = double.Parse(e) + 5;
			Console.WriteLine(f);
			string g = "123.4";
			int h = int.Parse(g);//不可以直接转成int
			Console.WriteLine(h);
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			int a;
			int b;
			//a = Console.Read();//Read函数从键盘输入一个字符，得到字符的asc码
			//string x = Console.ReadLine();//ReadLine从键盘读入的是字符串
			//a = int.Parse(x);//将字符串转换成数字
			//Console.WriteLine(a);

			//a = int.Parse(Console.ReadLine());
			//Console.WriteLine(a);
			//b = int.Parse(Console.ReadLine());
			//Console.WriteLine(b);

			char c;
			c = (char)Console.Read();//a
			c = (char)(c - 32);
			Console.WriteLine(c);
		}
	}
}*/
/*using System;
namespace aaa
{

	enum color { red, green=11, yellow, blue, black, white };//定义枚举：把所有可以设置的颜色放在color枚举中
	//color称为枚举类型 d和e称为枚举变量 red,green,yellow称为枚举值
	class MainClass
	{
		public static void Main()
		{
			//枚举：所有可能取值的集合

			color d;//怪物的颜色属性 用枚举变量当怪物的颜色属性
			d = color.red;//在枚举中选择一个颜色
			color e;
			e = color.green;
			Console.WriteLine((int)color.red);
			Console.WriteLine((int)color.green);
			Console.WriteLine((int)color.yellow);
			Console.WriteLine((int)color.blue);
			Console.WriteLine((int)color.black);
			Console.WriteLine((int)color.white);
			//每一个枚举值都对应着一个整数值
			//第一个枚举值默认是0，后边依次加1
		}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//数组：相同类型元素的集合
			int[] a = new int[100];//创建一个100元素的数组
								   //int[] 表示数组中的元素是int类型的数组
								   //a是数组名
								   //new int[]创建数组，在内存中开辟空间
								   //100 是数组中元素的个数
								   //整个数组（100个元素）在内存中是连续分布的

			//访问数组中的元素：通过元素的下标去访问
			//下标：数组中的每一个元素都对应着一个数字标识的位置，这个数字就是下标
			//下标从第一个元素开始 从0开始依次加1

			//数组名+[]+下标
			a[0] = 100;
			a[1] = 99;

			Console.WriteLine(a[0]);
			Console.WriteLine(a[1]);

			int[] b = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			string[] c = { "aaa", "bbb", "ccc", "ddd" };
			int[,] d = new int[4, 3]{   
				{1,2,3 },
				{4,5,6 },
				{7,8,9 },
				{0,1,2 }
			};
			//1 2 3 4 5 6 7 8 9 0 1 2
			Console.WriteLine(d[0,0]);
			Console.WriteLine(d[1,1]);
			Console.WriteLine(d[3,2]);






			int[] x = new int[10];
			//x = { 1,2,3,4,5,6,7,8,9,10};//数组创建后只能一个元素一个元素的初始化
			x[0] = 1;
			x[1] = 2;
			//....
			x[9] = 10;
			int[] y = new int[10]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		}
	}
}*/
using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			Person p;//创建一个人物
			p.name = "张三";
			p.age = 20;
			p.sex = '男';

			Console.WriteLine(p.name + " " + p.age + " " + p.sex);
			//属性的访问：通过点.访问

			//p就是一个结构体变量，一个具体的人
			//name age sex就是这个人的内在属性
			//Person是结构体类型 规定了人的内在结构

			Person q;
			Person person;
		}
	}

	//struct：定义结构体的关键字
	//结构体：自己定义一个结构列出某个事物的内在属性
	struct Person
	{
		public string name;//public标识的属性可以在结构体外直接访问
		public char sex;
		public int age;
	}

	//定义一个结构列出点的内在属性
	struct Point
	{
		int x;
		int y;
	}
}

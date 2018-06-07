using System;

namespace Day02_0516{



	enum color {red,green=11,yellow};
	//color 称为枚举类型，也是值类型，且在C#中，需要定义在main 函数外
	//括号里面的值成为  枚举值，每个枚举值都有一个整型数对应，默认从第一个开始为 0 并逐渐递增1

	enum attack { onehand,twohand,special};



	class MainClass
	{



		public static void Main (string[] args)
		{
			/*//一：浮点数 ， 和  {}的使用，{0}，{1} 是根据变量的安放次序来打印
			int a = 12;
			float b = 122.1234567f;
			float c = 12.1234567f;
			float d = 1.1234567f;
			float e = .123456789f;
			Console.WriteLine ("a = {0},b = {1}", a, b);//b输出122.1235
			Console.WriteLine ("c = {0}", c);//c输出12.12345
			Console.WriteLine ("d = {0}", d);//d输出1.123457
			Console.WriteLine ("e = {0}", e);//e输出0.1234568
			//说明float浮点数的有效精度为7位数，是对整个数而言，而非小数点后7位数
			//应该是当值为0.xxxxxxxx时，最多精确到小数点后7位
			
			Console.WriteLine ("qqq\"- -使用两个\\\\斜杠作为转义字符\"");
			Console.WriteLine("hello {{world}},{0}",a);
			Console.WriteLine ("hello\n \"\\n表示转行\" world");
			*/
			/*
			//二： 拼接 + write() \n
			int a = 10;
			int b = 12;
			Console.WriteLine ("qwqwqw" + a + b);
			//输出 qwqwqw1012
			Console.WriteLine (a + b);
			//输出 22
			Console.WriteLine ("qwq" + (a + b));
			//输出 qwq22
			Console.WriteLine (1 + 2 * 3);
			//输出  7
			Console.Write ("haha ");
			Console.Write ("QQQ\n123\n");
			//输出 haha QQQ
			//	  123
			//
			Console.WriteLine ("1,\n2,\n3,\n");
			//输出 1，
			//	  2，
			//	  3，
			//
			//
			*/
			/*
			//三：字符串
			string s = ":)(:";
			char c = 'a';//char  c# char内存占二个字节
			Console.WriteLine (s);
			Console.WriteLine (c+s);
			Console.WriteLine (sizeof(char));//输出2

			//Console.WriteLine (sizeof(string));错误，string是字符串（引用）类型，不能使用sizeof来确定字节数
			Console.WriteLine (s.Length);//输出4
			//s =   c;//char类型不能直接赋值给 string 类型变量
			s = "赋值一个字符串"+" assa";//赋值过程：将原来的空间释放掉，重新开辟新的空间，在开辟一块连续的空间

			Console.WriteLine (s);//输出 赋值一个字符串

			s = "123 " + 123;
			Console.WriteLine (s);//输出123 123

			c = '哈';
			Console.WriteLine (c);//输出 哈

			string s1 = "10"; //string s1 = 10;  不能直接赋值整型
			string s2 = "12";
			string f = string.Format ("a={0},b={1},c={2}", s1, s2,s1+s2+s1);
			Console.WriteLine (f);//输出a=10,b=12,c=101210
			int a1 = 10;
			int a2 = 13;
			string f1 = string.Format ("s1+s2 = {0},a1 = {1}", s1+s2,a1);
			Console.WriteLine (f1);//输出a = 1012,a1 = 10
			string f2 = string.Format ("s1+s2 = {0},a1+a2 = {1}", s1+s2,a1+a2);
			Console.WriteLine (f2);//s1+s2 = 1012,a1+a2 = 23
			//ToDo f1.format
			*/
			/*
			//=======================================
			//四：类型转换
			//低精度转成高精度是隐式转换（编译器默认转换）
			//高精度转成精度是显示转换（强转）
			int a = 1;
			float f = 1.23456789f;
			Console.WriteLine(a+f);//2.234568 隐式转换
			char c = 'a';
			int b = c + a;
			Console.WriteLine (b);//98
			int e = 'a' - 'A';//char类型进行运算时先转换成int类型再进行计算
			//char c1 = 'a' - 'A'; 此时有语法错误，字符型不能进行相-
			Console.WriteLine (e);//32

			float f2 = 2.1111114f;
			float f3 = 2.2345654f;
			float f4 = f2 + f3;//浮点间进行计算会先隐式转换成 double类型再进行计算，再进行float转换，
			Console.WriteLine (f4);//4.345677 先进行double为 2.3456768,四舍五入得出2.2345677


			//=======================================	
			//强制转换
			double d = 5.5d;
			//1、使用括号
			int bt = (int)d;//会丢失进度，直接丢掉小数点后面的数
			Console.WriteLine(bt);//5
			//2、使用Convert类中的方法
			int bt2 = Convert.ToInt32 (d);
			Console.WriteLine (bt2);//6,5.5会四舍五入

			double d1 = 1.12345678;
			float bt3 = Convert.ToSingle (d1);//没有tofloat 但有ToSingle转换成单精度
			Console.WriteLine (d1);//1.12345678
			Console.WriteLine (bt3);//1.123457

			int bt4 = Convert.ToInt32(Math.Floor(d));//强转不进行四舍五入
			Console.WriteLine (bt4);//5

			//3、专门转换字符串和数字的方式 x.parse(s)只能转换纯数字的字符串如果字符串是（123abc)会报错 带f d也不可以
			string s = "123";
			float ft = float.Parse(s)+5;
			Console.WriteLine(ft);//128
				
			//string s2 = "123.52345678"; 
			//int bt5 = int.Parse (s2);
			//Console.WriteLine (bt5);
			//也不能直接用带浮点的字符串转换成int，而是应该先转换成double，然后转换成int
			string s2 = "123.52345678"; 
			//int bt5 = double.Parse (s2); 这样也会报错
			double dt2 = double.Parse (s2);//正确转换
			Console.WriteLine (dt2);//123.52345678;
			//int bt5 = int.Parse(double.Parse(s2));//错误写法.parse()的参数只能为String类型
			//Console.WriteLine (bt5);
			//int bt6 = int.Parse(dt2);//同上报错，dt2为浮点型，不能作为字符串类型
			//Console.WriteLine (bt6);
			int bt7 = Convert.ToInt32 (dt2);//正确转换带浮点字符串转换成整数做法。先进行浮点转换，然后调用Convert类函数转换成int类
			Console.WriteLine (bt7);//124
			*/
			/*
			//六：Read ReadLine()读入操作
			int a;
			a = Console.Read ();//Read只是读入一字符m
			Console.WriteLine (a);//且这里a显示的是字符的ASCLL码（用十进制表示1 = 49）

			char c;
			//c = c + 1;//可以相加（先隐式转换成整形相加，然后在赋值成 c,但由于c 是char类型，如果不强转char类型就报错）
			c = (char)Console.Read ();//强转出Char类型  输入a
			Console.Write (c+"\n");//输出a
			*/
		/*	//空格也是一个字符
			string b;
			b = Console.ReadLine ();
			Console.WriteLine (b);
			int i = int.Parse(b);//这里的字符串如果是字符，则会发生异常中段
			Console.WriteLine (i);//通过将String类型用int.parse()转换成整形，再打印出来
		

			//将 字符a 转换成 大小字符 A (小写转换成大写)
			char ct;
			ct = (char)Console.Read ();
			ct = (char)(ct - 32);
			Console.WriteLine (ct);
		
			/*

			 //如何将字符串的小写转换成大写？
			string st;
			char[] ct = new char[100];
			int j = 0;
			st = Console.ReadLine ();
			for (int i = 0; i < st.Length; i++) {
				//Console.Write (st [i]);
				if (st [i] <= 'z' && st [i] >= 'a') {
					char sss;
					sss = (char)(st [i] - 32);//该步骤无法实现，因为st[]是字符串类型 ,需要新定义一个 char 来取得值，或将其赋值给char数组
					Console.Write (sss); 
					ct [j++] = sss;
				} else {
					Console.Write (st [i]);
				}

			}
			Console.Write ("\n");
			for (int i = 0; i < j; i++)
				Console.Write (ct [i]);
			Console.Write ("\n");
			*/
			/*
			//七： 枚举 
			color d; //枚举变量 d 可当作怪物颜色属性
			d = color.green; //在枚举中选择一个颜色

			attack a;
			a = attack.onehand;//此时的 a 的值为 
			Console.WriteLine(a);//输出onehand
			//Console.WriteLine (a + d); + 不能 连接不同的枚举变量
			Console.WriteLine("a= {0},d = {1}",a,d);//但可以这样打印 输出：a= onehand,d = green

			Console.WriteLine (color.green);//输出 green
			Console.WriteLine ((int)color.green);//输出1 ,该 在枚举中改green = 11 ,则从green开始，它的下一个枚举值从11开始+1递增 
			Console.WriteLine ((int)color.yellow);//yellow为green的下一个枚举值 输出12
			Console.WriteLine ((int)color.red);//red 是green 的上一个枚举值，没有被影响 输出为 0
			*/

			/*
			//八： 数组
			int [] a = new int[100];//int [] 表示是int类型的数组   new int[] 创建数组
			a [0] = 2; 
			a [99] = 1000;

			int [] arr = {1,2,3,4,5,6,7};//直接赋值初始化int 类型数组
			for (int i = 0; i < 100; i++)
			Console.Write (a[i]+" ");
			//Console.Write (a[i]+" "+arr[i]);//当a[i] 不赋值时默认为打印为 0 ,越界打印会保错
			Console.WriteLine ();

			//字符串类型数组初始化
			string[] str = { "aaa", "bbb", "ccc", "ddd" };
			string [] str2 = new string[5];
			for (int i = 0; i < 4; i++) {
				str2 [i] = str [i]; //字符串类型可以直接赋值
				Console.WriteLine (str2 [i]);
			}
			//二维数组初始化
			int[,] dArr = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
			int[,] dArr2 = new int[3, 3];
			dArr2 [1, 1] = 2;
			Console.WriteLine (dArr2[1,1]);
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					Console.Write(dArr[i,j]);//二维数组打印方式
			*/
			//九：结构体
			/*
			Person p; //创建一个人物，p是结构体变量 里面有3个属性 person是结构体类型，
			p.age = 20;
			p.sex = '男';
			p.name = "LS";
			Console.WriteLine("age = {0},sex = {1}, name = {2}",p.age,p.sex,p.name);//age = 20,sex = 男, name = LS
			Console.WriteLine (p);//打印：Day02_0516.person
			string s;
			s = string.Format ("age = {0},sex = {1}, name = {2}", p.age, p.sex, p.name);
			Console.WriteLine (s);
			*/
			/*
			//t1
			char a;
			a = (char)Console.Read ();
			a = (char)(a - 32);
			Console.WriteLine(a);
			*/
			/*
			//t2
			string a, b, c;
			int a1, b1, c1;
			a = Console.ReadLine ();
			a1 = int.Parse (a);
			b = Console.ReadLine ();
			b1 = int.Parse (b);
			c = Console.ReadLine ();
			c1 = int.Parse (c);

			Console.WriteLine (a1 + b1 + c1);
			*/
			//decimal类型 表示128位高精度十进制表示法
		}
	}
	//结构体是值类型，里面的包含属性
	struct Person
	{
		public string name;
		public char sex;
		public int age;
	}
	//规范命名  结构类型首字母大写，结构体变量写小写字母
	struct Point {
		int x;
		int y;
	}
}
	
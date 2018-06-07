/*using System;

namespace _1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			MainClass m = new MainClass();
			Console.WriteLine(m.add(1, 2));//非静态方法由对象调用
			Console.WriteLine(add(1.1d, 2.2d));
			//重载之后的函数在调用时，根据参数的类型自动选择对应的函数
		}
		//函数名一样但参数列表不一样，称为函数重载。
		//参数列表不同指：参数的个数和参数的类型不同
		//函数名字：add
		//参数列表：(int a,int b)
		public  int add(int a, int b)
		{
			return a + b;
		}
		//函数名字：add
		//参数列表：(double a,double b)
		public static double add(double a, double b)
		{
			return a + b;
		}
		//函数重载跟返回值类型没有关系
		//public static void add(int a, int b)
		//{
		//	Console.WriteLine(a + b);
		//}
	}
}*/
/*using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//Person p = new Person();//调用无参构造函数
			Person p = new Person("zhangsan", 20, 201801);//调用带参构造函数
			p.print();
			Person p2 = new Person("lisi", 22, 201802);
			p2.print();

			Person p3 = new Person();
			Person p4 = new Person();
			Person p5 = new Person();
			p3.print();
			p4.print();
			p5.print();

			//p中的成员现在需要初始化，但是没有set方法
			//构造函数的作用：在创建对象时对对象进行初始化
			//构造函数的特点：
			//1.函数名和类名一样
			//2.没有返回值(不写void)
			//3.一般为公有
			//4.如果不写构造函数，系统会自动提供一个无参构造函数，如果自己写了构造函数，系统就不再提供无参构造函数了
			//5.构造函数可以重载
		}
	}

	class Person
	{
		private string name;
		private int age;
		private int id;

		public Person(string _name, int _age, int _id)
		{
			name = _name;
			age = _age;
			id = _id;
		}
		//函数名，参数列表不一样，称为函数重载
		//构造函数的重载
		public Person()
		{
			name = "noname";
			age = 0;
			id = 0;
		}
		public Person(string _name)
		{
			name = _name;
			age = 0;
			id = 0;
		}
		public Person(string _name, int _age)
		{
			name = _name;
			age = _age;
			id = 0;
		}

		public string Name
		{
			get { return name; }
		}
		public int Age
		{
			get { return age; }
		}
		public int Id
		{
			get { return id; }
		}

		public void print()
		{
			Console.WriteLine("name:{0},age:{1},id:{2}", name, age, id);
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
			Person p = new Person("zhangsang", 201801, 2000, 5, 1);
			p.print();

			Date d = new Date(2000, 5, 1);
			Person p2 = new Person("lisi",201802,d);
			p2.print();
		}
	}

	class Date
	{
		private int year;
		private int month;
		private int day;

		public Date(int _year, int _month, int _day)
		{
			year = _year;
			month = _month;
			day = _day;
		}
		public int Year { get { return year; } }
		public int Month { get { return month; } }
		public int Day { get { return day; } }

		public int age()//计算年龄
		{
			return 2018 - year;
		}

		public void print()
		{
			Console.WriteLine("{0}/{1}/{2}", year, month, day);
		}
	}

	class Person
	{
		private string name;
		private int age;
		private int id;
		private Date birthday;

		public Person(string _name, int _id, int _year, int _month, int _day)
		{
			birthday = new Date(_year, _month, _day);
			name = _name;
			age = birthday.age();//通过age方法计算年龄赋值给age字段
			id = _id;
		}

		public Person(string _name, int _id, Date d)
		{
			birthday = d;
			name = _name;
			age = birthday.age();
			id = _id;
		}

		public void print()
		{
			Console.Write("name:{0},age:{1},id:{2},birthday:", name, age, id);
			birthday.print();
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
			//Person p1 = new Person("zhangsan",1);
			//Person p2 = new Person("zhangsan",1);
			//Person p3 = new Person("zhangsan",1);
			//Person p4 = new Person("zhangsan",1);
			//Console.WriteLine(Person.totalPerson);
			Person.fun();
		}
	}

	class Person
	{
		private string name;
		private int age;

		public static int totalPerson;//标记一共有多少个Person对象

		//静态字段用静态构造函数初始化
		//静态构造函数的特点：
		//1.没有访问权限修饰符
		//2.没有返回值
		//3.没有参数
		//4.不能重载
		//5.不能手动调用(只会自动调用一次)

		//静态构造函数调用时机：
		//1.在第一次创建对象之前
		//2.在第一次访问静态成员之前
		static Person()
		{
			totalPerson = 0;//给静态字段初始化
			Console.WriteLine("static constructor");
		}

		public Person(string _name, int _age)
		{
			name = _name;
			age = _age;
			totalPerson++;//每创建一个对象，给totalPerson加1
			Console.WriteLine("constructor");
		}

		public static void fun()
		{
			Console.WriteLine("static fun");
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
			Person p = new Person();//创建对象，调用构造函数
			Person p2 = new Person();
			Console.WriteLine("hello world");
		}//程序结束释放对象，调用析构函数
	}

	class Person
	{
		private string name;
		private int age;
		public Person()
		{
			Console.WriteLine("constructor");
		}

		//析构函数
		//调用时机：在对象释放时自动调用
		//作用：释放对象中存在的非托管资源
		//特点：
		//1.没有修饰符没有参数
		//2.不能重载，只能有一个
		//3.不能手动调用，只能自动调用
		//4.结构体中不能创建析构函数
		~Person()
		{
			Console.WriteLine("destructor");
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
			Person p = new Person();
			//Console.WriteLine(p.id);
			Console.WriteLine(Person.id);
		}
	}
	class Person
	{
		private string name;
		private int age;

		//private readonly int id;
		public const int id=1;//const声明的字段不能加static，因为const声明的字段默认就是static的
							  //readonly和const都表示字段是只读字段
							  //const声明的字段必须在声明时赋初始值
							  //readonly声明的字段可以在声明时初始化，也可以在构造函数中初始化
		public Person()
		{
			//id = 1;//只有readonly声明的只读字段才可以在构造函数中初始化，
			//const声明的只能在声明时初始化
		}
	}
}
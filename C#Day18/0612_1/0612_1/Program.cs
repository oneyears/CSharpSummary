/*using System;
using System.Reflection;//反射命名空间
using System.Collections.Generic;

namespace aaaaa
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//Assembly用来加载程序集，获取程序集信息
			//Type用来加载类型，获取某个类的信息

			//使用Type时，先获取类型的信息(创建Type对象)
			Type t1 = typeof(Person);//1.使用typeof方法获取类的信息
			Type t2 = Type.GetType("aaaaa.Person");//2.使用Type的静态方法GetType方法，参数是类的名字

			Person p = new Person("zhangsan", 20, 2018);
			Type t3 = p.GetType();//3.使用对象的实例方法GetType

			Console.WriteLine(t1.Name);
			Console.WriteLine(t1.FullName);//完全限定名
			Console.WriteLine(t1.Namespace);
			Console.WriteLine(t1.IsInterface);
			Console.WriteLine(t1.IsClass);

			List<int> li = new List<int>();
			Type tl = li.GetType();
			Console.WriteLine(tl.IsArray);
			int[] a = new int[] { 1, 2, 3, 5 };
			Type ta = a.GetType();
			Console.WriteLine(ta.IsArray);
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

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public int Age
		{
			get { return age; }
			set { age = value; }
		}
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public void print()
		{
			Console.WriteLine("name:{0},age:{1},id:{2}", name, age, id);
		}
	}
}
*/
/*using System;
using System.Reflection;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			Type t = Type.GetType("aa.Person");

			//获取所有成员，返回MemberInfo数组
			//BindingFlags.Public公有成员
			//BindingFlags.NonPublic非公有成员
			//BindingFlags.DeclaredOnly当前类中声明的
			//BindingFlags.Instance实例成员(非静态成员)
			//BindingFlags.Static静态成员
			MemberInfo[] mis = t.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance);
			foreach (MemberInfo mi in mis)
			{
				Console.WriteLine(mi.Name + " " + mi.MemberType);
			}

			FieldInfo[] fis = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance);
			foreach (FieldInfo fi in fis)
			{
				Console.WriteLine(fi.Name + " " + fi.FieldType);
			}
			MethodInfo[] methodis = t.GetMethods();
			ConstructorInfo[] cis = t.GetConstructors();
		}
	}
	class Person
	{
		private string name;
		private int age;
		private int id;

		private static int totalPerson;

		public Person(string _name, int _age, int _id)
		{
			name = _name;
			age = _age;
			id = _id;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public int Age
		{
			get { return age; }
			set { age = value; }
		}
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public void print()
		{
			Console.WriteLine("name:{0},age:{1},id:{2}", name, age, id);
		}
	}
}*/
/*using System;
using System.Reflection;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			Type t = Type.GetType("aa.Person");
			//ConstructorInfo[] cis = t.GetConstructors();
			//foreach (ConstructorInfo ci in cis)
			//{
			//	Console.WriteLine(ci.Name + " " + ci.MemberType);
			//	ParameterInfo[] pis = ci.GetParameters();
			//	foreach (ParameterInfo pi in pis)
			//	{
			//		Console.WriteLine(pi.Name + " " + pi.ParameterType);
			//	}
			//	Console.WriteLine("-------------");
			//}

			//GetConstructor参数是Type数组，表示要获取的构造函数的参数列表
			Type[] ts = new Type[3];
			ts[0] = typeof(string);
			ts[1] = typeof(int);
			ts[2] = typeof(int);
			ConstructorInfo ci = t.GetConstructor(ts);
			//Console.WriteLine(ci.Name + " " + ci.MemberType);
			//ParameterInfo[] pis = ci.GetParameters();
			//foreach (ParameterInfo pi in pis)
			//{
			//	Console.WriteLine(pi.Name + " " + pi.ParameterType);
			//}

			//Person p = new Person("aa", 20, 201801);

			object[] parameters = new object[3];
			parameters[0] = "zhangsan";
			parameters[1] = 20;
			parameters[2] = 201801;

			//调用invoke方法执行ci这个构造函数，构造函数需要的参数放在object数组中
			object o = ci.Invoke(parameters);
			Console.WriteLine(o);
			//Console.WriteLine(((Person)o).Name);

			PropertyInfo pi = t.GetProperty("Name");//先获取Name属性
			object n = pi.GetValue(o);//通过pi.GetValue获取属性pi属性的值
			Console.WriteLine(n);

			PropertyInfo pi_age = t.GetProperty("Age");
			object age = pi_age.GetValue(o);
			Console.WriteLine(age);
		}
	}
	class Person
	{
		private string name;
		private int age;
		private int id;

		private static int totalPersons = 0;
		public Person(string _name, int _age)
		{
			name = _name;
			age = _age;
			id = ++totalPersons;
		}
		public Person(string _name, int _age, int _id)
		{
			name = _name;
			age = _age;
			id = _id;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public int Age
		{
			get { return age; }
			set { age = value; }
		}
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public void print()
		{
			Console.WriteLine("name:{0},age:{1},id:{2}", name, age, id);
		}

		public override string ToString()
		{
			return string.Format("[Person: Name={0}, Age={1}, ID={2}]", Name, Age, ID);
		}
	}
}*/
/*using System;
using System.Reflection;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			Type t = Type.GetType("aa.Person");
			//使用Activator创建对象
			//第一个参数是Type对象t，后边是构造函数的参数，根据参数自动匹配合适的构造函数
			//object o = Activator.CreateInstance(t, "zhangsan", 20, 201801);
			object[] parameters = new object[3];
			parameters[0] = "zhangsan";
			parameters[1] = 20;
			parameters[2] = 201801;
			object o = Activator.CreateInstance(t, parameters);
			Console.WriteLine(o);

			PropertyInfo pi_name = t.GetProperty("Name");
			pi_name.SetValue(o, "lisi");
			Console.WriteLine(pi_name.GetValue(o));
			Console.WriteLine(o);

			MethodInfo mi = t.GetMethod("print");
			mi.Invoke(o, null);//调用invoke执行print方法，第二个参数
							   //是print方法的参数，如果print没有参数直接传null
		}
	}
	class Person
	{
		private string name;
		private int age;
		private int id;

		private static int totalPersons = 0;
		public Person()
		{
			name = "noname";
			age = 0;
			id = 0;
		}
		public Person(string _name, int _age)
		{
			name = _name;
			age = _age;
			id = ++totalPersons;
		}
		public Person(string _name, int _age, int _id)
		{
			name = _name;
			age = _age;
			id = _id;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public int Age
		{
			get { return age; }
			set { age = value; }
		}
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public void print()
		{
			Console.WriteLine("name:{0},age:{1},id:{2}", name, age, id);
		}

		public override string ToString()
		{
			return string.Format("[Person: Name={0}, Age={1}, ID={2}]", Name, Age, ID);
		}
	}
}*/
/*using System;
using System.Reflection;
namespace aaa
{
	class MainClass
	{
		public static void Main()
		{
			Type t = Type.GetType("aaa.Person");
			object o = Activator.CreateInstance(t);
			//通过参数列表获取重载的方法，用Type数组表示参数列表
			Type[] ts = new Type[] { typeof(int), typeof(string) };
			MethodInfo mi = t.GetMethod("fun", ts);
			//mi.Invoke(o, new object[] { 1, "aaa" });
			object[] parameters = new object[] { 1, "aaa" };
			mi.Invoke(o, parameters);

			Type[] ts2 = new Type[0];//用0个元素的Type数组表示没有参数
			MethodInfo mi2 = t.GetMethod("fun", ts2);
			MethodInfo mi3 = t.GetMethod("fun", new Type[0]);
			mi2.Invoke(o, null);
		}
	}
	class Person
	{
		private string name;
		private int age;
		private int id;

		private static int totalPersons = 0;
		public Person()
		{
			name = "noname";
			age = 0;
			id = 0;
		}
		public Person(string _name, int _age)
		{
			name = _name;
			age = _age;
			id = ++totalPersons;
		}
		public Person(string _name, int _age, int _id)
		{
			name = _name;
			age = _age;
			id = _id;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public int Age
		{
			get { return age; }
			set { age = value; }
		}
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		public void fun()
		{
			Console.WriteLine("fun1");
		}
		public void fun(int a)
		{
			Console.WriteLine("fun2 " + a);
		}
		public void fun(int a, string b)
		{
			Console.WriteLine("fun3 " + a + " " + b);
		}

		public void print()
		{
			Console.WriteLine("name:{0},age:{1},id:{2}", name, age, id);
		}

		public override string ToString()
		{
			return string.Format("[Person: Name={0}, Age={1}, ID={2}]", Name, Age, ID);
		}
	}
}*/
/*using System;
using System.Reflection;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//加载程序集：
			//1.Assembly.Load("");先将程序集引用到工程中，参数是程序集的名字
			Assembly ass = Assembly.Load("背包");

			//2.Assembly.LoadFile("");不需要将程序集引用到工程中，参数填写程序集的路径
			//Assembly ass = Assembly.LoadFile("");

			//3.Assembly.LoadFrom("");不需要将程序集引用到工程中，参数填写程序集的路径
			//Assembly ass = Assembly.LoadFrom("");
			//LoadFile和LoadFrom区别：
			//LoadFile只加载程序集本身，不加载程序集的依赖项
			//LoadFrom会加载程序集和程序集中的依赖项

			//Assembly程序集信息
			//GetTypes获取程序集中所有的类型
			Type[] ts = ass.GetTypes();
			foreach (Type t in ts)
			{
				Console.WriteLine(t.FullName);
			}
			Console.WriteLine("-----------------");
			Type hero = ass.GetType("aa.Hero");//获取某一个指定的类型，参数是完全限定名
			MemberInfo[] mis = hero.GetMembers();
			foreach (var mi in mis)
			{
				Console.WriteLine(mi.Name + " " + mi.MemberType);
			}
			Console.WriteLine("------------------");

			Type goods = ass.GetType("aa.Goods");
			ConstructorInfo[] cis = goods.GetConstructors();
			foreach (ConstructorInfo t in cis)
			{
				ParameterInfo[] pis = t.GetParameters();
				foreach (ParameterInfo pi in pis)
				{
					Console.WriteLine(pi.Name + " " + pi.ParameterType);
				}
				Console.WriteLine("-----------------");
			}
			Type[] ci_ts = new Type[] { typeof(string), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(int) };
			ConstructorInfo ci = goods.GetConstructor(ci_ts);
			object o = ci.Invoke(new object[] { "aa", 1001, 5, 100, 100, 100, 100 });
			Console.WriteLine(o);
		}
	}
}*/
/*using System;
using System.Reflection;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//LoadFile参数是程序集路径
			//路径：文件在电脑中的位置
			//绝对路径：也叫完整路径，是从硬盘根目录开始的路径
			//相对路径：是相对当前可执行文件位置的路径
			//Assembly ass = Assembly.LoadFile("/Users/wzc/Desktop/code/0515第一教室/背包/背包/bin/Debug/背包.exe");
			Assembly ass = Assembly.LoadFile("../../../../背包/背包/bin/Debug/背包.exe");
			Type[] ts = ass.GetTypes();
			foreach (Type t in ts)
			{
				Console.WriteLine(t.FullName);
			}
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
			int x = add(5, 10);
			Console.WriteLine(x);

			//可选实参，可以选择传或不传实参，形参要带默认值
			int y = add(5);//形参带有默认值，就可以不用传实参了，形参直接使用默认值
			Console.WriteLine(y);

			int z = add(b:5);//2.实参可以指定赋值给哪个形参，称为命名实参
			Console.WriteLine(z);
		}
		//1.可选实参必须防止必选实参之后
		//3.ref或out声明的形参不能有默认值
		public static int add(int a=1000, int b=100)
		{
			return a + b;
		}
	}
}
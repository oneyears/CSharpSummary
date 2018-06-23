using System;
using System.Reflection; //使用反射需要引用的命名空间
using System.Collections.Generic;
/*
namespace CSharpDay18_06_12
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Assembly 用来加载程序集，获取程序集信息
			//Type用来加载类型，获取某个类的信息
			//使用Type时，先获取类型的信息（创建Type对象）
			//3种方式，获取一个类的信息，常用第二种
			Type t = typeof(Person);//1、使用typeof方法获取类的信息
			Type t2 = Type.GetType ("CSharpDay18_06_12.Person");//2、使用Type的静态方法GetType方法，参数是类的名字（字符串）
			Person p = new Person ("ls", 20, 1805);
			Type t3 = p.GetType (); // 3、使用对象的实例方法GetType();
			Console.WriteLine (t);//完全限定名
			Console.WriteLine (t.Name);
			Console.WriteLine (t.FullName);
			Console.WriteLine (t.Namespace);//返回值空间名（字符串）
			Console.WriteLine (t.IsAbstract);
			Console.WriteLine (t.IsArray);
			Console.WriteLine (t.IsClass);
			Console.WriteLine (t.IsInterface);
			Console.WriteLine (t.IsPublic);
			Console.WriteLine (t.IsSealed);
			Console.WriteLine (t.IsValueType);
			//Console.WriteLine (t.IsInterface);
			//Console.WriteLine (t.IsInterface);

			//Console.WriteLine (t2);
			//Console.WriteLine (t3);
			List<int> li = new List<int> ();
			Type tl = li.GetType ();
			//为何可以直接写方法名，而不用调用方法（）
			Console.WriteLine (tl.IsClass);//true;
			Console.WriteLine (tl.IsArray);//false 容器是类类型不是数组类型

		}
	}

	class Person{
		private string name;
		private int age;
		private int id;

		public Person(string name,int age,int id){
			this.name = name;
			this.age = age;
			this.id = id;
		}

		public String Name{
			get{ return name; }
			set{ name = value; }
		}
		public int Age{
			get{ return age; }
			set{ age = value; }
		}
		public int Id{
			get{ return id; }
			set{ id = value; }
		}

		public override string ToString ()
		{
			return string.Format ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}

		public void print(){
			Console.WriteLine ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}
	}
}

*/
/*
namespace demo1{
	class MainClass{
		public static void Main(){
			Type t = Type.GetType ("demo1.Person");
			//获取所有的成员
			MemberInfo[] mis = t.GetMembers ();

			//MemberInfo 可以用var代替
			//获取所有成员，返回MemberInfo数组
			foreach (MemberInfo v in mis) {
				Console.WriteLine (v.Name);
			}
			Console.WriteLine ();

			//BindingFlags.NonPublic 非公有成员
			//BindingFlags.Public  公有成员 
			//BindingFlags.DeclaredOnly 当前类中的声明的
			//BindingFlags.Instance 实例成员（非静态成员）
			//BindingFlags.Static 静态成员
			// 

			MemberInfo[] miss = t.GetMembers ( BindingFlags.NonPublic | BindingFlags.Public| BindingFlags.DeclaredOnly | BindingFlags.Instance|BindingFlags.Static);
			foreach (MemberInfo v in miss) {
				Console.WriteLine (v.Name+" "+v.MemberType);
			}
			Console.WriteLine ("----------字段--------");
			//没有显示？ 需要加上在方法里 加上BindingFlags.NonPublic |BindingFlags.Instance
			FieldInfo[] fis = t.GetFields (BindingFlags.NonPublic |BindingFlags.Instance|BindingFlags.DeclaredOnly|BindingFlags.Public);
			foreach (FieldInfo v in fis) {
				Console.WriteLine (v.Name+" "+v.MemberType);
			}
			Console.WriteLine ();
			Console.WriteLine ("----------方法--------");
			MethodInfo[] methodis = t.GetMethods ();
			foreach (MethodInfo v in methodis) {
				Console.WriteLine (v.Name+" "+v.MemberType);
			}
			Console.WriteLine ();
			Console.WriteLine ("----------结构体--------");
			ConstructorInfo[] cis = t.GetConstructors ();
			foreach (ConstructorInfo v in cis) {
				Console.WriteLine (v.Name+" "+v.MemberType);
			}
		}
	}
	class Person{
		private string name;
		private int age;
		private int id;

		public Person(string name,int age,int id){
			this.name = name;
			this.age = age;
			this.id = id;
		}

		public String Name{
			get{ return name; }
			set{ name = value; }
		}
		public int Age{
			get{ return age; }
			set{ age = value; }
		}
		public int Id{
			get{ return id; }
			set{ id = value; }
		}

		public override string ToString ()
		{
			return string.Format ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}

		public void print(){
			Console.WriteLine ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}

		public override bool Equals (object obj)
		{
			return this.age > ((Person)obj).age;
		}
	}
}
*/
/// <summary>
/// 结构体构造函数与参数列表的关系
/// </summary>
/*
namespace demo2{
	class MainClass{
		public static void Main(){

			Type t = Type.GetType ("demo2.Person");
			ConstructorInfo[] cis = t.GetConstructors ();
			foreach (ConstructorInfo ci in cis) {
				Console.WriteLine (ci.Name + " " + ci.MemberType);
				ParameterInfo[] pis = ci.GetParameters ();

				foreach (ParameterInfo pi in pis) {
					Console.WriteLine (pi.Name + " " + pi.ParameterType);
				}
				Console.WriteLine ();
			}
		}
	}
	class Person{
		private string name;
		private int age;
		private int id;
		private static int totalPerson;

		public Person(string name,int age,int id){
			this.name = name;
			this.age = age;
			this.id = id;
			totalPerson++;
		}

		public Person(){
			totalPerson++;
		}

		public Person(string name){
			this.name = name;
			totalPerson++;
		}

		public String Name{
			get{ return name; }
			set{ name = value; }
		}
		public int Age{
			get{ return age; }
			set{ age = value; }
		}
		public int Id{
			get{ return id; }
			set{ id = value; }
		}

		public override string ToString ()
		{
			return string.Format ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}

		public void print(){
			Console.WriteLine ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}

		public override bool Equals (object obj)
		{
			return this.age > ((Person)obj).age;
		}
	}
}
*/

/// <summary>
/// GetConstructor 与 ConstructorInfo用构造函数获取参数列表，通过参数列表创建对象
/// </summary>
/*
namespace demo3{
	class MainClass{
		public static void Main(){

			Type t = Type.GetType ("demo3.Person");

			// GetConstructor参数是Type数组，表示要获取的构造函数参数列表
			Type[] ts = new Type[3];
			ts [0] = typeof(string);
			ts [1] = typeof(int);
			ts [2] = typeof(int);
			//ts [3] = typeof(int);
			ConstructorInfo ci = t.GetConstructor (ts);

			//参数信息 
			ParameterInfo[] pis = ci.GetParameters ();
			foreach (ParameterInfo pi in pis) {
				Console.WriteLine (pi.Name + " " + pi.ParameterType);
			}

			object[] parameters = new object[3];
			parameters [0] = "张三";
			parameters [1] = 20;
			parameters [2] = 2018;
			//调用invoke方法执行ci这个构造函数，构造函数需要的参数放在object数组中
			object o = ci.Invoke (parameters);

			Console.WriteLine (o);
			Console.WriteLine (((Person)o).Name);
		
			PropertyInfo p = t.GetProperty("Name");//先获取Name属性，这个属性是要可读的
			object n = p.GetValue(o);//通过p.GetValue获取属性pi属性的值
			Console.WriteLine (n);

			PropertyInfo p_age = t.GetProperty ("Age");
			object age = p_age.GetValue (o);
			age = 100;
			Console.WriteLine (age);
		}
	}
	class Person{
		private string name;
		private int age;
		private int id;
		private static int totalPerson;

		public Person(string name,int age,int id){
			this.name = name;
			this.age = age;
			this.id = id;
			totalPerson++;
		}
		public Person(){
			totalPerson++;
		}
		public Person(string name){
			this.name = name;
			totalPerson++;
		}
		public String Name{
			get{ return name; }
			set{ name = value; }
		}
		public int Age{
			get{ return age; }
			private	set{ age = value; }
		}
		public int Id{
			get{ return id; }
			set{ id = value; }
		}

		public override string ToString ()
		{
			return string.Format ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}

		public void print(){
			Console.WriteLine ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}
		public override bool Equals (object obj)
		{
			return this.age > ((Person)obj).age;
		}
	}
}
*/

/// <summary>
/// 使用Activator直接创建对象/获得个别方法
/// </summary>
/*
namespace demo4{
	class MainClass {
		public static void Main(){
			Type t = Type.GetType ("demo4.Person");
			//1、使用Activator创建对象
			//2、第一个参数是Type对象t，后边是构造函数的参数，根据参数自动匹配合适的结构体
			object o = Activator.CreateInstance (t, "张三", 20, 2018);
			object o1 = Activator.CreateInstance (t);

			object[] parameters = new object[3];
			parameters [0] = "ls";
			parameters [1] = 20;
			parameters [2] = 1805;

			object o2 = Activator.CreateInstance (t, parameters [0], parameters [1], parameters [2]);

			Console.WriteLine (o);

			Console.WriteLine (o1);
			Console.WriteLine (o2);

			PropertyInfo pi_name = t.GetProperty ("Name");
			pi_name.SetValue (o1, "李四");
			Console.WriteLine (pi_name.GetValue (o1));
			Console.WriteLine (o1);

			//1、先找到对象的方法名.GetMethod.
			//2、找到的方法变量调用方法，里边传入执行方法的对象和参数
			MethodInfo mi = t.GetMethod ("print");

			object[] parameters2 = new object[1];

			parameters2 [0] = 100;
			mi.Invoke (o,parameters2);//调用invoke 执行print方法，第二个参数是print方法的参数,如果print没有参数直接传null
		
		}
	}
	class Person{
		private string name;
		private int age;
		private int id;
		private static int totalPerson;

		public Person(string name,int age,int id){
			this.name = name;
			this.age = age;
			this.id = id;
			totalPerson++;
		}

		public Person(){
			totalPerson++;
		}
			
		public Person(string name){
			this.name = name;
			totalPerson++;
		}

		public String Name{
			get{ return name; }
			set{ name = value; }
		}
		public int Age{
			get{ return age; }
			private	set{ age = value; }
		}
		public int Id{
			get{ return id; }
			set{ id = value; }
		}

		public override string ToString ()
		{
			return string.Format ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}

		public void print(int x)
		{
			Console.WriteLine (x);
			Console.WriteLine ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}

		public override bool Equals (object obj)
		{
			return this.age > ((Person)obj).age;
		}
	}
}
*/
/*
namespace demo5{
	class MainClass{
		public static void Main(){
			Type t = Type.GetType ("demo5.Person");
			//通过参数列表获取重载的方法，用Type数组表示参数列表
			object o = Activator.CreateInstance (t);
			//集合初始化器
			Type[] ts = new Type[]{ typeof(int), typeof(string) };

			MethodInfo mi = t.GetMethod ("fun", ts);
			//第二个参数是传入object类型数组，作为方法的参数
			mi.Invoke (o, new object[]{ 1, "qwq" });

			object[] parameters = new object[]{ 2, "qwq" };

			mi.Invoke (o, parameters);

			MethodInfo mi2 = t.GetMethod ("fun", new Type[0]);

			mi2.Invoke (o, new object[0]);

			mi2.Invoke (o, null);
		}
	}
	class Person{
		private string name;
		private int age;
		private int id;
		private static int totalPerson;

		public Person(string name,int age,int id){
			this.name = name;
			this.age = age;
			this.id = id;
			totalPerson++;
		}

		public Person(){
			totalPerson++;
		}

		public Person(string name){
			this.name = name;
			totalPerson++;
		}

		public String Name{
			get{ return name; }
			set{ name = value; }
		}
		public int Age{
			get{ return age; }
			private	set{ age = value; }
		}
		public int Id{
			get{ return id; }
			set{ id = value; }
		}

		public override string ToString ()
		{
			return string.Format ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}

		public void print(int x)
		{
			Console.WriteLine (x);
			Console.WriteLine ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}

		public void fun(){
			Console.WriteLine ("fun");
		}
		public void fun(int a){
			Console.WriteLine ("fun2",a);
		}
		public void fun(int a,string b){
			Console.WriteLine ("fun3 {0},{1}",a,b);
		}

		public override bool Equals (object obj)
		{
			return this.age > ((Person)obj).age;
		}
	}
}
*/

/*
namespace demo6加载程序集{

  class MainClass{

	public static void Main(){
		
			//加载程序集 
			//1、Assemble.Load("")；先将程序集引用到工程中
			Assembly ass = Assembly.Load ("CSharpDay16_06-07背包系统");

			//2、Assemble.LoadFile("")；不需要将程序集引用到工程中，参数填写程序集的路径
			//Assembly ass2 = Assembly.LoadFile("");

			//3、Assemble.LoadFrom("");不需要将程序集引用到工程中，参数填写程序集的路径

			//LoadFile 和LoadFrom的区别
			//LoadFile 只会加载程序集本身，不加载程序集的依赖对象
			//LoadFrom 会加载程序集和程序集中的依赖项

			Type[] ts = ass.GetTypes();

			foreach (Type t in ts) {
				Console.WriteLine (t.FullName);
			}
			Console.WriteLine ("-------------------");
			Type hero = ass.GetType ("CSharpDay16_0607背包系统.Hero");

			MemberInfo[] mis = hero.GetMembers ();

			foreach (var mi in mis) {
				Console.WriteLine (mi.Name + " " + mi.MemberType);
			}
			Console.WriteLine ("-------------------");

			Type goods = ass.GetType ("CSharpDay16_0607背包系统.Goods");

			ConstructorInfo[] cis = goods.GetConstructors ();

			foreach (ConstructorInfo ci in cis) {
				ParameterInfo[] pis = ci.GetParameters ();
				foreach (ParameterInfo pi in pis) {
					Console.WriteLine (pi.Name + " " + pi.ParameterType);
		
				}
				Console.WriteLine ("-------------------");
			}
			Type [] ci_ts = new Type[]{typeof(string),typeof(int),typeof(int),ass.GetType("CSharpDay16_0607背包系统.GoodsType")};


			ConstructorInfo ci1 = goods.GetConstructor(ci_ts);
			object o = ci1.Invoke(new object[4]{"物品",1,100,0});
			Console.WriteLine (o);
	}
   }
}
*/
/*
namespace demo7根据绝对路径或相对路径获得程序集{
	class MainClass{
		public static void Main(){
			// LoadFile参数是程序集的路径
			// 路径：文件在电脑中位置
			// 绝对路径：也叫做完整路径，是从硬盘根目录开始的路径，可以打开终端，把文件拖进去。复制时从 （不带空格）/开始 到 exe 结束(前后不加空格)
			// 相对路径：是相对当前可执行文件（exe文件）位置的路径 ../为返回上级文档 一般用相对路径，通常把该文件与被调用的文件放在一起，就可以直接写exe名直接调用

			Assembly ass = Assembly.LoadFile ("/Users/neworigin/Desktop/MyC#Test/背包/CSharpDay16_06-07背包系统/CSharpDay16_06-07背包系统/bin/Debug/CSharpDay16_06-07背包系统.exe");
			//获取程序集（exe文件）中的所有类
			Type[] ts = ass.GetTypes ();
			foreach (Type t in ts) {
				Console.WriteLine (t.FullName + " " + t.MemberType);
			}
			Console.WriteLine ("-------------------------");
			//桌面文档反回到最后就是桌面，再就可以进入其他文档了
			Assembly ass2 = Assembly.LoadFile ("../../../../../../背包1/CSharpDay16_06-07背包系统/CSharpDay16_06-07背包系统/bin/Debug/CSharpDay16_06-07背包系统.exe");

			Type[] ts2 = ass.GetTypes ();

			foreach (Type t in ts) {
				Console.WriteLine (t.FullName + " " + t.MemberType);
			}
		}
	}
}
*/
/*
namespace demo8{
	class MainClass{
		public static void Main(){
			//可选实参，可以选择传或不传实参，形参要带默认值
			int x = add ();
			Console.WriteLine (x);

			int a = add (b:5);//实参可以指定赋值给哪个形参，称为命名实参
			Console.WriteLine (a);
		}

		//可选实参必须放在必选实参之后
		public static int add(int a = 1000,int b = 100) {return a + b;}

		//1 可选
	}
}
*/

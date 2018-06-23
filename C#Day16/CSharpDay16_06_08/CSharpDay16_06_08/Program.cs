using System;
using System.Collections;
using System.Collections.Generic;
/*
namespace CSharpDay16_06_08
{
	//其他特性 ？  Nullable 允许 值类型赋值为null  x.HasValue 判断是否有值 ，有返回true，null返回false 
	class MainClass
	{
		public static void Main (string[] args)
		{
			//int a = null;;
			int? b = null; //值类型后边加 ？ 表示可空类型
							//可空类型是可以为空的值类型
			double? c = null;
			float? d = 5.5f;
			//引用类型本身就可以为空，所以不能加？
			// int ? 实际上就是 Nullable<int>
			Nullable <int>  a = 10, b1 = null;

			//结构体用样可以
			PerStr ? a2 = null;
			Nullable<PerStr> a3 = null;
			if (a3 == null) {
				Console.WriteLine ("a3 is null");
			}

			if (b.HasValue) {
				Console.WriteLine (b);
			}

			if (a.HasValue) {
				Console.WriteLine (a);
			}

		}
	}
	struct PerStr{}
}
*/
/**/
namespace demo1Nullable的运用{
	class MainClass{
		public static void Main(){
			int? a = null;
			int a1 = 3;
			double a2 = 10.2;
			int b = a ?? a1;//?? 是空合并操作符，判断？？左边是否为空，不为空返回左边的值，为空返回右边的值
							
			Console.WriteLine (b);
			//？？左边可以是可空类型或引用类型，但不能是普通的值类型。
			//??右边只能是普通的值类型或引用类型,且在赋值时类型应该一致，否则值类型和引用类型需要转换
			////右边不能为可空类型
			string s = "qwqw";
			string s2 = "5";
			string s3 = null;
		
			string ss2 = s3 ?? s2;
			Console.WriteLine (ss2);

			string s4 = s3 ?? s;
			Console.WriteLine (s4);
		}
	}
}

//什么情况下要使用匿名函数？ 
//匿名函数的好处？用途？（为什么需要匿名函数？）
//匿名函数的使用方法，使用规则？
/*
namespace demo2匿名方法 {
	class MainClass{
		public delegate void MyDelegate(int a,int b);
		public delegate int MyDelegate2(int a,int b);
		public delegate void MyDelegate3();
		public static void Main(){
			//匿名方法是在委托的基础上实现的
			//匿名方法本身没有名字，只能通过委托变量调用这个没有名字的方法

			MyDelegate m = delegate (int a, int b) {
				Console.WriteLine(a+b);
			};
			m (2, 2);
			MyDelegate2 m2 = delegate (int a, int b){
				return  a + b;
			};
			Console.WriteLine (m2 (1, 2));

			MyDelegate3 m3 = delegate() {
				Console.WriteLine("没有参数没有返回值的匿名方法");
			};
			m3 ();
		}
		public static void fun(int a,int b) {
			Console.WriteLine (a + b);
		}
	}
}
*/
/*
namespace demo3函数匿名函数内存变量释放机制{
	//匿名函数在函数中不释放内存
	class MainClass{
		public delegate int GetDelegate();
		public delegate int GetDelegate2(int a);
		public static GetDelegate get_del;
		public static GetDelegate2 get_del2;/
		public static void Main(){
			fun ();//调用函数时，函数内创建a变量，函数调用结束后a就释放掉了
			fun ();//再次调用fun函数时，函数又重新创建了一个a
			//get_del 委托变量
			//get_del指向fun中创建的匿名方法
			//get_del要等带程序结束才释放，所以fun中的匿名方法就不会释放，匿名方法不释放fun就不会释放
			fun2 ();
			fun2 ();
			Console.WriteLine (get_del ());
			Console.WriteLine (get_del ());
			Console.WriteLine (get_del2 (5));
			Console.WriteLine (get_del2 (100));
		}
		public static void fun(){
			int a = 0;
			Console.WriteLine (++a);
		}
		public static void fun2(){
			int  a = 0;
			get_del = delegate {
				a++;
				return ++a;
			};
			get_del2 = delegate(int s){
				return ++s;
			};
		}
	}
}
*/
/*
namespace demo4匿名函数在函数中不释放内存{
	class MainClass{

		public delegate string Get_Name();
		public delegate void Set_Name(string a);
		public delegate int Get_Age();
		public delegate void Set_Age(int a);

		public static void Main(){

			Person ("张三", 20);
			//函数调用时，会形成一个封闭的空间，称为闭包
			Console.WriteLine (Name ());
			Console.WriteLine (Age ());
			setName ("lisi");
			setAge (18);
			Console.WriteLine (Name ());
			Console.WriteLine(Age());

		}
		public static Get_Name Name;
		public static Set_Name setName;
		public static Get_Age Age;
		public static Set_Age setAge;

		public static void Person(string _name,int _age) {
			string name = _name;
			int age = _age;

			Name = delegate {
				return name;
			};

			setName = delegate(string a) {
				name = a;
			};

			Age = delegate {
				return age;
			};

			setAge = delegate (int a) {
				age = a;
			};
		}
	}
}
*/
/*
namespace demo5迭代器{
	class MainClass{

		public static void Main(){
			//foreach会自动调用容器的迭代器
			int[] a = { 1, 2, 3, 4, 5, 6, 7 };
			foreach (int t in a) {
				Console.WriteLine (t);
			}

			ArrayList al = new ArrayList ();
			al.Add (1);
			al.Add (2);
			al.Add (3);
			al.Add (4);
			al.Add (5);

			foreach (object o in al) {
				Console.WriteLine (o);
			}

			Vector v = new Vector ();
			v.add (1);
			v.add (2);
			v.add (3);
			v.add (4);
			v.add (5);
			//foreach 会自动调用迭代器，所以在自定义的类型中需要自己实现迭代器
			//需要自己写迭代器
			foreach (int t in v) {
				Console.WriteLine (t);
			}

		}
	}
	//实现迭代器，需要继承一个接口（IEnumerable 接口的命名空间Collections ）
	class Vector:IEnumerable{
		private int[] array;
		private int size;
		public Vector ()
		{
			array = new int[100];
			size = 0;
		}

		public void add(int a){
			array [size++] = a;
		}
		//注意不能写错接口名  需要实现接口方法：GetEnumerator
		public IEnumerator GetEnumerator(){
			for (int i = 0; i < size; i++) {
				yield return array [i];//将返回值挨个返回到迭代器中里
			}
		}
		//yield return : 遇到yield return 不会直接返回，而是直接把这个值返回去，然后继承循环，继续return 
		//yield return : 对应的返回值类型必须是迭代器类型（IEnumerator）
	}
}
*/
/*
namespace demo6每周一考No3Test2{
	class MainClass{
		public static void Main(){
			Student s1 = new Student ("L1", 10);
			Student s2 = new Student ("L2", 20);
			Student s3 = new Student ("L3", 30);
			Student s4 = new Student ("L4", 40);
			StudentManager sm = new StudentManager();
			sm.add (s1);
			sm.add (s2);
			sm.add (s3);
			sm.add (s4);
			sm.print ();
			sm.remove (s3);
			sm.print ();
			sm.revise (2, s3);
			sm.print ();
		}
	}
	class Student{
		private string name;
		private int age;
		private int id;
		public Student(string name,int age) {
			this.name = name;
			this.age = age;
			++id;
		}
		public override string ToString ()
		{
			return string.Format ("[Student] name: {0},age: {1}",name,age);
		}
	}
	class StudentManager{
		private List<Student> array;
		public StudentManager(){
			array = new List<Student> ();
		}
		public Student this[int index] {
			get{ return array [index];}
		}
		public void add(Student s){
			array.Add (s);
		}
		public void remove(Student s){
			array.Remove (s);
		}
		public void print(){
			foreach (Student s in array) {
				Console.WriteLine (s);
			}
		}
		//传入要修改的索引下标和对应新的值
		public void revise(int index,Student s){
			if (index < 0 && index+1 > array.Count)
				return;
			array [index] = s;
		}
	}
}
*/
/**/
namespace demo7类型转换复习{
	class MainClass{

		//什么情况下需要强转？
		//当需要得值要我们想要的时候  因为强转是将高精度转换成低精度（因此会造成数据精度丢失）

		//为什么需要强转？

		public static void Main(){
			//1、第一种强转()
			double d = 1.2;
			int a =(int) d;
			Console.WriteLine (a);
			//2、第二种强转 Convert.Toint32();
			double d1 = 2.2;
			int a1 = Convert.ToInt32 (d1);
			Console.WriteLine (a1);
			//char 类型需要用int、long等单精度整数类型转换 不能传97.0浮点类型的数值
			char c = Convert.ToChar ((int)97.0);
			Console.WriteLine (c);
			//3、第三中强转 xx.parse();
			string s = "123456";
			int a2 = int.Parse (s);
			Console.WriteLine (a2);
			string s1 = "123.456";
			double d2 = double.Parse (s1);

			Console.WriteLine (d2);
			Console.WriteLine ((int)d2);
			Console.WriteLine (d2);

			char c1 ;
			string s2 = "a";
			c1 = char.Parse (s2);
			Console.WriteLine (c1);
			char ?c2 = null;
			//c2 = (char)s2;   string类型不能强转为char类型，
			//就算是只有1个字符的字符串，但是可以使用char.parse()转换一个字符的字符串
			Console.WriteLine (c2);//打印null为空

			String s3 = "123.45677";
			double d3 = Convert.ToDouble (s3);
			Console.WriteLine (d3);
			String s4 ="231241";
			int a3 = Convert.ToInt32 (s4);
			Console.WriteLine (a3);
			char c3 = Convert.ToChar ("a");
			Console.WriteLine (c3);

			//隐式转换： 低精度转换成高精度,数据不会丢失（失去精度）
			int a4 = 1;
			double d4 = a4;
			Console.WriteLine (a4);



		}
	}
}




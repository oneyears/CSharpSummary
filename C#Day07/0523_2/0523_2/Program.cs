/*using System;

namespace _2
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//Person p1 = new Person();
			//p1.Name = "aaa";

			//Person p2 = new Person();
			//p2.Name = "bbb";

			//Person p3 = new Person();
			//p3.Name = "ccc";

			//单例模式：在程序执行期间，指定的某一个类只能创建一个对象
			//在类中提供一个供全局调用的方法来获取这个单一实例

			Person p1 = Person.getInstance();//singleInstance = new Person();
			Person p2 = Person.getInstance();//singleInstance = new Person();
			Person p3 = Person.getInstance();//singleInstance = new Person();

			p1.Name = "aaa";
			p2.Name = "bbb";
			p3.Name = "ccc";
			Console.WriteLine(p1.Name);
			Console.WriteLine(p2.Name);
			Console.WriteLine(p3.Name);


		}
	}

	class Person
	{
		//单例模式实现过程：
		//1.在类外不可以通过构造函数创建对象
		//2.在类中创建一个全局唯一的Person对象
		//3.提供一个供全局调用的方法来获取这个单一实例
		private static Person singleInstance;
		//类中的静态成员在程序执行期间只存在一个，而且不会释放
		private Person() { } //创建私有构造函数(不让系统再提供公有无参构造函数了)
		//返回值类型是Person
		public static Person getInstance()
		{
			if (singleInstance == null)
			{
				singleInstance = new Person();
			}
			return singleInstance;
		}








		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
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
			Person p1 = Person.getInstance();
			Person p2 = Person.getInstance();
			Person p3 = Person.getInstance();

			p1.Name = "aa";
			p2.Name = "bb";
			p3.Name = "cc";

			Console.WriteLine(p1.Name);
			Console.WriteLine(p2.Name);
			Console.WriteLine(p3.Name);
		}
	}

	class Person
	{
		//静态字段的特点，只会执行一次
		private static Person singleInstance = new Person();
		private Person() { }
		public static Person getInstance()
		{
			return singleInstance;
		}





		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
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
			Person p = new Person("zhangsan", 20);
			p.print();//p1调用print，print中的this就是p1

			Person p2 = new Person("lisi", 20);
			p2.print();//p2调用print，print中的this就是p2
		}
	}

	class Person
	{
		private string name;
		private int age;

		public Person(string name, int age)
		{
			this.name = name;//name是形参name
			this.age = age;//this就是当前对象
		}

		//谁调用方法，this就是谁
		public void print()
		{
			Console.WriteLine("name:{0},age:{1}", this.name, this.age);
		}

		public static void fun()
		{
			//Console.WriteLine(this.name);
			//静态方法是由类调用的，静态方法中的this没有意义
		}
	}
}
*/
using System;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			//Vector v = new Vector();
			//Console.WriteLine(v.array[0]);
			//Console.WriteLine(v[0]);//直接用对象名加[下标]访问数组中的元素
			//先访问到数组，然后再加[下标]
			//数组必须是公有

			Vector v = new Vector(10);
			for (int i = 0; i < 10; i++)
			{
				v[i] = i; //调用索引器的set方法
			}

			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(v[i]);//调用索引器的get方法
			}
		}
	}
	class Vector
	{
		private int n;
		private int[] array;

		public Vector(int _n)
		{
			array = new int[_n];
			n = _n;
		}

		//索引器：可以通过对象名直接加[下标]访问数组中的元素
		public int this[int index]//下标类型是int
		{
			get { return array[index]; }
			set { array[index] = value; }
		}
		public int N
		{
			get { return n; }
			set { n = value; }
		}
	}
}
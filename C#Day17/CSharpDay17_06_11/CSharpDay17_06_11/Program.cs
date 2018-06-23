using System;
using System.Collections.Generic;
using System.Collections;

//Day19 c#其他特性day2
/*
namespace CSharpDay17_06_11
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Console.WriteLine ("Hello World!");
			Person1 p1 = new Person1 ("qwq",10,1);
			//p1.Age = 10;
			//p1.Id = 200;
			//p1.Name = "ls";
			Console.WriteLine (p1.Name+p1.Age+p1.Id);//p1.Age+p1.Id+p1.Name  打印出为 210ls
			//p1.Name+p1.Age+p1.Id	打印出 ls10200
		}
	}

	class Person{
		private string name;
		private int age;

		public string Name
		{
			get{ return name; }
			set{ name = value;}
		}

		public int Age
		{
			get{ return age;}
			set{ age = value;}
		}

		//自动实现的属性，不用声明字段，直接声明属性, get set 后直接跟分号
		//不能直接写一个set or get
		//自动实现的属性会生成一个没有名字的字段，该字段没有名字只能通过自动实现的属性访问
		//自动实现的属性跟自己手动声明的字段没有任何关系
	}
	class Person1{

		public string Name{ get; private set;}
		public int Age{ get; private set; }
		public int Id{ get; private set; }
		public Person1(string name,int age,int id) {
			this.Name = name;
			this.Age = age;
			this.Id = id; 
		}


		//public string Name{get {return name;}}
	}
}
*/

/*
namespace demo1var隐式类型{
	class MainClass{

		public static void Main(){

			int a = 5;
			var b = 5;//声明时不知道b的类型
					//b的类型要通过等号后边的值确定
			var c = "hello";
			//b是int， c就是字符串
			var d = new int[]{ 1, 2, 3, 4, 5, 6, 7 };
			//1、var 声明变量时，要通过等号右边的值确定变量的类型
			//2、var 声明的变量不能赋值为null
			//3、var 声明的变量必须初始化
			//4、var 声明的变量不能等于匿名方法
			//5、var 只能声明局部变量，不能声明类中的字段
			//6、var 不能声明方法的参数
			var v = 0;
			v = 100;
//			v = null;语法错误，不能编译
			Console.WriteLine (v);
//			var v1 = delegate {
//			}; 不能声明，直接语法报错

			//使用var的好处
			//1、在声明字典时可以直接用 var 代替前面的类型声明如： var dir = new Dicionary<string,int>(); 
			//2、在 foreach遍历时  var 代替 KeyValuePair	
			var dir = new Dictionary<string,int>(); 
			Dictionary<KeyValuePair<string,int>,int> dir2 = new Dictionary<KeyValuePair<string,int>,int> ();
			dir.Add ("ls", 1);
			dir.Add ("ls1", 2);
			dir.Add ("ls3", 3);
			dir.Add ("ls4", 4);
			dir2.Add (new KeyValuePair <string,int>("qwq", 21), 22);
			foreach (var t in dir2) {
				Console.WriteLine (t);//[[qwq, 21], 22]
			}
			//var 代替的是 KeyValuePair
			foreach(var t in dir) {
				Console.WriteLine (t.Key + t.Value + t);
			}
		}
		//public void static fun1(var a){}
	}
}
*/

/*
namespace demo2对象初始书器{
	class MainClass{
		public static void Main(){
			Person p = new Person();
			Person p1 = new Person (){ Name = "ls",Age = 10 ,Score = 100};//unexecuted 未实行的,未执行的 ,symbol 符号
			//对象初始化器，先调用无参构造函数初始化对象，再通过属性初始化
			//优点：不用重载很多构造函数，大扩号中可以选择对哪些属性初始化
			Console.WriteLine (p1);
		}
	}
	class Person{
		public string Name{ get; set;}
		public int Age{get; set;}
		public int Id{ get; set;}
		private int score;
		public int Score{
			get{ return Score;}
			set{ score = value; }
		}
		public Person(){
		}
		public override string ToString ()
		{
			return string.Format ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}
	}
}
*/

/*
namespace demo3集合初始化器{
	class MainClass{
		public static void Main(){
			int[] a = new int[]{ 1, 2, 3, 4, 5, 6, 7 };
			ArrayList array = new ArrayList(){1,2,3,4,5,6,7,8};
			List<int> array2 = new List<int> (){ 1, 2, 3, 4, 5, 6, 7 };
			foreach (var t in array)
				Console.WriteLine (t);
			foreach (var t in array2)
				Console.WriteLine (t);

			Vector<int> vi = new Vector<int> (){ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			//集合初始化器，需要用到迭代器和Add



			foreach (var v in vi) {
				Console.WriteLine (v);
			}
		}
		class Vector<T> :IEnumerable{
	
			private T[] array;
			private int size;
			public Vector(){
				array = new T[20];
				size = 0;
			}
			public void Add(T x){
				array [size++] = x;
			}
			public IEnumerator GetEnumerator(){
				for (int t = 0; t < size; t++)
					yield return array [t];
			}
		}
	}
}
*/
 
/*
namespace demo4匿名类型{
	class MainClass{
		public static void Main(){

			//匿名类型，没有类型
			//匿名类型对象，没有类型对象
			//匿名类型要配合var使用
			var p = new {Name = "ls",Age = 20};
			Console.WriteLine (p);
			//p.Name = "lsq";
			//匿名类型对象的属性是只读的
			//p1 和p2 是两个不同类型的对象，虽然都是没有类型的对象，但是结构不一样(如果结构一样则相等)
			var p1 = new {Name = "ls1",Age = 20};
			if (Equals (p, p1)) {
				Console.Write ("qq\n");
			} else {
				Console.WriteLine ("~");
			}
			//匿名类型对象的数组
			var array = new [] {
				new{name = "ls",Age = 20},
				new{name = "ls1",Age = 21},
				new{name = "ls2",Age = 22}//注意这里不用逗号了
			};
			foreach (var t in array) {
				Console.WriteLine (t);
			}
		}
	}
}
*/

/*
namespace demo5判断是否相等{

	//c# 在判断相同时有判断值类型的值相等，还有引用类型的相等方式（地址是否相同）
	class MainClass{
		public static void Main(){
			//如果在赋值时他们的地址一样，则会指向相同的空间
			string str1 = "Test";
			string str2 = "Test";
			string a = str1;
			if (str1 == str2) {
				Console.WriteLine ("地址相同");
			}else{2
				Console.WriteLine("地址不同");
			}

			if (str2 == a) {
				Console.WriteLine ("地址相同");
			}else{
				Console.WriteLine("地址不同");
			}

		}
	}

}
*/

/*
namespace demo6Lambda表达式Lambda语句{

	class MainClass{
		public delegate int MyDelegate(int a,int b);
		public static void Main(){

			MyDelegate d1 = add;
			MyDelegate d2 = delegate(int a, int b) {
				return a + b;
			};

			MyDelegate d3 = (a, b) => {
				double x = 1.2;
				Console.WriteLine(x);
				return a+b;
			};
			Console.WriteLine (d3 (1, 2));
			//对于只有return表达式，可以去掉括号和return
			//=>右边如果只有一个表达式，表示return这个表达式的值
			MyDelegate d4 = (a, b) => a + b;
			fun (10, 20, d3);
			fun (10, 20, d1);

			fun (10, 20, (a, b) => a + b);
			//将lambda表达式直接赋值给形参d

			fun (10, 20, d4);
			//将匿名方法直接赋值给形参d
			fun (10, 20, delegate(int a, int b) {
				return a + b;
			});
			fun (10, 20, d2);
			//lambda表达式的分类
			//有大括号的称为语句lambda，没有大括号的称为表达式lambda
		}
		public static int add(int a,int b){
			return a + b;
		}
		//参数是委托变量，则可以传入一个方法，lambda表达式，语句，匿名函数、委托变量
		public static void fun(int a,int b, MyDelegate d){
			int x = d (a, b);
			Console.WriteLine (x);
		}

	}
}
*/

/*
namespace demo7Lambda表达式在函数中的使用{
	class MainClass{
		public delegate int GetDelegate();
		public delegate void SetDelegate (int a);
		public delegate int GetDelegate2(int b);
		public static GetDelegate get_del;
		public static SetDelegate set_del;
		public static GetDelegate2 set_del1;
		public static void Main(){
			fun ();
			Console.WriteLine (get_del ());
			set_del (100);
			Console.WriteLine (get_del ());
			set_del (21);
			Console.WriteLine (get_del ());

			Console.WriteLine (set_del1 (10));
		}
		public static void fun(){
			int a = 5;
			//就算是无参也要写()=>
			get_del = () => a;
			//如果一个参数可以不加()  (_a)
			set_del = _a =>a = _a;

			set_del1 = _a => _a + a;
		}
	}
}
*/  

/*
namespace demo8泛型委托系列{
	class MainClass{
		public static void Main(){

			Func<int,int> d = (x) => x * x;
			Console.WriteLine (d (2));
			//默认最后一个是返回值
			Func<string,bool> d2 = (string arg) => {
				return arg.Length > 5;
			};

			Console.WriteLine (d2 ("hello world"));

			Func<int,int,int> d3 = (arg1, arg2) => arg1 + arg2;
				Console.WriteLine(d3(5,10));
			//当系统泛型委托的参数是一个时，只可以用return返回，不可以传参




			Func<int> d4 = () => 5;
			Console.WriteLine (d4());
			Func<int> d5 = () =>{Console.WriteLine("qwq");return 0;};
			d5 ();
		}
	}

}
*/

/*
namespace demo8Sort与CompareTo排序{

	class MainClass{
		public static void Main(){
			Person p1 = new Person ("ls1", 20, 1801);
			Person p2 = new Person ("ls2", 21, 1806);
			Person p3 = new Person ("ls3", 22, 1805);
			Person p4 = new Person ("ls4", 22, 1801);
			Person p5 = new Person ("ls5", 22, 1804);
			Person p6 = new Person ("ls6", 22, 1805);
			Person p7 = new Person ("ls7", 21, 1807);
			Person p8 = new Person ("ls8", 22, 1803);
			List<Person> array = new List<Person> {p1, p2, p3, p4, p5, p6, p7, p8};
			foreach (Person p in array)
				Console.WriteLine (p);
			Console.WriteLine ("---------------------------");
			array.Sort ();//自动调用CompareTo方法进行排序，默认从小到大
			foreach (Person p in array)
			Console.WriteLine (p);
			//array.Reverse ();
			Console.WriteLine ("---------------------------");
			foreach (Person p in array)
			Console.WriteLine (p);
			Console.WriteLine ("---------------------------");
//			foreach (Person p in array)
//			Console.WriteLine (p);
		}
	}
	class Person:IComparable{
		public string Name{get;set;}
		public int Age{ get; set;}
		public int Id{ get; set;}
		public Person(string name,int age,int id){
			this.Name = name;
			this.Age = age;
			this.Id = id;
		}
		public override string ToString ()
		{
			return string.Format ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}
		//用来比较两个对象大小的,返回值大于0，表示前面大于后边，等于0相等，小于0小于后边.
		//如要从大到小，则改成相反结果
		public int CompareTo(object o){

			if (this.Age == ((Person)o).Age) {
				if (this.Id == ((Person)o).Id) {
					//TODO
				}
				return -(this.Id - ((Person)o).Id);
			}

			return -(this.Age - ((Person)o).Age);
		}
	}
}
*/

/**/
namespace demo8ListSort方法传入Lambda{

	class MainClass{
		public static void Main(){
			Person p1 = new Person ("ls1", 20, 1801);
			Person p2 = new Person ("ls2", 21, 1806);
			Person p3 = new Person ("ls3", 22, 1805);
			Person p4 = new Person ("ls4", 22, 1801);
			Person p5 = new Person ("ls5", 22, 1804);
			Person p6 = new Person ("ls6", 22, 1805);
			Person p7 = new Person ("ls7", 21, 1807);
			Person p8 = new Person ("ls8", 22, 1803);
			List<Person> array = new List<Person> {p1, p2, p3, p4, p5, p6, p7, p8};
			foreach (Person p in array)
				Console.WriteLine (p);
			Console.WriteLine ("---------------------------");
			array.Sort (((x, y) => x.CompareAge(y)*3 + x.CompareId(y)*2));//不传参默认调用CompareTo方法，传参时可以调用lambda表达式
			//多权重排序，按权重值排序  可以按*2 *3 *4 放大倍来写权重
			foreach (Person p in array)
				Console.WriteLine (p);
		}
	}
	class Person{
		public string Name{get;set;}
		public int Age{ get; set;}
		public int Id{ get; set;}
		public Person(string name,int age,int id){
			this.Name = name;
			this.Age = age;
			this.Id = id;
		}
		public override string ToString ()
		{
			return string.Format ("[Person: Name={0}, Age={1}, Id={2}]", Name, Age, Id);
		}

		//控制返回值返回1,0,-1   通过 * 2 *3 来获得权重，权重越大越先执行
		public int CompareAge(Person p) {
			int x = this.Age - p.Age;
			return x == 0 ? 0 : (x > 0 ? 1 : -1);
		}
		public int CompareId(Person p) {
			int x = this.Id - p.Id;
			return x == 0 ? 0 : (x > 0 ? 1 : -1);
		}
	}
}


/*
namespace demo9Test1{
	class MainClass{
		public static void Main(){
			Person p = new Person (){ Name = "ls", Age = 20 };
			Person p2 = new Person (){ Name = "ls2", Age = 20 };
			Person p3 = new Person (){ Name = "ls3", Age = 20 };
			Person p4 = new Person (){ Name = "ls4", Age = 20 };
			Vector v = new Vector (){ p, p2, p3, p4 };
			foreach (Person i in v)
				Console.WriteLine (i);
		}
	}
	class Person{
		public String Name{get;set;}
		public int Age{ get; set;}
		public override string ToString ()
		{
			return string.Format ("[Person: Name={0}, Age={1}]", Name, Age);
		}
	}
	class Vector:IEnumerable{
		private Person[] array;
		private int size;
		public Vector(){
			array = new Person[4];
			size = 0;
		}
		public void Add(Person p) {
			array [size++] = p;
		}
		public IEnumerator GetEnumerator(){
			for (int i = 0; i < size; i++)
				yield return array [i];
		}
	}
}
*/

/*
namespace demo10Test2{
	class MainClass{
		public delegate void mydelegate();
		public static void Main(){
			List<int> list = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			var newlist = list.FindAll (delegate(int i) {
				return i > 3;
			});
			foreach (var v in newlist) {
				Console.WriteLine (v);
			}
		}
	}
}
*/



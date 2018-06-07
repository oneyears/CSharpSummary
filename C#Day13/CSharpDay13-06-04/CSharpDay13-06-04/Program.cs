using System;
using System.Diagnostics;//灰色字体表示没有使用
/*
namespace CSharpDay130604
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			PersonStr p_str = new PersonStr ("ls", 20, 217);
			PersonStr p_str2 = p_str;

			p_str.name = "xxx";
			p_str.id = 1805;
			p_str.age = 20;
			Console.WriteLine (p_str);
			Console.WriteLine (p_str2);
			//PersonCla p_cla = new PersonCla ("ls1", 21, 1805);

			string a = "hello";
			string b = a;
			a = "你好~";
			Console.WriteLine (a);
			Console.WriteLine (b);

			PersonCla p_cla1 = new PersonCla ("LS", 20, 1805);
			PersonCla p_cla2 = p_cla1;
			p_cla1.Name = "廖圣";
			Console.WriteLine (p_cla1);
			Console.WriteLine (p_cla2);


		}
	}

	struct PersonStr{
		public string name;
		public int age;
		public int id;
		public PersonStr(string name,int age,int id) {
			this.age = age;
			this.id = id;
			this.name = name;
		}
		public override string ToString ()
		{
			return string.Format (name + age + id);
		}
	}

	class PersonCla{
		public string name;
		public int age;
		public int id;
		public PersonCla(string name,int age,int id) {
			this.age = age;
			this.id = id;
			this.name = name;
		}

		public string Name{
			get{ return name;}
			set{ name = value;}
		}


		public override string ToString ()
		{
			return string.Format ("name{0},age{1},id{2}",name,age,id);
		}
	}
}
*/
/*
namespace demo1装箱拆箱 {

	class MainClass{

		public static void Main(){

			//(2)
			//值类型继承自ValueType,ValueType又继承自System.Object
			//引用类型直接继承于System.Object



			int a = 5; //值类型

			//装箱
			object o = a; // o 是引用类型，栈上的o指向堆空间
			//将值类型变量赋值给引用类型：装箱
			//装箱过程：


			//拆箱
			int b = (int)o;//将引用类型赋值给值类型变量b
			//将引用类型赋值给值类型变量：拆箱
			//拆箱过程：在栈上开辟一块空间，将堆空间上的内容拷贝到栈上
			//装相：值类型-->引用类型
			//拆箱: 引用类型-->值类型

			//所以值类型都可以装箱
			//但是引用类型却不是都可以拆箱

			//如 string x = "hello";
			//int a = int (x);
			//拆箱时，数据和拆箱后的类型一致才可以拆箱
			//只有装箱后的数据才可以拆箱

			Object[] array = new object[100];
			for (int i = 0; i < 100; i++) {
				//装箱100次
				array [i] = i;
			}
			int[] arrayi = new int[100];
			for (int i = 0; i < 100; i++) {
				arrayi [i] = i;
			}

		}
	}
}
*/
/*
namespace demo2时间测试装箱性能差别{
	class MainClass{
		public static void Main(){

			int Max = 50000000;

			Stopwatch sw1 = new Stopwatch ();//统计时间的类
			sw1.Start (); //开始统计时间

			object[] array0 = new object[Max];
			for (int i = 0; i < Max; i++) {
				array0 [i] = i;//装箱
			}
			sw1.Stop ();//结束统计时间


			Stopwatch sw2 = new Stopwatch ();
			sw2.Start ();

			int[] array1 = new int[Max];
			for (int i = 0; i < Max; i++) {
				array1 [i] = i;
			}
			sw2.Stop ();
			TimeSpan span1 = sw1.Elapsed; //时间结构体
			TimeSpan span2 = sw2.Elapsed;//Elapsed:获取时间的属性

			Console.WriteLine ("Span1 {0},{1}", span1.Seconds, span1.Milliseconds);
			Console.WriteLine ("Span2 {0},{1}", span2.Seconds, span2.Milliseconds);

		}

	}
}
*/
/*
namespace demo3形参中值类型按值传递{

	class MainClass{
		public static void Main() {
			int x = 5;
			fun (x);
			Console.WriteLine("函数外x的值：{0} ",x);

			//形参和实参是拷贝关系，修改形参不会影响实参
			//传参方式是按值传递的
		}

		public static void fun(int x) {
			x += 1;
		}

	}

}
*/
/*
namespace demo4形参中引用类型按值传递{

	class MainClass{
		public static void Main() {
			Person p = new Person ("ls", 20);
			//将实参p传递给形参p
			fun (p);
			p.print ();
		}

		public static  void fun(Person p){
			p = new Person ("list", 100);//直接修改形参的值
			p.print ();

		}


	}

	class Person{

		private string name;
		private int age;
		public Person(string name,int age) {
			this.name = name;
			this.age = age;
		}

		public void print(){
			Console.WriteLine ("name:{0},age:{1}", name, age);
		}

	}

}

*/
/*
namespace demo5ref修饰符{

	class MainClass {
		public static void Main(){
			int x = 5;
			fun (ref x);
			Console.WriteLine("函数外的x: {0} ", x);

			int a = -1, b = -3;
			swap (ref a, ref b);
			Console.WriteLine ("a:{0},b:{1}", a, b);

		}

		//值类型按引用传递（传参方式：按引用传递）
		//在形参声明前加ref，传递实参时也要加ref
		//按值传递时，形参和实参是拷贝的关系
		//按引用传递时，形参是实参的引用，是实参的别名，即实参和形参是同一个变量

		//但要注意是传递方式，而不是真的变成引用类型了
	
		public static void fun(ref int x) {
			x = 100;
			Console.WriteLine ("函数内的x: {0}", x);
		}

		//形参是实参的别名，形参和实参是同一个变量
		public static void swap(ref int a,ref int b) {
			a = a + b;
			b = a - b;
			a = a - b;
		}
//		object 类型 不能直接用操作符 + -进行算术运算
//		public static void swap2(ref object a,ref object b) {
//			a = a + b;
//			b = a - b;
//			a = a - b;
//		}
//
//
	}
}
*/
/*
namespace demo6参数中的引用类型按引用类型传递{
	class MainClass{
		public static void Main(){
			Person p = new Person ("ls", 20);
			fun (ref p);
			Console.WriteLine ("函数外"+p);
		}

		public static void fun(ref Person p) {
			p = new Person ("LS", 100);
			Console.WriteLine ("函数内"+p);
		}


	}

	class Person {
		private string name;
		private int age;
		public Person(string name,int age) {
			this.name = name;
			this.age = age;
		}
		public override string ToString ()
		{
			return string.Format ("name:{0},age{1}",name,age);
		}
	}
}
*/
/*
namespace demo7out修饰符{
	class MainClass{
		public static void Main(){
			int a = 1;
			fun (out a);
			Console.WriteLine ("函数外的x:{0}",a);
			//变量不初始化，不可以直接使用
		}
		//ref 或者 out 都可以将参数按引用传递
		//用out 修饰形参，必须在函数内对形参赋值
		public static void fun(out int x){
			x = 100;
			Console.WriteLine ("函数内的x：{0}", x);
		}
	}
}
*/
/*
namespace demo8Switchtest{
	class MainClass{
		public static void Main(){
			for (int i = 1; i <= 3; i++) {
				switch (i) {
				case 1:
					Console.Write (i.ToString ());
					break;
				case 2:
					Console.Write ((i*2).ToString ());
					break;
				//不能定义重复的case值,而且需要break；跳出switch
				case 3:
					Console.WriteLine ((i * 3).ToString ());
					break;
				}
			}
		}
	}
}
*/
/*
namespace demo9eventTest11{
	//老鼠发布事件
	//猫是订阅者
	class MainClass{

		public static void Main(){
			Mouse m = new Mouse ();
			m.getRead ();
			m.runOut ();
		}
	}
	class Mouse{
		public delegate void Mdelegate();
		public event Mdelegate m;

		public void runOut(){
			Console.WriteLine ("老鼠出来了");
			m ();
		}
		public void getRead(){
			m += new Cat ().waitingMouse;
		}

	}
	class Cat{
		public void waitingMouse(){
			Console.WriteLine ("老鼠出来了，猫扑过去");
		}
	}
}
*/
/*
namespace demo10eventTest12{
	// 我是触发者
	// 控制台是订阅者
	class MainClass{
		public static void Main(){
			My m = new My ();
			m.iSay ();
			
		}
	}
	class My{
		public delegate void MyCin();
		public event MyCin m;

		public void iSay(){
			m += new Replay ().isRightEvent;
			m ();
		}

	}
	class Replay{
		public void  isRightEvent(){
			Console.WriteLine ("输入一个字符");
			string num = Console.ReadLine ();
			if(num == "a")
				Console.WriteLine("my event is ok");
			else{
				Console.WriteLine("error");
			}
		}
	}
}
*/
//			object a;
//			int b = 5;
//			a = b;
//			Console.WriteLine (a); a = 5 引用类型可以直接拆箱
/*
namespace demo11Test{
	class MainClass{
		public static void Main(){
			int a = 5;
			fun (a);
			Console.WriteLine (a);
		}
		public static void fun(int x){
			x++;
			Console.WriteLine (a);
		}
	}
}
*/
/*
namespace demo12Test{
	class MainClass{
		public static void Main(){
			int a = 5;
			fun (ref a);
			Console.WriteLine (a);
		}
		public static void fun(ref int a){
			a++;
			Console.WriteLine (a);
		}
	}
}
*/

using System;

/*
  接口的疑问：
  一：接口是什么（概念）?
  1️⃣ 接口用于描述一组类的公共方法（或属性），并不对方法作任何的实现
  二：接口有什么作用?
  三：为什么用到接口？
  四：接口和多态有什么关系?
  五：接口的表面是什么（定义）?
  六：接口的使用规则、要求？
  七：接口的起到作用后有什么效果（好处）
  八：接口的特性是什么？
  九：接口有多少个关键字？
 */ 
/*
namespace CSharpDay11_05_31
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Animal a = new Tanglaoya ("tan", 5);
			//a.speak (); 父类无法调用接口的里的方法（尽管子类已经实现）
		}
	}

	class Animal{
		private string name;
		private int age;
		public Animal(string name,int age) {
			this.name = name;
			this.age = age;
		}
	}
	// 在C#中不支持多重继承，子类不能（同时）有多个父类，C++可以继承多个父类
	// 但是类可以继承多个接口
	//接口：对一组方法进行统一声明，和类的关系是CAN-NO的关系

	//关键字 interface
	//接口中的所有方法必须要实现
	interface Speak{
		void speak();//接口中的方法没有修饰符（默认为公有，普通类中的方法字段默认是私有的），没有函数体
		//需要在继承该接口的类中实现函数体
		一接口里面不能  
		1、使用static关键字
		2、不能有字段
		3、不能有运算符重载
		4、实例构造函数
		5、析构函数
		二：接口里可以有
		1、属性
		2、事件
		3、索引器
		4、方法
		5、4类的任意组合

		不按规则要求，编译会报错

	}

	class Tanglaoya:Animal,Speak{
		public Tanglaoya(string name,int age):base(name,age) {

		}
		//实现接口方法要加修饰符，不加默认是私有的 （在接口不加修饰符默认是公有）
		public void speak(){
			Console.WriteLine("tang speak");
		}
	}
}
*/
/*
namespace demo1{
	class MainClass{
		public static void Main(){
			Chinese c = new Chinese();
			English e = new English ();
			//第一种调用方法 直接用对象名调用接口方法
			c.sayHello ();
			e.sayHello ();
			//第二种调用方法 或者赋值给接口变量（x1 和 x2），再调用接口方法（接口类似父类被子类继承）
			SayHello x1 = c;
			SayHello x2 = e;
			x1.sayHello ();
			x2.sayHello ();
		}

	}
	class Person{}
	interface SayHello{
		void sayHello();
	}
	class English:Person,SayHello{
		public void sayHello(){
			Console.WriteLine("hi");
		}
	}
	class Chinese:Person,SayHello{
		public void sayHello(){
			Console.WriteLine("你好");
		}
	}
}
*/
/**/
namespace demo2显示接口隐示接口{
	class MainClass{
		public static void Main(){
			abc a = new abc();
			//此时a不能直接访问到相同名方法(fun())，
			//1、需要将对象类型转换成对应的接口
			Ix x = a;
			x.fun ();
			//2、显示接口，这样可以标识出调用的哪个接口中的哪个方法，这里需要注意两个括号，来标识显示a的类型为Iy接口
			((Iy)a).fun ();
		}
	}
	interface Ix{
		//接口里的方法也不能定义为公有
		void funx();
		void fun();
	}
	interface Iy{
		void funy();
		void fun();
	}
	class abc: Ix,Iy{
		public void funx(){Console.WriteLine("funx");}
		public void funy(){Console.WriteLine("funy");}
		//显式实现接口 通俗的讲，显式接口实现就是使用接口名称作方法名的前缀 接口名.方法（多个接口同名方法）
		//继承的多个接口中存在同名方法时，必须要显示实现同名的接口方法
		//显式实现接口不加修饰符，默认是私有的，方法名前要知道是哪个接口中的方法
		//不能用public 修饰显式接口，因为接口的默认方法是私有的了
		 void Ix.fun(){Console.WriteLine("Ixfun()");}
		 void Iy.fun(){Console.WriteLine("Iyfun()");}
		//接口的显式和隐式的对比
		//隐式接口实现，类和接口都可以访问接口中方法
		//显式接口实现，只能通过接口访问
	}
}

/*
namespace demo3接口与抽象类{
	class MainClass{
		public static void Main(){
			P p = new P();
			p.fun();
			B b = new P();
			b.fun ();



		}
	}
	//回调方法， 当我调用一个方法，用了其他类的方法，而在其他类的方法里又包含了我的一个方法
	//相同点 
	//1、都不能实例化
	//不同点
	//1、关键字不一样
	//2、接口可以支持多继承，抽象类不能实现多继承
	//3、接口中的方法不能有函数体，抽象类中的方法可以有，可以没有函数体
	//4、接口和继承接口的类是CAN-DO关系，父类和子类是IS-A的关系
	//5、接口可以用于支持回调，抽象类不能实现回调，因为继承不支持（java中）
	//6、接口中的成员只有方法属性索引器和事件，类中还可以有字段，虚方法，静态成员
	//7、值类型可以继承接口，但不能继承类。（因此接口可以继承接口，但是接口不能继承类）

	interface A{
		//当子类有相同的方法名（但是也是虚方法），此时不会报错，可以正常运行
		void fun();

	}
	abstract class B{
		public virtual void fun(){
			Console.WriteLine("qw函数体");
		}
	}
	class P: B,A{
		public override void fun(){
			Console.WriteLine("重写的函数体fun P");
		}
	}
}
*/

/*
	委托的疑问：
	一、委托是什么？
	二、委托有什么作用
	三、为什么需要委托
	四、用了委托能起到什么作用
	五、什么时候需要用委托
	六、委托包含什么内容
	七、怎么使用委托
	1、创建委托类型
	2、创建委托变量
	3、给委托变量添加可以执行的方法
	4、通过委托变量调用该方法

	八、委托的特性是什么
	九、委托和其他之间的关系是什么？
	十、委托有多少个关键字
*/
/*
namespace demo4委托{

	class MainClass{
		public static void Main(string [] args) {
			B b = new B();//b 委托 A
			b.Action ();// 我是A,我在帮别人买吃的

			Danshiren dang = new Danshiren ();
			LvShi l = new LvShi ();
			dang.d = l.fun;//将fun方法赋值给委托变量d
			dang.d ();//通过委托变量d调用fun方法
			//委托过程：在dang中定义一个委托变量，调用l中的某个方法，让l去执行某个方法
			//l.fun()
			//通过dang对象中的委托变量。命令l去执行fun
		}
	}

	class A{
		public void BuyFood(){
			Console.WriteLine("我是A,我在帮别人买东西");
		}
	}
	class B{
		//声明一个委托
		public delegate void doSomeThing();
		//A是 被委托的对象
		doSomeThing d = new doSomeThing(new A().BuyFood);
		//使用方法调用委托变量
		public void Action(){
			d();
		}
	}

	//委托：当事人对象委托律师对象执行某个任务
	class LvShi
	{
		public void fun(){
			Console.WriteLine("我是律师，我在帮当事人辩护");
		}
	}

	class Danshiren{
		//通过委托变量调用l中的方法
		//定义委托变量
		//1、先声明一个委托类型
		public delegate void MyDelegate();
		//2、定义委托变量 d 当调用委托对象，其所以的有方法都将执行（即一个委托可以执行多个方法）
		public MyDelegate d;
		//3、委托能够包装的方法也有要求限制
		//（1）方法的签名必须与委托一致
		// (2) 方法的返回类型要和委托一致
	}
}
*/
/*
namespace demo5委托Test{
	class MainClass{
		public static void Main(){
			Apple a = new Apple();
			Fushikang f = new Fushikang ();
			a.m = f.package;  // 用apple 的指针变量 指向 f对象的包装方法 （指针移动到富士康pack的方法）
			a.m (); // apple对象的委托变量m 调用方法，（这时就调用了 富士康的pack的方法了），这就是说明苹果叫富士康包装组装 
			// 苹果叫富士康 （苹果想包装组装材料，但是他没有这个方法，而富士康有这个方法，所以苹果就委托富士康工作），此时就完成了苹果自己想做的事
			// 富士康进行包装工作
		}
	}

	class Fushikang {
		public void package(){
			Console.WriteLine("我是富士康，我在帮苹果组装");
		}
	}
	class Apple{
		public delegate void MyNeed(); //定义一个 委托类型
		public MyNeed m ; //用这个委托类型 定义一个委托变量，（相当与指针变量）
	}
}
*/
/*
namespace demo6委托Test2{

	class MainClass{
		public static void Main(){
			Person p = new Person();
			p.d = new Computer ().add;
			int sum = p.d (1,2,3);
			Console.WriteLine ("sum={0}", sum);
		}
	}


	//委托的类型和执行的方法原型要一致（返回值类型，参数列表）,否则报错
	class Person{
		public delegate int Mydelegate(int a,int b,int c);
		public Mydelegate d;
	}

	class Computer{
		public int add(int a,int b,int c) {
			return a + b + c;
		}
	}
}
*/
/*
namespace demo7委托链{
	class MainClass{
		public static void Main(){
			De de = new De();//这里d委托默认为NULL，说明可以直接 += 方法同时也需要和委托类型保持一致
			de.d += fun;
			de.d += fun1;
			de.d += fun2;
			int s = de.d (3);//通过委托变量 d 可以调用委托链中所有的方法
			Console.WriteLine (s); //得到的返回值是最后一个方法的返回值，因此一般写委托链不写返回值类型（写void）
			de.d += fun;//1、可以添加重复的方法，移除的时候可以移除不存在的方法
			de.d -= fun1;
			de.d -= fun1;//2、可以删除以及不存在的方法，（前提是有这个方法）
			s = de.d (1);
			Console.WriteLine (s);
			de.d += de.d;//3、可以添加委托链本身
			de.d (2);
			Console.WriteLine (s);
		}
		public static int fun(int a){
			Console.WriteLine("fun "+a);
			return a;
		}
		public static int fun1(int b){
			Console.WriteLine("fun1 "+b);
			return b;
		}
		public static int fun2(int c){
			Console.WriteLine("fun2 "+c);
			return c;
		}
	}

	class De{
		public delegate int MyNeed(int x);
		public MyNeed d;
	}
		
}
*/
/*
namespace demo8委托作为参数传递{
	class MainClass{
		//定义委托类型 不能用static 修饰
		public delegate int myNeed(int a,int b);
		public static myNeed mn ;
		public static void Main(){
			Person p = new Person();
			p.m = add;
			p.m += add;
			p.fun (p.m);
			MainClass.mn = add;
			//由于委托类型不同（委托类型，返回类型相同，参数列表相同，但名字不同）所以不能传递这个委托变量
			//p.fun (mn);
		}
		public static int add(int a,int b) {
			return a + b;
		}

	}

	class Person{

		public delegate int myDelegate(int a,int b);
		public myDelegate m;
		public void fun(myDelegate f){
			Console.WriteLine("fun");
			Console.WriteLine (f (1, 2));
		}
	}
}
*/
/*
namespace demo9委托和switch关系{

	class MainClass{
		public delegate void myDelegate(string name);

		public static void Main(){
			greet("ls",ChineseGreeting);
			greet ("jack", EnglishGreeting);
			greet ("youzhai", JanpenGreeting);
		}

		public static void greet(string name,myDelegate f){
			f(name);
		}

		public static void ChineseGreeting(string name) {
			Console.WriteLine("你好"+name);
		}

		public static void EnglishGreeting(string name) {
			Console.WriteLine("hello"+name);
		}

		public static void JanpenGreeting(string name) {
			Console.WriteLine("喵帕斯"+name);
		}
			

	}
}
*/
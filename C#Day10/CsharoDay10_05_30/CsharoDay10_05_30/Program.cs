using System;

/*
：
十个疑问：
  1、多态包含什么内容？
   1️⃣ 方法重写： 相同的类对象，调用出相同的方法，产生不一样的结果
   2️⃣ 密封类、密封方法 用关键字sealed修饰，表示该类不能被继承，方法不能被重写
   3️⃣ 抽象类 用abstruct关键字修饰，也成抽象基类，修饰的方法叫做 纯虚方法，纯虚方法没有函数体，必须在派生类中实现
   4️⃣ 基类 System.Object 的小名缩写 为 object ,用console.writeLine(a)打印的对象，默认会调用ToString()方法
   5️⃣ new关键字 用来隐藏方法，这样父类对象就不能通过虚方法来调用派生类的new修饰过的方法了
  2、多态有什么作用
   1️⃣ 应用程序不必为每一个派生类编写功能调用，只需要对抽象类进行处理即可，大大提高程序的可重复性
   2️⃣ 派生类的功能可以被基类的方法或引用变量调用，提高可扩充性和可维护性
   3️⃣ 消除类型之间的耦合关系
  3、为什么需要多态？
  多态实现了方法的重写，当有多个子类要写不同的方法时，如果每个都写不同类型会很麻烦，当有了重写，那么只需重写其方法，
  不同对象调用相同的方法名，就可以有不同的操作了。
  4、多态是什么？
   1️⃣ 简单来说，多态就是相同的表达式，不同的操作。（相同的类型调用相同的方法却表现出不同的行为）
   2️⃣ 同类的对象对同一消息做出不同的响应叫做多态 就像上课铃响了，上体育课的学生跑到操场上站好，上语文课的学生在教室里坐好一样。
  5、多态与其他特征（封装、继承）的关系
  1️⃣ 有继承关系
  2️⃣ 子类重写父类方法 
  3️⃣ 父类引用指向子类对象 
以下3种无法表现出多态特性（因为无法被重写）
 1️⃣ static方法，因为被static修饰的方法属于类，而不是属于实例的
 2️⃣ sealed方法，因为被sealed修饰的方法无法被子类重写
 3️⃣ private 和protected方法，他们都无法被外部调用（虽然protected方法可以被重写），不能被外部引用的方法也就没什么意义了
  6、什么时候用到多态
当有同一个接口（父类）的方法 在多个子类都类似的方法需要写，如：动物有吃的行为，各种动物类也有吃的行为，此时就可以使用多态，将同样（行为）方法名进行重写,来表现出不同的具体操作。
  7、用到后起到什么样的效果
对同一方法进行重写，可以提高可扩充性和可维护性
  8、多态的表面是什么
相同类型的父类指向不同类型的子类，父类对象调用相同的方法会根据其指向的派生类做出不同的操作
 */ 
/*
namespace CsharoDay10_05_30
{

	class MainClass
	{
		public static void Main (string[] args)
		{
			Sheep s = new Sheep("ls",29);
			s.print ();
			Animal a = new Animal ("xx", 20);
			a.print ();
			Animal a1 = s;
			a1.print ();//S Is A Animal
			// Animal 中的print（）  是 Animal ,还是 Sheep的？
			//因为food 是虚方法，虚方法在执行时会根据实际对象调用对应类中的方法 (等号后面根据 实际 对象，调用对应的方法)
			//多态：相同类型的对象（a,a1) 调用相同的方法，却表现出不同的行为
			//实现多态的前提是实现虚方法

			Animal c = new Tiger ("c", 20); // c 对象，实际指向的是Tiger 对象，调用的方法也是Tiger的方法
			c.print ();

			Animal[] array = new Animal[5];
			array [0] = a;
			array [1] = a1;
			array [2] = c;
			array [3] = s;
			for (int i = 0; i < 4; i++) {
				Console.WriteLine ("{0}", i);
				array[i].print ();//根据实际指的对象不同，调用不同的方法
			}
			Animal a2 = new birth ("麻雀", 3);//由于birth类没有继承 Animal ,所以不能直接将a2指向birth类对象
			a2.print ();
		}
	}
	class Animal{
		private string name;
		private int age;

		public Animal(string name,int age){
			this.name = name;
			this.age = age;
		}

		public virtual void print(){

			Console.WriteLine("...");
		}
	}
	class Sheep :Animal{
		public Sheep(string name,int age):base(name,age){}
		//继承下来的food方法不能表示样的行为，羊需要重新实现继承下来的food方法
		//重新实现父类继承下来的方法称为重写
		//需要先将父类中的方法声明成虚方法（virtural），子类中重写的方法前加 override

		public override void print(){
			Console.WriteLine("吃草");
		}
	}
	class Tiger:Animal{
		public Tiger(string name,int age):base(name,age) {}

		public override void print(){
			// base 表示父类对象 base.print() 表示用父类对象打印父类的print()方法
			Console.WriteLine("吃肉");
		}
	}

	class birth:Animal{
	
		public birth(string name,int age):base(name,age){

		}
		public override void print(){
			Console.WriteLine("吃虫子");
		}
	}

}
*/
/*
namespace demo1new
{

	class MainClass
	{
		public static void Main (string[] args)
		{
			//如果不写虚方法，那么就算是指向其子类对象，但实际调用的还是根据对象本身类型（Animal类的方法）来调用
			Animal a = new Animal("a",2);
			Animal b = new Sheep ("b",3);
			Animal s = new Sheep ("b",3);
			Animal a2 = new Tiger ("laohu", 6);
			a.print ();
			// b、 s 的子类对象sheep 将print（）方法new（隐藏了），因此只能调用父类的方法了
			b.print ();
			s.print ();

			a2.print ();


		}
	}


	class Animal{
		private string name;
		private int age;

		public Animal(string name,int age){
			this.name = name;
			this.age = age;
		}

		public virtual void print(){

			Console.WriteLine("...");
		}
	}

	class Sheep :Animal{
		public Sheep(string name,int age):base(name,age){}
		//继承下来的food方法不能表示样的行为，羊需要重新实现继承下来的food方法
		//重新实现父类继承下来的方法称为重写
		//需要先将父类中的方法声明成虚方法（virtural），子类中重写的方法前加 override

		//通过new关键字，来覆盖父类中的方法,这样父类对象就无法通过虚方法来调用子类方法了
		public new void print(){
			Console.WriteLine("吃草");
			base.print();
		}

	}

	class Tiger:Animal{
		public Tiger(string name,int age):base(name,age) {}

		public override void print(){
			// base 表示父类对象 base.print() 表示用父类对象打印父类的print()方法
			Console.WriteLine("吃肉");
		}
	}

	class birth:Animal{

		public birth(string name,int age):base(name,age){

		}
		public override void print(){
			Console.WriteLine("吃虫子");
		}
	}

}
*/
/*
namespace demo2{

	class MainClass{
		public static void Main(string [] args) {
			Person p1 = new Person("ls",10);
			Voter v1 = new Voter("v1",12,1);
			Person p2 = new Voter ("v2", 22,2);
			p1.print ();
			v1.print ();
			p2.print ();
		}
	}


	class Person{
		private string name;
		private int age;

		public Person(string name,int age) {
			this.name = name;
			this.age = age;
		}

		public virtual void print(){
			Console.WriteLine("name{0},age{1}",name,age);
		}

	}
	class Voter:Person{
		private int pollingstation;

		public Voter(string name,int age,int pollingstation):base(name,age) {
			this.pollingstation = pollingstation;
		}
		public override void print(){
			base.print();
			Console.WriteLine("{0}",pollingstation);
		}

	}
}
*/
/*
namespace demo3密封类{
	class MainClass{
		public static void Main(String []args) {
			
		}
	}
	// 被sealed 修饰的类叫密封类
	// 被sealed修饰的类不能被继承
	//编译报错，B 不能继承 sealed修饰的 A类 
	sealed class A{
		public void print(){}
	}
	//但是 B可以被继承
	class B:A{
	
	}
	// c可以继承B
	class C:B{
	
	}
}
*/
/*
namespace demo4密封方法 {
	class MainClass{
		public static void Main(string [] args) {
			
		}
	}

	class Animal{
		public virtual void print(){Console.WriteLine("...");}
	}

	class Dog:Animal{
		public sealed override void print(){Console.WriteLine("狗");}
	}
	class ZangAo:Dog{
		// 由于声明 sealed 的虚方法不能再重写 ，所以这里不能再重写方法了
		public override void print(){Console.WriteLine("藏獒");}
		//override 也是虚方法。
		//很明显，因为virtual是说明该方法要被继承，而sealed是说该方法不能被继承，所以这两个关键字不能写在同一个方法里，否则就矛盾了
	}

}
*/
/*
namespace demo5抽象类{

	class MainClass{
		public static void Main(String [] args) {

		}
	}

	// 1、不需要创建对象的类声明成抽象类，用abstract 声明
	// 2、抽象类只能当父类使用，称为抽象基类
	// 3、抽象类不能创建具体的实例对象，但是可以用来作为声明类，但是实例其子类
	// 4、abstract 修饰方法，表示纯虚方法，纯虚方法没有函数体，必须在子类中实现
	// 5、纯虚方法只能在抽象类中存在，纯虚方法没有函数体，必须在子类中存在，纯虚方法只能在抽象类中存在
	// 6、
	abstract class Animal{
		//可以定义字段，供子类使用
		private string name;
		//抽象类的方法必须声明成纯虚方法 
		//纯虚方法，没有结构体，只能在抽象类中，且（派生类）子类必须实现纯虚方法
		//public abstract void food(){}
	}
}
*/
/*
namespace demo6基类{
	class MainClass{
		public static void Main(){
//			System.Object o1;
//			object o2;
//			//object 是System.Object类的别名（小名、缩写）
//			System.string s1;
//			string s2; 
			//string 是system.Object类的别名
			Animal a = new Animal("sas",20);
			Console.WriteLine(a);
			//希望输出a的文本信息，但输出的是完全限定名
			//console.writeLine的特点，会自动调用类中的ToString方法
			//a.ToString ();

			//如果不重写ToString 方法，则console.writeLine（a），则a对象会默认调用a.ToString（）方法，该方法默认打印出该对象的
			//（命名空间名.类名）类名

		}
	}
	//如果不声明父类，则父类默认是system.object 类
	class Animal {
		private string name;
		private int age;
		public Animal (string name,int age) {
			this.name = name;
			this.age = age;
		}
		//ToString 方法需要写 override重写，否则不会被调用
		public override string ToString(){

			return string.Format("name:{0},age{1}",name,age) ;
		}

	}

}
*/
/*
namespace demo7ToString{

	class MainClass{
		public static void Main(){
			Person p = new Person("ls",20,2018,5,30);
			Console.WriteLine(p);
		}
	}

	class Date{
		private int year;
		private int month;
		private int day;

		public Date(int year,int month,int day) {
			this.year = year;
			this.month = month;
			this.day = day;
		}
		public override string ToString ()
		{
			return string.Format ("year:{0},month:{1},day{2}",year,month,day);
		}
	}

	class Person{
		private string name;
		private int age;
		private Date date;

		public Person(string name,int age,int year,int month,int day) {
			this.name = name;
			this.age = age;
			this.date = new Date (year, month, day);
		}

		public override string ToString ()
		{
			//这里的date对象调用了date.ToString()方法，因此可以直接打印出date的信息
			return string.Format ("name:{0}, age:{1}, data:{2}",name,age,date);
		}
	}
}
*/
/*
namespace HomeWork{
	class MainClass{
		public static void Main() {
			IntSet a = new IntSet();
			a [0] = 0;
			a [1] = 1;
			a [2] = 4;
			a [3] = 9;
			a [4] = 16;
		}
	}
	class IntSet{
		private int [] array;
		public IntSet() {
			array = new int[5];
		}
		public int this[int index] {
			get{ return array[index];}
			set{ array[index] = value;}
		}
	}
}
*/
/*
namespace HomeWork2{
	class MainClass{
		public static void Main(){

		}
	}
	class Point{
		private int x;
		private int y;

		public Point(int x,int y) {
			this.x = x;
			this.y = y;
		}

		public double getDistance(Point a,Point b) {
			int d1 = a.x-b.x;
			int d2 = a.y-b.y;
			return Math.Sqrt (d1 * d1 + d2 * d2);
		}

		public Point getMinPoint(Point a,Point b) {
			int d1 = a.x+b.x;
			int d2 = a.y+b.y;
			Point p = new Point (d1/2, d2/2);
			return p;
		}

		public static Point operator+(Point a,Point b) {
			Point p = new Point(a.x+b.x,a.y+b.y);
			return p;
		}

		public static Point operator-(Point a, Point b) {
			return new Point(a.x-b.x,a.y-b.y);
		}

		public void print() {
			Console.WriteLine("x:{0},y{1}",x,y);
		}
	}
}
*/
/*
namespace HomeWork3{
	class MainClass{
		public static void Main() {
			Student s = new Student("ls",20);
			s.print();
		}
	}
	class Person{
		private string name;
		private int age;

		public Person(){}
		public Person(string name,int age) {
			this.name = name;
			this.age = age;
		}
		public void print(){
			Console.WriteLine("name:{0},age:{1}",name,age);
		}
		public override string ToString ()
		{
			return string.Format("name:{0},age:{1}",name,age);
		}
	}
	class Student:Person{
		private int id;

		public Student(string name,int age) : base(name,age){
			id++;
		}
		public void print() {
			Console.WriteLine("{0},id{1}",base.ToString(),id);
		}
	}
}
*/
/*
namespace HomeWork4{
	class MainClass{
		public static void Main() {
			Person p = new Student("ls",20);
			p.print();
		}
	}
	class Person{
		protected string name;
		protected int age;
		public Person (string name,int age){
			this.name = name;
			this.age = age;
		}
		public virtual void print() {
			Console.WriteLine("name{0},age{1}",name,age);
		}
	}
	class Student:Person{
		private int id;
		public Student(string name,int age):base(name,age) {
			id++;
		}
		public override void print(){
			Console.WriteLine("name:{0},age:{1},id:{2}",name,age,id);
		}
	}
}
*/

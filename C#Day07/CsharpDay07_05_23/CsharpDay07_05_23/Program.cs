using System;

/*
namespace CsharpDay07_05_23
{
	class MainClass
	{
		//一：函数重载，当函数名相同时，会根据函数的参数列表以及参数的类型进行调用适合的函数
		public static void Main (string[] args)
		{
			Console.WriteLine ("{0},{1}", Add (1, 2), Add (1.2, 2.324));
			Add (123, 1.213123123);
			Add (123.12, 123123.123);//如果传入的参数类型不正确，就不会调用
			MainClass mclass = new MainClass ();
			mclass.Add (1.2,1);//如果参数不对应会报错
		}

		public static int Add(int a, int b) {
			return a + b;
		}
		public static double Add(double a, double b){
			return a + b;
		} 
		public static void Add(int a, double b){
			Console.WriteLine ("{0} ", a + b);
		}

		public void Add(double a,int b){
			Console.WriteLine ("{0}", a + b);
		}
		public static void Add(double a, int b){   //如果定义了静态方法，就不能再定义完全一样的非静态方法了
			Console.WriteLine ("{0} ", a + b);		//同样，如果先定义了非静态方法，就不能再定义完全一样的静态方法了
		}

		//函数重载跟返回值类型没有关系
		//参数列表不同指：参数的个数，和参数的参数类型
	}
}
*/
/*
namespace demo1{
	class MainClass{
		public static void Main(String []args) {
			person p = new person ("ls",18,1805);//构造函数再初始化就会调用，如果构造函数写了有参，就一定要传入参数，
			//如果不写构造函数，系统会给我们一个默认为空的构造函数，如果写了，系统就不会提供了
			// = new person() 相当于就是调用构造函数
			Console.WriteLine ("{0},{1},{2}", p.Name, p.Age, p.Id);
			person p1 = new person ();
			Console.WriteLine ("{0},{1},{2}", p1.Name, p1.Age, p1.Id);
			person p2 = new person ("苍老师");
			Console.WriteLine ("{0},{1},{2}", p2.Name, p2.Age, p2.Id);
			person p3 = new person (20, 1805);
			Console.WriteLine ("{0},{1},{2}", p3.Name, p3.Age, p3.Id);
		}
	}

	class person{
		private string name;
		private int age;
		private int id;

		public int Age {
			get {
				return age;
			}
		}

		public int Id {
			get {
				return id;
			}
		}

		public string Name {
			get {
				return name;
			}
		}
	

		//1、构造函数组成： 修饰符 函数名 参数列表
		public person (String _name,int _age,int _id) {
			name = _name;
			age = _age;
			id = _id;
		}
		//2：无参构造函数
		public person(){
			name = "廖圣";
			age = 20;
			id = 1805;
		}
		//3：构造函数的重载
		public person(string _name) {

			name = _name;

			// 不写 id = 0 ; 那么调用id 还是默认为 0 ，并且可以打印出0,说明字段都是默认为0的。
		}
		//字符串默认为 ”“空 不是0
		public person(int _age,int _id){
			age = _age;
			id = _id;
		}



	}

}
*/
/*
namespace demo2{
	class MainClass{
		public static void Main(string []args){

			Person p = new Person ("ls",2018,5,23);
			p.print ();
			Date mdate = new Date (2018, 5, 23);
			Person p1 = new Person ("廖圣", mdate);
			p1.print ();
		}
	}
	class Date{
		private int year;
		private int month;
		private int day;
		public Date(int _year,int _month,int _day) {
			year = _year;
			month = _month;
			day = _day;
		}
		public int Year {
			get {
				return year;
			}
		}
		public int Day {
			get {
				return day;
			}
		}
		public int Month {
			get {
				return month;
			}
		}
		public void print(){
			Console.WriteLine ("{0},{1},{2}", year, month, day);
		}
		public int Age(){
			return year - 1998;
		}
	}
	class Person{
		private String name;
		private Date mdate;
		private int age;

		public Person(string _name,int _year,int _month,int _day){
			mdate = new Date (_year,_month, _day);
			name = _name;
			age = mdate.Age ();

		}

		public Person(string _name,Date _date) {
			mdate = _date;
			name = _name;
			age = mdate.Age ();
		}

		public void print(){
			Console.WriteLine ("{0},{1},{2},{3}", name, mdate.Year,mdate,age);
			mdate.print ();
		}

	}
}
*/
/*
namespace demo3{
	class MainClass{
		public static void Main(string [] args) {
			person p = new person ("ls", 19);
			p.printTotalPerson ();
			person p1 = new person ("ls1", 19);
			p1.printTotalPerson ();
			person p2 = new person ("ls2", 19);
			person p3 = new person ("ls3", 19);
			person p4 = new person ("ls4", 19);
			p.printTotalPerson ();
			Console.WriteLine (person.TotalPerson);

			//Console.WriteLine (p.TotalPerson); // 对象不能直接访问静态属性

		}
	}
	class person{
		private string name;
		private int age;
		private static int totalPerson;//标记一共有多少个Person对象
		public static int TotalPerson{
			get { return totalPerson; }
		} 
		//静态字段用静态构造函数初始化
		//静态构造函数的特点
		//1、没有访问权限修饰符
		//2、没有返回值
		//3、没有参数
		//4、不能重载
		//不能手动调用（只能自动调用一次）
		//静态构造函数调用时机
		//1、在第一次创建对象之前
		//2、在第一次访问静态成员之前 （静态成员：字段、属性、方法）
		static person(){
			totalPerson = 0;//给静态字段初始化
			Console.WriteLine ("static person " + totalPerson);
		}
		public person (string _name,int _age) {
			name = _name;
			age = _age;
			totalPerson++;
		}
		public void printTotalPerson(){
			Console.WriteLine (totalPerson);
		}
	}
}
*/
/*
namespace demo4{

	class Mainclass{
		public static void Main(){
			person p = new person ();
			Console.WriteLine ("hello world");//
		}//程序结束释放对象，调用析构函数
	}



	class person{
		//托管资源 ，程序结束对象自动释放
		private int age;
		//非托管资源，在析构函数中




		public person() {
			Console.WriteLine ("constructor");
		}
		//析构函数
		//调用时机：在对象释放时自动调用
		//释放对象中存在的非托管资源
		//特点：
		//1、没有访问修饰符也没有参数
		//2、不能重载，只能有一个
		//3、不能手动调用，只能自动调用
		//4、结构体中不能创建新析构函数
		~person() {
			Console.WriteLine ("destructor");
		}


	}
}
*/
/*
namespace demo5{

	class Person {
		private stirng name;
		private const  int age = 20;  //const 声明的字段不能加static 因为const 声明的默认为 static
		private readonly int id;	
		//private readonly int id；
		//readonly const 都表示字段只是只读字段
		//const声明的字段必须在声明时赋初始值
		//readonly 声明的字段可以在声明时初始化，也可以在构造函数中初始化

		public Person(){
			id = 12;
		}
			
		public int ID {
			get{ return id;}
		}
	}
}
*/
/*
namespace demo6{

	//单例模式
	//在程序指执行期间，指定某一个类只能创建一个对象
	//在类中提供一个全局调用的方法来获取这一个单例模式


	//单例模式实现流程	
	//1、在类外不可以通过构造函数创建对象
	//2、在类中创建一个全局唯一的person对象
	//3、提供一个供全局调用的方法来获取这一个单一实例
	//4、类中的静态成员在程序执行期间只存在一个，而且不会释放
	class MainClass {
		public static void Main() {
			person.getInstance ().print();
			person p1 = person.getInstance ();
			p1.print ();
			//值一样不变
		}
	}

	class person {

		//在类中的静态成员在程序执行期间只能存在一个
		private static person SingleInstance;
	
		private person() { //创建私有构造函数（不让系统再提供公有的构造函数了）
				
		}

		public static person getInstance() {
			if (SingleInstance == null) {
				SingleInstance = new person ();
			}
			return SingleInstance;
		}
		//方法二
		//静态字段的特点,只会执行一次
		//private static Person singleInstance = new person();
		// public static Person getInstance(){return singleInstance;}

		public void print(){
			Console.WriteLine ("diaoyong sigleInstance");
		}


	}
}
*/
/*
namespace demo7 {
	class MainClass{
		public static void Main(string []args) {
			person p1 = new person ("ls",20);
			p1.print ();
		}
	}
	class person{
		private string name;
		private int age;
		//谁（对象）调用构造函数，谁（对象）就是this
		public person(string name,int age) {
			this.name = name;
			this.age = age;
		}
		public void print(){
			Console.WriteLine ("name:{0},age:{1}", this.name, this.age);
		}

		public static void fun(){

			//Console.WriteLine (this.name);
			//静态方法不能调用this
			//静态方法由类调用，静态方法中的this没有意义
		}

	}
}
*/
/*
namespace demo8{
	class MainClass{

		public static void Main(string []args) {
			Vector v = new Vector (10);

			for (int i = 0; i < 10; i++)
				v [i] = int.Parse (Console.ReadLine ());
				
			for(int i = 0; i < 10; i++)
				Console.WriteLine("")
		}


	}


	class Person{ }
	class Vector{//容器
		private int n;
		private Person [] array;

		public Vector(int _n){
			//array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			array = new int[_n];
			n = _n;

		}

		//索引器：可以通过对象名直接加[下标]访问数组中的元素
		public Person this[int index] // 下标类型为 int
		{
			get { return array [index]; }
			set { array [index] = value; }
		}

		public int N
		{
			get { return n; }
			set { n = value; }
		}
			
	}

}
*/
namespace demo9{

	class MainClass{
		public static void Main(String [] args){
			Person p = new Person ("ls","jiangxi",1998,5,1);
			Person p1 = new Person ("ls1","jiangxi",1998,5,1);
			Person p2 = new Person ("ls2","jiangxi",1998,5,1);
			Person p3 = new Person ("ls3","jiangxi",1998,5,1);
			Person p4 = new Person ("ls4","jiangxi",1998,5,1);
			Person p5 = new Person ("ls5","jiangxi",1998,5,1);

			Vector v = new Vector (2);
			v.Add (p);
			v.Add (p1);
			v.Add (p2);
			v.Add (p3);
			v.Add (p4);
			v.Add (p5);
			Console.WriteLine (v.size ());
			for (int i = 0; i < v.size (); i++) {
				v [i].print ();
			}
			v.Remove ();
			v.Remove ();
			v.Remove ();
			v.Remove ();
			v.Remove ();
			Console.WriteLine (v.size ());
		}
	}

	class Data{

		private int year;
		private int month;
		private int day;

		public Data(){}
		public Data(int year,int month,int day) {
			this.year = year;
			this.month = month;
			this.day = day;
		}
	
		public void print() {
			Console.WriteLine ("yera = {0},month = {1},day = {2}", year, month, day);
		}

	}

	class Person {
		private string name;
		private string email_address;
		private Data birthdate;


		public Person(string name,string email_address,int year,int month,int day){
			this.name = name;
			this.email_address = email_address;
			this.birthdate = new Data (year, month, day);
		}

		public string Name{
			get{ return name; }
		}

		public string Email_address{
			get{ return email_address; }
		}


		public void print(){
			Console.WriteLine ("name = {0},email_address = {1}", name, email_address);
			birthdate.print ();
		}

	}

	class Vector{
		private Person [] array;
		private int maxSize;
		private int index;
		//private Person [] swap;


		public Vector (int maxSize) {
			this.maxSize = maxSize;
			this.array = new Person[maxSize];
		}

		public Person this[int index]{
			get {return array [index]; }
			set {array [index] = value;}
		}

		//添加操作
		public void Add(Person p) {
			if (index == maxSize) {
				maxSize *= 2;
				Console.WriteLine ("当前容器最大容量*2 :{0}", maxSize );

				Person[] swap = array;
				array = new Person[maxSize];
				for (int i = 0; i < index; i++)
					array [i] = swap [i];

			}

			array[index] = p;
			index++;
		}

		//删除操作
		public void Remove() {

			if (index * 2 == maxSize) {
				Console.WriteLine ("当前容量为最大容量一半，现在删除最大容量的一半：{0}", maxSize / 2);
				maxSize /= 2;
			}

			Person[] swap = array;
			array = new Person[maxSize];
			for (int i = 0; i < index; i++)
				array [i] = swap [i];

			Console.WriteLine ("删除末尾一个元素:{0}", array [index-1].Name);
			index--;
		}

		//返回容器大小
		public int size(){
			Console.WriteLine ("当前容量个数：{0} ", index);
			return index;
		}

	}

}




using System;
/*
namespace CsharpDay06_05_22
{
	class MainClass
	{
		//主类：包含Main函数的类叫做主类
		public static void Main (string[] args)
		{
			person p1 = new person ();//声明一个person类的对象p1 并且实例化
			p1.Name = "ls";
			p1.Age = 18;
			int b = p1.Age;//get方法
			Console.WriteLine ("name = {0},age = {1},age2 = {2}", p1.Name,p1.Age,b);


			

		}
	}

	//person类
	class person{
		//对私有字段的访问
		//属性的作用：访问私有字段
		//属性的本质：通过属性自动生成字段的set方法和get方法
		private string name;
		private int age;
		private int id;


		public void setName(String _name){
			name = _name;		
			}
		public void setAge(int _age){
			age = _age;
		}
		public void setId(int _id) {
			id = _id;
		}

		public String getName(){
			return name;
		}
		public int getAge(){
			return age;
		}
		public int getId(){
			return id;
		}

		//p1.Name = xx 是表示使用的是set方法
		//xx = p1.Name 是表示的get方法
		public string Name
		{
			get {return name;}
			set {name = value;}//value是隐藏的参数，将value值赋值给name
		}

		public int Age
		{
			get{return age; }
			set{age = value;}
		}
	}


	//声明类用class关键字
	//类是对一组对象进行的抽象的统一描述，在类中描述了所有该类对象的属性和行为
	//类和对象的关系：类是对象的抽象类型，对象是类的具体实例 
	//公有类：外部类可以直接访问成员
	//私有类：类外不可以直接访问
	//属性：成员变量 //也可说是字段
	//操作:对成员变量进行操作的函数，也可说是方法
	//
}
*/

/*
namespace demo1{
	class MainClass{

		public static void Main(){
			Date mdate = new Date ();
			mdate.Year = 2018;
			mdate.Mounth = 5;
			mdate.Day = 22;
			Console.WriteLine ("{0},{1},{2}", mdate.Year, mdate.Mounth, mdate.Day);
			string s = string.Format("{0},{1},{2}",mdate.Year,mdate.Mounth,mdate.Day);
			Console.WriteLine (s);
			mdate.print();
			Person p1 = new Person ();

			Date dateTest = new Date ();
			dateTest.Day = 22;

			p1.Name = "qwq";
			p1.Age = 18;
			p1.Id = 1805;
			p1.Birthday = dateTest;//将Date的对象mdae赋值给 p1的Date对象bitrhday，此时p1的date字段就包含了mdate的全部数据
									//假若date 没有全部赋值给p1 ,则会使用默认值 0 
			p1.print ();

		}
	}

	class Date{

		//字段
		private int year;
		private int mounth;
		private int day;
		//属性
		public int Year
		{
			get{return year;}
			set{year = value;}
		}

		public int Mounth
		{
			get{return mounth;}
			set{mounth = value;}
		}
		public int Day
		{
			get{return day;}
			set{day = value;}
		}

		public void print()
		{
			Console.WriteLine ("{0},{1},{2}", year, mounth,day);//在类里可以直接访问属性，但效率更低
		}
	}

	class Person
	{
		private Date birthday;//用Date日期对象表示生日，跟普通字段一样
		private string name;
		private int age;
		private int id;

		public Date Birthday 
		{
			get{ return birthday; }
			set{ birthday = value; }
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

		public void print(){
			Console.WriteLine ("{0},{1},{2}", name, age, id);					
			birthday.print ();
		}
	}
}
*/
/*
namespace demo2{
	class MainClass{
		public static void main(){

		}


	}

	class Point{
		private int x;
		private int y;

		//私有属性，在set或者get方法前加private
		//只读属性 私有set或者不写set是只读属性 （不能修改数据，只能查看使用数据）
		//只写属性 私有get或者不写get是只写属性  (只能修改数据，而不能使用，意义不大) 
		//但是不能两个都不写
		//属性名记得应首字母大写
		public int X
		{
			get{ return x;}
		}

		public int Y
		{
			get{ return y;}
			private set { y = value; }
		}
}
*/
/*
	namespace demo3{
		class MainClass{

		} 
		class person{
			private int age;
			private string name;

			//set的其他写法
			public int Age{
				set
				{
//					age = value;
//					if(age <= 0)
//					{
//					Console.WriteLine ("年龄设置错误");
//					age = 1;	 
//
//					}
				age = value <= 0 ?  1 : value;
				}
			}
		}
	}
	*/
/*
namespace demo4{
	class MainClass{

			public static void Main(string []args){
			
			Circle c1 = new Circle ();
			Circle c2 = new Circle ();
			c1.X = 0;
			c1.Y = 0;
			c1.Radius = 2;

			Console.WriteLine (c1.Area ());
			c2.Radius = 4;
			c2.X = 5;
			c2.Y = 5;
			
			Console.WriteLine ("两个圆的圆心距的距离是{0}", c1.distance (c2));

		}
	}


	class Circle
	{
			private int x;
			private int y;
			private int radius;

			public int X
			{
				get{ return x; }
				set{ x = value;}
			}
			public int Y
			{
				get{ return y;}
				set{ y = value; }
			}
			public int Radius
			{
				get{ return radius;}
				set{ radius = value;}
			}
			//求圆的面积
			public double Area()
			{
			return Math.PI * radius * radius;
			}
			//求两个圆的圆心距
			public double distance(Circle anotherCircle)
			{
				return Math.Sqrt((x - anotherCircle.x) * (x - anotherCircle.x) + (y - anotherCircle.y) * (y - anotherCircle.y));
			}

	}
		//面向对象：只需知道对象的方法的功能，干什么用的，怎么使用，拿来用就可以了，不需要知道也不需要关心具体的实现。

}
*/

namespace demo5{
		//static 成员的访问
		//1、类可以访问静态成员
		//2、类中的静态方法可以访问静态成员
		//3、类中的非静态方法可以访问静态成员
		//4、类的对象可以直接访问静态成员（前提该成员是公有的）
		//非static 成员的访问
		//1、类不可以直接访问非静态成员
		//2、类中的静态方法不可以直接访问非静态成员
		//3、只有具体对象和非静态方法可以访问非静态成员

		//静态只能访问静态，非静态可以访问静态的也可以访问非静态的
		class MainClass{
			public static void Main(string []args) {
			Student p1 = new Student ();
			Student p2 = new Student ();
			p1.Name = "ls";
			Student.Teacher = "苍老师";	
			Console.WriteLine ("{0},{1}",p1.Name,Student.Teacher);
			Student.printTeacher ();//静态方法可以访问静态成员
			p1.printTeach ();//非静态方法可以访问静态成员
				 
			}
		}
		class Student{
			private string name;//非静态成员属于某个具体对象
			private static string teacher;//静态成员属于整个类，如果修改了值，则其他的对象中调用的也会变化
			private static int roomNum; 

			public string Name
			{
				get{ return name; }
				set{ name = value;}
			}

			public static string Teacher
			{
				get{return teacher;}
				set{teacher = value; }
			}

			public static void printTeacher(){

			Console.WriteLine (teacher);

			}
			public void printTeach(){
			Console.WriteLine (teacher);
			}
		}
	}

	/*
	namespace demo6{
		class MainClass{
			public static void main(){
			Student p1 = new Student ();
				p1.Name = "Tom";
				p1.Id = 1805;
			Console.WriteLine ("{0},{0}", p1.Name, p1.Id);
			}
		}
		class Student{
			private string name;
			private int id;
			public string Name{
				get{ return name;}
				set { name = value;}
			}
			public int Id{
				get{ return id;}
				set{ id = value;}
			}
		}
	}
	*/
using System;

//结构体
			/* 1、结构体用 struct关键字定义  类用class 关键字
			 * 2、结构体中 不可以在声明时直接对字段初始化，而类可以
			 * 3、结构体中无论声明构造函数，默认构造函数都存在，而类一旦创建构造函数，系统就不给默认构造函数了
			 * 4、结构体中不能显示地声名无参构造函数，（因为方法写重了）
			 * 5、结构体中构造函数必修为所以字段初始化，（否则报错，（编译后报错））
			 * 6、创建结构体对象可以用new ，也可以不用new ，在后边赋值，但类在创建时必修new空间，才能进行赋值
			 * 7、结构体不能被继承，也不能使用abstract 或者sealed关键字；
			 * 8、结构体是值类型，类是引用类型
			 * 9、结构体不能定义析构函数
			 * 
			 */
/*
namespace CsharpDay08_5_24
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Person1 x1 = new Person1 (20);
			x1.age = 20;
			x1.id = 201805;
			Person1 x2 = x1;//引用类型赋值过程：x2 和 x1 都指向同一个对象
			x1.age = 100;//改变x1的值 x2的值也改变了
			x2.print ();

			Person2 y1 = new Person2 ();
			y1.age = 20;
			y1.id = 201802;
			Person2 y2 = y1;//值类型是赋值过程：s1 和s2 是两块不同的空间，两块空间之间是拷贝关系
			y2.age = 100;
			y1.print ();

			Person1 c1 = new Person1(22);
			Person2 s1 = new Person2();

			s1.print ();

			//Person1 c2;
			//c2.age = 12; ide 不报错，编译后报错，说显示没有分配内存 not use of assigned local value c2

			//6、值类型不用new 声明也可以在后面直接赋值，而类就不行了
			Person2 s2;
			s2.age = 18;


			Person2 s3 = new Person2 (20, 1805);
			s3.print ();



			//说明：结构体是值类型，直接包含它自己的数据，每个结构都保存自己的一份数据，修改每一个结构的数据都不会对其它结构的数据造成影响
			//

			//结构体与类的区别





		}
	}
	class Person1{
		public int age;
		public int id=1;

		public Person1(int age) {
			this.age =age;
		}

		public void print (){
			Console.WriteLine("{0},{1} ",age,id);
		}
	}
	struct Person2{
		public int age;
		public int id ;

		//2、结构体字段不能直接初始化
		//public int id = 5; 
		//9、结构体不能调用析构函数
//		~Person2(){
//
//		}
		//（2）出错，需要把字段都初始化
//		public Person2(int _age) {
//			age = _age;
//		}
//
		//4、不能显示地声明无参的默认构造函数
//		public Person2(){
//
//		}
//
		public Person2 (int age ,int id){
			this.age = age;
			this.id = id;
		}

		public void print (){
			Console.WriteLine("{0},{1}",age,id);
		}
	}


}
*/

namespace demo1{
	//运算符重载的定义
	class MainClass{
		public static void Main(){

			int a = 5;
			int b = 10;
			int c = a + b;
			//运算符是+, +两个操作数是a和b，是int类型

			double d = 5.5d;
			double e = 6.6d;
			double f = d + e;

			Point p1 = new Point (1, 2);
			Point p2 = new Point (4, 6);

			Point p3 = p1 + p2;
			//Point p4 = p1 + a;//没有写这种类型（point ，int）的运算符重载
			Console.WriteLine ("x = {0},y = {1}",p3.x,p3.y);
			//Console.WriteLine ("x = {0},y = 5", p4.x, p4.y);

			Console.WriteLine ("dis = {0}", p1 - p2);

			Point p5 = p1 + 5;
			Console.WriteLine ("x = {0},y = {1}", p5.x, p5.y);
			//系统提供的运算符只能对系统提供的基本数据类型进行操作
			//如果要操作自定义的类型，操作符不知道该如何操作
			//为什么要运算符重载：对自定义的类型进行操作需要重载运算符的算法
			//什么是运算符重载：运算符一样，操作数不一样
			//操作数的个数和原操作符个数一样，但类型必须至少有一个是自定义类型
			//重载后优先级不变
		}
	}
	struct Point{
		public int x;
		public int y;

		public Point(int x,int y) {
			this.x = x;
			this.y = y;
		}

		//重载的运算符要操作谁，就写在这个类的类中
		//重载后运算符的功能：让两个Point对象相加，得到一个新的Point
		//加法运算符名字：operator+
		//运算符的参数列表：（Point p1,Point p2） 
		//运算符的返回值类型：Point		
		
		public static Point operator+ (Point p1,Point p2){
			Point newPoint = new Point (p1.x + p2.x, p1.y + p2.y);
			return newPoint;
		}

		//重载后运算符的功能：让两个Point对象相减，得到两个点的距离
		//
		//跟具需要的功能返回需要计算得出的值
		//math.sqrt()返回的是double类型
		public static double operator-(Point p1,Point p2){
			int tx = (p1.x - p2.x) * (p1.x - p2.x);
			int ty = (p1.y - p2.y) * (p1.y - p2.y);
			double dis = Math.Sqrt (tx + ty);
			return dis;
		}

		//先想好思路，把思路弄清晰，再去写代码，如果写了一遍有错，改对了还不算学会，要一次写对才算是学会。
		//参数的顺序，和操作符的顺序要一样 如： a + p1 是错的
		public static Point operator+(Point p1,int a) {
			Point newpoint = new Point (p1.x + a, p1.y + a);
			return newpoint;
		}

		//可以再定义一个这样 a+p1 就可以正确运行了
		public static Point operator+(int a, Point p1) {
			Point newpoint = new Point (p1.x + a, p1.y + a);
			return newpoint;
		}



	}	


	
}


using System;

/*
 * 一：什么是事件？
 * 二：为什么需要事件？
 * 三：事件可以用来干什么？
 * 四：用到事件可以起到什么效果？
 * 五：什么时候用到事件？
 * 六：事件的关键字是什么，怎么用？
 * 七：事件的使用规则要求是什么？
 * 八：事件和委托的关系是什么？
 */
/*
namespace CSharpDay11_06_01
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// 事件使用过程
			// 1、定义委托类型
			// 2、定义事件
			// 3、订阅事件（给事件添加方法）
			// 4、发布事件(通过事件调用委托链中的方法)
			Birdegroom b = new Birdegroom ();
			Friend f1 = new Friend ();
			Friend f2 = new Friend ();
			Friend f3 = new Friend ();

			//订阅事件
			b.marryEvent += f1.receivedMessage;
			b.marryEvent += f2.receivedMessage;
			b.marryEvent += f3.receivedMessage;
			//发布事件 事件不能在外面被直接调用
			//b.marryEvent (); 不能在外面直接像委托那样直接调用，而是要在类内写一个共有方法，在方法里面调用事件，在类外用方法调用事件
			b.sendMessage ();

		}
	}
	//事件：两个角色，事件发布者和事件订阅者
	//新郎类，事件发布者
	class Birdegroom{
		//事件本质就是一个委托
		//声明事件的结构：修饰符 event 委托类型，事件变量
		//委托类型可以是自定义的委托类型，也可以是系统提供的委托类型

		//方法类型 和委托类型 的签名和 返回值类型要保持一致
		public delegate void MyDelegate();
		public event MyDelegate marryEvent; //通过event关键字声明事件  委托不用event定义委托变量

		public void sendMessage(){
			marryEvent();
		}
	}
	//朋友类，事件的订阅者
	class Friend{
		//收到事件做出的响应
		public void receivedMessage(){
			Console.WriteLine("收到，我会准时参加");
		}
	}
}
*/
/*
namespace demo1Test{

	class MainClass{
		public static void Main(){
			Psend p = new Psend();
			Qre q1 = new Qre ("ls");
			Qre q2 = new Qre ("ls2");
			p.m += q1.replay;
			p.m += q2.replay;
			p.sendMyEvent ();
		}
	}

	class Psend {
		public delegate void MyEvent();
		public event MyEvent m;

		public void sendMyEvent(){
			m();
		}

	}
	class Qre{
		private string name;
		public Qre(string name){
			this.name = name;
		}
		public void replay(){
			Console.WriteLine("{0}: 我收到了",name);
		}
	}
}
*/
/*
namespace demo2Test{
	class MainClass{
		public static void Main(){
			Friend f1 = new Friend ("f1");
			Friend f2 = new Friend ("f2");
			Friend f3 = new Friend ("f3");

			BirdeRoom b = new BirdeRoom ("ls");
			b.myevent += f1.friendReplay;
			b.myevent += f2.friendReplay;
			b.myevent += f3.friendReplay;
			b.sendEvent ();

		}
	}
	class Person{
		private string name;

		public Person(string name) {
			this.name = name;
		}
	
		public string Name {
			get {
				return name;
			}
		}
	}

	class Friend:Person{
		public Friend(string name):base(name){}

		public void friendReplay(string message) {
			Console.WriteLine("{0}: 我收到信息了,{1}",Name,message);
		}
	}

	class BirdeRoom:Person{
		public BirdeRoom(string name):base(name){}

		public delegate void MyEvent(string message);
		public event MyEvent myevent;

		public void sendEvent(){
			Console.WriteLine("{0}:各位，我要结婚了",Name); //{1}多写一个括号会报错
			myevent (" ：) ");
		}

	}

}
*/
/**/
namespace demo3系统提供的委托类型事件{
	class MainClass{
		public static void Main(){
			Friend f1 = new Friend ("f1");
			Friend f2 = new Friend ("f2");
			Friend f3 = new Friend ("f3");

			Bridegroom b = new Bridegroom ("ls");

			b.marryEvent += f1.receiveMessage;
			b.marryEvent += f2.receiveMessage;
			b.marryEvent += f3.receiveMessage;

			b.sendMessage ();
		}
	}
	class Person{
		private string name;

		public Person(string name) {
		this.name = name;
		}

		public string Name{
			get{return name;}
		}
	}
	class Friend:Person {
		public Friend(string name):base(name){}
		//2、订阅事件：写EventHandler类型的 方法（里面需要定义两个固定形参用来获取当前对象的信息，和委托类型EventArgs对象的信息）
		public void receiveMessage(object o,EventArgs e){
			//收到事件后，o就是事件发布者对象，就是新郎对象
			//2-1 获取当前发布者对象 （需要转换类型（由object类转换发布者类型））
			Bridegroom temp = (Bridegroom)o;
			//2-2 获取EventArgs子类的对象 （需要用传进来的形参对象转换成子类类型的对象）
			MyEventArgs tempe = (MyEventArgs)e;
			Console.WriteLine("{0}： 收到消息:){1},Time:{2},Address:{3}",this.Name,temp.Name,tempe.Time,tempe.Address);
			tempe.print ();
		}
	}
	class Bridegroom:Person{

		public Bridegroom(string name):base(name){}
		//使用系统自定义的事件类型

		//1、定义事件（发布者）：声明声明自定义的事件类型 名
		public EventHandler marryEvent;
		//3、发布事件
		public void sendMessage(){
			//object o = new object();
			//3-1 定义EventArgs的对象，并实例化，作为实参传入事件中
			EventArgs e = new MyEventArgs ("1805","eath");
			//第一个是 传入的是当前对象this()，也可以是其他类 类型的对象，第二个是传入的是 EventArgs的派生类的对象
			marryEvent (this, e);
		}
	}
	// EventArgs的派生类，在类中扩展两个字段，保存事件的内容（事件，地点）
	class MyEventArgs : EventArgs{
		private string time;
		private string address;
		public MyEventArgs (string time,string address) {
			this.time = time;
			this.address = address;
		}
		public string Time{
			get{return time; }
		}
		public string Address{
			get{return address; }
		}
		public void print(){
			Console.WriteLine("测试使用");
		}

	}
}

/*
namespace demo4EventHandlerTest{
	class MainClass {

	}

	class Person{
		private string name;
		public Person (string name){this.name = name;}
		public string Name{get{ return name;}}
	}
	class Psend:Person{
		public Psend(string name) :base (name){}
		public EventHandler MyEvent;

		public void pSend(object o, EventArgs e){
			Console.WriteLine("{0}:各位,我要结婚了",Name);
			MyEvent (this,e);
		}

	}
	class Qreceive:Person{
		public Qreceive(string name):base(name) {}

		public void qReceive(object o,EventArgs e) {
			Psend p = (Psend)o;
			Console.WriteLine("{0}: 我收到了,{1}",Name,p.Name);
		}
	}

	class MyEventArgs : EventArgs{
		private string time;
		private string address;

		public void 
	}
}
*/
/*
namespace demo5每周一考{
	class MainClass{
		public static void Main(){
			Person s = new Saber(10,10,10,10,20);
			Person m = new Mages (10, 20, 10, 10, 10);
			Person a = new Assassin (10, 10, 20, 10, 10);
			Person ar = new Archer (20, 10, 10, 10, 10);
			Person p = new Pastor (10, 10, 10, 20, 10);
			s.print ();
			s.aWakening ();
			s.print ();
			m.aWakening ();
			m.print ();
			a.aWakening ();
			a.print ();
			ar.aWakening ();
			ar.print ();
			p.aWakening ();
			p.print ();

		}
	}

	class Person{
		private int attack;
		private int magic;
		private int speed;
		private int blood;
		private int defense;

		public Person(int attack,int magic,int speed,int blood,int defense) {

			this.attack = attack;
			this.magic = magic;
			this.speed = speed;
			this.blood = blood;
			this.defense = defense;
		}
		public int Attack {
			get {
				return attack;
			}
			set { 
				attack = value;
			}
		}
		public int Magic {
			get {
				return magic;
			}
			set { 
				magic = value;
			}
		}
		public int Speed {
			get {
				return speed;
			}
			set { 
				speed = value;
			}
		}
		public int Blood {
			get {
				return blood;
			}
			set { 
				blood = value;
			}
		}
		public int Defense {
			get {
				return defense;
			}
			set { 
				defense = value;
			}
		}

		public virtual void aWakening(){
			Console.WriteLine("觉醒...");
		}
		public override string ToString ()
		{
			return string.Format ("Attack={0}, Magic={1}, Speed={2}, Blood={3}, Defense={4}", Attack, Magic, Speed, Blood, Defense);
		}
		public virtual void print(){
			Console.WriteLine(this.ToString());
		}
	}
		
	class Saber:Person{
		public Saber(int attack,int magic,int speed,int blood,int defense):base(attack,magic,speed,blood,defense){}
		public override void aWakening(){
			Console.WriteLine("Saber觉醒...");
			base.Defense *= 3;
			base.Attack *= 2;
			base.Magic *= 2;
			base.Speed *= 2;
			base.Blood *= 2;
		}
	}

	class Mages:Person{
		public Mages(int attack,int magic,int speed,int blood,int defense):base(attack,magic,speed,blood,defense){}
		public override void aWakening ()
		{
			Console.WriteLine("Mages觉醒...");
			base.Magic *= 3;
			base.Attack *= 2;
			base.Speed *= 2;
			base.Blood *= 2;
			base.Defense *= 2;
		}
	}

	class Assassin:Person{
		public Assassin(int attack,int magic,int speed,int blood,int defense):base(attack,magic,speed,blood,defense){}
		public override void aWakening ()
		{
			Console.WriteLine("Assassin觉醒...");
			base.Speed *= 3;
			base.Attack *= 2;
			base.Magic *= 2;
			base.Blood *= 2;
			base.Defense *= 2;
		}
	}

	class Archer:Person{
		public Archer(int attack,int magic,int speed,int blood,int defense):base(attack,magic,speed,blood,defense){}
		public override void aWakening ()
		{
			Console.WriteLine("Archer觉醒...");
			base.Attack *= 3;
			base.Magic *= 2;
			base.Speed *= 2;
			base.Blood *= 2;
			base.Defense *= 2;
		}
	}

	class Pastor:Person{
		public Pastor(int attack,int magic,int speed,int blood,int defense):base(attack,magic,speed,blood,defense){}
		public override void aWakening ()
		{
			Console.WriteLine("Pastor觉醒...");
			base.Blood *= 3;
			base.Attack *= 2;
			base.Magic *= 2;
			base.Speed *= 2;
			base.Defense *= 2;
		}
	}
}
*/
/*
namespace demo6test11{
	class MainClass{}
	abstract class Employes{
		private string name;
		private int salary;

		public Employes(string name,int salary){
			this.name = name;
			this.salary = salary;
		}

		public string Name{
			get{ return name;}
		}
		public int Salary{
			get{ return salary;}
		}

		public virtual void print(){
			Console.WriteLine("name:{0},salary:{1}",name,salary);
		}

	}
	interface IPrpmotable{
		void promots();
	}
	interface IGoodEmployee{
		void promots();
	}

	class Inttern:Employes{
		private int periodofinatemi;
		public Inttern(string name,int salary,int periodofinatemi):base(name,salary){
			this.periodofinatemi = periodofinatemi;
		}
		public override void print ()
		{
			base.print ();
		}
	}

	class Programmer:Employes,IPrpmotable{
		private int averageot;

		public Programmer(string name,int salary,int averageot):base(name,salary){
			this.averageot = averageot;
		}

		public int Averageot{
			get{ return averageot;}
		}

		public override void print ()
		{
			base.print ();
		}

		public void promots(){
			Console.WriteLine("我想晋升经理");
		}
	}

	class Manager:Employes,IPrpmotable,IGoodEmployee{
		private string secretaryName; 
		public Manager(string name,int salary,string secretaryName):base(name,salary){
			this.secretaryName = secretaryName;
		}
		void IPrpmotable.promots(){
			Console.WriteLine("我想晋升总经理");
		}
		void IGoodEmployee.promots(){
			Console.WriteLine("我想成员优先员工");
		}
		public string SecretaryName{
			get{return secretaryName;}
		}
	}

}
*/
/*
namespace demo7test11{
	class MainClass{
		public static void Main(){
			Buyer b = new Buyer("小明");

			b.buyMovieTicket ();
			b.buySellStock ();
			b.buyTicket ();
			b.allBuy ();
			b.buyMovieTicket ();
			b.buySellStock ();
			b.allBuy ();
		}
	}

	class Person{
		private string name;
		public Person(string name) {
			this.name = name;
		}
		public string Name{
			get{ return name;}
		}
	}
	class Payment{
	
		public void sellTicket(){
			Console.WriteLine("出售一张车票");
		}
		public void sellMovieTicket(){
			Console.WriteLine("出售一张电影票");
		}
		public void sellStock(){
			Console.WriteLine("出售xx股票");
		}

	}

	class Buyer:Person{
		public Buyer(string name):base(name) {

		}

		public delegate void Mydelegate();
		public Mydelegate m;

		public void buyTicket(){
			m+= new Payment().sellTicket;
		}
		public void buyMovieTicket(){
			m+= new Payment().sellMovieTicket;
		}
		public void buySellStock(){
			m+= new Payment().sellStock;
		}

		public void allBuy(){
			Console.WriteLine("{0} 在支付包里买票...",Name);
			m();
		}
	}
}
*/
/*
namespace demo8test12{
	class MainClass{
		public static void Main(){
			Psend p = new Psend();
			QRecive q = new QRecive ();
			p.delaverage ();
			Console.WriteLine (p.m (1, 2));
			p.deltwoSum ();
			Console.WriteLine (p.m (2, 3));
			p.delaverage ();
			Console.WriteLine (p.m (2, 3));
		}
	}

	class Psend{
		public delegate double Calculation(int a,int b);
		public Calculation m;
		public void deltwoSum(){
			m+=new QRecive().twoSum;
		}
		public void delaverage(){
			m+=new QRecive().average;
		}
		public void delRemove(){
			m-=new QRecive().twoSum;
			m -= new QRecive ().average;
		}
	}

	class QRecive{
		public double twoSum(int a,int b){
			return a+b;
		}
		public double average(int a,int b){
			return (a+b)/2.0;
		}
	}
}
*/
/*
namespace demo9 {
	namespace demo13EventHandlTest{

		class MainClass{
			public static void Main(){
				Mouse m = new Mouse ();
				m.runOut ();
			}
		}
		class Cat:EventArgs{
			private string name;
			private int age;

			public Cat(string name,int age){
				this.name = name;
				this.age = age;
			}

			public void waiting(){
				Console.WriteLine ("老鼠从洞里出来了，{0}扑了过去", name);
			}
			public void sleep(){
				Console.WriteLine ("老鼠进洞里了，{0}在洞边睡觉", name);
			}

		}
		class Mouse{
			public EventHandler  TestEvent(object o,EventArgs e);
			public void runOut(){
				Cat e = new Cat ("Tom",5);
				TestEvent += e.sleep;
				TestEvent += e.waiting;
				TestEvent (this,e);
			}
		}
	}
}
	*/

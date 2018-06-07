using System;

/*
namespace CsharpDay09_05_25
{

	class MainClass
	{
		public static void Main (string[] args)
		{
			Person p1 = new Person ("ls", 20);
			Person p2 = new Person ("cls", 3);
			Person p3 = new Person ("cls3", 230);
			Person p4 = new Person ("cls4", 310);
			Person p5 = new Person ("cls5", 21);
			Person p6 = new Person ("cls6", 12);
			Person p7 = new Person ("cls7", 32);
			Person p8 = new Person ("cls8", 40);
			if (p1 > p2) {
				Console.WriteLine ("p1的年龄更大");
			} else {
				Console.WriteLine ("p2的年龄更大");
			}

			//冒泡的两种格式 第一种：i判断< 有几个对象就写多少个（8），在j 判断 小于 就要 8 - i - 1
			//第二种， i判断有几个就写几个-1 （8-1 = 7） ，在j判断 就是  (7-i) 就可以
			Person [] array = {p1,p2,p3,p4,p5,p6,p7,p8};
			for (int i = 0; i < 8; i++) {

				for (int j = 0; j < 8 - i - 1; j++) {
					if (array [j] > array [j + 1]) {
						Person pt = array [j];
						array [j] = array [j + 1];
						array [j + 1] = pt;
					}
				}
			}

			for (int i = 0; i < 8; i++) {
				Console.WriteLine("{0} ,",array[i].Age);
			}
		}
	}

	class Person{
		private string name;
		private int age;

		public Person (string name,int age) {

			this.name = name;
			this.age = age;

		}

		public void print() {
			Console.WriteLine ("name:{0},age{1}", name, age);
		}

		public string Name{
			get {return name;}
		}
		public int Age{
			get{return age;}
		}
		//当定义大于号时，需要定义小于号 （大于小于成对出现）(== !=) (>= <=) 都要成对出现
		public static bool operator > (Person x,Person y) {
			return x.age > y.age;
		}

		public static bool operator < (Person x,Person y) {
			return x.age < y.age;
		}

	}

}
*/

/*
namespace 封装{

	class MainClass{
		public static void Main(string [] args) {
			Console.WriteLine ("qq");

		}



	}
}
*/
/*
namespace demo2{
	class MainClass{

		public static void Main(string [] args) {
			Horse h1 = new Horse ();
			//h内存中的结构 -------------|--------------
			//前半部分是父类，后半部分是自己的
			//继承下来之后就变成自己的成员了
			Horse h2 = new Horse ();

		}

	}

	class Animal{
		private string name;
		private int age;

		public string Name{
			get {return name;}
			set { name = value;}
		}

		public int Age{
			get { return age; }
			set { age = value; }
		}

		public void print(){
			Console.WriteLine ("name:{0},age:{1}",name,age);
		}

	}

	//继承：类名：父类名
	//可以复用父类中的代码，在子类中就不用重复定义了

	class Horse : Animal{

	}


}
*/
/*
namespace demo3{

	class MainClass{

		public static void Main(string [] args) {

			Student s = new Student ("ls",20,1805,"ycxy",217,90,100,120);
		
			s.print ();
			s.print2 ();


		}

	}



	class Person {

		private string name;
		private int age;
		protected int id;

		public Person(string name,int age,int id){
			Console.WriteLine ("Person construct");
			this.name = name;
			this.age = age;
			this.id = id;

		}

		public string Name{
			get{ return name;}
			set{ name = value;}
		}
		public int Age{
			get{ return age;}
			set{ age = value;}
		}
		public int Id{
			get{ return id;}
			set{ id = value;}
		}
		public void print(){
			Console.WriteLine ("person name:{0},age:{1},id:{2}", name, age, id);
		}
	}

	//继承的作用：1、代码复用，2、体现两个类是IS-A的关系（student is a person）000000
	class Student:Person{
		private string school;
		private int num;
		private double chinese;
		private double math;
		private double english;

		//子类的构造顺序
		//在构造子类对象时，要先调用父类的构造函数构造父类那一部分成员，再调用
		//子类自己的构造函数构造子类扩展的成员
		//子类构造函数如果不手动调用父类的构造函数，会自动调用父类的无参构造函数
		//子类构造函数一定要写父类的参数，并且使用base()调用父类的构造参数

		//person [] array = new person[10]; array里面可以放 student对象， 因为 student is a person
		//但不能反过来，student[] array  里 放 person 对象， 因为 perosn 不是 一个 student 


		public Student (string name,int id,int age,string school,int num,double chinese,double math,double english):base(name,id,age)
		{

			Console.WriteLine ("Student Construct");
			this.school = school;
			this.num = num;
			this.chinese = chinese;
			this.math = math;
			this.english = english;
		}


		public string School
		{
			get { return school; }
			set { school = value; }
		}
		public int Num
		{
			get { return num; }
			set { num = value; }
		}
		public double Chinese
		{
			get { return chinese; }
			set { chinese = value; }
		}
		public double Math
		{
			get { return math; }
			set { math = value; }
		}
		public double English
		{
			get { return english; }
			set { english = value; }
		}

		//父类中私有成员在子类中访问的问题
		//父类中的私有成员在子类中不能直接访问，父类那一部分成员的封装性依然存在
		//如果想在子类中访问父类的成员，又不想父类的成员在类外被访问，需要把
		//父类的成员设置为protected 受保护成员
		//protected声明的成员可以被子类访问,不能被类外访问
		public void print2(){
			print();
			Console.WriteLine ("School:{0},Num:{1},Chinese:{2},Math:{3},:English{4}",school,num,chinese,math,english);
		}
	}
}
*/
/*
namespace demo4{

	class studentSet{
		private student[] array;


	}

	class student{

		private string name;
		private int id;
		private int a;
		private int b;
		private int c;
		private int ave;

	}
}

*/

/*
namespace demo5{
	class MainClass{

		public static Random r = new Random ();

		public static void Main(string [] args) {

			//1、定义一些固定（常量）的投票者
			Voter v1 = new Voter("John", 20, 6000,1);
			Voter v2 = new Voter("Frank", 26, 30000,2);
			Voter v3 = new Voter("Anna", 20, 199600,1);
			Voter v4 = new Voter("James", 67, 9600,2);
			Voter v5 = new Voter("Jane1", 40, 29600,3);
			Voter v6 = new Voter("Jane2", 42, 39600,1);
			Voter v7 = new Voter("Jane3", 50, 49600,3);
			Voter v8 = new Voter("Jane4", 60, 112345,3);
			//2、定义三个候选人
			Candidate c1 = new Candidate("number1_Jan", 67, 9600,8);
			Candidate c2 = new Candidate("number2_Feb", 40, 29600,8);
			Candidate c3 = new Candidate("number3_Mar", 40, 29600,8);

			//Console.WriteLine (person.Persons());
			//Console.WriteLine (v2.Id); id 打印不出来，是因为属性写错了

			//添加投票者 
			Voterset v = new Voterset (10);
			v.Add (v1);
			v.Add(v2);
			v.Add (v3);
			v.Add (v4);
			v.Add (v5);
			v.Add (v6);
			v.Add (v7);
			v.Add (v8);
			//添加候选人 
			CandidateSet c = new CandidateSet (5);
			c.addCandidates (c1);
			c.addCandidates (c2);
			c.addCandidates (c3);

			//如果投票者被正确插入到列表中，输出投票者的人数
			int numVoters = Voter.Voters ();
			Console.WriteLine ("number of voters = " + numVoters);
			for (int i = 0; i < numVoters; i++) {
				Voter voter = (Voter)v[i];
				voter.print ();
			}

			//允许投票者进行投票
			Console.WriteLine ("voting ");
			for (int i = 0; i < numVoters; i++) {
				Voter sv = (Voter)v [i];
				//选择一个候选人
				Candidate choseCandidate = (Candidate)sv.SelectCadidate (c);
				sv.Vote (choseCandidate);
			}

			//判断是否所有的投票者都进行了投票
			if (v.size () != Voter.Voters ()) {
				Console.WriteLine ("Not all voters voted !!!!");
			} else {
				Console.WriteLine ("Success: 100% voted ");
			}

			//选择领导
			Candidate winner = (Candidate)( c[0]);
			for (int i = 0; i < c.CandidateSize (); i++) {
				if (winner < (Candidate)c [i]) {
					winner = c [i];
				}
			}

			winner.print2 ();

			Console.WriteLine ("Select Winner Success");
		}
	}

	//人的基本类
	class person{
		private string name;
		private int age;
		private int salary;
		private int id;

		private static int totalPersons;

		public person(string name,int age,int salary){
			this.name = name;
			this.age = age;
			this.salary = salary;
			totalPersons++;
			id = totalPersons;
		}

		static person(){
			totalPersons = 0;
		}

		public string Name{
			get{ return name; }
		}

		public int Id{
			get { return id; }
		}

		public int SetAge{
			get{ return age; }
			set{age = value;}
		}
		public int SetSalary{
			get{ return SetSalary; }
			set{ SetSalary = value; }
		}

		public static int Persons(){
			return totalPersons;
		}
			
	}

	//投票者 类
	class Voter : person{
		private int polingStation;
		private static int totalNumVoters;
		public Voter(string name,int age,int salary,int polingStation):base(name,age,salary){
			this.polingStation = polingStation;
			totalNumVoters++;
		}
		public void print() {
			// id 没有值，导致打印不出来
			Console.WriteLine ("Voter name:{0} , polingStation:{1}, id:{2} ", Name,polingStation,Id);
		}

		//返回投票人总数
		public static int Voters(){
			return totalNumVoters;
		}
		//随机选择一个候选人，返回这个候选人
		public Candidate SelectCadidate(CandidateSet candidates) {
			int x = MainClass.r.Next (candidates.CandidateSize ());
			Console.WriteLine ("candidate name {0}, x = {1}", candidates[x].Name, x);
			return candidates [x];
		}
		//投票人
		public void Vote(Candidate c) {
			c.AddVoter (this);
		}

	}

	//候选人 类
	class Candidate : person{
		//投票给候选人的对象数组
		private Voter [] voterSet;
		//一个候选人的投票者数
		private int votersNum;
		//获得全部候选者的投票总数
		private static int numCandidates;

		//maxSize
		private int maxSize;

		public Candidate(string name,int age,int salary,int maxSize):base(name,age,salary){
			numCandidates++;
			this.maxSize = maxSize;
			voterSet = new Voter[maxSize];
		}

		public Voter this[int index] {
			get{ return voterSet[index];}
			set{ voterSet [index] = value;}
		}

		//返回投票数
		public int GetVotesNum(){
			return votersNum;
		}

		//添加一个投票者到候选人
		public void AddVoter(Voter aVoter) {
			if (votersNum >= maxSize) {
				maxSize *= 2;
				Console.WriteLine ("当前容器最大容量*2 :{0}", maxSize );

				Voter[] swap = voterSet;
				this.voterSet = new Voter[maxSize];
				for (int i = 0; i < votersNum; i++) {
					voterSet[i] = swap [i];
				}
			}
			voterSet[votersNum] = aVoter;
			votersNum++;
		}

		//打印投给候选人的投票者名
		public void print2() {
			if(votersNum == 0) {
				Console.WriteLine ("There are no voters !!!!");
				return;
			}
			Console.WriteLine ("Candidate Name : {0},ID:{1},VotersNum:{2}", this.Name,this.Id,this.votersNum);
			for (int i = 0; i < votersNum; i++) {
				Console.Write ("voter:ID: {0} name: {1} \n",voterSet[i].Id,voterSet[i].Name);
			}
			Console.WriteLine ();
		}

		//获得投票者们的平局年龄
		public int GetAverageVotersAge() {
			int sum = 0;
			for (int i = 0; i < votersNum; i++) {
				sum += voterSet [i].SetAge;
			}
			return sum/votersNum;
		}
		//获得投票者们的平局薪水
		public int GetAverageVotersSalary() {
			int sum = 0;
			for (int i = 0; i < votersNum; i++) {
				sum += voterSet[i].SetSalary;
			}
			return sum / votersNum;
		}

		public static bool operator<(Candidate A ,Candidate B) {
			return A.votersNum < B.votersNum;
		} 

		public static bool operator>(Candidate A ,Candidate B) {
			return A.votersNum > B.votersNum;
		}

		//返回获选人总数
		public static int candidates(){
			return numCandidates;
		}
	}

	//候选人容器类
	class CandidateSet{

		private Candidate[] Candidates;
		private int CandidateNums;

		public CandidateSet(int n) {
			Candidates = new Candidate[n];
		}

		public Candidate this[int index]{
			get{ return Candidates [index];}
			set{Candidates[index] = value;}
		}
		//添加候选人（固定个数、注意是否越界）	
		public void addCandidates(Candidate c) {
			Candidates [CandidateNums] = c;
			CandidateNums++;
		}

		public int CandidateSize() {
			return CandidateNums;
		}
	}

	//投票者容器类
	class Voterset{
		private Voter [] array;
		private int maxSize;
		private int index;

		public Voterset (int maxSize) {
			this.maxSize = maxSize;
			this.array = new Voter[maxSize];
		}
		public Voter this[int index]{
			get {return array [index]; }
			set {array [index] = value;}
		}

		//添加操作
		public void Add(Voter p) {
			if (index == maxSize) {
				maxSize *= 2;
				Console.WriteLine ("当前容器最大容量*2 :{0}", maxSize );

				Voter[] swap = array;
				this.array = new Voter[maxSize];
				for (int i = 0; i < index; i++) {
					array[i] = swap [i];
				}
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
			Voter [] swap = array;
			this.array = new Voter[maxSize];
			for (int i = 0; i < index; i++) {
				array[i] = swap [i];
			}
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
*/

/*
namespace demo6{

	class MainClass{

		public static Random r = new Random ();

		public static void Main(string [] args) {

			//1、定义一些固定（常量）的投票者
			Voter v1 = new Voter("John", 20, 6000,1);
			Voter v2 = new Voter("Frank", 26, 30000,2);
			Voter v3 = new Voter("Anna", 20, 199600,1);
			Voter v4 = new Voter("James", 67, 9600,2);
			Voter v5 = new Voter("Jane1", 40, 29600,3);
			Voter v6 = new Voter("Jane2", 42, 39600,1);
			Voter v7 = new Voter("Jane3", 50, 49600,3);
			Voter v8 = new Voter("Jane4", 60, 112345,3);
			//2、定义三个候选人
			Candidate c1 = new Candidate("number1_Jan", 67, 9600,8);
			Candidate c2 = new Candidate("number2_Feb", 40, 29600,8);
			Candidate c3 = new Candidate("number3_Mar", 40, 29600,8);

			//Console.WriteLine (person.Persons());
			//Console.WriteLine (v2.Id); id 打印不出来，是因为属性写错了

			//添加投票者 
			PersonSet v = new PersonSet (10);
			v.Add (v1);
			v.Add (v2);
			v.Add (v3);
			v.Add (v4);
			v.Add (v5);
			v.Add (v6);
			v.Add (v7);
			v.Add (v8);
			//添加候选人 
			PersonSet c = new PersonSet (5);
			c.Add (c1);
			c.Add (c2);
			c.Add (c3);

			//如果投票者被正确插入到列表中，输出投票者的人数
			int numVoters = v.size();
			Console.WriteLine ("number of voters = " + numVoters);
			for (int i = 0; i < numVoters; i++) {
				Voter voter = (Voter)v[i];
				voter.print ();
			}

			//允许投票者进行投票
			Console.WriteLine ("voting ");
			for (int i = 0; i < numVoters; i++) {
				Voter sv = (Voter)v[i];
				//选择一个候选人
				Candidate choseCandidate = (Candidate)sv.SelectCadidate (c);
				sv.Vote (choseCandidate);
			}

			//判断是否所有的投票者都进行了投票
			if (v.size () != Voter.Voters ()) {
				Console.WriteLine ("Not all voters voted !!!!");
			} else {
				Console.WriteLine ("Success: 100% voted ");
			}

			//选择领导
			Candidate winner = (Candidate)(c[0]);
			for (int i = 0; i < c.size (); i++) {
				if (winner < (Candidate)c[i]) {
					winner =(Candidate) c[i];
				}
			}

			winner.print2 ();

			Console.WriteLine ("Select Winner Success");
			Console.WriteLine ("投票者平均年龄：{0}", winner.GetAverageVotersAge ());
			Console.WriteLine ("投票者平均薪水: {0} ",(int)winner.GetAverageVotersSalary());


		}
	}

	//人的基本类
	class person{
		private string name;
		private int age;
		private double salary;
		private int id;

		private static int totalPersons;

		public person(string name,int age,double salary){
			this.name = name;
			this.age = age;
			this.salary = salary;
			totalPersons++;
			id = totalPersons;
		}

		static person(){
			totalPersons = 0;
		}

		public string Name{
			get{ return name; }
		}

		public int Id{
			get { return id; }
		}

		public int SetAge{
			get{ return age; }
			set{age = value;}
		}
		public double SetSalary{
			get{ return salary; }
			set{ salary = value; }
		}

		public static int Persons(){
			return totalPersons;
		}

	}

	//投票者 类
	class Voter : person{
		private int polingStation;
		private static int totalNumVoters;
		public Voter(string name,int age,double salary,int polingStation):base(name,age,salary){
			this.polingStation = polingStation;
			totalNumVoters++;
		}
		public void print() {
			Console.WriteLine ("Voter name:{0} , polingStation:{1}, id:{2} ", Name,polingStation,Id);
		}

		//返回投票人总数
		public static int Voters(){
			return totalNumVoters;
		}
		//随机选择一个候选人，返回这个候选人
		public Candidate SelectCadidate(PersonSet candidates) {
			int x = MainClass.r.Next (candidates.size ());
			Console.WriteLine ("candidate name {0}, x = {1}", candidates[x].Name, x);
			return (Candidate)candidates[x];
		}
		//投票人
		public void Vote(Candidate c) {
			c.AddVoter (this);
		}

	}

	//候选人 类
	class Candidate : person{
		//投票给候选人的对象数组
		private PersonSet  voterSet;
		//一个候选人的投票者数
		private int votersNum;
		//获得全部候选者总数
		private static int numCandidates;

		public Candidate(string name,int age,double salary,int maxSize):base(name,age,salary){
			numCandidates++;
			voterSet = new PersonSet(10);

		}

		//添加投票到一个候选人
		public void AddVoter(Voter v) {
			voterSet.Add (v);
			votersNum++;
		}
			
		//返回投票数
		public int GetVotesNum(){
			return votersNum;
		}
		//打印投给候选人的投票者名
		public void print2() {
			if(votersNum == 0) {
				Console.WriteLine ("There are no voters !!!!");
				return;
			}
			Console.WriteLine ("Candidate Name : {0},ID:{1},VotersNum:{2}", this.Name,this.Id,this.votersNum);
			for (int i = 0; i < votersNum; i++) {
				Console.Write ("voter:ID: {0} name: {1} \n",voterSet[i].Id,voterSet[i].Name);
			}
			Console.WriteLine ();
		}

		//获得投票者们的平均年龄
		public int GetAverageVotersAge() {
			int sum = 0;
			for (int i = 0; i < votersNum; i++) {
				sum += voterSet [i].SetAge;
			}
			return sum/votersNum;
		}
		//获得投票者们的平均薪水
		public double GetAverageVotersSalary() {
			double sum = 0;
			for (int i = 0; i < votersNum; i++) {
				sum += voterSet[i].SetSalary;
			}
			return sum/votersNum;
		}

		public static bool operator<(Candidate A ,Candidate B) {
			return A.votersNum < B.votersNum;
		} 

		public static bool operator>(Candidate A ,Candidate B) {
			return A.votersNum > B.votersNum;
		}
			
	}

	//容器类
	class PersonSet{
		private person [] array;
		private int maxSize;
		private int index;

		public PersonSet () {
			this.maxSize = 1;
			this.array = new person[1];
		}
			
		public PersonSet (int maxSize) {
			this.maxSize = maxSize;
			this.array = new person[maxSize];
		}

		public person this[int index]{
			get {return array [index]; }
			set {array [index] = value;}
		}

		//添加操作
		public void Add(person p) {
			if (index == maxSize) {
				maxSize *= 2;
				Console.WriteLine ("当前容器最大容量*2 :{0}", maxSize );

				person[] swap = array;
				this.array = new person[maxSize];
				for (int i = 0; i < index; i++) {
					array[i] = swap [i];
				}
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
			person [] swap = array;
			this.array = new person[maxSize];
			for (int i = 0; i < index; i++) {
				array[i] = swap[i];
			}
			Console.WriteLine ("删除末尾一个元素:{0}", array [index-1].Name);
			index--;
		}
		//返回容器大小
		public int size(){
			//Console.WriteLine ("当前容量个数：{0} ", index);
			return index;
		}
	}
}
*/

namespace demo7{
	class MainClass{

		public static void Main(String [] args){
			Random r = new Random ();	//new Random()为随机数种子 ()里面不写默认为系统时间随机数种子
			///random()由用的是默认系统时间，当在循环里面，电脑运算速度快，获得的随机数种子几乎相同，参数的值也几乎相同
			//也就是说，只需要一个随机数种子，然后只调用他，不要再生成新的随机数种子了
			for (int j = 0; j < 10; j++) {
				Random r2 = new Random ();
				int i = r.Next (10);
				int i2 = r2.Next (10);
				Console.WriteLine (i+" "+i2);
			}
		}
	}
}





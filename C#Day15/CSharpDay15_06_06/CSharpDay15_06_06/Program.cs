using System;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 第17天_泛型高级
/// 疑问：
/// 什么是约束？ 泛型高级讲了什么
/// 约束和泛型的关系？
/// 有多少中约束方式？
/// 为什么需要约束（好处、优点、作用）
/// 什么时候要到约束
/// 约束的使用规则、方法？
/// 
/// </summary>
/*//值类型约束，引用类型约束
namespace CSharpDay15_06_06
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			fun<int> (5);//调用泛型方法，指定泛型参数的类型是int
			//fun<string> ("hello");//泛型参数被约束为值类型,字符串是引用类型，所以编译报错
			fun<double>(5.5f);
			fun1<string> ("hi");
		}

		//泛型参数T没有加约束时，T的类型可以是任意类型
		//可以通过where关键字给T加约束，即缩小T的类型范围
		//表示T的类型范围必须是值类型 （struct 表示值类型）
		public static void fun<T>(T x)where T:struct {
			Console.WriteLine (x);
		}
		//where T: class 表示T的类型必须是引用类型
		public static void fun1<T>(T x)where T:class {
			Console.WriteLine (x);
		}


	}
	//类名后加约束
	class ABC<T> where T: struct {
		private T[] array;
	}
}
*/
/*
namespace demo1基类约束{
	class MainClass{
		public static void Main(){
			Vector<Abc> v = new Vector<Abc> ();
			//Vector<Bcd> v1 = new Vector<Bcd> (); Bcd是Abc的子类则可以成功运行，,但如果Bcd是Abc的父类，依然会报错
			Bcd b1 =  new Bcd ();
			Bcd b2 =  new Bcd ();
			Bcd b3 =  new Bcd ();
			Bcd b4 =  new Bcd ();
			Bcd b5 =  new Bcd ();
			v [0] = b1;
			v [1] = b2;
			v [2] = b3;
			v [3] = b4;
			v [4] = b5;
			v.print ();


		}
	}


	//基类约束
	class Abc{
		public virtual void fun(){
			Console.WriteLine ("fun in Abc");
		}
	}
	class Bcd:Abc{
		public override void fun ()
		{
			Console.WriteLine ("fun in Bcd");
		}
	}
	//基类约束
	//泛型约束中约束了T的类型必须是Abc的类或者Abc的子类
	//然后T对象可以直接访问指定了的类中的公有成员，父类中的公有成员，但不能访问子类的公有成员
	class Vector<T> where T: Abc{
		private T[] array;
		public Vector(){
			array = new T[5];
		}

		public T this[int index] {
			get{return array [index];}
			set{ array [index] = value;}
		}



		public void print(){
			for (int i = 0; i < 5; i++) {
				//给T缩小了范围，虽然还不能确定T的具体类型，
				//但是我们知道T的类型要么是Abc类型，要么是Abc子类类型
				//不管是Abc类型还是Abc子类类型都可以访问Abc类中的公有成员

				array [i].fun ();
				//同时能访问的方法一定是可以确定的，也就是说其父类类型是不能访问到子类的方法的
				//而子类是一定可以访问到父类方法，和子类方法的。
			}
		}

	}
}
*/
/*
namespace demo2接口约束{
	class MainClass{
		public static void Main(){
			Person p = new Person ();
			Abc<Person> abc = new Abc<Person> (p);

			Animal a = new Animal ();
			Abc<Animal> abc1 = new Abc<Animal> (a);
			abc.X.speak ();
			abc1.X.speak ();

		}
	}

	interface ISpeak{
		void speak();
	}
		
	//接口约束：约束T的类型必须继承指定的接口
	class Abc<T>where T: ISpeak
	{
		private T x;

		public T X{
			get{ return x;}
		}

		public Abc(T x) {
			this.x = x;
		}
		public void fun(){
			//虽然不确定x的具体类型，但知道x肯定继承了ISpeak接口，所以可以直接调用接口中的方法
			x.speak ();
		}
	}
	class Person:ISpeak{
		public void speak(){
			Console.WriteLine ("Person speak");
		}
	}
	class Animal:ISpeak{
		public void speak(){
			Console.WriteLine ("Animal speak");
		}
	}
}
*/
/*
namespace demo3构造函数约束{
	//疑问，是否可以约束成带参构造函数
	class MainClass{
		public static void Main(){
			Person p = new Person ();
			Animal a = new Animal ("熊猫");
			Abc<Person> abc = new Abc<Person> ();
			//由于该对象在构造函数中的泛型类型只能使用无参构造函数，Animal只有有参构造函数，所以不满足条件，编译保错
			//Abc<Animal> abc1 = new Abc<Animal> ();
		}
	}

	//构造函数约束：约束T的类型中必须存在一个无参构造函数 where T : new()
	//可以通过无参构造函数初始化T对象
	class Abc<T> where T : new(){
		private T x;
		public Abc(){
			//不能直接new 一个泛型类型的构造函数
			x = new T ();
		}
	}

	class Person{

	}
	class Animal{
		private string name;
		public Animal(string name) {
			this.name = name;
		}
	}


}
*/
/*
namespace demo4组合约束{
	class MainClass{
		public static void Main(){

		}
	}

	class Person{}
	interface ISpeak{}
	//需要同时满足这些约束，所以范围更小了，如下面，类型参数必须满足是个基类(Person)，必须继承哪个接口(ISpeak)，且必须有无参构造函数(new Person(){...})。
	//语法规则
	//1、值类型、基类约束不能和引用类型一起作为约束（不能同时存在，只能使用一个），放在最前边
	//2、new()约束必须放在最后边
	//3、接口约束在new（）约束的前边，在（值类型，引用类型，基类型约束）的后边
	//4、接口约束可以存在多个，但是基类约束只能有一个
	//5、new（）约束不可以和值类型约束一起使用
	class Abc<T> where T: Person,ISpeak,new(){

	}
}
*/
/*
namespace demo5泛型委托{
	class MainClass{
		public delegate X MyDelegate<T,X>(T a);

		public static void Main(){
			// MyDelegate<string,void> d1 += fun1; 不能用void 作为泛型参数
			MyDelegate <string,string> d2 = fun1;  // 且在声明初始化时不能直接 +=
			MyDelegate<int,int> d3 = fun2;
			Console.WriteLine (d2 ("qqq"));
			Console.WriteLine (d3 (5));//5
		}
		public static string fun1(string a){
			Console.WriteLine ("fun1");
			return a;
		}
		public static int fun2(int a) {
			return a++;//注意这里先返回a的值了
		}
	}
}
*/
/*
namespace demo6泛型接口{
	class MainClass{
		public static void Main(){
			IAbc<int> iabc = new Abc ();
			iabc.fun (5);
			IAbc<string> iabc1 = new Bcd<string> ();
			iabc1.fun ("QWQ");
			IAbc<int> iabc2 = new Cde<string> ();
			iabc2.fun (5);
		}
	}
	//在接口名后边加<T>
	interface IAbc<T>{
		void fun (T a);
		//T fun2(T a);
	}
	//泛型接口中的泛型参数应该在继承该接口时确定泛型参数的类型		<T>：泛型参数  确定具体的泛型参数的类型<int>
	class Abc:IAbc<int> {
		public void fun(int a) {
			Console.WriteLine (a);
		}
	}
	//泛型类继承泛型接口
	// 1: 泛型接口中的泛型参数可以直接使用泛型类的泛型参数
	class Bcd<V> : IAbc <V> {
		//泛型接口中的泛型参数T被指定成泛型类的泛型参数V了
		public void fun(V a) {
			Console.WriteLine ("qwq"+a);
		}
	}
	// 2: 可以使用泛型类中的泛型参数，也可以自己指定泛型参数
	class Cde<Z>:IAbc<int>{
		public void fun(int a){
			Console.WriteLine ("Cde fun "+a);
		}
	}
}
*/
/*
namespace demo7泛型类泛型接口泛型方法之间泛型参数的关系{
	class MainClass{
		public static void Main(){
			//泛型类在实例化时，确定泛型参数
			Abc<int> abc = new Abc<int>();
			//泛型方法在调用时确定泛型参数
			abc.fun<string> (5,"qwq");


		}
	}

	interface Iabc<A>{}

	class Abc<B>:Iabc<B>{
		//泛型类中继承泛型接口后，接口中的泛型参数与泛型类的泛型参数无关了（需要使用就要确定参数类型，或者设置成和泛型类一样的泛型参数名）
		//但是泛型类在指定接口的泛型参数应该和自己的泛型参数一样，也可以直接使用确定参数类型
		//注意泛型方法的泛型参数和泛型类的泛型参数是不同的（没有关系），但是泛型参数名是可以相同的
		private B a;

		public void fun<C>(B x,C c) {
			//当然泛型方法里还是可以使用泛型类的泛型参数
			Console.WriteLine ("{0},{1}",x,c);
		}
	}
}
*/
/*
namespace demo8泛型重载{
	class MainClass{
		public static void Main(){
			fun<int,string> (2, "a");
			fun<int,string> ("a", 2);
			//当两个泛型参数一样，系统就不知道调用哪个，会编译出错 fun<int,int> (2, 3);
			fun<int> (2, 3);
		}

		public static void fun<T,V>(T a,V b){
			Console.WriteLine ("fun1");
		}
		public static void fun<T,V>(V a,T b){
			Console.WriteLine ("fun2");
		}
		public static void fun<T>(T a, T b){
			Console.WriteLine ("fun3");
		}

	}
}
*/
/*
namespace demo9泛型调用规则{
	class MainClass{
		public static void Main(){
			Test<int , string> t = new Test<int, string> ();
			t.fun (1, "a");
			t.fun (1, 2);
			t.fun ("a", 3);
		}
	}
	//先调用非泛型方法，
	//如果非泛型方法不匹配，在两个泛型方法中不知道掉哪一个就会编译出现错误
	class Test<T,V>{
		public void fun(T t, V v) {
			Console.WriteLine ("fun1:{0},{1}", t, v);
		}
		public void fun(V v, T t) {
			Console.WriteLine ("fun2:{0},{1}", v, t);
		}
		public void fun(int a,int b){
			Console.WriteLine ("fun3:{0},{1}", a, b);
		}
	}
}
*/
/**/
/* */   //背包系统 1.0
namespace demo10背包系统{
	class MainClass{
		public static void Main(){

			Goods w = new Weapon ("ak-74", 1, 5, 100, 0, GoodsType.Weapon);
			Goods c = new Cloth ("一级甲", 5, 2, 20, 30, GoodsType.Cloth);
			Goods g = new Durg ("止痛药", 3, 3, 30, 30, GoodsType.Durg);
			AllBackPack allBackPack = new AllBackPack ();
			allBackPack.add (w);
			allBackPack.add (c);
			allBackPack.add (g);
			Console.WriteLine (Hero.getInstance ());
			//Hero.getInstance ().ugoods += BackPack.getInstance ().add;
			Hero.getInstance ().ugoods += BackPack.getInstance ().remove;

			Hero.getInstance ().useGoods (w);
			Console.WriteLine (Hero.getInstance ());
			Hero.getInstance ().ugoods (w);
			Hero.getInstance ().useGoods (c);
			//Hero.getInstance ().ugoods (c);

			Console.WriteLine (Hero.getInstance ());

			allBackPack.printSort ();
		}
	}

	public enum GoodsType{Weapon,Cloth,Durg}
	class Goods{
		protected string name;
		protected int id;
		protected int level;
		protected int attack;
		protected int defense;
		protected int blood;
		protected int magic;

		private GoodsType goodsType;

		public Goods(){}
		public Goods(string name,int id,int level,GoodsType g){
			this.name = name;
			this.id = id;
			this.level = level;
			this.goodsType = g;
		}
		public GoodsType getGoodsType(){
			return goodsType;
		}
		public string Name{
			get{ return name;}
		}
		public int Id{
			get{ return id;}
		}
		public int Level{
			get{ return level;}
		}

		public static bool operator >(Goods a,Goods b) {
			return a.level > b.level;
		}
		public static bool operator <(Goods a,Goods b) {
			return a.level > b.level;
		}

	}
	class Weapon : Goods {
		public Weapon(string name,int id,int level,int attack,int magic,GoodsType g):base(name,id,level,g){
			base.attack = attack;
			base.magic = magic;
		}

		public int Attack{
			get { return attack;}
		}
		public int Magic{
			get{ return magic;}
		}
			
		public override string ToString ()
		{
			return string.Format ("[Weapon: Name={0}, Attack={1}, Magic={2}, Id={3}, Level={4}]", Name, Attack, Magic, Id, Level);
		}

		
	}
	class Cloth : Goods{
		public Cloth(string name,int id,int level,int defense,int blood,GoodsType g):base(name,id,level,g){
			this.name = name;
			this.defense = defense;
			this.blood = blood;
			this.id = id;
			this.level = level;
		}
		public int Defense{
			get{ return defense;}
		}
		public int Blood{
			get{ return blood;}
		}
		public override string ToString ()
		{
			return string.Format ("[Cloth:Name = {0}, Defense={1}, Blood={2},Id={3}, Level={4}]",name,Defense, Blood,id,level);
		}
	}
	class Durg : Goods{

		private int addBlood;
		private int addMagic;
	
		public Durg(string name,int id,int level ,int addBlood,int addMagic,GoodsType g):base(name,id,level,g){
			this.addBlood = addBlood;
			this.addMagic = addMagic;
		}
		public int AddBlood{
			get{ return addBlood;}
		}
		public int AddMagic{
			get{return addMagic;}
		}
		public override string ToString ()
		{
			return string.Format ("[Durg:Name = {0}, AddBlood={1}, AddMagic={2},Id={3}, Level={4}]",Name, AddBlood, AddMagic,Id,Level);
		}
	}
	class Hero{
		private string name;
		private int blood;
		private int magic;
		private int currentBlood;
		private int currentmagic;
		private int attack;
		private int denfens;
		//private BackPack backPack;
		private static Hero instance;
		private Hero(){
			name = "我";
			blood = 100;
			magic = 100;
			currentBlood = 100;
			currentmagic = 100;
			attack = 20;
			denfens = 10;
		}

		public int Blood{
			get{ return blood;}
			set{ blood = value;}
		}
		public int Magic{
			get{ return magic;}
			set{ magic = value;}
		}
		public int CurrentBlood{
			get{ return currentBlood;}
			set{ currentBlood = value;}
		}
		public int Currentmagic{
			get{ return currentmagic;}
			set{ currentmagic = value;}
		}
		public int Attack{
			get{ return attack;}
			set{ attack = value;}
		}
		public int Denfens{
			get{ return denfens;}
			set{ denfens = value;}
		}
		public static Hero getInstance(){
			if (instance == null) {
				instance = new Hero ();
			}
			return instance;
		}

		public delegate void ReomoveGoods(Goods goods);
		public ReomoveGoods ugoods;



		//使用物品 
		public void useGoods(Goods g)  {
			switch (g.getGoodsType()) {
			case GoodsType.Weapon:
				BackPack.getInstance ().add (g);
				break;
			case GoodsType.Cloth:
				BackPack.getInstance ().add (g);
				break;
			case GoodsType.Durg:
				if (BackPack.getInstance ().isHaveDurg ((Durg)g)) {
					useDurg ((Durg)g);
				} else {
					Console.WriteLine ("使用失败");
				}
				break;
			default:
				break;
			}
		}
		public void useDurg(Durg g){

			if ((g.AddBlood + currentBlood) >= blood) {
				currentBlood = blood;
			}
			currentBlood += g.AddBlood;
			if (g.AddMagic + currentmagic >= magic) {
				currentmagic = magic; 
			}
		}
		public override string ToString ()
		{

			return string.Format ("[Hero{0}: Blood={1}, Magic={2}, CurrentBlood={3}, Currentmagic={4}, Attack={5}, Denfens={6}]",name, Blood, Magic, CurrentBlood, Currentmagic, Attack, Denfens);
		}
	}

	class BackPack{

		private Dictionary <Durg,int> durg;
		private Weapon weapon;
		private Cloth cloth;

		private static BackPack instance;

		private AllBackPack allBackPack;


		private BackPack(){
			durg = new Dictionary<Durg, int> ();
			allBackPack = new AllBackPack ();
			weapon = null;
			cloth = null;
		}
		public static BackPack getInstance(){
			if(instance == null) {
				instance = new BackPack();
			}
			return instance;
		}

		//添加物品(大背包减少)
		public void add(Goods goods){

			switch (goods.getGoodsType()) {

			case GoodsType.Weapon:
				if (weapon != null) {
					Console.WriteLine ("替换武器");
					remove (weapon);
					weapon = (Weapon)goods;

				}
				weapon = (Weapon)goods;
				Hero.getInstance ().Attack += weapon.Attack;
				Hero.getInstance ().Magic += weapon.Magic;
				break;
			case GoodsType.Cloth:
				if (cloth != null) {
					Console.WriteLine ("替换衣服");
					remove (cloth);
					Hero.getInstance ().Denfens += cloth.Defense;
					Hero.getInstance ().Blood += cloth.Blood;
				}

				cloth = (Cloth)goods;
				Hero.getInstance ().Denfens += cloth.Defense;
				Hero.getInstance ().Blood += cloth.Blood;
				break;
			case GoodsType.Durg:
				if (durg.ContainsKey ((Durg)goods)) {
					durg[(Durg)goods]++;
				} else {
					durg.Add ((Durg)goods, 1);
				}
				break;
			default:
				Console.WriteLine("无法识别该物品类型");
				break;
			}

		}

		//删除物品(丢弃物品，丢进大背包)
		public void remove(Goods goods){
			switch (goods.getGoodsType()) {

			case GoodsType.Weapon:
				Hero.getInstance ().Attack -= weapon.Attack;
				Hero.getInstance ().Magic -= weapon.Magic;
				allBackPack.add (weapon);
				weapon = null;
				break;
			case GoodsType.Cloth:
				Hero.getInstance ().Denfens -= cloth.Defense;
				Hero.getInstance ().Blood -= cloth.Blood;
				allBackPack.add (cloth);
				cloth = null;
				break;
			case GoodsType.Durg:
				if (durg.ContainsKey ((Durg)goods)) {
					//TODO 药品丢弃功能
					allBackPack.add (goods);
					durg.Remove ((Durg)goods);
				}
				break;
			default:
				Console.WriteLine("无法识别该物品类型");
				break;
			}
		}
		public bool isHaveDurg<G>(G goods) where G : Durg{
			if (durg.ContainsKey ((G)goods)) {
				if (durg [goods] > 0) {
					durg [goods]--;
					return true;
				} else {
					Console.WriteLine ("这药用完了");
					return false;
				}
			}
			else {
				Console.WriteLine ("没有这种药");
				return false;
			}
		}

		//输出物品所以信息
		public void print ()
		{
			Console.WriteLine("weapon:{0},cloth:{1}",weapon,cloth);
			foreach (Durg s in durg.Keys) {
				Console.WriteLine ("{0}", s);
			}
		}
	}
	class AllBackPack{

		private List<Goods> goodslist;
		
		public AllBackPack (){
			goodslist = new List<Goods>();
		}
		public void add(Goods g){
			goodslist.Add (g);
		}
		public void remove(Goods g) {
			goodslist.Remove (g);
		}
		public void printSort(){
			for (int i = 0; i < goodslist.Count; i++) {
				Console.WriteLine ("{0} ", goodslist [i]);
			}
		}
		//按等级、id排序 TODO
	
	}
}


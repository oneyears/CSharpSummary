using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//C#Da14泛型

/// <summary>
/// 疑问：
/// 1、什么是泛型
/// 2、List 和 ArrayList的关系
/// 3、为什么要泛型
/// 4、什么时候用泛型
/// 5、泛型的使用规则
/// 6、泛型的使用方式
/// 7、泛型的优点、缺点
/// </summary>

/*
namespace CSharpDay14_06_05
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//系统提供的ArrayList容器中是object数组，保存值类型数据会参生装箱操作。
			//使用ArrayList 需要引用 using System.Collections;
			ArrayList al = new ArrayList ();
			for (int i = 0; i < 10; i++) {
				al.Add (i);
			}
			al.Add ("hello");
			al.Add ("world");

			foreach (object o in al) {
				Console.Write (o);
			}

		}
	}

	class MyArray{

		private object[] array;
		private int capacity;
		private int count;

		public MyArray(){
			array = new object[5];
			this.capacity = 5;
			count = 0;
		}

		public void Add(object o){
			array [count++] = 0;
			if (count == capacity) {
				object[] s = array;
				capacity *= 2;
				array = new object[capacity];
				for(int i = 0; i < capacity;i++)
					array[i] = s[i];
			}
				

		}

		public int size(){
			return count;
		}



	}
}
*/
/*
namespace demo2泛型数组(泛型容器){
	class MainClass {
		public static void Main(){
			List<int> il = new List<int> ();
			for (int i = 0; i < 10; i++) {
				il.Add (i);
			}
			foreach (int a in il) {
				Console.WriteLine (a);
			}
			List<string> iS = new List<string> ();
			iS.Add ("hello");
			iS.Add ("world");
			foreach (string a in iS) {
				Console.WriteLine (a);
			}
			List<double> dl = new List<double> ();
			dl.Add (5.5);
			foreach (double a in dl) {
				Console.WriteLine (a);
			}
			//泛型容器List容器可以通过设置类型然后保存对应类型的数据
			//使用List<>需要先引用 using System.Collections.Generic;
			//尖括号<> 里面的类型就是泛型
			//通过设置元素类型避免装箱操作
			//泛型List容器设置元素诶下后，容器中只能保存该类型的元素，更安全。
		}
	}
}
*/
/*
namespace demo3泛型使用{
	class MainClass{

		public static void Main(){
			int x = add (1, 2);
			double d = add (3, 1.2);
			Console.WriteLine (x +","+ d);
			string z = add<string> ("hello", "world");
			//在调用泛型方法时，在<>中指定T的类型。
			//也可以省略类型，由参数自动确定T的类型
			//

			Console.WriteLine (z);
			add2 (1, 2);
		}
		//现在的问题，不同类型的数据类型要写一个对应类型的方法
		//可以通过泛型解决，通过泛型只写一个方法就可以了。
//		public static int add(int a, int b) {
//			return a + b;
//		}
//		public static double add(double a, double b) {
//			return a + b;
//		}
		//T 是一个不确定的类型，可以表示任何类型
		public static T add<T>(T a , T b) {
			//因为T是不确定的，所以不能直接 a + b （因为T可能是类型的对象，而对象有多个数据，因此不能直接+ - * /）
			return a;
		}
		public static void add2<T>(T a , T b) {
			// 可以 直接 add(xx,xxx) 但是不能有返回值，要写出void返回值类型 方法  ，由参数自动确定T的类型
			// 可以直接add2 (1, 2)调用; 而不必 add2<int>(1,2)  
			Console.WriteLine ("{0},{1}", a, b);
		}
	}
}
*/
/*
namespace demo4泛型方法{

	class MainClass{
		public static void Main(){
			fun (5);
			fun (5.5);
			fun ("helloWorld");
			fun<float> (5.5f);
			fun<char> ('a');
			fun<short> (5);
			Console.WriteLine ("qwq"+fun<short> (5,0));
		}
		//一个泛型方法可以操作多种不同类型的参数
		// T 是一个不确定的类型，可以是任意类型，需要在调用方法时指定T的类型
		public static void fun<T>(T a){
			Console.WriteLine ("{0}", a);
		}
		//返回值不同不是重载因此如果方法名相同，参数列表相同，仅仅是返回值不同是不能重载的（编译报错）。
		public static T fun<T>(T a,T b){
			return a;
		}
	}
}
*/
/*
namespace demo5泛型类{
	//通过泛型类：通过泛型参数T来代替数组的类型
	class MainClass{
		public static void Main(){
			MyArray<int> a = new MyArray<int> ();

//			for (int i = 0; i < 10; i++) {
//				a.add (i);
//			}

			for (int i = 0; i < a.size (); i++) {
				Console.WriteLine (a [i]);
			}

			List<int> ll = new List<int>();

			MyArray<double> d = new MyArray<double> ();
			MyArray<float> f = new MyArray<float> ();
			MyArray<String> s = new MyArray<string> ();
			MyArray<Edge<double>> e = new MyArray<Edge<double>> ();

			Stopwatch sw = new Stopwatch ();
			Stopwatch sw2 = new Stopwatch ();

			int Max = 1000000;
			sw.Start ();
			for(int i = 1; i <=Max;i++ ) {
				ll.Add (i);
			}
			sw.Stop ();
		
			ArrayList arrayListA = new ArrayList();
			sw2.Start ();
			for (int i = 0; i < Max; i++)
				arrayListA.Add (i);
			sw2.Stop ();
			TimeSpan span = sw.Elapsed;
			TimeSpan span2 = sw2.Elapsed;
			Console.WriteLine ("{0}ms", span.Milliseconds);
			Console.WriteLine ("{0}ms", span2.Milliseconds);

			e.add (new Edge <double>(0, 1, 0.35));
		}
	}
	//在类名后面加<T>，在类中可以用T表示不确定的类型
	class MyArray<T>{
		private T[] array;//用T表示数组的类型
		private int capacity;
		private int count;
		public MyArray(){
			array = new T[5]; //创建一个T类型的数组
			capacity = 5;
			count = 0;
		}
		//用T表示参数类型 
//		public void add<T>(T a) {
//			这里的T不是泛型类的T 而是类里新定义的T了，可以把T该成其他名，如V等等...
//		}
		public void add(T a) {
			array [count++] = a;
			if (count == capacity) {
				T[] temp = array;
				array = new T[capacity * 2];
				for (int i = 0; i < count; i++) {
					array [i] = temp [i];
				}
				capacity *= 2;
			}
		}

		public int Capacity{
			get{ return capacity; }
			set{ capacity = value;}
		}
		public int size(){
			return count;
		}
		public T this[int index] {
			get{ return array [index];}
			set{ array [index] = value;}
		}
	}
		
	class Edge<Weight>{
		int a;
		int b;
		Weight weight;

		public Edge(int a, int b,Weight weight){
			this.a = a;
			this.b = b;
			this.weight = weight;
		}

		public int V{
			get{ return a; }
		}
		public int E{
			get{ return b;}
		}
		public Weight W{
			get{ return weight; }
		}



	}


}
*/
/*
namespace demo6字典Dictionnary{
	class MainClass{
		public static void Main(){
			//泛型容器Dictionary：字典
			//Dcitionary中保存的是键值对 每一个值对应一个键，键就是值的下标（键的类型自己定义（任意类型）），值也是可以任意类型
			int[] a = new int[5]{ 1, 2, 3, 4, 5 };
			Console.WriteLine (a [0]);
			Console.WriteLine (a [1]);

			// 前面表示索引下标类型，后面string值类型
			Dictionary<int,string> dic = new Dictionary<int, string> ();
			dic.Add (0, "hello");
			dic.Add (1, "world");
			dic.Add (2, "!!!");

			for (int i = 0; i < 3; i++)
				Console.WriteLine (dic [i]);
			//访问时，方括号中填写键，
			Dictionary <string,int> dic2 = new Dictionary<string, int> ();

			dic2.Add ("a", 1);
			dic2.Add ("b", 2);
			Console.WriteLine (dic2 ["a"]);
			Console.WriteLine (dic2 ["b"]);

			//foreach 访问容器
			//1、用KeyValuePair 来访问字典
			foreach (KeyValuePair<string,int> t in dic2) {
				Console.WriteLine ("key:{0},value:{1}",t.Key,t.Value);
				Console.WriteLine (t);
			}

			//2、用 dic.values属性得到所以值的容器  或者 dic2.keyss属性得到所以的键的容器 来确定访问的某一类值
			foreach (int t in dic2.Values) {
				Console.WriteLine (t);
			}

			//3、
			foreach (string s in dic2.Keys) {
				Console.WriteLine (s);
			}
		}
	}
}
*/
/*
namespace demo7字典类{
	class MainClass{
		public static void Main(){

			News n1 = new News ("QQQ", "2018", "qqq");
			News n2 = new News ("WWW", "2018", "www");
			News n3 = new News ("EEE", "2018", "eee");
			News n4 = new News ("RRR", "2018", "rrr");
			News n5 = new News ("TTT", "2018", "ttt");

			Dictionary <string,News> dic = new Dictionary<string, News> ();
			dic.Add (n1.Title,n1);
			dic.Add (n2.Title,n2);
			dic.Add (n3.Title,n3);
			dic.Add (n4.Title,n4);
			dic.Add (n5.Title,n5);
			foreach (string s in dic.Keys) {
				Console.WriteLine (s);
			}
			foreach (News k in dic.Values) {
				Console.WriteLine ("Time:{0} d:{1}",k.Time,k.Description);
			}
			foreach(KeyValuePair<string,News> k in dic) {
				Console.WriteLine (k.Key);
				Console.WriteLine (k.Value);
			}

			//dic.Remove (n1.Title);
			//dic.Clear ();

			//判断字典中是否包含某个键或值
			if (dic.ContainsKey ("QQQ")) {
				Console.WriteLine ("包含QQQ");
			} 
			else {
				Console.WriteLine ("不包含QQQ");
			}

		}
	}

	class News{
		private string title;//新闻标题
		private string time;//新闻发生的时间
		private string description;//新闻描述

		//构造函数
		public News(string title,string time,string description ) {
			this.title = title;
			this.time = time;
			this.description = description;
		}

		//属性
		public string Title{
			get{ return title;}
		}

		public string Time{
			get{ return time;}
		}

		public string Description{
			get{ return description;}
		}

		public override string ToString ()
		{
			return string.Format ("[News: Title={0}, Time={1}, Description={2}]", Title, Time, Description);
		}
	}
}
*/
/*
namespace demo8频道管理{
	class MainClass{
		public static void Main(){
			ChannelManager cm = new ChannelManager ();

			News n1 = new News ("公益广告","30s","~");
			News n2 = new News ("剑南春","10s","~");
			//将频道添加到cm中
			Channel c1 = new Channel ("记录频道",n1);
			Channel c2 = new Channel ("新闻频道",n2);
			//将新闻添加到cm中的对应的频道下

			cm.Add (c1, n1);
			cm.Add (c1, new News ("预告片", "20s", "~"));
			c2.add (n2);
		}
	}
	class News{
		private string title;
		private string time;
		private string des;
		public News (string title, string time, string des){
			this.title = title;
			this.time = time;
			this.des = des;
		}
		public string Title{
			get{return title;}
		}

	}
	//一个频道有多个新闻
	class Channel{
		private string name;
		private Dictionary <string ,News> dic;
		public string Title{
			get{return name;}
		}
		//构造函数

		public Channel(string name,News n){
			dic = new Dictionary<string, News> ();
			this.name = name;
		}
		//添加新闻的方法（不要重复添加新闻，如果存在输出一条信息不再添加）
		public void add(News n){
			if (dic.ContainsValue(n)) {
				Console.WriteLine ("该条新闻已经被添加");

			} else {
				dic.Add (n.Title, n);
				Console.WriteLine ("添加成功：新闻名为：{0}", n.Title);
			}
		}
		//删除某条新闻
		public void remove(string title){
			if (dic.ContainsKey (title)) {
				dic [title] = null;
			} else {
				Console.WriteLine ("没有包含这条新闻");
			}
			//dic.Remove (title);
		}
		//输出该频道下所有的新闻
		public void clear(){
			foreach (string i in dic.Keys) {
				dic [i] = null;
			}
			//dic.Clear ();
		}
	}
	//频道管理 管理频道、和广告
	class ChannelManager{
		private Dictionary<string,Channel> dic;
		//构造函数
		public ChannelManager(){
			dic = new Dictionary<string, Channel> ();
		}
		//在某频道下添加新闻（先判断是否存在该频道，不存在频道先添加频道再添加新闻）
		public void Add(Channel c, News n){
			if (dic.ContainsValue (c)) {
				c.add(n);
				Console.WriteLine ("已有频道：{0}，成功添加{1}", c.Title, n.Title);
			} else {
				c.add(n);
				dic.Add(c.Title,c);
			}
		}
		//删除某频道下的某新闻
		public void Remove(Channel s,string n){
			if (dic.ContainsValue(s)) {
				s.remove (n);
			}		
		}
		//输出所有频道及频道下的新闻
		public void Clear(){
			dic.Clear ();
		}
	}
}
*/
/*
namespace demo9Test11{
	class MainClass{}
	class SimpleT<T> {
		private SimpleT<T> instance;
		private SimpleT(){
		}
		public SimpleT<T> getInstance() {
			if (instance == null) {
				instance = new SimpleT<T> ();
			}
			return instance;
		}
	}
}
*/
/*
namespace demo10Test12{
	class Mainclass{}
	class Tarray<T>{
		private List<T> array;
		public Tarray() {
			array = new List<T> ();
		}
		public T this[int index]{
			get{ return array [index];}
			set{ array [index] = value;}
		}
	}
}
*/



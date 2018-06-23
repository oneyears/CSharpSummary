using System;
using System.Collections.Generic;
/*
*/
namespace CSharpDay16_0607背包系统
{
	//英雄有自身属性， 有英雄背包（装备武器） 和大背包（可以直接吃药？药是否可以叠加？）
	//英雄背包替换的装备是否要放回大背包？
	class MainClass{
		public static void Main(){

			Goods w = new Weapon ("ak-74", 1, 5, 100, 0, GoodsType.Weapon);
			Goods c = new Cloth ("一级甲", 5, 2, 20, 30, GoodsType.Cloth);
			Goods g = new Durg ("止痛药", 3, 3, 30, 30, GoodsType.Durg);

			AllBackPack allBackPack = new AllBackPack ();
			allBackPack.add (w);
			allBackPack.add (c);
			allBackPack.add (g);

			Hero.getInstance ().allBackPack.add (g);

			Console.WriteLine (Hero.getInstance ());

			//Hero.getInstance ().ugoods += BackPack.getInstance ().add;
			Hero.getInstance ().rGoods +=Hero.getInstance().BackPack.remove;

			Hero.getInstance ().useGoods (w);
			Console.WriteLine (Hero.getInstance ());

			Hero.getInstance ().remove (w);
			Hero.getInstance ().useGoods (c);

			Console.WriteLine (Hero.getInstance ());
			allBackPack.sort ();
			allBackPack.remove (w);
			allBackPack.print();

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
	class Hero 
	{
			private string name;
			private int blood;
			private int magic;
			private int currentBlood;
			private int currentmagic;
			private int attack;
			private int denfens;
			private BackPack backPack;

			public AllBackPack allBackPack;
			private static Hero instance;
			private Hero(){
				name = "我";
				blood = 100;
				magic = 100;
				currentBlood = 100;
				currentmagic = 100;
				attack = 20;
				denfens = 10;
				backPack = new BackPack ();
				allBackPack = new AllBackPack ();
			}
			public int Blood{
				get{ return blood;}
			}
			public int Magic{
				get{ return magic;}
				set{ magic = value;}
			}
			public int CurrentBlood{
				get{ return currentBlood;}
			}
			public int Currentmagic{
				get{ return currentmagic;}
			}
			public int Attack{
				get{ return attack;}
			}
			public int Denfens{
				get{ return denfens;}
			}
		public BackPack BackPack{
			get{ return backPack;}
		}
		public static Hero getInstance(){
			if (instance == null) {
				instance = new Hero ();
			}
			return instance;
		}

		public delegate void ReomoveGoods(Goods goods);
		public ReomoveGoods rGoods;

		public delegate void UseGoodsdelegate(Goods goods);
		public UseGoodsdelegate uGoods;

		//使用物品 
		public void useGoods(Goods g)  {
			switch (g.getGoodsType()) {
			case GoodsType.Weapon:
				backPack.add (g);
				break;
			case GoodsType.Cloth:
				backPack.add (g);
				break;
			case GoodsType.Durg:
				if (backPack.isHaveDurg ((Durg)g)) {
					useDurg ((Durg)g);
				
				} 
				else {
					Console.WriteLine ("使用失败");
				}
				break;
			default:
				break;
			}

		}
		//从英雄背包丢进大背包
		public void remove(Goods g) {
			switch (g.getGoodsType()) {
			case GoodsType.Weapon:
				removeDataWeapon ();
				break;
			case GoodsType.Cloth:
				removeDataCloth ();
				break;
			case GoodsType.Durg:
				//TODO
				break;
			default:
				break;
			}
			rGoods += backPack.remove;
			rGoods (g);
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
		public void upDataWeapon(){
			if (backPack.getWeapon == null)
				return;
			attack += backPack.getWeapon.Attack;
			magic += backPack.getWeapon.Magic;
		}
		public void upDataCloth(){
			if (backPack.getCloth == null) 
				return;
			denfens += backPack.getCloth.Defense;
			blood += backPack.getCloth.Blood;
		}
		private void removeDataWeapon(){
			attack -= backPack.getWeapon.Attack;
			magic -= backPack.getWeapon.Magic;
		}
		private void removeDataCloth(){
			denfens -= backPack.getCloth.Defense;
			blood -= backPack.getCloth.Blood;
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

		private AllBackPack allBackPack;
		public BackPack(){
			durg = new Dictionary<Durg, int> ();
			allBackPack = new AllBackPack ();
			weapon = null;
			cloth = null;
		}

		public Weapon getWeapon{
			get { return weapon;}
		}

		public Cloth getCloth{
			get{ return cloth;}
		}

			//添加物品(大背包减少)
		public void add(Goods goods){

			switch (goods.getGoodsType()) {

			case GoodsType.Weapon:
				if (weapon != null) {
					Console.WriteLine ("替换武器");
					remove (weapon);
				}
				weapon = (Weapon)goods;
				Hero.getInstance ().upDataWeapon ();

				break;
			case GoodsType.Cloth:
				if (cloth != null) {
					Console.WriteLine ("替换衣服");
					remove (cloth);
				}
				cloth = (Cloth)goods;
				Hero.getInstance ().upDataCloth ();
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
				if (weapon == null)
					return;
					allBackPack.add (weapon);
					weapon = null;
					break;
			case GoodsType.Cloth:
				if (cloth == null)
					return;
					allBackPack.add (cloth);
					cloth = null;
					break;
				case GoodsType.Durg:
				if (durg.ContainsKey ((Durg)goods)) {
					//TODO 药品丢弃功能 药品应该就在大背包使用，所以该功能
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
			if (goodslist.Remove (g)) {
				Console.WriteLine ("删除成功");
			} else {
				Console.WriteLine ("删除失败，可能没有该物品了");
			}
		}	
		//按等级、id排序 
		public void sort(){
			Goods temp = null;
			for (int i = 0; i < goodslist.Count; i++) {
				for (int j = 0; j < goodslist.Count - i - 1; j++) {
					if (goodslist [j].Level == goodslist [j + 1].Level) {
						if (goodslist [j].Id < goodslist [j + 1].Id) {
							temp = goodslist [j + 1];
							goodslist [j + 1] = goodslist [j];
							goodslist [j] = temp;
						}
					} 
					if (goodslist [j].Level < goodslist [j+1].Level) {
						temp = goodslist [j + 1];
						goodslist [j + 1] = goodslist [j];
						goodslist [j] = temp;
					}
				}
			}

		}
		public void print(){
			for (int i = 0; i < goodslist.Count; i++) {
				Console.WriteLine ("{0} ", goodslist [i]);
			}
		}
	}
}


/*
namespace demo1泛型单例{

	class MainClass{
		public static void Main(){
			Single<double>.getInstance ().fun (5);
		}
	}
	class news{}
	class Single<T> where T : new(){

		private static Single<T> instance;
		private Single(){}

		public static Single<T> getInstance(){
			if (instance == null) {
				instance = new Single<T> ();
			}
			return instance;
		}
		public void fun(T a){
			Console.WriteLine(a);
		}
	}
}

/*
namespace demo2Test11传递泛型数组{
	class MainClass{
		public static void Main(){

			int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			fun<int>(ref arr,3);

		}
		public static void fun<T>(ref T[] ar,int position)where T:struct{
			for (int i = position-1; i < 10-1; i++) {
				ar [i] = ar [i + 1];
			}
			for (int i = 0; i < 10-1; i++) {
				Console.WriteLine (ar [i]);
			}
		}
	}
	struct News{
		int id ;
		int age;
		public override string ToString ()
		{
			return string.Format ("[News]");
		}
	}
	struct Array{
		News [] array;
		public Array(){
			array = new News[10];
		}
		public override string ToString ()
		{
			return string.Format ("[Array]");
		}
	}

}
*/
/*
namespace demo3interface{
	class MainClass{
		public static void Main(){
		
		}
	}

	interface Interface<T,V>{
		void fun(T t);
		void fun(V v);
	}
	class A : Interface<int,string>{
		public void fun(int a){

		}
		public void fun(string b){
		}
	}

}
*/
/*
namespace demo4{

}
*/
using System;
using System.Collections.Generic;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			Weapon w1 = new Weapon ("aa", 1001, 5, 30, 30);
			Weapon w2 = new Weapon ("bb", 1002, 4, 20, 10);
			Weapon w3 = new Weapon ("cc", 1003, 5, 30, 40);
			Weapon w4 = new Weapon ("dd", 1004, 6, 50, 50);

			Clothes c1 = new Clothes ("ee", 1011, 5, 40, 30);
			Clothes c2 = new Clothes ("ff", 1012, 6, 50, 60);
			Clothes c3 = new Clothes ("gg", 1013, 4, 30, 30);
			Clothes c4 = new Clothes ("hh", 1014, 3, 20, 30);

			Consumables con1 = new Consumables ("ii", 1021, 30, 30);
			Consumables con2 = new Consumables ("jj", 1022, 40, 50);
			Consumables con3 = new Consumables ("kk", 1023, 60, 40);

			Bag b = new Bag ();
			b.add (w2);
			b.add (c1);
			b.add (w3);
			b.add (c4);
			b.add (con3);
			b.add (w1);
			b.add (con1);
			b.add (c2);
			b.add (w4);
			b.add (c3);
			b.add (con2);
			b.sort ();
			for (int i = 0; i < b.Size; i++) {
				Console.WriteLine (b [i]);
			}
			Console.WriteLine ("-------------------");
			Hero h = new Hero ();
			h.useGoods += b.remove;//订阅事件，事件指向背包b的remove方法
			Console.WriteLine (h);

			h.use (w1);//use方法中发布事件，事件指向背包b的remove方法
			h.use (c1);
			Console.WriteLine (h);

			h.use (con1);
			Console.WriteLine (h);
			h.use (con2);
			Console.WriteLine (h);

			Console.WriteLine ("-------------------");
			for (int i = 0; i < b.Size; i++) {
				Console.WriteLine (b [i]);
			}
			Console.WriteLine ("-------------------");
			h.showBag ();
		}
}

	public enum Types
	{
		weapon,
		clothes,
		consumables
	}
	public class Goods
	{
			protected string name;
		protected int id;
			protected Types t;
		protected int star;

		protected int attack;
		protected int defense;
		protected int hp;
		protected int mp;

		public string Name
		{
			get { return name; }
		}
		public int ID
		{
			get { return id; }
		}
		public int Star
		{
			get { return star; }
		}
		public Types T
		{
			get { return t; }
		}

		public Goods(string _name, int _id, int _star, int _attack, int _defense, int _hp, int _mp)
		{
			name = _name;
			id = _id;
			star = _star;
			attack = _attack;
			defense = _defense;
			hp = _hp;
			mp = _mp;

			if (id >= 1001 && id <= 1010) {
				t = Types.weapon;
			} else if (id >= 1011 && id <= 1020) {
				t = Types.clothes;
			} else if (id >= 1021 && id <= 1030) {
				t = Types.consumables;
			}
		}
		//...
	}
	public class Weapon : Goods
	{
		//武器只加攻击和蓝上限
		//衣服只加防御和血上限 
		public Weapon(string _name, int _id, int _star, int _attack, int _mp) : base(_name, _id, _star, _attack, 0, 0, _mp)
		{

		}
		public int Attack
		{
			get { return attack; }
		}
		public int MP
		{
			get { return mp; }
		}
		public override string ToString()
		{
			return string.Format("[Weapon: Star={0}, Name={1}, ID={2}, Attack={3}, MP={4}]", star, name, id, attack, mp);
		}
	}
	public class Clothes : Goods
	{
		public Clothes(string _name, int _id, int _star, int _defense, int _hp) : base(_name, _id, _star, 0, _defense, _hp, 0)
		{

		}
		public int Defense
		{
			get { return defense; }
		}
		public int HP
		{
			get { return hp; }
		}
		public override string ToString()
		{
			return string.Format("[Clothes: Star={0}, Name={1}, ID={2}, Defense={3}, HP={4}]", star, name, id, defense, hp);
		}
	}
	public class Consumables : Goods
	{
		private int addHP;
		private int addMP;
		public Consumables(string _name, int _id, int _addHP, int _addMP) : base(_name, _id, 0, 0, 0, 0, 0)
		{
			addHP = _addHP;
			addMP = _addMP;
		}
		public int AddHP
		{
			get { return addHP; }
		}
		public int AddMP
		{
			get { return addMP; }
		}
		public override string ToString()
		{
			return string.Format("[Consumables: Name={0}, ID={1}, AddHP={2}, AddMP={3}]", name, id, AddHP, AddMP);
		}
	}

	public class Bag
	{
		private List<Goods> goodsArray;
		public Bag()
		{
			goodsArray = new List<Goods>();
		}
		public Goods this[int index]
		{
			get { return goodsArray[index]; }
		}
		public int Size
		{
			get { return goodsArray.Count; }
		}
		//添加物品
		public void add(Goods g)
		{
			goodsArray.Add(g);
		}
		//删除物品
		public void remove(Goods g)
		{
			if (!goodsArray.Contains(g))
			{
				Console.WriteLine("not exists");
				return;
			}
			goodsArray.Remove(g);
		}
		//对物品排序
		//public void sort()
		//{
		//	for (int i = 0; i < goodsArray.Count - 1; i++)
		//	{
		//		for (int j = 0; j < goodsArray.Count - i - 1; j++)
		//		{
		//			if (goodsArray[j].ID > goodsArray[j + 1].ID)
		//			{
		//				Goods temp = goodsArray[j];
		//				goodsArray[j] = goodsArray[j + 1];
		//				goodsArray[j + 1] = temp;
		//			}
		//		}
		//	}
		//}
		public void sort()
		{
			for (int i = 0; i < goodsArray.Count - 1; i++)
			{
				for (int j = 0; j < goodsArray.Count - i - 1; j++)
				{
					if (goodsArray[j].Star > goodsArray[j + 1].Star)
					{
						Goods temp = goodsArray[j];
						goodsArray[j] = goodsArray[j + 1];
						goodsArray[j + 1] = temp;
					}
					else if (goodsArray[j].Star == goodsArray[j + 1].Star)
					{
						if (goodsArray[j].ID > goodsArray[j + 1].ID)
						{
							Goods temp = goodsArray[j];
							goodsArray[j] = goodsArray[j + 1];
							goodsArray[j + 1] = temp;
						}
						else if (goodsArray[j].ID == goodsArray[j + 1].ID)
						{
							//if (goodsArray[j].Name > goodsArray[j + 1].Name)
							//{

							//}
						}
					}
				}
			}
		}
	}
	public class Hero
	{
		private int HP;
		private int currentHP;
		private int MP;
		private int currentMP;
		private int attack;
		private int defense;
		private Bag bag;

		public delegate void BagDelegate(Goods g);
		public event BagDelegate useGoods;
		public Hero()
		{
			HP = 100;
			MP = 100;
			currentHP = 90;
			currentMP = 90;
			attack = 100;
			defense = 100;

			bag = new Bag();
		}

		//穿戴物品
		public void use(Goods g)
		{
			if (g.T == Types.weapon)
			{
				attack += ((Weapon)g).Attack;
				MP += ((Weapon)g).MP;
				bag.add(g);
			}
			else if (g.T == Types.clothes)
			{
				defense += ((Clothes)g).Defense;
				HP += ((Clothes)g).HP;
				bag.add(g);
			}
			else if (g.T == Types.consumables)
			{
				currentHP += ((Consumables)g).AddHP;
				currentHP = currentHP > HP ? HP : currentHP;
				currentMP += ((Consumables)g).AddMP;
				currentMP = currentMP > MP ? MP : currentMP;
			}
			//bag.add(g);
			if (useGoods != null)
			{
				useGoods(g);//useGoods --> remove
				//事件接收者要移除g物品，背包对象b收到事件调用remove方法移除g物品
			}
		}

		public void showBag()
		{
			for (int i = 0; i < bag.Size; i++)
			{
				Console.WriteLine(bag[i]);
			}
		}
		public override string ToString()
		{
			return string.Format("[Hero: Attack={0}, Defense={1}, HP={2}, MP={3}, CurrentHP={4}, CurrentMP={5}]", attack, defense, HP, MP, currentHP, currentMP);
		}
	}
}



/*using System;
using System.Collections.Generic;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			List<Student> l = new List<Student>();

			Student s1 = new Student("aa", 20, 100, 90, 80);
			Student s2 = new Student("aa", 40, 100, 90, 80);
			Student s3 = new Student("aa", 10, 100, 90, 80);
			Student s4 = new Student("aa", 50, 100, 90, 80);
			Student s5 = new Student("aa", 30, 100, 90, 80);

			l.Add(s1);
			l.Add(s2);
			l.Add(s3);
			l.Add(s4);
			l.Add(s5);

			for (int i = 0; i < l.Count; i++)
			{
				Console.WriteLine("name:{0},age:{1}", l[i].Name, l[i].Age);
			}

			l.Sort();//List<>容器中的Sort方法，需要调用元素的IComparable接口的CompareTo方法

			Console.WriteLine("---------------");
			for (int i = 0; i<l.Count; i++)
			{
				Console.WriteLine("name:{0},age:{1}", l[i].Name, l[i].Age);
			}

		}
	}

	public class Student : IComparable
	{
		public string Name { get; set; }
		public int Age { get; set; }

		public double Chinese { get; set; }
		public double Math { get; set; }
		public double English { get; set; }

		public Student(string _name, int _age, double _chinese, double _math, double _english)
		{
			Name = _name;
			Age = _age;
			Chinese = _chinese;
			Math = _math;
			English = _english;
		}

		public int CompareTo(object anotherStudent)
		{
			if(this.Age == ((Student)anotherStudent).Age) {
				return this.Chinese-((Student)anotherStudent).Chinese;
			}
			return this.Age - ((Student)anotherStudent).Age;
		}
	}
}*/
/*using System;
using System.Collections.Generic;
namespace aa
{
	class MainClass
	{
		public static void Main()
		{
			List<Student> l = new List<Student>();

			Student s1 = new Student("aa", 20, 100, 90, 80);
			Student s2 = new Student("bb", 30, 60, 60, 80);
			Student s3 = new Student("cc", 30, 60, 90, 80);
			Student s4 = new Student("dd", 30, 60, 70, 80);
			Student s5 = new Student("ee", 30, 70, 90, 80);

			l.Add(s1);
			l.Add(s2);
			l.Add(s3);
			l.Add(s4);
			l.Add(s5);

			for (int i = 0; i < l.Count; i++)
			{
				Console.WriteLine("name:{0},age:{1},chinese:{2},math:{3}", l[i].Name, l[i].Age, l[i].Chinese,l[i].Math);
			}

			//Sort方法中使用lambda表达式进行排序
			//多权重排序，根据规则的权重优先按某个规则排序
			//
			l.Sort((x, y) => x.sortByAge(y) * 4 + x.sortByChinese(y) * 2 + x.sortByMath(y)*1);

			Console.WriteLine("---------------");
			for (int i = 0; i < l.Count; i++)
			{
				Console.WriteLine("name:{0},age:{1},chinese:{2},math:{3}", l[i].Name, l[i].Age, l[i].Chinese,l[i].Math);
			}

		}
	}

	public class Student
	{
		public string Name { get; set; }
		public int Age { get; set; }

		public double Chinese { get; set; }
		public double Math { get; set; }
		public double English { get; set; }

		public Student(string _name, int _age, double _chinese, double _math, double _english)
		{
			Name = _name;
			Age = _age;
			Chinese = _chinese;
			Math = _math;
			English = _english;
		}

		public int sortByAge(Student anotherStudent)
		{
			int result = this.Age - anotherStudent.Age;
			return result == 0 ? 0 : (result > 0 ? 1 : -1);
		}
		public int sortByChinese(Student anotherStudent)
		{
			int result = (int)(this.Chinese - anotherStudent.Chinese);
			return result == 0 ? 0 : (result > 0 ? 1 : -1);
		}
		public int sortByMath(Student anotherStudent)
		{
			int result = (int)(this.Math - anotherStudent.Math);
			return result == 0 ? 0 : (result > 0 ? 1 : -1);
		}
	}
}*/

using System;
using System.Text;
using System.Collections;
namespace CsharpDay05_5_21
{

 
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }

	class MainClass
	{
		public static void Main (string[] args)
		{

			//函数功能
			//函数名字
			//函数参数列表
			//函数的返回值类型
			//一个函数只能返回一个结果，不能返回多个结果
			//void 可以用return; 直接返回（跳出函数） 没有返回值

			//实参 和 形参， 将实参传入到函数，新参拷贝了，修改形参数数值，实参并不会改变
			//递归 当函数调用自己本身，称为递归函数
			//递归需要终止条件


			string 	s = "qwqes1234()23&";
			Console.WriteLine (fun3 (s));
		}

		public static int fun1(int a) {
			int s = 1;
			while (a > 0) {
				s *= a;
				a--;
			}
			return s;	
		}
		//斐波那契数列
		public static int fun2(int n) {
			if (n == 1 || n == 2) {
				return 1;
			}
			return fun2 (n - 1) + fun2 (n - 2);
		}


		//将除数字和字母以外的字符除去并返回string
		public static string fun3(string s){
		
			String news = "";
			for(int i = 0 ; i < s.Length; i++) {
				if (s[i] <= '9' && s[i] >= '0')
					news += s[i];
				if (s[i] <= 'z' && s[i] >= 'a')
					news += s[i];
				if (s[i] <= 'Z' && s[i] >= 'A')
					news += s[i];
			}
			return news;
		}
	}
}
	/*
	//leetcode 20
	public class Solution {
		public bool IsValid(string c) {

			Stack stack = new Stack ();

			for (int i = 0; i < c.Length; i++) {
				char c = (char)c [i];
				if (c  == "{" || c  == "[" || c  == "(") {
					stack.Push (c);					
				} else {
				
					if (stack.Count == 0)
						return false;
					else {
						object num1 = stack.Pop ();
						object num2;
						if (c == "}")
							num2 = "{";
						else if (c  == "]")
							num2 = "[";
						else {
							num2 = "(";
						}

						if (Equals(num1,num2))
							return false;
					}
				}
			}

			if (stack.Count != 0) {
				return false;
			}
			return true;
		}
	}
		*/

	/*
		//leetcode 150
	public class Solution {
		public int EvalRPN(string[] tokens) {
			Stack stack = new Stack();
			int sum = 0;
			for (int i = 0; i < tokens.Length; i++) {

				if(tokens.Length==1){
					int s1 = int.Parse (tokens [0]);
					return s1;
				}
				if (tokens [i] == "+" || tokens [i] == "-" || tokens [i] == "*" || tokens [i] == "/") {


					string s1 = (string)stack.Pop();
					string s2 = (string)stack.Pop();
					int num1 = int.Parse (s1);
					int num2 = int.Parse (s2);

					if (tokens [i] == "+")
						sum = num1 + num2;
					else if (tokens [i] == "-")
						sum = num2 - num1;
					else if (tokens [i] == "*")
						sum = num1 * num2;
					else
						sum = num2 / num1;
					string s3 = sum.ToString ();
					stack.Push (s3);

				} else {
					stack.Push (tokens [i]);
				}

			}
			return sum;
		}
	}
	*/


	//leetcode 71 Simple Path

//	public class Solution {
//		public string SimplifyPath(string path) {
//		
//		}
//	}
	
	//leetcode 144 Binary Tree Preorder Traversal
	
	public class Solution {
		public IList<int> PreorderTraversal(TreeNode root) {
		List<int> mlist = new list<int>();
		mlist.Add (root.val);
		PreorderTraversal (root.left);
		PreorderTraversal (root.left);
		return mlist;
		}
	}


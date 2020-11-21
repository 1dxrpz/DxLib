
using System;
using System.Collections.Generic;
using DxLib.Utils;

namespace DxLib
{
	namespace Utils {
		class Vector2
		{
			public double x, y;
			public Vector2(double a = 0, double b = 0)
			{
				x = a;
				y = b;
			}
			public void Set(double a = 0, double b = 0)
			{
				x = a;
				y = b;
			}
			public void Set(Vector2 v)
			{
				x = v.x;
				y = v.y;
			}
			public void Add(double a = 0, double b = 0)
			{
				x += a;
				y += b;
			}
			public void Add(Vector2 v)
			{
				x += v.x;
				y += v.y;
			}
			public Vector2 AddTo(double a = 0, double b = 0)
			{
				return new Vector2(x + a, y + b);
			}
			public Vector2 AddTo(Vector2 v)
			{
				return new Vector2(x + v.x, y + v.y);
			}
			public void Transposition()
			{
				double temp = x;
				x = y;
				y = temp;
			}
		}
		class Vector3
		{
			public double x, y, z;
			public Vector3(double a = 0, double b = 0, double c = 0)
			{
				x = a;
				y = b;
				z = c;
			}
			public void Set(double a = 0, double b = 0, double c = 0)
			{
				x = a;
				y = b;
				z = c;
			}
			public void Set(Vector3 v)
			{
				x = v.x;
				y = v.y;
				z = v.z;
			}
			public void Add(double a = 0, double b = 0, double c = 0)
			{
				x += a;
				y += b;
				z += c;
			}
			public void Add(Vector3 v)
			{
				x += v.x;
				y += v.y;
				z += v.z;
			}
		}
		class COLOR
		{
			static public ConsoleColor BLACK = ConsoleColor.Black;
			static public ConsoleColor DARKBLUE = ConsoleColor.DarkBlue;
			static public ConsoleColor DARKGREEN = ConsoleColor.DarkGreen;
			static public ConsoleColor DARKCYAN = ConsoleColor.DarkCyan;
			static public ConsoleColor DARKRED = ConsoleColor.DarkRed;
			static public ConsoleColor DARKMAGENTA = ConsoleColor.DarkMagenta;
			static public ConsoleColor DARKYELLOW = ConsoleColor.DarkYellow;
			static public ConsoleColor GRAY = ConsoleColor.Gray;
			static public ConsoleColor DARKGRAY = ConsoleColor.DarkGray;
			static public ConsoleColor BLUE = ConsoleColor.Blue;
			static public ConsoleColor GREEN = ConsoleColor.Green;
			static public ConsoleColor CYAN = ConsoleColor.Cyan;
			static public ConsoleColor RED = ConsoleColor.Red;
			static public ConsoleColor MAGENTA = ConsoleColor.Magenta;
			static public ConsoleColor YELLOW = ConsoleColor.Yellow;
			static public ConsoleColor WHITE = ConsoleColor.White;
		}
		class DxHashCode
		{
			public string hash = "";
			public void Set(string hash)
			{
				int a = 2;
				while (a < hash.Length)
					a *= 2;
				string offset = "";
				for (int i = 0; i < a - hash.Length; i++)
					offset += 0;
				this.hash = hash + offset;
			}
			public string Get()
			{
				return this.hash;
			}
			public int GetSize()
			{
				return hash.Length;
			}
		}
		class Sprite
		{
			public DxHashCode SpriteHash;
		}
	}
	abstract class Theatre
	{
		static private List<Scene> Scenes = new List<Scene>();
		static public void Merge(Scene s)
		{
			Scenes.Add(s);
		}
		static public void GetOverallInfo()
		{
			for (int i = 0; i < Scenes.Count; i++)
			{
				Console.WriteLine("[{0:X4}]\t[{1}]\t{2}", i, "Scene", Scenes[i].GetName());
				Scenes[i].GetSceneInfo();
			}
		}
	}
	class Scene
	{
		static public List<Layer> Layers = new List<Layer>();
		static public string background = "";

		private string name = "";

		public Scene()
		{
			Theatre.Merge(this);
			this.SetName("Scene");
		}
		public Scene(string name)
		{
			Theatre.Merge(this);
			this.SetName(name);
		}
		public string GetName()
		{
			return name;
		}
		public void SetName(string n)
		{
			name = n;
		}
		public void Add(Layer l)
		{
			l.SetName(l.GetName() == "null" ? "Layer" + Scene.Layers.Count : l.GetName());
			Layers.Add(l);
		}
		public void GetSceneInfo()
		{
			for (int i = 0; i < Layers.Count; i++)
			{
				Console.WriteLine("\t[{0:X4}]\t{1}\t", i, Layers[i].GetName());
				Layers[i].GetLayerInfo();
			}
		}
		public void Render()
		{
			Console.SetCursorPosition(0, 0);
			foreach (Layer layer in Layers)
				layer.Render();
		}
	}
	class Layer : GameObject
	{
		private List<RenderTypeObject> Objects = new List<RenderTypeObject>();
		private string layerName = "";
		
		public bool isVisible = true;
		
		public Layer()
		{
			layerName = "null";
		}
		public Layer(string name){
			layerName = name;
		}
		public string GetName()
		{
			return layerName;
		}
		public void SetName(string name)
		{
			foreach (Layer a in Scene.Layers)
				if (name.Equals(a.layerName))
				{
					Console.ForegroundColor = COLOR.RED;
					throw new Exception("Name " + name + " has already taken.");
				}
			layerName = name;
		}
		public void Add(RenderTypeObject g)
			{
				Objects.Add(g);
			}
		public void GetLayerInfo()
		{
			if (Objects.Count > 0) Console.WriteLine("\t\t{2} [{0:X4}]\t\t[{1}]\t\t\t[{3}]", "N", "type", "├", "name");
			for (int i = 0; i < Objects.Count; i++)
				Console.WriteLine("\t\t{2} [{0:X4}] \t[{1}] {3}", i, Objects[i], i == Objects.Count - 1 ? "└" : "├", Objects[i].name);
		}
		public void Render()
		{
			if (isVisible)
				foreach(RenderTypeObject obj in Objects)
				{
					obj.Render();
					Console.ResetColor();
				}
		}
	}
	class RenderTypeObject
	{
		public string name = "";
		public int width;
		public int height;

		public RenderTypeObject(string name = "")
		{
			this.name = name;
		}

		private Vector2 pos = new Vector2();
		public Vector2 position
		{
			get { return pos; }
			set
			{
				Translate((int)(value.x - pos.x), (int)(value.y - pos.y));
				pos = value;
			}
		}

		public ConsoleColor color = ConsoleColor.Black;
		public ConsoleColor fontColor = ConsoleColor.White;

		public void Translate(int a, int b)
		{
			Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;
			for (int y = 0; y < height; y++)
			{
				if (position.x + a > position.x)
					for (int x = 0; x < a; x++)
					{
						Console.SetCursorPosition(((int)position.x + x) * 2, (int)position.y + y);
						Console.Write("  ");
					}
				if (position.x + a < position.x)
					for (int x = 0; x < width - a; x++)
					{
						Console.SetCursorPosition(((int)position.x + x) * 2, (int)position.y + y);
						Console.Write("  ");
					}
			}
			for (int x = 0; x < width; x++)
			{
				if (position.y + b > position.y)
					for (int y = 0; y < b; y++)
					{
						Console.SetCursorPosition(((int)position.x + x) * 2, (int)position.y + y);
						Console.Write("  ");
					}
				if (position.y + b < position.y)
					for (int y = 0; y < height - b; y++)
					{
						Console.SetCursorPosition(((int)position.x + x) * 2, (int)position.y + y);
						Console.Write("  ");
					}
			}
			this.position.x += a;
			this.position.y += b;
		}
		public virtual void Render()
		{
			
			Console.SetCursorPosition((int)position.x, (int)position.y);
		}
	}
	class Label : RenderTypeObject
	{
		public List<string> text = new List<string>();
		
		public Label()
		{
			//string test = lines.Count;
		}

		public override void Render()
		{
			Console.BackgroundColor = color;
			Console.ForegroundColor = fontColor;

			for (var i = 0; i < text.Count; i++)
			{
				
				Console.SetCursorPosition((int)position.x * 2, (int)position.y + i);
				Console.Write(text[i]);
			}
		}
	}
	class GameObject : RenderTypeObject
	{
		public string name = "unnamed object (1)";
		
		public override void Render()
		{
			Console.BackgroundColor = Console.ForegroundColor = color;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Console.SetCursorPosition(((int)position.x + x) * 2, (int)position.y + y);
					Console.Write("##");
				}
			}
		}
		
	}
}
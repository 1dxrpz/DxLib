using System;
using DxLib;
using System.Collections.Generic;
using DxLib.Utils;
using DxEditor;

namespace ConsoleApp4
{
	
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Console.CursorVisible = false;
			Console.SetWindowSize(240, 60);

			//DxEditor.SpriteEditor.Run();
			
			var scene = new Scene();

			var layer1 = new Layer();
			var layer2 = new Layer();
			var layer3 = new Layer();

			scene.Add(layer2);
			scene.Add(layer1);
			scene.Add(layer3);

			GameObject player = new GameObject();
			layer1.Add(player);
			player.position = new Vector2(10, 5);
			player.width = 10;
			player.height = 10;
			player.color = ConsoleColor.Green;

			GameObject player1 = new GameObject();
			layer1.Add(player1);
			player1.position = new Vector2(20, 5);
			player1.width = 10;
			player1.height = 10;
			player1.color = ConsoleColor.Magenta;

			GameObject test = new GameObject();
			layer2.Add(test);
			test.position.Set(10, 6);
			test.width = 5;
			test.height = 5;
			test.color = ConsoleColor.Red;

			GameObject test2 = new GameObject();
			layer3.Add(test2);
			test2.position.Set(20, 6);
			test2.width = 5;
			test2.height = 5;
			test2.color = ConsoleColor.White;

			GameObject test3 = new GameObject();
			layer3.Add(test3);
			test3.position.Set(20, 16);
			test3.width = 5;
			test3.height = 5;
			test3.color = ConsoleColor.Blue;

			//Theatre.GetOverallInfo();

			Label t = new Label();
			t.text.Add("Player");
			t.text.Add("dxrpz - 100%");
			layer1.Add(t);

			scene.Render();
			while (true)
			{
				var key = Console.ReadKey().Key;
				if (key == ConsoleKey.LeftArrow)
					player.Translate(-1, 0);
				if (key == ConsoleKey.RightArrow)
					player.Translate(1, 0);
				if (key == ConsoleKey.UpArrow)
					player.Translate(0, -1);
				if (key == ConsoleKey.DownArrow)
					player.Translate(0, 1);

				if (key == ConsoleKey.A)
					player1.Translate(-1, 0);
				if (key == ConsoleKey.D)
					player1.Translate(1, 0);
				if (key == ConsoleKey.W)
					player1.Translate(0, -1);
				if (key == ConsoleKey.S)
					player1.Translate(0, 1);


				t.position = player.position.AddTo(2, -2);
				scene.Render();
			}
			
		}
	}
}
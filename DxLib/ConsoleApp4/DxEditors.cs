using DxLib;
using DxLib.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DxEditor
{
	class SpriteEditor
	{
		static ConsoleColor PrimaryColor = COLOR.WHITE;
		static ConsoleColor SecondaryColor = COLOR.RED;
		static public void Run()
		{
			Scene SpriteEditorScene = new Scene();
			Layer GUI = new Layer();

			SpriteEditorScene.Add(GUI);
			var border = new GameObject();
			border.color = ConsoleColor.White;
			border.position.Set(0, 16);
			border.width = 17;
			border.height = 1;

			var border2 = new GameObject();
			border2.color = ConsoleColor.White;
			border2.position.Set(16, 0);
			border2.width = 1;
			border2.height = 16;

			GUI.Add(border);
			GUI.Add(border2);

			var cursor = new GameObject();
			cursor.width = 2;
			cursor.height = 2;
			cursor.position.Set(2, 2);
			cursor.color = ConsoleColor.Red;

			GUI.Add(cursor);

			while (true)
			{
				var key = Console.ReadKey().Key;
				if (key == ConsoleKey.LeftArrow)
					cursor.position.x--;
				if (key == ConsoleKey.RightArrow)
					cursor.position.x++;
				if (key == ConsoleKey.UpArrow)
					cursor.position.y--;
				if (key == ConsoleKey.DownArrow)
					cursor.position.y++;
				SpriteEditorScene.Render();
			}
		}
		static public void ChangeColors()
		{
			ConsoleColor temp = PrimaryColor;
			PrimaryColor = SecondaryColor;
			SecondaryColor = temp;
		}
	}
}

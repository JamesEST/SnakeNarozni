using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using WMPLib;
using System.IO;
using System.IO.Ports;

namespace SnakeNarozni
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.Write("Напиши свое имя: ");
			string name = Console.ReadLine();

			Console.SetWindowSize(80,25);
            
            Walls walls = new Walls(80, 25);
            walls.draw();

			// Отрисовка точек			
			point p = new point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Drow();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');
			point food = foodCreator.CreateFood();
			food.draw();

			Params settings = new Params();
			Sounds sound = new Sounds(settings.GetResourceFolder());
			sound.Play();

			Sounds sound1 = new Sounds(settings.GetResourceFolder());
			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					food = foodCreator.CreateFood();
					food.draw();
					sound1.PlayEat();

				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			sound.Stop();
			WriteGameOver(name, snake.score);
			Console.ReadLine();
	
		}
		static void WriteGameOver(string name, int score)
		{
			
			Params settings = new Params();
			Sounds sound2 = new Sounds(settings.GetResourceFolder());
			sound2.PlayNo();
			Random rnd = new Random();
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			yOffset++;
			WriteText("Автор: Владислав Нарожний", xOffset + 2, yOffset++);
			WriteText("Сделано в Эстонии", xOffset + 5, yOffset++);
			WriteText("   Ваш результат: " + score, xOffset + 2, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			Console.WriteLine(score);
			using (var file = new StreamWriter("score.txt", true))
			{
				file.WriteLine("Name: " + name + " | Score:" + score);
				file.Close();
			}
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}

	}
}

﻿/*
 * Создано в SharpDevelop.
 * Пользователь: admin
 * Дата: 15.09.2018
 * Время: 10:27
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Drawing.Design;

namespace AI.MathMod.ComputerVision
{
	/// <summary>
	/// Description of ObjectGenerate.
	/// </summary>
	public class ObjectGenerate
	{
		
		Bitmap bmp;
		int _w, _h;
		Random rnd = new Random();
		
		public ObjectGenerate(int w = 100, int h = 100)
		{
			_w = w;
			_h = h;
		}
		
		/// <summary>
		/// Генерация изображения
		/// </summary>
		/// <returns>Вывод изображения</returns>
		public Bitmap Generate(int count)
		{
			bmp = new Bitmap(_w, _h);
			
			Graphics gr = Graphics.FromImage(bmp);
			int x = 10, y = 10, h = _h/count, w = _w/count, randForm;
			
			SolidBrush[] br = new SolidBrush[3];
			br[0] = new SolidBrush(Color.Red);
			br[1] = new SolidBrush(Color.Green);
			br[2] = new SolidBrush(Color.Blue);
			
			gr.FillRectangle(new SolidBrush(Color.White), 0, 0, _w, _h);
			
			for(int i = 0; i<count; i++)
			{
				randForm = rnd.Next(2);
				
				if(randForm == 0)
				gr.FillEllipse(br[rnd.Next(3)], 
				                 rnd.Next(_w-(w+1)),rnd.Next(_h-(h+1)),
				                 w, h);
				
				if(randForm == 1)
				gr.FillRectangle(br[rnd.Next(3)], 
				                 rnd.Next(_w-(w+1)),rnd.Next(_h-(h+1)),
				                 w, h);
				
			}
			
			return new Bitmap(bmp, _w, _h);
		}
		
	}
}

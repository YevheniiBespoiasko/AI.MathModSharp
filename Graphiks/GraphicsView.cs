﻿/*
 * Создано в SharpDevelop.
 * Пользователь: 01
 * Дата: 03.06.2017
 * Время: 14:12
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using AI.MathMod;
using ZedGraph;
using AI.MathMod.AdditionalFunctions;
using System.Drawing;
using System.Windows.Forms;


namespace AI.MathMod.Graphiks
{
	/// <summary>
	/// Description of GraphicsView.
	/// </summary>
	public static class GraphicsView
	{
		
		/// <summary>
		/// Строит график в контроле graph, по отсчетам funcSempl
		/// </summary>
		/// <param name="graph">Элемент интерфейса для вывода графика</param>
		/// <param name="funcSempl">Значения y</param>
		public static void Plot(ZedGraphControl graph, Vector funcSempl)
		{
			try{
			double[] y = funcSempl.Vecktor;
			double[] x = MathFunc.GenerateTheSequence(0,y.Length).Vecktor;
			
			graph.GraphPane.CurveList.Clear();
			graph.GraphPane.XAxis.Title.Text = "x";
			graph.GraphPane.YAxis.Title.Text = "f(x)";
			graph.GraphPane.Title.Text = "Функция";
			graph.GraphPane.XAxis.MajorGrid.IsVisible = true;
			graph.GraphPane.YAxis.MajorGrid.IsVisible = true;
			graph.GraphPane.AddCurve("Функция", x, y, Color.Red, SymbolType.None);
			graph.AxisChange ();
    		graph.Invalidate ();
			}
			catch{}
		}
		
		
	
		
		
		
		public static void Plot(ZedGraphControl graph, Vector y, Vector x, string nameFunc, string nameX, string nameY, Color colorLine)
		{
			try{
			double[] y1 = y.Vecktor;
			double[] x1 = x.Vecktor;
			graph.GraphPane.CurveList.Clear();
			graph.GraphPane.XAxis.Title.Text = nameX;
			graph.GraphPane.YAxis.Title.Text = nameY;
			graph.GraphPane.Title.Text = nameFunc;
			graph.GraphPane.XAxis.MajorGrid.IsVisible = true;
			graph.GraphPane.YAxis.MajorGrid.IsVisible = true;
			graph.GraphPane.AddCurve(nameFunc, x1, y1, colorLine, SymbolType.None);
			graph.AxisChange ();
    		graph.Invalidate ();
			}
			catch{}
		}
		
		
		
		
		public static void Plot(ZedGraphControl graph, Vector y, Vector x, string nameX, string nameY, Color colorLine)
		{
			try{
			double[] y1 = y.Vecktor;
			double[] x1 = x.Vecktor;
			graph.GraphPane.CurveList.Clear();
			graph.GraphPane.XAxis.Title.Text = nameX;
			graph.GraphPane.YAxis.Title.Text = nameY;
			graph.GraphPane.Title.Text = "Функция";
			graph.GraphPane.XAxis.MajorGrid.IsVisible = true;
			graph.GraphPane.YAxis.MajorGrid.IsVisible = true;
			graph.GraphPane.AddCurve("Функция", x1, y1, colorLine, SymbolType.None);
			graph.AxisChange ();
    		graph.Invalidate ();
			}
			catch{}
		}
		
		
		
		public static void Plot(ZedGraphControl graph, Vector y, Vector x, Color colorLine)
		{
			try{
			double[] y1 = y.Vecktor;
			double[] x1 = x.Vecktor;
			graph.GraphPane.CurveList.Clear();
			graph.GraphPane.XAxis.Title.Text = "x";
			graph.GraphPane.YAxis.Title.Text = "f(x)";
			graph.GraphPane.Title.Text = "Функция";
			graph.GraphPane.XAxis.MajorGrid.IsVisible = true;
			graph.GraphPane.YAxis.MajorGrid.IsVisible = true;
			graph.GraphPane.AddCurve("Функция", x1, y1, colorLine, SymbolType.None);
			graph.AxisChange ();
    		graph.Invalidate ();
			}
			catch{}
		}
		
		
		
		
		public static void Plot(ZedGraphControl graph, Vector y, Vector x)
		{
			try{
			double[] y1 = y.Vecktor;
			double[] x1 = x.Vecktor;
			graph.GraphPane.CurveList.Clear();
			graph.GraphPane.XAxis.Title.Text = "x";
			graph.GraphPane.YAxis.Title.Text = "f(x)";
			graph.GraphPane.Title.Text = "Функция";
			graph.GraphPane.XAxis.MajorGrid.IsVisible = true;
			graph.GraphPane.YAxis.MajorGrid.IsVisible = true;
			graph.GraphPane.AddCurve("Функция", x1, y1, Color.Red, SymbolType.None);
			graph.AxisChange ();
    		graph.Invalidate ();
			}
			catch{}
		}
		
		
		
		
		public static void Plot(Vector funcSempl)
		{
			VisualPlot vp = new VisualPlot(funcSempl);
			vp.Show();
		}
		
		public static void Plot(Vector y, Vector x, string nameX, string nameY, Color colorLine)
		{
			VisualPlot vp = new VisualPlot( y,  x, nameX, nameY, colorLine);
			vp.Show();
		}
		
		public static void Plot(Vector y, Vector x, string nameFunc, string nameX, string nameY, Color colorLine)
		{
			VisualPlot vp = new VisualPlot(y,  x, nameFunc, nameX, nameY, colorLine);
			vp.Show();
		}
		
		public static void Plot(Vector y, Vector x, Color colorLine)
		{
			VisualPlot vp = new VisualPlot(y,  x,  colorLine);
			vp.Show();
		}
		
		
		public static void Plot(Vector y, Vector x)
		{
			VisualPlot vp = new VisualPlot(y,  x);
			vp.Show();
		}
	}
}
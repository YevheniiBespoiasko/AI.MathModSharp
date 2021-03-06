﻿/*
 * Создано в SharpDevelop.
 * Пользователь: 01
 * Дата: 04.03.2017
 * Время: 18:00
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;

namespace AI.MathMod.ML.Regression
{
	
	/// <summary>
	/// Модель для линейной регрессии хранит k и b   
	/// f(x) = k*x+b;
	/// </summary>
	[Serializable]
	public class LinearRegressionModel
	{
		/// <summary>
		/// Тангенс угла наклона
		/// </summary>
		public double k{get; set;}
		/// <summary>
		/// Смещение относительно (0;0)
		/// </summary>
		public double b{get; set;}
	}
	
	
	
	
	
	
	
	
	/// <summary>
	/// Линейная регрессия
	/// </summary>
	public class LinearRegression
	{
		/// <summary>
		/// Парамметры линейной регрессии
		/// </summary>
		public LinearRegressionModel Lrm{get; set;}
		
		
		
		/// <summary>
		/// Обучающая выборка
		/// </summary>
		/// <param name="X">Вектор X(независимая переменная)</param>
		/// <param name="Y">Вектор Y(зависимая переменная)</param>
		public LinearRegression(Vector X, Vector Y)
		{
			Lrm = new LinearRegressionModel();
			Lrm.k = Statistic.Cov(X,Y)/Statistic.Dispers(X);
			Lrm.b = Statistic.ExpectedValue(Y)-Lrm.k*Statistic.ExpectedValue(X);
		}
		
		
		/// <summary>
		/// Вывод в строку
		/// </summary>
		/// <returns>Строка типа: f(x) = k*x+(b)</returns>
		public override string ToString()
		{
			return String.Format("f(x) ={0}*x+({1})", Lrm.k, Lrm.b);
		}
		
		/// <summary>
		/// Прогнозирование с помощью линейной модели
		/// </summary>
		/// <param name="x">Независимая переменная</param>
		/// <returns>Зависимая переменная</returns>
		public double Predict(double x)
		{
			return Lrm.k*x+Lrm.b;
		}
		
		/// <summary>
		/// Прогнозирование с помощью линейной модели
		/// </summary>
		/// <param name="X">Вектор независимых переменных</param>
		/// <returns>Вектор зависимых переменных</returns>
		public Vector Predict(Vector X)
		{
			Vector outp = new Vector(X.N);
			
			for (int i = 0; i < X.N; i++)
				outp[i] = Predict(X[i]);
			
			return outp;
		}
		
		
	}
}

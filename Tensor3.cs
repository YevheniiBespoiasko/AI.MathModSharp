using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AI.MathMod
{
    /// <summary>
    ///     ������������ ������ 3-�� �����, ��� ������� ���� ��������� ����
    /// </summary>
    [Serializable]
    public class Tensor3
    {
        
        public int Depth;
        public int Height;
        public double[] WeightGradients;
        public double[] Weights;
        public int Width;

        /// <summary>
        ///     ���������� ������� ���������� �������
        /// </summary>
        /// <param name="width">������</param>
        /// <param name="height">������</param>
        /// <param name="depth">�������</param>
        public Tensor3(int width, int height, int depth)
        {
            
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
            
            //���������� ��������� � �������
            var n = width * height * depth;
            this.Weights = new double[n];
            this.WeightGradients = new double[n];

            // ������������ ���� ����������� ��� ������������ ���������
            // ������ ������� �������, ����� ������� � ������� �����������
            // ������ ����� ����� ������ ������� ���������
            var scale = Math.Sqrt(1.0 / (width * height * depth));

            for (var i = 0; i < n; i++)
            {
                this.Weights[i] = RandomUtilities.Randn(0.0, scale);
            }
        }

        /// <summary>
        /// ������ 3-�� �����
        /// </summary>
        /// <param name="width">������</param>
        /// <param name="height">������</param>
        /// <param name="depth">�������</param>
        /// <param name="c">�������� ������� ���������������� ������</param>
        public Tensor3(int width, int height, int depth, double c)
        {
            
            this.Width = width;
            this.Height = height;
            this.Depth = depth;

            var n = width * height * depth;
            this.Weights = new double[n];
            this.WeightGradients = new double[n];

            if (c != 0)
            {
                for (var i = 0; i < n; i++)
                {
                    this.Weights[i] = c;
                }
            }
        }


        /// <summary>
        /// ������������� � ������ ���������� IList<double>
        /// </summary>
        /// <param name="weights">��������</param>
        public Tensor3(IList<double> weights)
        {
            this.Width = 1;
            this.Height = 1;
            this.Depth = weights.Count;

            this.Weights = new double[this.Depth];
            this.WeightGradients = new double[this.Depth];

            for (var i = 0; i < this.Depth; i++)
            {
                this.Weights[i] = weights[i];
            }
        }


        public double Get(int x, int y, int d)
        {
            var ix = ((this.Width * y) + x) * this.Depth + d;
            return this.Weights[ix];
        }




        public void Set(int x, int y, int d, double v)
        {
            var ix = ((this.Width * y) + x) * this.Depth + d;
            this.Weights[ix] = v;
        }

        public void Add(int x, int y, int d, double v)
        {
            var ix = ((this.Width * y) + x) * this.Depth + d;
            this.Weights[ix] += v;
        }

        public double GetGradient(int x, int y, int d)
        {
            var ix = ((this.Width * y) + x) * this.Depth + d;
            return this.WeightGradients[ix];
        }

        public void SetGradient(int x, int y, int d, double v)
        {
            var ix = ((this.Width * y) + x) * this.Depth + d;
            this.WeightGradients[ix] = v;
        }

        public void AddGradient(int x, int y, int d, double v)
        {
            var ix = ((this.Width * y) + x) * this.Depth + d;
            this.WeightGradients[ix] += v;
        }

        public Tensor3 CloneAndZero()
        {
            return new Tensor3(this.Width, this.Height, this.Depth, 0.0);
        }

        public Tensor3 Clone()
        {
            var Tensor3 = new Tensor3(this.Width, this.Height, this.Depth, 0.0);
            var n = this.Weights.Length;

            for (var i = 0; i < n; i++)
            {
               Tensor3.Weights[i] = this.Weights[i];
            }

            return Tensor3;
        }

        public void AddFrom(Tensor3 Tensor3)
        {
            for (var i = 0; i < this.Weights.Length; i++)
            {
                this.Weights[i] += Tensor3.Weights[i];
            }
        }

        public void AddGradientFrom(Tensor3 Tensor3)
        {
            for (var i = 0; i < this.WeightGradients.Length; i++)
            {
                this.WeightGradients[i] += Tensor3.WeightGradients[i];
            }
        }

        public void AddFromScaled(Tensor3 Tensor3, double a)
        {
            for (var i = 0; i < this.Weights.Length; i++)
            {
                this.Weights[i] += a * Tensor3.Weights[i];
            }
        }

        public static Tensor3 operator +(Tensor3 A, double b)
        {
            Tensor3 newTensor = new Tensor3(A.Width, A.Height, A.Depth);

            for (int i = 0; i < A.Weights.Length; i++)
            {
                newTensor.Weights[i] = A.Weights[i] + b;
            }

            return newTensor;
        }

        public static Tensor3 operator+ (double b, Tensor3 A)
        {
            Tensor3 newTensor = new Tensor3(A.Width, A.Height, A.Depth);

            for (int i = 0; i < A.Weights.Length; i++)
            {
                newTensor.Weights[i] = A.Weights[i] + b;
            }

            return newTensor;
        }



        public static Tensor3 operator- (double b, Tensor3 A)
        {
            Tensor3 newTensor = new Tensor3(A.Width, A.Height, A.Depth);

            for (int i = 0; i < A.Weights.Length; i++)
            {
                newTensor.Weights[i] = b - A.Weights[i];
            }

            return newTensor;
        }


        public static Tensor3 operator- (Tensor3 A, double b)
        {
            Tensor3 newTensor = new Tensor3(A.Width, A.Height, A.Depth);

            for (int i = 0; i < A.Weights.Length; i++)
            {
                newTensor.Weights[i] = A.Weights[i] - b;
            }

            return newTensor;
        }
        public void SetConst(double c)
        {
            for (var i = 0; i < this.Weights.Length; i++)
            {
            	this.Weights[i] += c;
            }
        }
    }
}
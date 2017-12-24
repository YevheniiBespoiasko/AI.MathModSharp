using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AI.MathMod
{
    /// <summary>
    ///     ������������ ������ 3-�� �����, ��� ������� ���� ��������� ����
    /// </summary>
    [Serializable]
    public class Tensor
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
        public Tensor(int width, int height, int depth)
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
        public Tensor(int width, int height, int depth, double c)
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
        public Tensor(IList<double> weights)
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

        public Tensor CloneAndZero()
        {
            return new Tensor(this.Width, this.Height, this.Depth, 0.0);
        }

        public Tensor Clone()
        {
            var Tensor3 = new Tensor(this.Width, this.Height, this.Depth, 0.0);
            var n = this.Weights.Length;

            for (var i = 0; i < n; i++)
            {
               Tensor3.Weights[i] = this.Weights[i];
            }

            return Tensor3;
        }

        public void AddFrom(Tensor Tensor3)
        {
            for (var i = 0; i < this.Weights.Length; i++)
            {
                this.Weights[i] += Tensor3.Weights[i];
            }
        }

        public void AddGradientFrom(Tensor Tensor3)
        {
            for (var i = 0; i < this.WeightGradients.Length; i++)
            {
                this.WeightGradients[i] += Tensor3.WeightGradients[i];
            }
        }

        public void AddFromScaled(Tensor Tensor3, double a)
        {
            for (var i = 0; i < this.Weights.Length; i++)
            {
                this.Weights[i] += a * Tensor3.Weights[i];
            }
        }

        public static Tensor operator +(Tensor A, double b)
        {
            Tensor newTensor = new Tensor(A.Width, A.Height, A.Depth);

            for (int i = 0; i < A.Weights.Length; i++)
            {
                newTensor.Weights[i] = A.Weights[i] + b;
            }

            return newTensor;
        }

        public static Tensor operator+ (double b, Tensor A)
        {
            Tensor newTensor = new Tensor(A.Width, A.Height, A.Depth);

            for (int i = 0; i < A.Weights.Length; i++)
            {
                newTensor.Weights[i] = A.Weights[i] + b;
            }

            return newTensor;
        }


		
		public static Tensor operator * (Tensor A, double k)
		{
			Tensor C = new Tensor(A.Width, A.Height, A.Depth);
		
			for(int i = 0; i < A.Weights.Length; i++)
				 C.Weights[i] = A.Weights[i]*k;
			
			return C;
		}
        
		
		public static Tensor operator - (Tensor A, double k)
		{
			Tensor C = new Tensor(A.Width, A.Height, A.Depth);
		
			for(int i = 0; i < A.Weights.Length; i++)
				 C.Weights[i] = A.Weights[i]-k;
			
			return C;
		}
		
		
		public static Tensor operator / (Tensor A, double k)
		{
			Tensor C = new Tensor(A.Width, A.Height, A.Depth);
		
			for(int i = 0; i < A.Weights.Length; i++)
				 C.Weights[i] = A.Weights[i]/k;
			
			return C;
		}
        
		
		public Vector ToVector()
		{
			return new Vector(Weights);
		}
		
		
        public static Tensor operator- (double b, Tensor A)
        {
            Tensor newTensor = new Tensor(A.Width, A.Height, A.Depth);

            for (int i = 0; i < A.Weights.Length; i++)
            {
                newTensor.Weights[i] = b - A.Weights[i];
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
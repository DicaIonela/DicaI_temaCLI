//using Laborator4;
//using OpenTK;
//using OpenTK.Graphics.OpenGL;
//using System.Drawing;

//namespace Laborator4
//{
//    class Triangle3D
//    {
//        private Vector3 pointA;
//        private Vector3 pointB;
//        private Vector3 pointC;
//        private Color color;
//        private bool visibility;
//        private float linewidth;
//        private float pointsize;
//        private Randomizer localRando;
//        private PolygonMode polMode;

//        public Triangle3D(Randomizer _r)
//        {
//            localRando = _r;
//            pointA = _r.Generate3DPoint();
//            pointB = _r.Generate3DPoint();
//            pointC = _r.Generate3DPoint();
//            //olor = _r.GenerateColor();

//            Inits();
//        }

//        private void Inits()
//        {
//            visibility = true;
//            linewidth = 3.0f;
//            pointsize = 3.0f;
//            polMode = PolygonMode.Fill;
//        }

//        public void Draw()
//        {
//            if (visibility)
//            {
//                GL.PointSize(pointsize);
//                GL.LineWidth(linewidth);
//                GL.PolygonMode(MaterialFace.FrontAndBack, polMode);
//                GL.Begin(PrimitiveType.Triangles);
//                GL.Color3(color);
//                GL.Vertex3(pointA);
//                GL.Vertex3(pointB);
//                GL.Vertex3(pointC);
//                GL.End();
//            }
//        }

//        public void ToggleVisibility()
//        {
//            visibility = !visibility;
//        }

//        public void TogglePolygonMode()
//        {
//            if (polMode == PolygonMode.Fill)
//            {
//                polMode = PolygonMode.Line;
//            }
//            else if (polMode == PolygonMode.Line)
//            {
//                polMode = PolygonMode.Point;
//            }
//            else
//            {
//                polMode = PolygonMode.Fill;
//            }
//        }

//        public void DiscoMode()
//        {
//            color = localRando.RandomColor();
//        }

//        public void Morph()
//        {
//            int select = localRando.GeneratePositiveInt(3);
//            Vector3 tmp = localRando.Generate3DPoint();

//            if (select == 0)
//            {
//                pointA = tmp;
//            }
//            else
//            {
//                if (select == 1)
//                {
//                    pointB = tmp;
//                }
//                else
//                {
//                    pointC = tmp;
//                }
//            }
//        }

//        public void Morph2()
//        {
//            Vector3 tmp = localRando.Generate3DPoint(5);
//            pointC = tmp;
//        }

//    }
//}

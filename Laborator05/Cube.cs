using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


namespace Laborator05

{
    class Cube
    {

        private bool visibility;
        private bool hasError;
        List<Vector3> coordonate = new List<Vector3>();
        List<Color> colors = new List<Color> { Color.Red, Color.Blue, Color.Green, Color.Brown, Color.Yellow, Color.Gray };
        Randomizer rand = new Randomizer();
        public Cube(string NumeFisier)
        {
            try
            {
                coordonate = LoadFromObjFile(NumeFisier);

                if (coordonate.Count == 0)
                {
                    Console.WriteLine("Crearea obiectului a esuat: obiect negasit/coordonate lipsa!");
                    return;
                }
                visibility = true;

                hasError = false;
                Console.WriteLine( coordonate.Count.ToString() + " vertexuri disponibile!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: <" + NumeFisier + "> lipseste!");
                hasError = true;
            }
        }
        public Cube()
        {
            visibility = true;
            hasError = false;
        }
        public void Draw2()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Silver);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.Color3(Color.Honeydew);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            GL.Color3(Color.Moccasin);

            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);

            GL.Color3(Color.IndianRed);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);

            GL.Color3(Color.PaleVioletRed);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);

            GL.Color3(Color.ForestGreen);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);

            GL.End();
        }
        public void ToggleVisibility()
        {
            if (visibility == true)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
        public void Show()
        {
            visibility = true;
        }
        public void Hide()
        {
            visibility = true;
        }
        private List<Vector3> LoadFromObjFile(string NumeFisier)
        {
            List<Vector3> lst = new List<Vector3>();
            string[] lines = System.IO.File.ReadAllLines(NumeFisier);
            //for(int j=0; j<=lines.Length;j++)
            for (int i = 0; i < lines.Length; i++)
            {
                string[] coord = lines[i].Trim().Split(' ');

                float xval = float.Parse(coord[0]);
                float yval = float.Parse(coord[1]);
                float zval = float.Parse(coord[2]);
                lst.Add(new Vector3(xval, yval, zval));

            }

            return lst;
        }

        public void Draw()
        {
            if (hasError == false && visibility == true)
            {
                /*
                 /// metorada in care se foloseste foreach
                GL.Begin(PrimitiveType.Quads);
                foreach (var vert in coordonate)
                {
                    GL.Vertex3(vert);
                    GL.Color4(0.1,1,0.7,1);
                }

                GL.End();*/
                GL.Begin(PrimitiveType.Quads);


                for (int i = 0; i < coordonate.Count; i += 4)
                    for (int j = i / 4; j < colors.Count; j++)
                    {
                        GL.Color3(colors[j]);
                        GL.Vertex3(coordonate[i]);
                        GL.Vertex3(coordonate[i + 1]);
                        GL.Vertex3(coordonate[i + 2]);
                        GL.Vertex3(coordonate[i + 3]);

                    }

                GL.End();
            }
        }

        /*
         * Laborator 4 cerinta 3
         * functie care deseneaza un cub si genereaza random culorile lui
         *  mecanism de modificare a culorilor
         */
        public void DrawRand()
        {
            Randomizer rand = new Randomizer();
            if (hasError == false && visibility == true)
            {

                GL.Begin(PrimitiveType.Quads);
                foreach (var vert in coordonate)
                {
                    GL.Vertex3(vert);
                    GL.Color3(rand.RandomColor());
                }

                GL.End();
            }


        }

        /// <summary>
        /// Functii care schimba culoarea fetelor cubului
        /// LAborator4- cerinta 1
        /// </summary>

        #region ChangeColorFace
        public void ChangeColorFace1()
        {
            colors[0] = rand.RandomColor();

        }
        public void ChangeColorFace2()
        {
            colors[1] = rand.RandomColor();

        }
        public void ChangeColorFace3()
        {
            colors[2] = rand.RandomColor();

        }
        public void ChangeColorFace4()
        {
            colors[3] = rand.RandomColor();

        }
        public void ChangeColorFace5()
        {
            colors[4] = rand.RandomColor();

        }
        public void ChangeColorFace6()
        {
            colors[5] = rand.RandomColor();

        }
        #endregion
    }


}
using System;
using System.Drawing;
using System.Security.Policy;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_immediate_mode
{
    class ImmediateMode : GameWindow
    {

        private const int XYZ_SIZE = 75;
        private int redValue = 255;   // valoare maximă pentru roșu
        private int greenValue = 0;   // valoare minimă pentru verde
        private int blueValue = 0;    // valoare minimă pentru albastru
        private int alphaValue = 255; // Valoare maximă pentru canalul de transparență

        private Color[] vertexColors = new Color[3]
         {
            Color.FromArgb(255, 0, 0, 255), // Vertex 1 (Roșu)
            Color.FromArgb(0, 255, 0, 255), // Vertex 2 (Verde)
            Color.FromArgb(0, 0, 255, 255)  // Vertex 3 (Albastru)
         };

        private int selectedVertex = 0; // Indicele vertex-ului selectat

        public ImmediateMode() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            Console.WriteLine("OpenGl versiunea: " + GL.GetString(StringName.Version));
            Title = "OpenGl versiunea: " + GL.GetString(StringName.Version) + " (mod imediat)";

        }

        /**Setare mediu OpenGL și încarcarea resurselor (dacă e necesar) - de exemplu culoarea de
           fundal a ferestrei 3D.
           Atenție! Acest cod se execută înainte de desenarea efectivă a scenei 3D. */
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.FloralWhite);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);


            string projectDirectory = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;

            string triangleFilePath = System.IO.Path.Combine(projectDirectory, "triunghi.txt");

            LoadTriangleCoordinates(triangleFilePath);
        }
        private Vector3[] triangleVertices;
        private void LoadTriangleCoordinates(string filePath)
        {
            try
            {

                var lines = System.IO.File.ReadAllLines(filePath);
                triangleVertices = new Vector3[3];

                for (int i = 0; i < 3; i++)
                {
                    var parts = lines[i].Split(' ');
                    float x = float.Parse(parts[0]);
                    float y = float.Parse(parts[1]);
                    float z = float.Parse(parts[2]);
                    triangleVertices[i] = new Vector3(x, y, z);
                    Console.WriteLine($"Loaded vertex {i}: {triangleVertices[i]}"); // Debug output
                
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la incarcarea coordonatelor: " + ex.Message);
            }
        }

        /**Inițierea afișării și setarea viewport-ului grafic. Metoda este invocată la redimensionarea
           ferestrei. Va fi invocată o dată și imediat după metoda ONLOAD()!
           Viewport-ul va fi dimensionat conform mărimii ferestrei active (cele 2 obiecte pot avea și mărimi
           diferite). */
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 1000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);


        }

        /** Secțiunea pentru "game logic"/"business logic". Tot ce se execută în această secțiune va fi randat
            automat pe ecran în pasul următor - control utilizator, actualizarea poziției obiectelor, etc. */
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (keyboard[Key.Escape])
            {
                Exit();
            }

            //if (keyboard[Key.R]) triangleColor = Color.Red;
            //if (keyboard[Key.G]) triangleColor = Color.Green;
            //if (keyboard[Key.B]) triangleColor = Color.Blue;
            //if (keyboard[Key.Y]) triangleColor = Color.Yellow;
            //if (keyboard[Key.C]) triangleColor = Color.Cyan;
            //if (keyboard[Key.M]) triangleColor = Color.Magenta;
            switch (true)
            {
                
                case var _ when keyboard[Key.Up] && keyboard[Key.R]:
                    redValue = Math.Min(redValue + 10, 255);
                    Console.WriteLine("R=" + redValue + "\tG=" + greenValue + "\tB=" + blueValue);
                    break;
                case var _ when keyboard[Key.Down] && keyboard[Key.R]:
                    redValue = Math.Max(redValue - 10, 0);
                    Console.WriteLine("R=" + redValue + "\tG=" + greenValue + "\tB=" + blueValue);

                    break;
                case var _ when keyboard[Key.Down] && keyboard[Key.G]:
                    greenValue = Math.Max(greenValue - 10, 0);
                    Console.WriteLine("R=" + redValue + "\tG=" + greenValue + "\tB=" + blueValue);
                    break;
                case var _ when keyboard[Key.Up] && keyboard[Key.G]:
                    greenValue = Math.Min(greenValue + 10, 255);
                    Console.WriteLine("R=" + redValue + "\tG=" + greenValue + "\tB=" + blueValue);
                    break;
                case var _ when keyboard[Key.Up] && keyboard[Key.B]:
                    blueValue = Math.Min(blueValue + 10, 255);
                    Console.WriteLine("R=" + redValue + "\tG=" + greenValue + "\tB=" + blueValue);
                    break;
                case var _ when keyboard[Key.Down] && keyboard[Key.B]:
                    blueValue = Math.Max(blueValue - 10, 0);
                    Console.WriteLine("R=" + redValue + "\tG=" + greenValue + "\tB=" + blueValue);
                    break;
                case var _ when keyboard[Key.Up] && keyboard[Key.A]:
                    alphaValue = Math.Min(alphaValue + 10, 255); // Crește transparența
                    Console.WriteLine("Alpha=" + alphaValue);
                    break;
                case var _ when keyboard[Key.Down] && keyboard[Key.A]:
                    alphaValue = Math.Max(alphaValue - 10, 0); // Scade transparența
                    Console.WriteLine("Alpha=" + alphaValue);
                    break;
                    



        }
        }
        //private void PrintVertexColors()
        //{
        //    Console.Clear();
        //    for (int i = 0; i < vertexColors.Length; i++)
        //    {
        //        Console.WriteLine($"Vertex {i + 1}: R={vertexColors[i].R}, G={vertexColors[i].G}, B={vertexColors[i].B}");
        //    }
        //}

        /** Secțiunea pentru randarea scenei 3D. Controlată de modulul logic din metoda ONUPDATEFRAME().
            Parametrul de intrare "e" conține informatii de timing pentru randare. */
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            //GL.Clear(ClearBufferMask.ColorBufferBit);
            //GL.Clear(ClearBufferMask.DepthBufferBit);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            DrawAxes();
            DrawTriangle();
            DrawObjects();



            // Se lucrează în modul DOUBLE BUFFERED - câtă vreme se afișează o imagine randată, o alta se randează în background apoi cele 2 sunt schimbate...
            SwapBuffers();
        }

        private void DrawAxes()
        {

            //GL.LineWidth(3.0f);

            //// Desenează axa Ox (cu roșu).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(XYZ_SIZE, 0, 0);
            GL.End();

            // Desenează axa Oy (cu galben).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, XYZ_SIZE, 0); ;
            GL.End();

            // Desenează axa Oz (cu verde).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, XYZ_SIZE);
            GL.End();
        }
        private void DrawTriangle()
        {
            GL.Begin(PrimitiveType.Triangles);


            foreach (var vertex in triangleVertices)
            {
                GL.Color4(redValue / 255f, greenValue / 255f, blueValue / 255f, alphaValue / 255f);
                GL.Vertex3(vertex.X, vertex.Y, vertex.Z);
            }

            GL.End();
        }

        private void DrawObjects()
        {



        }


        [STAThread]
        static void Main(string[] args)
        {

            /**Utilizarea cuvântului-cheie "using" va permite dealocarea memoriei o dată ce obiectul nu mai este
               în uz (vezi metoda "Dispose()").
               Metoda "Run()" specifică cerința noastră de a avea 30 de evenimente de tip UpdateFrame per secundă
               și un număr nelimitat de evenimente de tip randare 3D per secundă (maximul suportat de subsistemul
               grafic). Asta nu înseamnă că vor primi garantat respectivele valori!!!
               Ideal ar fi ca după fiecare UpdateFrame să avem si un RenderFrame astfel încât toate obiectele generate
               în scena 3D să fie actualizate fără pierderi (desincronizări între logica aplicației și imaginea randată
               în final pe ecran). */
            using (ImmediateMode example = new ImmediateMode())
            {
                example.Run(30.0, 0.0);
            }
        }
    }

}

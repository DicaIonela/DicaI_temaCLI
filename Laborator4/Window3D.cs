//Min 18.24
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Laborator4
{
    class Window3D : GameWindow
    {

        private KeyboardState previousKeyboard;
        private MouseState previousMouse;
        private readonly Randomizer rando;
        //private Triangle3D firstTriangle;
        private readonly Axes ax;
        private readonly Grid grid;
        private readonly Camera3DIsometric cam;
        private Objectoid obj;
        private List<Objectoid> rainOfObjects;

        private bool GRAVITY = true;

        // CONST
        private Color DEFAULT_BKG_COLOR = Color.FromArgb(49,50,51);


        public Window3D() : base(1280, 768, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            rando = new Randomizer();
            ax = new Axes();
            grid = new Grid();
            cam= new Camera3DIsometric();
            rainOfObjects= new List<Objectoid>();

            DisplayHelp();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // setare fundal
            GL.ClearColor(DEFAULT_BKG_COLOR);

            // setare viewport
            GL.Viewport(0, 0, this.Width, this.Height);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 512);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            cam.SetCamera();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);


            // LOGIC CODE
            KeyboardState currentKeyboard = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();

            if (currentKeyboard[Key.Escape])
            {
                Exit();
            }

            if (currentKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                DisplayHelp();
            }

            if (currentKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                GL.ClearColor(DEFAULT_BKG_COLOR);
                ax.Show();
                grid.Show();
            }

            if (currentKeyboard[Key.K] && !previousKeyboard[Key.K])
            {
                ax.ToggleVisibility();
            }

            // triangle manipulation
            if (currentKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                GL.ClearColor(rando.RandomColor());
            }

            if (currentKeyboard[Key.V] && !previousKeyboard[Key.V])
            {
                grid.ToggleVisibility();
            }
            if (currentKeyboard[Key.G] && !previousKeyboard[Key.G])
            {
                //foreach (Objectoid obj in rainOfObjects)
                //{
                //    obj.ToggleGravity();
                //}
                GRAVITY = !GRAVITY;
            }

            //camera control isometric mode
            if (currentKeyboard[Key.W])
            {
                cam.MoveForward();
            }

            if (currentKeyboard[Key.S])
            {
                cam.MoveBackward();
            }

            if (currentKeyboard[Key.A])
            {
                cam.MoveLeft();
            }
            if (currentKeyboard[Key.D])
            {
                cam.MoveRight();
            }
            if (currentKeyboard[Key.Q])
            {
                cam.MoveUp();
            }
            if (currentKeyboard[Key.E])
            {
                cam.MoveDown();
            }
            if (currentMouse[MouseButton.Left] && previousMouse[MouseButton.Left])
            {
                rainOfObjects.Add(new Objectoid(GRAVITY));
            }
            if (currentMouse[MouseButton.Right] && previousMouse[MouseButton.Right])
            {
                rainOfObjects.Clear();
            }
            foreach (Objectoid obj in rainOfObjects)
            {
                obj.UpdatePosition(GRAVITY);
            }

            previousKeyboard = currentKeyboard;
            previousMouse= currentMouse;
            // END logic code
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // RENDER CODE
            grid.Draw();
            ax.Draw();
            //Objectoid obj = new Objectoid();
            //obj.Draw();
            foreach(Objectoid obj in rainOfObjects)
            {
                obj.Draw();
            }

            // END render code
            SwapBuffers();

        }

        private void DisplayHelp()
        {
            Console.WriteLine("\n     MENU");
            Console.WriteLine(" H - meniu");
            Console.WriteLine(" ESC - parasire aplicatie");
            Console.WriteLine(" R - reseteaza scena la valori implicite");
            Console.WriteLine(" B - schimbare culoare de fundal");
            Console.WriteLine(" V - schimbare vizibilitate grid");
            Console.WriteLine(" W,A,S,D,Q,E - deplasare camera(isometric)");
            Console.WriteLine(" K - schimbare vizibilitate sistem de axe");
            Console.WriteLine(" Mouse clic stanga - genereaza un nou obiect la o inatime aleatoare");
            Console.WriteLine(" Mouse clic dreapta - curata lista de obiecte");
            Console.WriteLine(" G - manipuleaza gravitatia");
        }

    }
}

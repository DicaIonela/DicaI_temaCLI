using Laborator05;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace Laborator05
{
    /// <summary>
    /// The graphic window. Contains the canvas (viewport to be draw).
    /// </summary>
    class Window3D : GameWindow
    {

        Axes xyz;

        Cube cube;
        Cube cube2;

        bool drawRand = false;
        bool changecolor = false;
        KeyboardState lastKeyPress;
        private const int XYZ_SIZE = 75;

        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

            xyz = new Axes();
            cube = new Cube();
            cube2 = new Cube("Cube.txt");
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (mouse[MouseButton.Left])
            {
                Console.WriteLine("Click non-accelerat (" + mouse.X + "," + mouse.Y + "); accelerat (" + mouse.X + "," + mouse.Y + ")");
                IntPtr pix = new IntPtr();
                GL.ReadPixels(mouse.X, mouse.Y, 1, 1, PixelFormat.Rgb, PixelType.Int, pix);
                Console.WriteLine("Pixel colour (" + IntPtr.Size + " - 32 or 64 bits process);");
                Console.WriteLine("");
            }


            // Se utilizeaza mecanismul de control input oferit de OpenTK (include perifcerice multiple, inclusiv
            // pentru gaminig - gamepads, joysticks, etc.).
            if (keyboard[Key.Escape])
            {
                Exit();
                return;
            }

            if (keyboard[Key.P] && !keyboard.Equals(lastKeyPress))
            {
                // Ascundere comandată, prin apăsarea unei taste - cu verificare de remanență! Timpul de reacție
                // uman << calculator.
                xyz.ToggleVisibility();
            }


            //la apasarea tastei r se vor schimba fetele cubului 
            if (keyboard[Key.R] && !keyboard.Equals(lastKeyPress))
            {

                cube2.ChangeColorFace6();
                cube2.ChangeColorFace5();
                cube2.ChangeColorFace4();

            }
            if (keyboard[Key.T] && !keyboard.Equals(lastKeyPress))
            {
                drawRand = true;
            }


            lastKeyPress = keyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            xyz.DrawMe();



            //cube.Draw2();

            cube2.Draw();


            SwapBuffers();
        }
    }
}
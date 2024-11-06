using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Laborator4
{
    /// <summary>
    /// This class renders an XYZ coordinates system for the 3D scene.
    /// </summary>
    class Axes
    {
        private bool myVisibility;

        private const int AXIS_LENGTH = 75;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Axes()
        {
            myVisibility = true;
        }

        /// <summary>
        /// This methods handles the drawing of the object. Must be called - always - from OnRenderFrame() method! The drawing can be unconditional.
        /// </summary>
        public void Draw()
        {
            if (myVisibility)
            {
                GL.LineWidth(1.0f);

                GL.Begin(PrimitiveType.Lines);
                GL.Color3(Color.Red);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(AXIS_LENGTH, 0, 0);
                GL.Color3(Color.ForestGreen);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, AXIS_LENGTH, 0);
                GL.Color3(Color.RoyalBlue);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, AXIS_LENGTH);
                GL.End();
            }
        }

        /// <summary>
        /// Sets visibility of the object ON.
        /// </summary>
        public void Show()
        {
            myVisibility = true;
        }

        /// <summary>
        /// Sets visibility of the object OFF.
        /// </summary>
        public void Hide()
        {
            myVisibility = false;
        }

        /// <summary>
        /// Toggles the myVisibility of the object. Once triggered, the attribute is applied automatically on drawing.
        /// </summary>
        public void ToggleVisibility()
        {
            myVisibility = !myVisibility;
        }
    }
}

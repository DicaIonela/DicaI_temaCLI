using System.Drawing;
namespace Laborator_05
{
    class VertexPoint
    {
        public int coordX;
        public int coordY;
        public int coordZ;
        public Color pointColor;

        public VertexPoint()
        {
            coordX = 0;
            coordY = 0;
            coordZ = 0;
            pointColor = Color.Black;
        }

        public VertexPoint(int _x, int _y, int _z)
        {
            coordX = _x;
            coordY = _y;
            coordZ = _z;
            pointColor = Color.Black;
        }

        public VertexPoint(int _x, int _y, int _z, Color _color)
        {
            coordX = _x;
            coordY = _y;
            coordZ = _z;
            pointColor = _color;
        }

        public void SetColor(Color _color)
        {
            pointColor = _color;
        }

        public void SetX(int _x)
        {
            coordX = _x;
        }

        public void SetY(int _y)
        {
            coordX = _y;
        }

        public void SetZ(int _z)
        {
            coordX = _z;
        }

    }
}
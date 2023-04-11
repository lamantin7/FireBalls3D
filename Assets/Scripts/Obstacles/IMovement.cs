

namespace Obstacles
{
    internal interface IMovement
    {
        float Speed { get; }
        void Move(float speed);
    }
}

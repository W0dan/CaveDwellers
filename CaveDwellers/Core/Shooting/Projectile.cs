using CaveDwellers.Resources;

namespace CaveDwellers.Core.Shooting
{
    public abstract class Projectile
    {
        private readonly ICanShootAProjectile _firedBy;
        private readonly double _direction;

        protected Projectile(ICanShootAProjectile firedBy, double direction)
        {
            _firedBy = firedBy;
            _direction = direction;
        }

        public ICanShootAProjectile FiredBy
        {
            get { return _firedBy; }
        }

        protected abstract ImageName Sprite { get; }
    }
}
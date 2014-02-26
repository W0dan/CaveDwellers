using CaveDwellers.Resources;

namespace CaveDwellers.Core.Shooting
{
    public abstract class Projectile
    {
        private readonly ICanShootAProjectile _firedBy;

        protected Projectile(ICanShootAProjectile firedBy)
        {
            _firedBy = firedBy;
        }

        public ICanShootAProjectile FiredBy
        {
            get { return _firedBy; }
        }

        protected abstract ImageName Sprite { get; }
    }
}
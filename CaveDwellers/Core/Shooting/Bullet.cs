using CaveDwellers.Resources;

namespace CaveDwellers.Core.Shooting
{
    public class Bullet : Projectile
    {
        public Bullet(ICanShootAProjectile firedBy, double direction) : base(firedBy, direction)
        {
        }


        protected override ImageName Sprite
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
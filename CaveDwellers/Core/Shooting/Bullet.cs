using CaveDwellers.Resources;

namespace CaveDwellers.Core.Shooting
{
    public class Bullet : Projectile
    {
        public Bullet(ICanShootAProjectile firedBy) : base(firedBy)
        {
        }


        protected override ImageName Sprite
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
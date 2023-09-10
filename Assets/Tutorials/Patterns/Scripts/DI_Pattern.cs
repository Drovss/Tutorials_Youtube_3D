using UnityEngine;

namespace Tutorials.Patterns.Scripts
{
    public class DI_Pattern
    {
        private Gun _gun = new Gun(new Bullet(10));
        private Gun _gun2 = new Gun(new BulletSupper(10));
    }

    public class Gun
    {
        private readonly IBullet _bullet;
        public Gun(IBullet bullet)
        {
            _bullet = bullet;
        }

        public void Shoot()
        {
            Debug.Log($"Bang: {_bullet.CalculateDamage()}");
        }
    }

    public class Bullet : IBullet
    {
        private readonly int _damage;

        public Bullet(int damage)
        {
            _damage = damage;
        }

        public int CalculateDamage()
        {
            return _damage;
        }
    }

    public class BulletSupper : IBullet
    {
        private readonly int _damage;

        public BulletSupper(int damage)
        {
            _damage = damage;
        }

        public int CalculateDamage()
        {
            var crete = Random.Range(2, 10);
            return _damage + crete; // дуже складні розрахунки =)
        }
    }

    public interface IBullet
    {
        public int CalculateDamage();
    }


    public class Player
    {
        public void Fire(Gun gun)
        {
            gun.Shoot();
            // ...
        }
    }
}
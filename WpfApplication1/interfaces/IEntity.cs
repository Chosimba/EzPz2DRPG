using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzPzRPG.interfaces
{

    public class Thing { public Thing() { } }
    public struct Position
    {
        public double X;
        public double Y;
        public double Z;
    }
    public enum EntityState { Standing, Walking, Running, Jumping, Casting, Crouching }
    public enum EntityDamageState { Safe, Hit, Dead }



    public class Snail : ILivingEntity
    {
        private double X = 0;
        private double Y = 0;
        private double Z = 0;
        private double HP = 0;
        private double MP = 0;
        private double CurrentSpeed = 0;
        private EntityDamageState CurrentDmgState = EntityDamageState.Safe;
        private EntityState CurrentState = EntityState.Standing;

        public Position GPS { get { return new Position { X = X, Y = Y, Z = Z }; } }
        public Thing EntityData { get { return new Thing(); } }
        public double MaxHealth { get { return 100; } }
        public double MaxResource { get { return 10; } }
        public string Name { get { return "Snail"; } }
        public double Speed { get { return CurrentSpeed; } }

        public EntityDamageState getDamageState() {
            return CurrentDmgState;
        }
        public EntityState getState() {
            return CurrentState;
        }
        public double getHealth() { return HP; }
        public double getResource() { return MP; }
        public void Spawn() {
            throw new NotImplementedException();
        }

        public Snail() { }
    }







    public class Entity : IEntity {
        private double X = 0;
        private double Y = 0;
        private double Z = 0;

        public Position GPS { get { return new Position { X = X, Y = Y, Z = Z }; } }
        public Thing EntityData { get { return new Thing(); } }
        public void Spawn() {

        }

        public Entity(double xPos, double yPos, double zPos)
        {
            X = xPos;
            Y = yPos;
            Z = zPos;
        }
        public Entity(Position initPos)
        {
            X = initPos.X;
            Y = initPos.Y;
            Z = initPos.Z;
        }
    }

    interface ILivingEntity : INamedEntity{
        double MaxHealth { get; }
        double MaxResource { get; }
        double Speed { get; }
        EntityState getState();
        EntityDamageState getDamageState();
        double getHealth();
        double getResource();
    }

    interface INamedEntity : IEntity {
        string Name { get; }
    }

    interface IEntity
    {
        Position GPS { get; }
        Thing EntityData { get; }
        void Spawn();
    }
}

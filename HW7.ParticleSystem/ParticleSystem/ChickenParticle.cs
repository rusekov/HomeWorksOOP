namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class ChickenParticle : ChaoticParticle
    {
        private int totalLayingTicks;
        private int layingTicksCounter;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator, int crazyness, int layingTicks = 200)
            : base(position, speed, randomGenerator, crazyness)
        {
            this.totalLayingTicks = layingTicks;
            this.layingTicksCounter = this.totalLayingTicks;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '<', '@' }, { '/', '|' } };
        }

        public override IEnumerable<Particle> Update()
        {
            if (this.Speed.Col == 0 && this.Speed.Row == 0)
            {
               if (this.layingTicksCounter > 0)
               {
                   this.layingTicksCounter--;
                   return new List<Particle>();
               }
               else
               {
                   this.layingTicksCounter = this.totalLayingTicks;
                   this.Move();
                   return new List<Particle>() { new ChickenParticle(this.Position, this.Speed, this.RandomGenerator, this.MaximalAcceleration, this.totalLayingTicks) };
               }
            }

            return base.Update();
        }
    }
}

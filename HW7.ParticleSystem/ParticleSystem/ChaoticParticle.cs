namespace ParticleSystem
{
    using System;

    public class ChaoticParticle : Particle
    {
        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator, int crazyness)
            : base(position, speed)
        {
            this.MaximalAcceleration = crazyness;
            this.MinimalAcceleration = -crazyness;
            this.RandomGenerator = randomGenerator;
        }

        public int MinimalAcceleration { get; private set; }

        public int MaximalAcceleration { get; private set; }

        public Random RandomGenerator { get; private set; }

        public override char[,] GetImage()
        {
            return new char[,] { { '(', '?', ')' } };
        }

        protected override void Move()
        {
            int acclerateRow = this.RandomGenerator
                .Next(this.MinimalAcceleration, this.MaximalAcceleration + 1);

            int acclerateCol = this.RandomGenerator
                .Next(this.MinimalAcceleration, this.MaximalAcceleration + 1);

            this.Accelerate(new MatrixCoords(acclerateRow, acclerateCol));

            base.Move();
        }
    }
}
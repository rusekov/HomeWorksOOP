using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class Program
    {
        public const int Rows = 40;
        public const int Cols = 60;

        public static readonly Random RandomGenerator = new Random();

        public static void Main()
        {
            var renderer = new ConsoleRenderer(Rows, Cols);

            var particleOperator = new AdvancedParticalUpdater();

            var engine = 
                new Engine(renderer, particleOperator, null, 300);

            GenerateInitialData(engine);

            engine.Run();
        }

        private static void GenerateInitialData(Engine engine)
        {
            engine.AddParticle(
               new DyingParticle(
                   new MatrixCoords(20, 5),
                   new MatrixCoords(-1, 1),
                   12)
               );

            ////Particle Emitter
            var emitterPosition = new MatrixCoords(29, 0);
            var emitterSpeed = new MatrixCoords(0, 0);
            var emitter = new ParticleEmitter(emitterPosition, emitterSpeed,
                RandomGenerator,
                5,
                2,
                GenerateRandomParticle
                );

            //engine.AddParticle(emitter);

            //// Paritcle Attractor
            var attractorPosition = new MatrixCoords(15, 20);
            var attractor = new ParticleAttractor(
                attractorPosition,
                new MatrixCoords(0, 0),
            3);
            //engine.AddParticle(attractor);
            
            //// IMPORTANT!
            //// Exercises 1 and 2 -> 
            //// check classes: ChaoticParticle, AdvancedParticalUpdater            
            var crazyPosition = new MatrixCoords(15, 12);
            var crazy = new ChaoticParticle(crazyPosition,
                new MatrixCoords(0, 0),
                RandomGenerator,
                1); 
            
            var crazyPositiontoo = new MatrixCoords(15, 15);
            var crazytoo = new ChaoticParticle(crazyPositiontoo,
                new MatrixCoords(0, 0),
                RandomGenerator,
                1); 
            
            var crazyPositionmore = new MatrixCoords(15, 19);
            var crazymore = new ChaoticParticle(crazyPositionmore,
                new MatrixCoords(0, 0),
                RandomGenerator,
                1);

            engine.AddParticle(crazy);
            engine.AddParticle(crazytoo);
            engine.AddParticle(crazymore);

            //// IMPORTANT!
            //// Exercises 3 and 4 -> 
            //// check classes: ChickenParticle, AdvancedParticalUpdater            
            var chickenPosition = new MatrixCoords(15, 12);
            var chcken = new ChickenParticle(chickenPosition,
                new MatrixCoords(0, 0),
                RandomGenerator,
                1,
                4);

            engine.AddParticle(chcken);

            //// IMPORTANT!
            //// Exercises 5 and 6 -> 
            //// check classes: ParticleEmitter, AdvancedParticalUpdater            
            var reppelerPosition = new MatrixCoords(18, 28);
            var reppeler = new ParticleRepeller(
                reppelerPosition,
                new MatrixCoords(0, 0),
                3);
            
            //engine.AddParticle(reppeler);
        }

        static Particle GenerateRandomParticle(ParticleEmitter emitterParameter)
        {
            MatrixCoords particlePos = emitterParameter.Position;

            int particleRowSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);
            int particleColSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);

            MatrixCoords particleSpeed = new MatrixCoords(particleRowSpeed, particleColSpeed);

            Particle generated = null;

            int particleTypeIndex = emitterParameter.RandomGenerator.Next(0, 2);
            switch (particleTypeIndex)
            {
                case 0: generated = new Particle(particlePos, particleSpeed); break;
                case 1:
                    uint lifespan = (uint)emitterParameter.RandomGenerator.Next(8);
                    generated = new DyingParticle(particlePos, particleSpeed, lifespan);
                    break;
                default:
                    throw new Exception("No such particle for this particleTypeIndex");
            }

            return generated;
        }
    }
}

namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class AdvancedParticalUpdater : AdvancedParticleOperator
    {
        private List<ParticleRepeller> repellers = new List<ParticleRepeller>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {           
            var reppelerCandidate = p as ParticleRepeller;
            if (reppelerCandidate == null)
            {
                return base.OperateOn(p);
            }
            else
            {
                this.repellers.Add(reppelerCandidate);
            }

            return p.Update();
        }

        public override void TickEnded()
        {
            foreach (var reppeler in this.repellers)
            {
                foreach (var particle in this.particles)
                {
                    var currAcceleration = GetAccelerationFromParticleAwayToReppeler(reppeler, particle);

                    particle.Accelerate(currAcceleration);
                }
            }

            this.repellers.Clear();
            base.TickEnded();
        }

        private static MatrixCoords GetAccelerationFromParticleAwayToReppeler(ParticleRepeller repeler, Particle particle)
        {
            var currParticleToReppelerVector = particle.Position - repeler.Position;

            int ptoReppRow = currParticleToReppelerVector.Row;
            ptoReppRow = DecreaseVectorCoordToPower(repeler, ptoReppRow);

            int ptoReppCol = currParticleToReppelerVector.Col;
            ptoReppCol = DecreaseVectorCoordToPower(repeler, ptoReppCol);

            var currAcceleration = new MatrixCoords(ptoReppRow, ptoReppCol);
            return currAcceleration;
        }

        private static int DecreaseVectorCoordToPower(ParticleAttractor attractor, int ptoAttrCoord)
        {
            if (Math.Abs(ptoAttrCoord) > attractor.Power)
            {
                ptoAttrCoord = (ptoAttrCoord / (int)Math.Abs(ptoAttrCoord)) * attractor.Power;
            }

            return ptoAttrCoord;
        }
    }
}